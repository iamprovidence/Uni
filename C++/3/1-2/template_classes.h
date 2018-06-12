#pragma once
#include <iostream>
#include <iomanip> 
#include <queue>
#include <string>
#include <fstream>
#include <iomanip>
#include <sstream>

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

		Link()
		{
			data = NULL;
			next = nullptr;
		}

		Link(int x, Link * n = nullptr)
		{
			data = x;
			next = n;
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
	int get_element_by_index(int i);
	Link * getNode();

};

class BinaryTree
{
public:
	struct Node
	{
		int data;
		Node * left;
		Node * right;

		Node();

		Node(int x, Node * l, Node * r);
	};
private:
	Node * T;
	int amount;
private:
	void addPrivate(int x, Node*&tree);
	bool removePrivate(int x, Node *&tree);
	Node * find_minimum(Node * min) const;
	bool findPrivate(int x, Node*tree)const;
	void print_tree(Node * T, int k, ostream & os)const;
	int calculate_high(Node * tree) const;
	
public:
	BinaryTree();
	~BinaryTree();

	void add(int x);
	bool remove(int x);
	bool find(int x)const;
	void printPretty(ostream & os)const;
	int get_size()const;
	int get_element_by_index(int i);
	Node * getNode();
};

void forEach(LinkedList & L, funcPtr F);
void forEach(BinaryTree & T, funcPtr F);

template <typename T, typename V>
bool Compare(T &first, V &second)
{
	int step;
	if (  (step = first.get_size() ) == second.get_size())
	{
		for (int i = 0; i < step; ++i)
		{
			if (first.get_element_by_index(i) != second.get_element_by_index(i))
			{
				return false;
			}
		}
		return true;
	}
	return false;
}
