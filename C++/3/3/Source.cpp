/*
Завдання 3: (3 бали)

У файлі задано список цілих чисел.

Прочитати дані файлу у list.Вилучити прості числа із заданого списку та помістити їх у контейнер set.

З контейнера set посортовані числа помістити у vector та вивести його вміст у консоль.
Ввести з клавіатури набір індексів отриманого вектора простих чисел.

Вставити послідовність елементів отриманого вектора, що визначена заданими індексами
у початковий список(у якому вже видалені прості числа) таким чином, щоб
вставлений фрагмент знаходився посередині списку.

При реалізації програми використовувати контейнери STL.
*/

#include <iostream>
#include <fstream>
#include <list>
#include <set>
#include <vector>

using namespace std;

bool is_prime(long long n)
{
	for (long long i = 2; i <= sqrt(n); ++i)
	{
		if (n%i == 0)
		{
			return false;
		}
	}

	return true;
}

void main()
{
	ifstream fin("file.txt");
	list<int> list;
	set<int> set;
	vector<int> vector;

	//Прочитати дані файлу у list
	while (!fin.eof())
	{
		int n;
		fin >> n;
		list.push_back(n);
	}
	fin.close();

	/*std::list<int>::iterator*/
	//Вилучити прості числа із заданого списку та помістити їх у контейнер set.
	for (auto i = list.begin(); i != list.end(); ++i)
	{
		if (is_prime(*i))
		{
			set.insert(*i);
		}
	}
	list.remove_if(is_prime);

	//З контейнера set посортовані числа помістити у vector та вивести його вміст у консоль
	vector.reserve(set.size());
	for (auto i = set.begin(); i != set.end(); ++i)
	{
		vector.push_back(*i);
	}
	int vector_size = vector.size();
	for (int i = 0; i < vector_size; ++i)
	{
		cout << vector[i] << ' ';
	}
	cout << endl;
	//	Ввести з клавіатури набір індексів отриманого вектора простих чисел.
	cout << "SET INDEX FROM 0 TO " << vector_size - 1 << endl;
	cout << "IF YOU WANT TO END WRITE NUMBER THAT WILL BE OUT RANGE LIKE " << vector_size << endl;

	std::set<int> vector_index;
	int write_index;

	while (true)
	{
		cin >> write_index;
		if (write_index < 0 || write_index >= vector_size)
		{
			break;
		}
		vector_index.insert(write_index);
	}

	/*
	Вставити послідовність елементів отриманого вектора, що визначена заданими індексами
	у початковий список(у якому вже видалені прості числа) таким чином, щоб
	вставлений фрагмент знаходився посередині списку.
	*/
	auto list_iterator = list.begin();
	for (int count_to_mid = 0; count_to_mid < list.size() / 2; ++count_to_mid)
	{
		++list_iterator;
	}
	for (auto i = vector_index.begin(); i != vector_index.end(); ++i)
	{
		list.insert(list_iterator, vector[*i]);
	}

	for (auto i = list.begin(); i != list.end(); ++i)
	{
		cout << *i << ' ';
	}


	cout << endl;
	system("pause");
}