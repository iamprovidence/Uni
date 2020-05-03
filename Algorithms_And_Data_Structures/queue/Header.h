#pragma once
#include <iostream>

using std::cout;
using std::endl;

class queue
{
private:
	struct Node
	{
		double data;
		int prioritet;
		Node * next;

		Node();
		Node(double d);
		Node(double d, int p, Node * n = nullptr);
	};

	const int max_size;
	const int max_prior;
	int quantity;
	Node * end;
	Node * start;
	
public:
	queue();
	queue(int m_s);
	queue(int m_s, int m_p);
	queue(const queue&Q);
	~queue();

	bool is_empty()const;
	bool is_full()const;
	int get_max_size()const;
	int get_max_prioritet()const;
	int get_amount() const;
	bool push(double X);
	bool push(double X, int P);
	bool pop();

	double peek_start_value()const;
	double peek_end_value()const;
	int peek_start_prioritet()const;
	int peek_end_prioritet()const;
};