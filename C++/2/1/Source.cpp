//Кізло Тарас варіант8 
#include <iostream>
#include <fstream>
#include <string>

using namespace std;

class Building
{
protected:
	string address;
	unsigned int amount_of_floors;
	int year;
public:
	Building() :address(""), amount_of_floors(0), year(0) {};
	virtual void input(istream &in)
	{
		in >> address >> amount_of_floors >> year;
	}
	virtual void otput(ostream &out)
	{
		out << address << ' ' << amount_of_floors << ' ' << year << ' ';
	}
	string getAddress()
	{
		return address;
	}
	unsigned int getAmounfoFloors()
	{
		return amount_of_floors;
	}
	int getYear()
	{
		return year;
	}
};

class Living :public Building
{
private:
	unsigned int amount_of_apartments;
	unsigned int amount_of_residents;
public:
	Living() :Building(), amount_of_apartments(0), amount_of_residents(0) {};
	virtual void input(istream &in)
	{
		Building::input(in);
		in >> amount_of_apartments >> amount_of_residents;
	}
	virtual void otput(ostream &out)
	{
		Building::otput(out);
		out << amount_of_apartments << ' ' << amount_of_residents << ' ';
	}
	unsigned int getAmountOfApartment()
	{
		return amount_of_apartments;
	}
	unsigned int getAmountOfResidents()
	{
		return amount_of_residents;
	}
};

class Industrial :public Building
{
private:
	string branch;
	unsigned int security_level;
public:
	Industrial() :Building(), branch(""), security_level(0) {};
	virtual void input(istream &in)
	{
		Building::input(in);
		in >> branch >> security_level;
	}
	virtual void otput(ostream &out)
	{
		Building::otput(out);
		out << branch << ' ' << security_level << ' ';
	}
	string getBranch()
	{
		return branch;
	}
	unsigned int getSecurityLevel()
	{
		return security_level;
	}
};

//сортування за адресою
void sort(Building **a, int n)
{
	Building *t;
	for (size_t i = 0; i < n - 1; i++)
	{
		for (size_t j = 0; j < n - 1 - i; j++)
		{
			if (a[j]->getAddress() > a[j + 1]->getAddress())
			{
				swap(a[j], a[j + 1]);
			}
		}
	}
}
//пошук наймолодшої будівлі з мін кл квартир
string theYoungestBuildingWithMinAmountofAppartment(Building **a, int n)
{
	int max_year = 3000, current_year;
	unsigned int max_amount_of_apartments = 5000 , current_amount_of_apartments;
	string address;
	Living *p;

	for (size_t i = 0; i < n; i++)
	{
		p = dynamic_cast<Living*>(a[i]);
		if (p)
		{
			current_year = p->getYear();
			current_amount_of_apartments = p->getAmountOfApartment();

			if (current_year < max_year && current_amount_of_apartments)
			{
				max_year = current_year;
				max_amount_of_apartments = current_amount_of_apartments;
				address = p->getAddress();
			}
		}
	}
	return address;
}
//вивід будівель вказаної галузі
void output_of_building_industry(Building **a, int n, string branch)
{
	Industrial *p;

	for (size_t i = 0; i < n; i++)
	{
		p = dynamic_cast<Industrial*>(a[i]);

		if (p && p->getBranch() == branch)
		{
			cout << a[i]->getAddress() << endl;
		}
	}
}

int main()
{
	int n, p;
	ifstream in("building.txt");
	in >> n;
	Building** a = new Building*[n];

	for (size_t i = 0; i < n; i++)
	{
		in >> p;
		switch (p)
		{
		case 1: a[i] = new Living(); break;
		case 2: a[i] = new Industrial(); break;
		}
		a[i]->input(in);
	}

	for (size_t i = 0; i < n; i++)
	{
		a[i]->otput(cout);
		cout << endl;
	}
	sort(a, n);
	cout << endl;
	cout << "After sorting\n";
	cout << endl;
	for (size_t i = 0; i < n; i++)
	{
		a[i]->otput(cout);
		cout << endl;
	}

	cout << endl;
	cout << "The Youngest Building With Minor Amount of Appartment on Street\n" << theYoungestBuildingWithMinAmountofAppartment(a, n) << endl;
	
	cout << endl;
	//Agriculture Wood Metal Silver
	string g;
	cin >> g;
	cout << "All building with this industry on street\n"; 
	output_of_building_industry(a, n, g);

	in.close();

	for (size_t i = 0; i < n; i++)
	{
		delete a[i];
	}
	delete[] a;

	system("pause");
}
