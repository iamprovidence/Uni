#include<iostream>
#include<string>
#include<Windows.h>
using namespace std;
class device
{
protected:
	string brand;
	int price;
public:
	device() :brand(""), price(0) {}
	device(string _brand, int _price) :brand(_brand), price(_price) {}
	device(const device& d)
	{
		brand = d.brand;
		price = d.price;
	}
	device& operator=(const device& d)
	{
		if (this != &d)
		{
			brand = d.brand;
			price = d.price;
		}
		return *this;
	}
	virtual void input(istream& in)
	{
		cout << "Enter the brand of device: ";
		in >> brand;
		cout << "Enter the price of device: ";
		in >> price;
	}
	virtual void output(ostream& out)const
	{
		out << "The brand of device: " << brand << endl;
		out << "The price of device is " << price << "$" << endl;
	}

	virtual ~device() {}
};

class electronic_device : virtual public device
{
protected:
	int year_of_production;
public:
	using device::price;//using використовуємо для використання price в main без помилки ( в public)
	electronic_device() :device(), year_of_production(0) {}
	electronic_device(string _brand, int _price, int year) :device(_brand, _price), year_of_production(year) {}
	electronic_device(const electronic_device& e)

	{
		brand = e.brand;
		price = e.price;
		year_of_production = e.year_of_production;
	}
	electronic_device& operator=(const electronic_device& e)
	{
		if (this != &e)
		{
			brand = e.brand;
			price = e.price;
			year_of_production = e.year_of_production;;
		}
		return *this;
	}
	virtual void input(istream& in)
	{
		cout << "Enter the brand of electronic device: ";
		in >> brand;
		cout << "Enter the price of electronic device: ";
		in >> price;
		cout << "Enter the year of production of electronic device: ";
		in >> year_of_production;
	}
	virtual void output(ostream& out)const
	{
		out << "The brand of electronic device: " << brand << endl;
		out << "The price of electronic device is " << price << "$" << endl;
		out << "The year of production of electronic device is " << year_of_production << endl;
	}
	virtual ~electronic_device() {}
};

class minicomputer :/*virtual*/ public electronic_device
{
protected:
	int ram;
public:
	minicomputer() : electronic_device(), ram(0) {}
	minicomputer(string _brand, int _price, int year, int _ram) :device(_brand, _price),
		electronic_device(_brand, _price, year), ram(_ram) {}
	minicomputer(const minicomputer& m)
	{
		brand = m.brand;
		price = m.price;
		year_of_production = m.year_of_production;
		ram = m.ram;
	}
	minicomputer& operator=(const minicomputer& m)
	{
		if (this != &m)
		{
			brand = m.brand;
			price = m.price;
			year_of_production = m.year_of_production;
			ram = m.ram;
		}
		return *this;
	}
	virtual void input(istream& in)
	{
		cout << "Enter the brand of minicomputer: ";
		in >> brand;
		cout << "Enter the price of minicomputer: ";
		in >> price;
		cout << "Enter the year of production of minicomputer: ";
		in >> year_of_production;
		cout << "Enter the RAM of minicomputer: ";
		in >> ram;
	}
	virtual void output(ostream& out)const
	{
		out << "The brand of minicomputer: " << brand << endl;
		out << "The price of minicomputer is " << price << "$" << endl;
		out << "The year of production of minicomputer is " << year_of_production << endl;
		out << "The RAM of minicomputer: " << ram << endl;
	}

	double func(double ram_)//функції з різним набором аргументів
	{
		cout << "minicomputer";
		return ram_;
	}

	int add(minicomputer& m)
	{
		return ram + m.ram;
	}
	virtual ~minicomputer() {}
};

class phone : /*virtual*/ public electronic_device
{
protected:
	int number_of_phone;

public:
	phone() :electronic_device(), number_of_phone(0) {}
	phone(string _brand, int _price, int year, int _number) :device(_brand, _price),
		electronic_device(_brand, _price, year), number_of_phone(_number) {}
	phone(const phone& p)
	{
		brand = p.brand;
		price = p.price;
		year_of_production = p.year_of_production;
		number_of_phone = p.number_of_phone;
	}
	phone& operator=(const phone& p)
	{
		if (this != &p)
		{
			brand = p.brand;
			price = p.price;
			year_of_production = p.year_of_production;
			number_of_phone = p.number_of_phone;
		}
		return *this;
	}
	virtual void input(istream& in)
	{
		cout << "Enter the brand of phone: ";
		in >> brand;
		cout << "Enter the price of phone: ";
		in >> price;
		cout << "Enter the year of production of phone: ";
		in >> year_of_production;
		cout << "Enter the number of phone ";
		in >> number_of_phone;
	}
	virtual void output(ostream& out) const
	{
		out << "The brand of phone: " << brand << endl;
		out << "The price of phone is " << price << "$" << endl;
		out << "The year of production of phone is " << year_of_production << endl;
		out << "The number of phone: " << number_of_phone << endl;
	}

	string func(string brand_)//функції з різним набором аргументів
	{
		cout << "phone";
		return brand_;
	}

	int add(phone& p)
	{
		return number_of_phone + p.number_of_phone;
	}
	virtual ~phone() {}
};

class smartphone :public minicomputer, public phone
{
public:
	using device::price;//using використовуємо для використання price в main без помилки ( в public)
	smartphone() :minicomputer(), phone() {}
	smartphone(string _brand, int _price, int year, int _ram, int _number_of_phone)
		:device(_brand, _price),/* electronic_device(_brand, _price, year),*/
		minicomputer(_brand, _price, year, _ram), phone(_brand, _price, year, _number_of_phone) {}
	smartphone(const smartphone& s)
	{
		brand = s.brand;
		price = s.price;
		//phone::price = s.phone::price;

		//year_of_production = s.year_of_production;
		phone::year_of_production = s.phone::year_of_production;
		ram = s.ram;
		number_of_phone = s.number_of_phone;
	}
	smartphone& operator=(const smartphone& s)
	{
		if (this != &s)
		{
			brand = s.brand;
			//phone::price = s.phone::price;
			price = s.price;
			//year_of_production = s.year_of_production;
			phone::year_of_production = s.phone::year_of_production;
			ram = s.ram;
			number_of_phone = s.number_of_phone;
		}
		return *this;
	}
	virtual void input(istream& in)
	{
		cout << "Enter the brand of smartphone: ";
		in >> brand;
		cout << "Enter the price of smartphone ";
		in >> /*phone::*/price;
		cout << "Enter the year of production of smartphone: ";
		in >> phone::year_of_production;
		cout << "Enter the RAM of smartphone: ";
		in >> ram;
		cout << "Enter the number of smartphone: ";
		in >> number_of_phone;
	}
	virtual void output(ostream& out)const
	{
		out << "The brand smartphone is " << brand << endl;
		out << "The price of smartphone is " << /*phone::*/price << "$" << endl;
		out << "The year of production of phone is " << phone::year_of_production << endl;
		out << "The RAM of smartphone: " << ram << endl;
		out << "The number of smartphone: " << number_of_phone << endl;
	}

	using phone::func;
	using minicomputer::func;
	virtual ~smartphone() {}
};

istream& operator >> (istream& in, device& d)
{
	d.input(in);
	return in;
}
ostream& operator<<(ostream& out, const device& d)
{
	d.output(out);
	return out;
}

void print_from_device(device** arr, int size)
{
	for (int i = 0; i < size; ++i)
	{
		arr[i]->output(cout);
		cout << endl;
	}
}

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	device** arr = new device*[5];
	arr[0] = new electronic_device("Петро", 23, 1998);
	arr[1] = new electronic_device("Іван", 30, 1996);
	arr[2] = new device("Назарій", 40);
	arr[3] = new electronic_device("Олег", 50, 2000);
	arr[4] = new smartphone("Hn", 23, 1998, 4, 8759);
	print_from_device(arr, 4);

	electronic_device** arra = new electronic_device*[2];
	arra[0] = (minicomputer*)new smartphone("Hn", 23, 1998, 4, 8759);
	arra[1] = new phone("ndsc", 92, 39, 9348);

	electronic_device e("Іван", 30, 1996);
	e.price = 5;
	e.output(cout);
	cout << endl;

	phone p("Андрій", 77, 2001, 965739);//застосування директиви using для надання доступу до полів базового класу
	p.price = 10;
	p.output(cout);
	cout << endl;

	minicomputer m("Олег", 30, 1700, 8);
	m.price = 2;
	m.output(cout);
	cout << endl;

	smartphone s("Вова", 90, 1750, 4, 876543);
	s.price = 6;
	s.output(cout);
	cout << endl;

	smartphone smart("Kez", 10, 1876, 6, 7546);
	smartphone sm("Vem", 20, 1678, 4, 9782);
	cout << smart.minicomputer::add(sm) << endl;// без minicomputer::  неоднозначність

	smartphone sma;
	sma.func("стрінг");
	cout << endl;
	sma.func(2.5);
	system("pause");
}