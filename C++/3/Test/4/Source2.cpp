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

array<string, 6> team{ "FCB" ,"Real" ,"MUnited" ,"Chelsea","Uventus","Arsenal" };
string get_rand_team()
{
	return team[get_rand<1, 6>()];
}

void main()
{
	//2
	struct winners
	{
		size_t year;
		string command;

		winners()
		{
			year = get_rand<1990, 2017>();
			command = get_rand_team();
		}

		bool operator<(const winners & w)const
		{
			return this->command < w.command;
		}
		bool operator==(const string & name)const
		{
			return this->command == name;
		}
	};
	list<winners> champion_leage(15);
	list<winners> euro_leage(27);

	cout << "\t\tCHAMPION_LEAGE\n";
	for (auto &s : champion_leage)
	{
		cout << s.year  << '\t' << s.command << endl;
	}
	cout << "\n\t\tEURO_LEAGE\n";
	for (auto &s : euro_leage)
	{
		cout << s.year << '\t' << s.command << endl;
	}
	cout << endl;

	cout << "\n\n\t\t\tWinrate over 3 times\n\n";
	cout << "\tTEAM\tCHAMPION LEAGE\tEURO LEAGE\tSUMMARY\n";
	for (auto iter = team.begin(); iter != team.end(); ++iter)
	{
		int counter_champ_leage = count(champion_leage.begin(), champion_leage.end(), *iter);
		int counter_euro_leage = count(euro_leage.begin(), euro_leage.end(), *iter);
		if (counter_champ_leage + counter_euro_leage > 3)
		{
			cout <<"\t" <<*iter << "\t" << counter_champ_leage <<"\t\t" << counter_euro_leage <<"\t\t" << counter_champ_leage + counter_euro_leage << endl;
		}
	}
	
	cin.get();
}
