#pragma once
#include <iostream>
#include <queue>

using std::ostream;

template <typename Type>
class BinaryTree
{
public:
	struct Node
	{
		Type data;
		Node * left;
		Node * right;
		Node * father;
		bool checked;

		Node()
		{
			data = NULL;
			left = nullptr;
			right = nullptr;
			father = nullptr;
			checked = false;
		}

		Node(Type x, Node * f, Node * l = nullptr, Node * r = nullptr)
		{
			data = x;
			father = f;
			left = l;
			right = r;
			checked = false;
		}
	};

private:
	Node * T;
	int amount;
private:
	void addPrivate(Type x, Node*&tree, Node *parrent = nullptr)
	{
		if (tree == nullptr)
		{
			tree = new Node(x, parrent);
		}
		else if (x > tree->data)
		{
			addPrivate(x, tree->right, tree);
		}
		else
		{
			addPrivate(x, tree->left, tree);
		}
	}
	bool removePrivate(Type x, Node *&tree)
	{
		if (tree == nullptr)
		{
			return false;
		}
		else if (x < tree->data)
		{
			return removePrivate(x, tree->left);
		}
		else if (x > tree->data)
		{
			return removePrivate(x, tree->right);
		}
		else
		{
			Node * kill = tree;

			if (kill->right && kill->left)//���� ��� �������
			{
				kill->data = find_minimum(tree->right)->data;//�������� �� ���� ��������� ������ ������
				return removePrivate(kill->data, kill->right);//��������, ��� �� ��������
			}
			else if (kill->left)//������� ����� ����
			{
				tree = tree->left;
			}
			else//������� ����� �������� ���� ��� ����
			{
				tree = tree->right;
			}

			delete kill;
			return true;

		}
	}
	Node * find_minimum(Node * min) const
	{
		if (min == nullptr)
		{
			return nullptr;
		}

		if (min->left)
		{
			return find_minimum(min->left);
		}
		return min;
	}
	bool findPrivate(Type x, Node*tree)const
	{
		if (tree == nullptr)
		{
			return false;
		}
		else
		{
			return tree->data == x || findPrivate(x, tree->left) || findPrivate(x, tree->right);
		}
	}
	void print_tree(Node * T, int k, ostream & os)const
	{
		if (T->right != nullptr)
		{
			print_tree(T->right, k + 5, os);
		}


		for (size_t i = 0; i < k; i++)
		{
			os << ' ';
		}
		os << T->data << std::endl;

		if (T->left != nullptr)
		{
			print_tree(T->left, k + 5, os);
		}
	}

public:
	BinaryTree()
	{
		T = nullptr;
		amount = 0;
	}
	~BinaryTree()
	{
		while (T)
		{
			remove(T->data);
		}
	}

	void add(Type x)
	{
		this->addPrivate(x, T);
		++amount;
	}
	bool remove(Type x)
	{
		if (this->removePrivate(x, T))
		{
			--amount;
			return true;
		}
		return false;
	}
	bool find(Type x)const
	{
		return this->findPrivate(x, T);
	}
	void printPretty(ostream & os)const
	{
		print_tree(this->T, 0, os);
	}
	int size()const
	{
		return amount;
	}
	int& operator[](int i)
	{
		/*
		����� ����
		�����->�����

		���� ����� �� �����
		1. ����� ������� � ������� ����� � ���� ���� ���� � ����� �����
		2. ������ ������ � ������� �����
		*/

		std::queue<Node> Element;
		Element.push(*T);
		int inner_index = 0;
		while (!Element.empty())
		{
			Node tempNode = Element.front();

			if (tempNode.left)
			{
				Element.push((*tempNode.left));
			}
			if (tempNode.right)
			{
				Element.push((*tempNode.right));
			}

			Element.pop();

			if (inner_index == i)
			{
				return tempNode.data; // ������� �������� �� ��������
			}
			++inner_index;
		}
		throw "out of range";
	}
	Node * getNode()
	{
		return T;
	}
public:
	class iterator
	{
	private:
		Node * ptr;
	public:
		iterator(Node * L = nullptr)
		{
			ptr = L;

			while (ptr != nullptr &&ptr->left != nullptr)
			{
				ptr = ptr->left;
			}
		}
		/*
		return mixed:: iterator || nullptr
		*/
		// ARB
		iterator& operator++()
		{
			//�������� � ���������
			if (this->ptr->left != nullptr && this->ptr->left->checked != true) //���� �� ���� ���� �� ����
			{
				// A
				this->ptr = this->ptr->left;
			}
			else if (this->ptr->checked != true)//������� �����
			{
				// R
				this->ptr->checked = true;
			}


			// ������� �� ���� �������
			if (this->ptr->right != nullptr && this->ptr->right->checked != true)//���� �� ���� ������, �� ����� ������
			{
				// B
				this->ptr = this->ptr->right;
				while (this->ptr->left != nullptr)
				{
					this->ptr = this->ptr->left;
				}
			}
			else//���� ����, ���������� �� ����������� �������, ���� �� �� ��������
			{
				while (this->ptr->checked != false)
				{
					this->ptr = this->ptr->father;
					//���� ������ �� �����
					if (ptr == nullptr)
					{
						break;
					}
				}
			}

			return *this;
		}		
		iterator& operator--()
		{
			//�������� ����� ������� ����, �� ����
			//�������� � �����������

			if (this->ptr->right != nullptr && this->ptr->right->checked != false) //���� ���� ������ �� ������
			{
				// B
				this->ptr = this->ptr->right;
			}
			else if (this->ptr->checked != false)// � ������ ������� �������� ������ � ������
			{
				// R
				this->ptr->checked = false;
			}

			// ������� �� ��������� �������
			if (this->ptr->left != nullptr && this->ptr->left->checked != false)//���� ���� ����, �� ����� ����
			{
				// �
				this->ptr = this->ptr->left;
				while (this->ptr->right != nullptr)
				{
					this->ptr = this->ptr->right;
				}

			}
			else//���� �� ����, ���������� �� ����������� �������, ���� ��� ��������
			{
				while (this->ptr->checked != true)
				{
					this->ptr = this->ptr->father;
					//���� ������ �� �����
					if (ptr == nullptr)
					{
						break;
					}
				}

			}

			return *this;
		}
		Type& operator*()
		{
			return ptr->data;
		}
		bool operator!=(const iterator &p)
		{
			return this->ptr != p.ptr;
		}
		bool operator==(const iterator &p)
		{
			return this->ptr == p.ptr;
		}

		iterator& operator+(int step)
		{
			for (int i = 0; i < step; ++i)
			{
				++ *this;
			}
			return *this;
		}
		iterator& operator-(int step)
		{
			for (int i = 0; i < step; ++i)
			{
				-- *this;
			}
			return *this;
		}
	};

	iterator begin()
	{
		return iterator(this->getNode());
	}
	iterator end()
	{
		return iterator();
	}
};
