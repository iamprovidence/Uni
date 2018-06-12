#include "template_classes.h"

BinaryTree::BinaryTree()
{
	T = nullptr;
	amount = 0;
}
BinaryTree::~BinaryTree()
{
	while (T)
	{
		remove(T->data);
	}
}
BinaryTree::Node::Node()
{
	data = NULL;
	left = nullptr;
	right = nullptr;
}
BinaryTree::Node::Node(int x, Node * l = nullptr, Node * r = nullptr)
{
	data = x;
	left = l;
	right = r;
}
void BinaryTree::addPrivate(int x, Node*&tree)
{
	if (tree == nullptr)
	{
		tree = new Node(x);
	}
	else if (x > tree->data)
	{
		addPrivate(x, tree->right);
	}
	else
	{
		addPrivate(x, tree->left);
	}
}
BinaryTree::Node * BinaryTree::find_minimum(Node * min) const
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
bool BinaryTree::removePrivate(int x, Node *&tree)
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

		if (kill->right && kill->left)//якщо два нащадки
		{
			kill->data = find_minimum(tree->right)->data;//записати на місці мінімальний листок справа
			return removePrivate(kill->data, kill->right);//видалити, той що записали
		}
		else if (kill->left)//нащадок тільки зліва
		{
			tree = tree->left;
		}
		else//нащадок тільки справого боку або немає
		{
			tree = tree->right;
		}
		
		delete kill;
		return true;
		
	}
}
bool BinaryTree::findPrivate(int x, Node*tree)const
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
void BinaryTree::add(int x)
{
	this->addPrivate(x, T);
	++amount;
}
bool BinaryTree::remove(int x)
{
	if (this->removePrivate(x, T))
	{
		--amount;
		return true;
	}
	return false;
}
bool BinaryTree::find(int x)const
{
	return this->findPrivate(x, T);
}
void BinaryTree::printPretty(ostream & os)const
{
	print_tree(this->T, 0, os);
}
int BinaryTree::get_size() const
{
	return amount;
}
int BinaryTree::get_element_by_index(int i)
{
	/*
											ПОШУК ВШИР
		Корінь->черга

		Поки черга не пуста
		1. візьми елемент з початку черги і кинь його дітей в кінець черги
		2. забери лемент з початку черги
	*/

	queue<Node> Element;
	Element.push( *T);
	int inner_index = 0;
	while ( !Element.empty() )
	{
		Node tempNode = Element.front();
		
		if (tempNode.left) 
		{
			Element.push( (*tempNode.left ));
		}
		if (tempNode.right) 
		{
			Element.push( (*tempNode.right ));
		}
		
		Element.pop();

		if (inner_index == i)
		{
			return tempNode.data; // вернути значення за індексом
		}
		++inner_index;
	}
	throw "out of range";
}
void BinaryTree::print_tree(Node * T, int k, ostream & os)const
{
	if (T->right != nullptr)
	{
		print_tree(T->right, k + 5, os);
	}

	
	for (size_t i = 0; i < k; i++)
	{
		os << ' ';
	}
	os << T->data << endl;

	if (T->left != nullptr)
	{
		print_tree(T->left, k + 5, os);
	}
	
}
int BinaryTree::calculate_high(BinaryTree::Node * tree) const
{
	int left, right;

	if (tree == nullptr)
	{
		return 0;
	}

	if (tree->left)
	{
		left = calculate_high(tree->left);
	}
	else
	{
		//--left;
	}

	if (tree->right)
	{
		right = calculate_high(tree->right);
	}
	else
	{
		//--right;
	}

	int max = (left > right) ? left : right;

	return max + 1;
}
BinaryTree::Node * BinaryTree::getNode()
{
	return T;
}