#include "Header.h"

queue::Node::Node()
{
	data = 0;
	prioritet = 0;
	next = nullptr;
}
queue::Node::Node(double d)
{
	data = d;
	prioritet = 23;
	next = nullptr;
}
queue::Node::Node(double d, int p, Node * n)
{
	data = d;
	prioritet = p;
	next = n;
}

queue::queue() : max_size(100), max_prior(2048)
{
	quantity = 0;
	end = nullptr;
	start = nullptr;
}
queue::queue(int m_s) : max_size(m_s), max_prior(2048)
{
	quantity = 0;
	end = nullptr;
	start = nullptr;
}
queue::queue(int m_s, int m_p) : max_size(m_s), max_prior(m_p)
{
	quantity = 0;
	end = nullptr;
	start = nullptr;
}
queue::queue(const queue & Q) : max_size(Q.max_size), max_prior(Q.max_prior)
{
	quantity = Q.quantity;

	if (Q.is_empty())
	{
		end = nullptr;
		start = nullptr;
	}
	else
	{
		Node * copy = Q.end;
		Node * creare_new = new Node(copy->data,copy->prioritet);
		end = creare_new;
		start = end;
		copy = copy->next;

		while (copy)
		{
			creare_new->next = new Node(copy->data, copy->prioritet);
			creare_new = creare_new->next;
			start = creare_new;
			copy = copy->next;
		}
	}
}
queue::~queue()
{
	Node * victim;

	while (end != nullptr)
	{
		victim = end;
		end = end->next;
		delete victim;
	}
	quantity = 0;
	end = nullptr;
	start = nullptr;
}

bool queue::is_empty()const
{
	return quantity == 0;
}
bool queue::is_full()const
{
	return quantity == max_size;
}
int queue::get_max_size()const
{
	return max_size;
}
int queue::get_max_prioritet()const
{
	return max_prior;
}
int queue::get_amount() const
{
	return quantity;
}
bool queue::push(double X)
{
	//return push(X, max_prior);
	if (is_full())
	{
		return false;
	}

	if (is_empty())
	{
		start = end = new Node(X, max_prior);
	}
	else
	{
		end = new Node(X, max_prior, end);
	}
	++quantity;
	return true;
}
bool queue::push(double X, int P)
{
	if (is_full())
	{
		return false;
	}
	
	//if(P < 0) P = 0;
	P = abs(P);
	if (P > max_prior)
	{
		P = max_prior;
	}
	
	Node * add = new Node(X, P);

	if (is_empty())
	{
		++quantity;
		start = add;
		end = add;
		return true;
	}
	else
	{
		++quantity;
		Node * find = end;
		//вставка в середину
		while (find->prioritet > add->prioritet)
		{
			if (find->next == nullptr)//вставка на початок
			{
				find->next = add;
				start = add;
				return true;
			}

			find = find->next;
		}

		Node * place = end;
		
		if (place == find)//вставка в кінець
		{
			add->next = find;
			end = add;
			return true;
		}
		//вставка в середину
		while (place->next != find)
		{
			place = place->next;
		}

		add->next = place->next;
		place->next = add;
	}

	return true;
}
bool queue::pop()
{
	if (is_empty())
	{
		return false;
	}

	Node * victim = start;
	--quantity;

	if (quantity == 0)
	{
		start = nullptr;
		end = nullptr;
	}
	else
	{
		Node * find = end;

		while (find->next != victim)
		{
			find = find->next;
		}

		start = find;
		start->next = nullptr;
	}

	delete victim;

	return true;
}

double queue::peek_start_value() const
{
	return (!is_empty()) ? start->data : 0;
}
double queue::peek_end_value() const
{
	return (!is_empty()) ? end->data : 0;
}
int queue::peek_start_prioritet() const
{
	return (!is_empty()) ? start->prioritet : -1;
}
int queue::peek_end_prioritet() const
{
	return (!is_empty()) ? end->prioritet : -1;
}
