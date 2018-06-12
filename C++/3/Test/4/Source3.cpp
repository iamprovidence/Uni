#include <algorithm>
#include <list>
#include <iostream>
#include <numeric>
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

string get_rand_name()
{
	switch (get_rand<1, 7>())
	{
		case 1:return "Taras";
		case 2:return "Nazar";
		case 3: return "Ivan";
		case 4:return "Petro";
		case 5: return "Vova";
		default: return "Bob";
	}
}

void main()
{
	//3
	const int amount_of_student = 15;
	struct student
	{
		string surname;
		float average_score;

		student()
		{
			surname = get_rand_name();
			average_score = get_rand<1, 100>();
		}
	};
	list<student> List_of_student(amount_of_student);

	for (auto &s : List_of_student)
	{
		cout << s.surname << '\t' << s.average_score << endl;
	}
	cout << endl;

	float average_score_from_all = 0;
	for_each(List_of_student.begin(), List_of_student.end(), [&average_score_from_all](const student & s)->void {average_score_from_all += s.average_score; }); 
	average_score_from_all /= amount_of_student;
	cout << "\tAverage Score\t" << average_score_from_all << endl;
	List_of_student.remove_if([&average_score_from_all](const student & s)->bool { return s.average_score < average_score_from_all; });
	cout << endl;

	for (auto &s : List_of_student)
	{
		cout << s.surname << '\t' << s.average_score << endl;
	}
	
	cin.get();
}
