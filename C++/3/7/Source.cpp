/*
Завдання 7: (4 бали)

Створити тип транспортний маршрут (початкова станція, кінцева станція, к-
сть зупинок, протяжність маршруту в км). Дані про маршрути містяться у
файлі.

Створити вектор маршрутів. Посортувати його за протяжністю. Вивести
к-сть маршрутів, для яких середня довжина між зупинками менша за X.

Створити список маршрутів, які починаються в станції Х. Вивести маршрут з
максимальною к-стю зупинок.

(copy, sort, count_if, remove_copy_if зі стандарт. предикатом, max_element i for_each з функцією-членом класу).
*/
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <list>
#include <algorithm>
#include <iterator>

using namespace std;

class transport_route
{
private:
	string start_station;
	string terminal_station;
	int number_of_stops;
	int length_of_the_route;

public:
	transport_route(string s, string t, int n, int l)
	{
		start_station = s;
		terminal_station = t;
		number_of_stops = n;
		length_of_the_route = l;
	}

	bool operator<(const transport_route & TR)const
	{
		return length_of_the_route < TR.length_of_the_route;
	}
	int get_average_length()const
	{
		return int(length_of_the_route / number_of_stops);
	}
	string get_name_first_stop()const
	{
		return start_station;
	}
	void show(ostream & os)const
	{
		os << start_station << ' ' << terminal_station << ' ' << number_of_stops << ' ' << length_of_the_route;
		//cout << ' ' << this->get_average_length();
	}
	friend bool find_max(const transport_route & L, const transport_route & R)
	{
		return L.number_of_stops < R.number_of_stops;
	}
};


template<typename T>
void print(T &TR)
{
	for (auto i = TR.begin(); i != TR.end(); ++i)
	{
		i->show(cout);
		cout << endl;
	}
}
template<typename T>
void input(char * file_name, T &TR)
{
	ifstream is;
	is.open(file_name);
	while (!is.eof())
	{
		string s, t;
		int n, l;
		is >> s >> t >> n >> l;
		TR.emplace_back(s, t, n, l);
	}
	is.close();
}

void main()
{
	vector<transport_route> TR;
	list<transport_route> TR_l;

	input("file.txt", TR);


	cout << endl << "UNSORTED VECTOR" << endl << endl;
	print(TR);
	cout << endl;
	cin.get();
	cout << endl << "SORTED VECTOR" << endl << endl;
	sort(TR.begin(), TR.end());//сортуємо
	print(TR);


	cin.get();
	system("cls");
	cout << endl << "AMOUNT OF ROUTES WHERE AVERAGE LENGTH LESS THAN " << 10 << endl << endl;
	cout << count_if(TR.begin(), TR.end(), [](const transport_route &i)->bool {return i.get_average_length() < 10; }) << endl;

	cin.get();
	system("cls");

	cout << endl << "COPIED LIST" << endl << endl;
	copy_if(TR.begin(), TR.end(), back_inserter(TR_l), [](const transport_route &i)->bool {return i.get_name_first_stop() == "Main"; });
	print(TR_l);
	cout << endl;

	cout << endl << "ROUTE WITH MAX STOP" << endl << endl;
	max_element(TR_l.begin(), TR_l.end(), find_max)->show(cout);

	cin.get();
}
