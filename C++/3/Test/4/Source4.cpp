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

string get_rand_product()
{
	switch (get_rand<1, 7>())
	{
		case 1:return "Soap";
		case 2:return "Water";
		case 3: return "Bread";
		case 4:return "Fruit";
		case 5: return "Cheese";
		default: return "Subject";
	}
}

void main()
{
	//4
	static int count = 1;
	struct Product
	{
	public:
		int id = count;
		string name;
		float price;

		Product()
		{
			name = get_rand_product();
			price = get_rand<7, 150>();
			count++;
		}
	};

	list<Product> product_list(20);

	cout << "\t\tITEM\n";
	for (auto & item : product_list)
	{
		cout << item.id << ' ' << item.name << ' ' << item.price << endl;
	}

	for_each(product_list.begin(), product_list.end(), [](Product & p) {return p.price -= p.price / 10; });
	cout << "\n\nCost less than 40 \t" << find_if(product_list.begin(), product_list.end(), [](Product & p) {return p.price < 40; })->name << "\n\n\n";
	cout << "\n\t\tITEM\n";
	for (auto & item : product_list)
	{
		cout << item.id << ' ' << item.name << ' ' << item.price << endl;
	}
	cin.get();
}
