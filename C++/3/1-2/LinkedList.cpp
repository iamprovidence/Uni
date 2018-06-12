#include "template_classes.h"

LinkedList::LinkedList()
{
	tail = head = new Link();
	length = 0;
}
LinkedList::~LinkedList()
{
	while (head)
	{
		Link * victim = head;
		head = head->next;
		delete victim;
	}
	tail = head = nullptr;
	length = 0;
}
bool LinkedList::add(int x, bool add_to_start)
{
	if (add_to_start)
	{
		head->next = new Link(x, head->next);
	}
	else
	{
		tail = tail->next = new Link(x);
	}

	++length;

	return true;
}
bool LinkedList::remove(int index)
{
	if (index < length && index >= 0)// вийшли за межі списку
	{

		Link * finder = head;
		int inner_index = 0;
		while (finder->next != nullptr)
		{
			if (index == inner_index)
			{
				break;
			}
			++inner_index;
			finder = finder->next;
		}

		if (finder->next != tail)//якщо видаляється ланка із середини
		{
			Link * victim = finder->next;
			finder->next = finder->next->next;
			delete victim;
		}
		else //якщо видаляється остання ланка
		{
			tail = finder;
			delete finder->next;
			tail->next = nullptr;
		}
		--length;
		return true;
	}
	return false;
}
int LinkedList::find(int x)const
{
	Link * finder = head->next;
	int index = 0;
	while (finder)
	{
		if (finder->data == x)
		{
			break;
		}
		++index;
		finder = finder->next;
	}
	return index;
}
int LinkedList::get_size() const
{
	return length;
}
ostream& LinkedList::prettyPrint(ostream& os)const
{

	for (Link * print = head->next; print != nullptr; print = print->next)
	{
		os << print->data;
		if (print->next != nullptr)
		{
			os << " -> ";
		}
	}
	return os;

}
int LinkedList::get_element_by_index(int i)
{
	if (i == get_size() - 1)
	{
		return tail->data;
	}
	Link * finder = head;
	int inner_index = 0;
	while (finder->next != nullptr)
	{
		if (i == inner_index)
		{
			return finder->next->data;
		}
		++inner_index;
		finder = finder->next;
	}
	throw "out of range";
}
LinkedList::Link * LinkedList::getNode()
{
	return head->next;
}
