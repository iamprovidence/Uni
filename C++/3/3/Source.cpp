/*
�������� 3: (3 ����)

� ���� ������ ������ ����� �����.

��������� ��� ����� � list.�������� ����� ����� �� �������� ������ �� �������� �� � ��������� set.

� ���������� set ���������� ����� �������� � vector �� ������� ���� ���� � �������.
������ � ��������� ���� ������� ���������� ������� ������� �����.

�������� ����������� �������� ���������� �������, �� ��������� �������� ���������
� ���������� ������(� ����� ��� ������� ����� �����) ����� �����, ���
���������� �������� ���������� ��������� ������.

��� ��������� �������� ��������������� ���������� STL.
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

	//��������� ��� ����� � list
	while (!fin.eof())
	{
		int n;
		fin >> n;
		list.push_back(n);
	}
	fin.close();

	/*std::list<int>::iterator*/
	//�������� ����� ����� �� �������� ������ �� �������� �� � ��������� set.
	for (auto i = list.begin(); i != list.end(); ++i)
	{
		if (is_prime(*i))
		{
			set.insert(*i);
		}
	}
	list.remove_if(is_prime);

	//� ���������� set ���������� ����� �������� � vector �� ������� ���� ���� � �������
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
	//	������ � ��������� ���� ������� ���������� ������� ������� �����.
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
	�������� ����������� �������� ���������� �������, �� ��������� �������� ���������
	� ���������� ������(� ����� ��� ������� ����� �����) ����� �����, ���
	���������� �������� ���������� ��������� ������.
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