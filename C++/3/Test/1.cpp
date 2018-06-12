#include <iostream>
#include <initializer_list>

using namespace std;

template <typename Type>
class Tree
{
private:
	int SIZE;
	int HIGHT;
	struct Node 
	{
		Type elem;
		Node * next_in_row;
		Node * lower;
		
		Node(Type el = 0, Node * next = nullptr, Node * low = nullptr):
			elem(el), 
			next_in_row(next),
			lower(low){}
	};
	
	class iterator
	{
	protected:
		Node * ptr;
		int level;
		int iter_in_this_level;
	public:
		typedef Type value_type;

		iterator(Node * p = nullptr) :ptr(p){};
		
		constexpr int difference()const
		{
			return SIZE;
		}

		Type& operator*()
		{
			return ptr->elem;
		}

		virtual iterator& operator++() = 0;
		virtual iterator& operator++(int)
		{
			iterator prev = this;
			++this;
			return prev;
		}

		bool operator!=(const iterator & ptr)const
		{
			return this->ptr != ptr.ptr;
		}
		bool operator==(const iterator & ptr)const
		{
			return this->ptr == ptr.ptr;
		}
	};

	Node * Top;
public:
	class deep_iter:public iterator 
	{
	public:
		deep_iter(Node * p = nullptr) :ptr(p) {};

		virtual iterator& operator++()
		{
			for (int i = 0; i < iter_in_this_level; ++i)
			{
				ptr = ptr->next_in_row;
				for (int j = 0; j < level; ++j)
				{
					ptr = ptr->lower;
				}
			}

			if (ptr->next_in_row == nullptr)
			{
				++level;
				iter_in_this_level = 0;
			}
			else
			{
				++iter_in_this_level;
			}

			return *this;
		}
	};
	class width_iter:public iterator 
	{		
	public:
		width_iter(Node * p = nullptr) :ptr(p){}

		virtual iterator& operator++()
		{
			for (int i = 0; i < level; ++i)
			{
				ptr = ptr->lower;
				for (int j = 0; j < iter_in_this_level; ++j)
				{
					ptr = ptr->next_in_row;
				}
			}

			if (ptr->next_in_row == nullptr)
			{
				++ level;
				iter_in_this_level = 0;
			}
			else
			{
				++iter_in_this_level;
			}

			return *this;
		}
	};
	
private:
	struct choice
	{
		virtual width_iter width() = 0;
		virtual	deep_iter deep() = 0;
	};
	struct begin_choice:choice
	{
		width_iter width()
		{
			return width_iter(::Top->next_in_row);
		}
		deep_iter deep()
		{
			return deep_iter(::Top->next_in_row);
		}
	};
	struct end_choice:choice
	{
		width_iter width()
		{
			return width_iter();
		}
		deep_iter deep()
		{
			return deep_iter();
		}
	};
private:
	Node * get_node(initializer_list<Type> &index)
	{
		Node * find = Top->next_in_row;
		for (auto i = index.begin(); i < index.end() && find != nullptr; ++i)
		{
			find = find->lower;

			for (int j = 0; j < *i && find != nullptr; ++j)
			{
				find = find->next_in_row;
			}
		}
		return find;
	}
public:
	Tree()
	{
		Top = new Node();
	}
	~Tree()
	{
		while (Top->next_in_row != nullptr)
		{
			this->remove({});
		}
		delete Top;
	}

	bool insert(initializer_list<Type> index, Type elem)
	{
		Node * inserter = Top;
		int j = 0;
		for (auto i = index.begin(); i < index.end() && inserter != nullptr; ++i)
		{
			inserter = inserter->next_in_row;

			for (j = 0; j < *i && inserter != nullptr; ++j)
			{
				if (j == 0)
				{
					inserter = inserter->lower;
				}			
				else
				{
					inserter = inserter->next_in_row;
				}
			}
		}
		if (inserter != nullptr)
		{
			if (j == 0 && index.begin() != index.end())
			{
				++HIGHT;
				inserter->lower = new Node(elem);
			}
			else
			{
				inserter->next_in_row = new Node(elem, inserter->next_in_row);
			}
			++SIZE;
			return true;
		}
		return false;
	}
	bool remove(initializer_list<Type> index)
	{
		Node * eraser = Top;
		int j = 0;
		for (auto i = index.begin(); i < index.end() && eraser != nullptr; ++i)
		{
			eraser = eraser->next_in_row;

			for (j = 0; j < *i && eraser != nullptr; ++j)
			{
				if (j == 0)
				{
					eraser = eraser->lower;
				}
				else
				{
					eraser = eraser->next_in_row;
				}
			}
		}

		if (eraser != nullptr)
		{
			if (j == 0 && index.begin() != index.end())
			{
				Node * victim = eraser->lower;
				eraser->lower = victim->next_in_row;
				--HIGHT;
				delete victim;
			}
			else
			{
				Node * victim = eraser->next_in_row;
				eraser->next_in_row = victim->next_in_row;
				eraser->lower = victim->lower;
				delete victim;
			}
			--SIZE;
			return true;
		}
		return false;
	}
	Type get(initializer_list<Type> index)
	{
		Node *find = get_node(index);
		if (find == nullptr)
		{
			throw "BadIndex";
		}
		return find->elem;
	}

	begin_choice begin()const
	{
		return begin_choice();
	}
	end_choice end()const
	{
		return end_choice();
	}

	constexpr int size()const
	{
		return SIZE;
	}
	constexpr int hight()const
	{
		return HIGHT;
	}
};

/*count_if_greater, що приймає на вхід діапазон ітераторів та деякий елемент
такого ж типу, як у дереві і повертає кількість елементів у дереві, значення яких є
більшим ніж заданий елемент;*/
template<typename Iter, typename Type>
int count_if_greater(Iter begin, Iter end, Type comparable)
{
	int counter = 0;
	while (begin != end)
	{
		if (comparable <= *begin)
		{
			++counter;
		}
		++begin;
	}
	return counter;
}
/*count_if, що приймає на вхід діапазон ітераторів і вказівник на функцію. Повертає
кількість елементів, результат застосування переданої функції до яких рівний true;*/
template<typename Iter, typename Pred>
int count_if(Iter begin, Iter end, Pred P)
{
	int counter = 0;
	while (begin != end)
	{
		if (P(*begin))
		{
			++counter;
		}
		++begin;
	}
	return counter;
}
/*find_if, що приймає на вхід діапазон ітераторів і вказівник на функцію. Повертає
ітератор, що вказує на перший елемент, результат застосування переданої функції до
якого рівний true;*/
template<typename Iter, typename Pred>
Iter find_if(Iter begin, Iter end, Pred P)
{
	while (begin != end)
	{
		if (F(*begin))
		{
			break;
		}
		++begin;
	}
	return begin;
}
/*adjacent_find, що приймає на вхід діапазон ітераторів і повертає ітератор, що
вказує на перший елемент у структурі даних, що співпадає з елементом, який
безпосередньо передує йому;*/
template<typename Iter>
Iter adjacent_find(Iter begin, Iter end)
{
	typename Iter::value_type prev;
	while (begin != end)
	{
		prev = *begin++;
		if (prev == *begin)
		{
			return begin;
		}
	}
	return nullptr;
}
/*partial_sum, що приймає на вхід діапазон ітераторів. Якщо x 1 , x 2 ,…, x n –
елементи дерева впорядковані з використанням ітератора, то функція повертає масив
чисел: {x 1 , x 1 +x 2 , x 1 +x 2 +x 3 ,…, x 1 +x 2 +…+x n }.*/
template<typename Iter>
typename Iter::value_type * partial_sum(Iter begin, Iter end)
{
	typename Iter::value_type arr[begin.difference()];
	int index = 0;
	arr[index++] = *begin++;

	while (begin != end)
	{
		arr[index++] = arr[index] + *begin++;
	}
	return arr;
}

void main()
{
	Tree<int> T;
	T.insert({}, 10);
	T.insert({ 0 }, 11);
	T.insert({ 1 }, 12);
	T.insert({ 1, 0 }, 4);
	T.insert({ 1, 1 }, 9);
	T.insert({ 1, 2 }, 8);
	T.insert({ 2 }, 5);


	cout << "el{} = " << T.get({}) << endl;
	cout << "el{ 0 } = " << T.get({ 0 }) << endl;
	cout << "el{ 1 } = " << T.get({ 1 }) << endl;
	cout << "el{ 1,0 } = " << T.get({ 1,0 }) << endl;
	cout << "el{ 1,1 } = " << T.get({ 1,1 }) << endl;
	cout << "el{ 1,2 } = " << T.get({ 1,2 }) << endl;
	cout << "el{ 2 } = " << T.get({ 2 }) << endl;
	cout << endl;

	for (auto i = T.begin().width(); i != T.end().width(); ++i)
	{
		cout << *i << ' ';
	}

	cout << endl;
	
	cout << "HGHT\t" << T.hight() << endl;
	cout << "SIZE\t" << T.size() << endl;

	cout << "remove { 1,1 }" << endl; T.remove({ 1,1 });

	cout << "HGHT\t" << T.hight() << endl;
	cout << "SIZE\t" << T.size() << endl;
	cout << "el{ 1,1 } = " << T.get({ 1,1 }) << endl;

	cout << "remove { 1 }" << endl; T.remove({ 1 });

	cout << "el{ 1 } = " << T.get({ 1 }) << endl;

	cin.get();
}
