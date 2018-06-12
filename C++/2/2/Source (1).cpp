//Кізло Тарас ПМі-14 Варіант №7

/*В 2 текстових файлах здані дані про торгову точку: дані про магазин (назва, адрес, тип) та товари (кад, назва, виробник, ціна, кількість).
Торгова точка торгує декількома товарами. Назви товарів можуть повторюватись*/

#include <iostream>
#include <fstream>
#include <string>
#include <sstream>

using namespace std;
//створити необхідні типи
class Shop
{
private:
	string name;
	string address;
	string type;
public:
	Shop() : name(" "), address(" "), type(" ") {};
	
	friend istream& operator >> (istream& in, Shop& a)
	{
		in >> a.name >> a.address >> a.type;
		return in;
	}

	friend ostream& operator<<(ostream& out, Shop& a)
	{
		out << a.name << "\t" << a.address << "\t" << a.type << "\t";
		return out;
	}

	string getName()
	{
		return name;
	}
	string getAddress()
	{
		return address;
	}
	string getType()
	{
		return type;
	}
	
	void setName(string n)
	{
		name = n;
	}
	void setAddress(string a)
	{
		address = a;
	}
	void setType(string t)
	{
		type = t;
	}

};

class Product
{
private:
	unsigned int code;
	string name;
	string developer;
	double price;
	int amount;
public:
	Product() : code(0), name(""), developer(""), price(0), amount(0) {};

	bool operator!=(const Product&P)const
	{
		return name != P.name && developer != P.developer;
	}

	friend istream& operator >> (istream& in, Product& a)
	{
		in >> a.code >> a.name >> a.developer >> a.price >> a.amount;
		return in;
	}

	friend ostream& operator<<(ostream& out, Product& a)
	{
		out << a.code << "\t" << a.name << "\t" << a.developer << "\t" << a.price << "\t" << a.amount << "\t";
		return out;
	}

	unsigned int getCode()
	{
		return code;
	}

	string getName()
	{
		return name;
	}
	string getDeveloper()
	{
		return developer;
	}
	double getPrice()
	{
		return price;
	}
	int getAmount()
	{
		return amount;
	}

	void setCode(unsigned int c)
	{
		code = c;
	}
	void setName(string n)
	{
		name = n;
	}
	void setDeveloper(string d)
	{
		developer = d;
	}
	void setPrice(double p)
	{
		price = p;
	}
	void setAmount(int a)
	{
		amount = a;
	}
};

class aPointOfSale
{
private:
	string name;
	Shop sh;
	Product * pr;
	int amount_of_products;
public:
	friend class Shop;
	friend class Product;

	aPointOfSale() :name(""), sh(), pr(nullptr), amount_of_products(0) {};
	aPointOfSale(const aPointOfSale&a)
	{
		name = a.name;
		sh = a.sh;
		pr = new Product[amount_of_products];
		for (size_t i = 0; i < amount_of_products; i++)
		{
			pr[i] = a.pr[i];
		}
	}
	aPointOfSale operator=(const aPointOfSale&a)
	{
		if (this != &a)
		{
			name = a.name;
			sh = a.sh;
			pr = new Product[amount_of_products];
			for (size_t i = 0; i < amount_of_products; i++)
			{
				pr[i] = a.pr[i];
			}
		}
		return *this;
	}
	friend istream&operator>>(istream&in, aPointOfSale&a)
	{
		in >> a.name >> a.sh >> a.amount_of_products;
		a.pr = new Product[a.amount_of_products];
		for (size_t i = 0; i < a.amount_of_products; i++)
		{
			in >> a.pr[i];
		}
		return in;
	}

	friend ostream&operator<<(ostream&out, aPointOfSale&a)
	{
		out << a.name << endl;
		out << a.sh << endl;
		string product;
		int amount;
		int sum_price;

		for (size_t i = 0; i < a.amount_of_products; i++)
		{
			product = a[i].getName();

			if (ill != ' ')
			{
				amount = 1;
				sum_price = 0;
				a[i].setName(' ');
				for (size_t j = i + 1; j < a.n; j++)
				{
					if (a[j].getName() == ill)
					{
						amount++;
						a[j].setName(' ');
						sum_price += a[j].getPrice();
					}
				}
				out << '\n' << ill << " - " << sum_price << ' - ' << amount;
			}
		}
		return out;
	}

	~aPointOfSale()
	{
		delete[]pr;
	}
	Product& operator[](int i)
	{
		return pr[i];
	}
	string getName()
	{
		return name;
	}
	Shop getShop()
	{
		return sh;
	}
	int getAmountOfProduct()
	{
		return amount_of_products;
	}
};

//вивести на екран список торгових точок з максимальною к-стю різних товарів
void searchMaxAmountDifferent(aPointOfSale *a, int n)
{
	int max = 0;
	int current_dif;
	//пошук макс числа
	for (size_t i = 0; i < n; i++)
	{
		current_dif = 0;
		//пошук різного товару товару
		for (size_t j = 0; j < a[i].getAmountOfProduct(); j++)
		{
			for (size_t l = j; l < a[i].getAmountOfProduct() - 1; l++)
			{
				if (a[i][j] != a[i][l + 1])
				{
					++current_dif;
				}
			}
		}
		if (max < current_dif)
		{
			max = current_dif;
		}
	}

	int find;
	//вивід
	for (size_t i = 0; i < n; i++)
	{
		find = 0;
		for (size_t j = 0; j < a[i].getAmountOfProduct(); j++)
		{
			for (size_t l = j; l < a[i].getAmountOfProduct() - 1; l++)
			{
				if (a[i][j] != a[i][l + 1])
				{
					++find;
				}
			}
		}
		if (max == find)
		{
			cout << a[i].getName() << endl;
		}
	}
}

//знайти торгову точку, в якій найменше товарів вказаного виробника
string findWithLessProduct(aPointOfSale* a, int n, string dev)
{
	int min = 9999;
	string point_name = "";
	for (int i = 0; i < n; i++)
	{
		int current = 0;
		for (size_t j = 0; j < a[i].getAmountOfProduct(); j++)
		{
			if (a[i][j].getDeveloper() == dev)
			{
				++current;
			}
		}
		if (min > current)
		{
			min = current;
			point_name = a[i].getName();
		}
	}
	return point_name;
}

void sort(aPointOfSale *a, int n)
{
	for (size_t i = 0; i < n - 1; i++)
	{
		for (size_t j = 0; j < n - 1 - i; j++)
		{
			if (a[j].getShop().getAddress() > a[j + 1].getShop().getAddress())
			{
				swap(a[j], a[j + 1]);
			}
		}
	}
}

void main()
{

	int n, m;
	ifstream in;

	in.open("shop.txt");
	in >> n;
	Shop* s = new Shop[n];
	for (int i = 0; i < n; i++)
	{
		in >> s[i];
	}
	in.close();

	in.open("products.txt");
	in >> m;
	Product* p = new Product[m];
	for (int i = 0; i < m; i++)
	{
		in >> p[i];
	}
	in.close();

	aPointOfSale APS[5];
	
	searchMaxAmountDifferent(APS, 5);
		
	cout << findWithLessProduct(APS, 5, "Soap") << endl;
		
	sort(APS, n);

	system("pause");
}