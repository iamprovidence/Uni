#include <algorithm>
#include <list>
#include <iostream>
#include <iterator>
#include <string>
#include <map>
#include <array>
#include <forward_list>

using namespace std;

// повертає випадкове число із діапазону [min, max)
template<int min = 1, int max = 5 >
int get_rand()
{
	//формула rand() % (різниця між границями) + ліва границя
	return rand() % (max - min) + min;
}

string get_rand_subject()
{
	switch (get_rand<1, 7>())
	{
		case 1:return "history";
		case 2:return "english";
		case 3:return "programming";
		case 4:return "biology";
		case 5:return "ukrainian";
		case 6:return "math";
		default:return "literature";
	}
}

string get_rand_name()
{
	switch (get_rand<1, 7>())
	{
		case 1:return "Taras";
		case 2:return "Nazar";
		case 3:return "Ivan";
		case 4:return "Petro";
		case 5:return "Vova";
		default:return "Bob";
	}
}

void main()
{

	//1
	const int amount_of_student = 15;
	array<forward_list<string>, amount_of_student> students;
	//заповнити
	for (int i = 0; i < amount_of_student; ++i)
	{
		generate_n(front_inserter(students[i]), get_rand(), get_rand_subject);
	}
	// вивід
	for (int i = 0; i < amount_of_student; ++i)
	{
		cout << get_rand_name() << '\t';
		for (auto s = students[i].begin(); s != students[i].end(); ++s)
		{
			cout << *s << ' ';
		}
		cout << endl;
	}
	//найпопулярніший предмет
	map<string, int> how_mush_every_subject_choosed;
	for (int i = 0; i < amount_of_student; ++i)
	{
		for (auto j = students[i].begin(); j != students[i].end(); ++j)
		{
			how_mush_every_subject_choosed[*j]++;
		}
	}
	auto most_popular_subject = max_element(how_mush_every_subject_choosed.begin(),	how_mush_every_subject_choosed.end(),
		[](pair<string, int> a, pair<string, int> b) {return a.second < b.second; });
	cout << "The most popular:\t" << most_popular_subject->first << "\t\twas choosed "<< most_popular_subject->second <<endl;

	system("pause");
}
