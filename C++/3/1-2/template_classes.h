#pragma once
#include <iostream>
#include <queue>

using namespace std;
typedef void(*funcPtr) (int&);

void make_bigger(int& a);
void make_smaller(int& a);

class LinkedList
{
public:
	struct Link
	{
		int data;
		Link * next;
		Link * prev;

		Link()
		{
			data = NULL;
			prev = next = nullptr;
		}

		Link(int x, Link * n = nullptr, Link * p = nullptr)
		{
			data = x;
			next = n;
			prev = p;
		}
	};
private:

	Link * head;
	Link * tail;
	int length;

public:
	LinkedList();
	~LinkedList();
	bool add(int x, bool add_to_start = false);
	bool remove(int index);
	int find(int x)const;
	int get_size()const;
	ostream& prettyPrint(ostream& os)const;
	int& operator[](int i);
	Link * getNode();
public:
	class iterator
	{
	private:
		Link * ptr;
	public:
		iterator(Link * L = nullptr);
		iterator& operator++();
		iterator& operator--();
		int operator*();
		bool operator!=(const iterator &p);
		bool operator==(const iterator &p);

		iterator& operator+(int step);
		iterator& operator-(int step);

	};

	iterator begin();
	iterator end();
};

class BinaryTree
{
public:
	struct Node
	{
		int data;
		Node * left;
		Node * right;
		Node * father;
		bool checked;

		Node();

		Node(int x, Node * f, Node * l, Node * r);
	};

private:
	Node * T;
	int amount;
private:
	void addPrivate(int x, Node*&tree, Node *parrent = nullptr);
	bool removePrivate(int x, Node *&tree);
	Node * find_minimum(Node * min) const;
	bool findPrivate(int x, Node*tree)const;
	void print_tree(Node * T, int k, ostream & os)const;

public:
	BinaryTree();
	~BinaryTree();

	void add(int x);
	bool remove(int x);
	bool find(int x)const;
	void printPretty(ostream & os)const;
	int get_size()const;
	int& operator[](int i);
	Node * getNode();
public:
	class iterator
	{
	private:
		Node * ptr;
	public:
		iterator(Node * L = nullptr);
		/*
			return mixed:: iterator || nullptr
		*/
		iterator& operator++();// ARB
		iterator& operator--();
		int& operator*();
		bool operator!=(const iterator &p);
		bool operator==(const iterator &p);

		iterator& operator+(int step);
		iterator& operator-(int step);
	};

	iterator begin();
	iterator end();
};

void forEach(LinkedList & L, funcPtr F);
void forEach(BinaryTree & T, funcPtr F);
template <typename Iter, typename Func>
void forEach(Iter start, Iter end, Func F)
{
	while (start != end)
	{

		F(*start);
		++start;
	}

}

template <typename T, typename V>
bool Compare(T &first, V &second)
{
	int step;
	if ((step = first.get_size()) == second.get_size())
	{
		for (int i = 0; i < step; ++i)
		{
			if (first[i] != second[i])
			{
				return false;
			}
		}
		return true;
	}
	return false;
}

template <typename Iter1, typename Iter2>
bool Compare(Iter1 firstStart, Iter1 firstEnd, Iter2 secondStart, Iter2 secondEnd)
{
	while(firstStart != firstEnd && (*firstStart) == (*secondStart) )
	{
		++ firstStart;
		++ secondStart; 
	}
	if (firstStart != firstEnd)
	{
		
		return false;
	}
	return true;
	
}
