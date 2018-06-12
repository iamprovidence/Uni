/*
Завдання 9: (3 бали)

На основі класу BinaryTree із завдання 1 реалізувати шаблонний клас -
адаптер PriorityQueue, що реалізує чергу з пріоритетом.Реалізувати логіку
генерування та обробки подій вставки та видалення елементів(патерн Observer).
*/

#include "tree.h"
#include <functional>
#include <string>
#include <forward_list>
#include <algorithm>

using std::cout;
using std::endl;
using std::string;

class Subject;
class Observer;
class handle_event;
template<typename T,template <typename > class Container = BinaryTree>
class priority_queue;


class Subject
{
public:
	virtual void attach(Observer *) = 0;
	virtual void detach(Observer *) = 0;
	virtual void notify(const string&) = 0;
};

class Observer
{
public:
	virtual void update(const string&) = 0;
};

class handle_event : public Observer
{
private:
	string event;
public:
	void update(const string &e) override
	{
		event += e + '\n';
	}
	string get_message()const
	{
		return event;
	}
};

template 
<
	typename T,
	template <typename > class Container = BinaryTree
>
class priority_queue:public Subject
{
private://Subject Interface
	std::forward_list<Observer *> observer;
public:
	void attach(Observer* O) override
	{
		observer.emplace_front(O);
	}
	void detach(Observer *O) override
	{
		auto find_iter = find(observer.begin(), observer.end(), O);
		
		observer.remove(*find_iter);
	}
	void notify(const string &message) override
	{
		for (Observer * obs : observer)
		{
			obs->update(message);
		}
	}
private://Queue Interface
	Container<T> C;
public:
	bool empty()const
	{
		return C.size() == 0;
	}
	int size()const
	{
		return C.size();
	}
	priority_queue& push(T value)
	{
		notify("add " + std::to_string(value));

		C.add(value);
		return *this;
	}
	priority_queue& pop()
	{
		notify("remove " + std::to_string(*C.begin()));

		C.remove(*C.begin());
		return *this;
	}
	T top()
	{
		return *C.begin();
	}
};

int main()
{
	handle_event Obs1, Obs2;

	int value_for_queueus[10] = { 4,8,9,7,4,6,9,1,2,56 };

	std::priority_queue<int, std::vector<int>, std::greater<int>> PQ;//STL
	priority_queue<int, BinaryTree> my_PQ;//MY
	my_PQ.attach(&Obs1);
	for (size_t i = 0; i < 10; ++i)
	{
		PQ.push(value_for_queueus[i]);
		my_PQ.push(value_for_queueus[i]);
	}
	cout << "STL\t";
	while (!PQ.empty())
	{
		cout << PQ.top() << ' ';
		PQ.pop();
	}
	cout << endl << "MY\t";
	my_PQ.attach(&Obs2);
	while (!my_PQ.empty())
	{
		cout << my_PQ.top() << ' ';
		my_PQ.pop();
	}

	my_PQ.detach(&Obs1);
	my_PQ.push(4);
	my_PQ.attach(&Obs1);
	my_PQ.pop();
	std::cin.get();

	std::cout << "\n\t\tFIRST:\n" << Obs1.get_message() << std::endl;
	std::cout << "\t\tSECOND:\n" << Obs2.get_message() << std::endl;

	std::cin.get();
	return EXIT_SUCCESS;
}