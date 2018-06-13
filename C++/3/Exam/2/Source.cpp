/*
Оголосіть шаблон класу "Комплект предметів", параметризований типом предметів
(наприклад, Сервіз – це Комплект посуду, Гербарій – Комплект рослин, Залікова – Комплект
оцінок тощо). Об’єкти класу вміють виводити себе в потік, додавати/вилучати предмети,
повідомляти кількість певних (однакових) предметів. Для комплектів визначено оператори
перетину, об’єднання, різниці. (8)
2. Введіть з клавіатури два комплекти підручників. Підручник – простий об’єкт, що зберігає
назву книги та прізвище автора. Обчисліть і надрукуйте перетин і об’єднання цих комплектів.
Чи є серед заданих підручників такі, в назві яких є слово «програмування»? (7)
3. За допомогою алгоритмів STL прочитайте з текстового файла декілька комплектів продуктів
харчування. Виведіть їх на екран. (Об’єкт Продукт зберігає назву та ціну.) Визначте, скільки є
комплектів, що містять продукти, дорожчі за 100, 200, 300 грошових одиниць. Вилучіть з
першого комплекту всі продукти, дорожчі за 100. (10)
4. Використайте один з патернів проектування (5):
a. «Декоратор» – декоровані комплекти виводять себе в потік у особливий спосіб
b. «Ланцюжок відповідальності» – вибір способу опрацювання запиту користувача на
виконання дій з комплектом
c. «Фабрика» чи «Прототип» – для виготовлення елементів комплекту
d. «Адаптер» – для долучення до комплекту предметів неспорідненого типу, наприклад,
компакт-дисків до підручників
e. «Будівельник» – для створення комплектів
f. Власний варіант
*/
#include <iostream>
#include <fstream>
#include <string>
#include <algorithm>
#include <vector>
#include <functional>
#include <iterator>

using namespace std;

struct IPrototype
{
	virtual IPrototype * clone()const = 0;
};
struct IObject
{
	 virtual ostream& show(ostream& os)const = 0;
	 virtual istream& read(istream& is) = 0;
};

template<typename T>
class mset: public IObject
{
private:
	vector<T> obj;

public:
	mset(int s = 0) :obj(s) {	}
	mset(vector<T> v) :obj(v) {	}

	typename vector<T>::iterator begin()
	{
		return obj.begin();
	}
	typename vector<T>::iterator end()
	{
		return obj.end();
	}

	int size()const
	{
		return obj.size();
	}
	mset<T>& add(const T& s)
	{
		obj.push_back(s);
		return *this;
	}
	mset<T>& remove(const T& s)
	{
		obj.erase(s);
		return *this;
	}
	template<typename Pred>
	mset<T>& erase_if(Pred &f)
	{
		obj.erase
		(
			remove_if(obj.begin(), obj.end(), f),
			obj.end()
		);
		return *this;
	}
	int same_as(const T& s)const
	{
		return count(obj.begin(), obj.end(), s);
	}

	mset<T> Union(mset<T> ms)
	{
		mset<T> temp;

		sort(obj.begin(), obj.end());
		sort(ms.obj.begin(), ms.obj.end());

		set_union(obj.begin(), obj.end(), ms.obj.begin(), ms.obj.end(), back_inserter(temp.obj));
		return temp;
	}
	mset<T> Intersection(mset<T> ms)
	{
		mset<T> temp;

		sort(obj.begin(), obj.end());
		sort(ms.obj.begin(), ms.obj.end());

		set_intersection(obj.begin(), obj.end(), ms.obj.begin(), ms.obj.end(), back_inserter(temp.obj));
		return temp;
	}
	mset<T> Difference(mset<T> ms)
	{
		mset<T> temp;

		sort(obj.begin(), obj.end());
		sort(ms.obj.begin(), ms.obj.end());

		set_difference(obj.begin(), obj.end(), ms.obj.begin(), ms.obj.end(), back_inserter(temp.obj));
		return temp;
	}

	virtual ostream& show(ostream& os)const
	{
		for (auto&& c : obj)
		{
			c.show(os);
			os << endl;
		}
		return os;
	}
	virtual istream& read(istream& is)
	{
		T temp;
		temp.read(is);
		obj.push_back(temp);
		return is;
	}
};

class book :public IObject, public IPrototype
{
private:
	string book_name;
	string author_name;
public:
	book(string bn = "bad_name", string an = "unknown")
	{
		book_name = bn;
		author_name = an;
	}

	bool has(string patern)
	{
		return book_name.find(patern) != std::string::npos;
	}
	virtual ostream& show(ostream& os)const
	{
		return os << book_name << ' ' << author_name;
	}
	virtual istream& read(istream& is)
	{
		return is >> book_name >> author_name;
	}
	virtual IPrototype * clone()const
	{
		return new book(*this);
	}
	bool operator<(const book & b)const
	{
		return book_name < b.book_name;
	}
};
class product :public IObject, public IPrototype
{
private:
	string name;
	float price;
public:
	product(string n = "bad_name", float p = 0.0)
	{
		name = n;
		price = p;
	}

	virtual ostream& show(ostream& os)const
	{
		return os << name << ' ' << price;
	}
	virtual istream& read(istream& is)
	{
		return is >> name >> price;
	}
	virtual IPrototype * clone()const
	{
		return new product(*this);
	}
	bool operator<(const product & p)const
	{
		return price < p.price;
	}
	float get_price()const
	{
		return price;
	}
};

ostream& operator<<(ostream& os, const IObject & my_obj)
{
	return my_obj.show(os);
}
istream& operator>>(istream& is, IObject & my_obj)
{
	return my_obj.read(is);
}

void main()
{
	ifstream f1("set1.txt"), f2("set2.txt");
	istream_iterator<book> it1(f1), it2(f2);
	vector<book> temp(it1, istream_iterator<book>()),	temp2(it2, istream_iterator<book>());
	mset<book> ms1(temp), ms2(temp2);
	f1.close(),	f2.close();

	cout << "SET 1" << endl << ms1 << endl;
	cout << "SET 2" << endl << ms2 << endl;

	cout <<"Intersection\n"<< ms1.Intersection(ms2) << endl;
	cout << "Union\n" << ms1.Union(ms2) << endl;

	for (auto it = ms1.begin(); it != ms1.end(); ++it)
	{
		if (it->has("programming"))
		{
			cout << *it << " has programming\n";
		}
	}

	for (auto it = ms2.begin(); it != ms2.end(); ++it)
	{
		if (it->has("programming"))
		{
			cout << *it << " has programming\n";
		}
	}

	system("pause");
	ifstream f3("product1.txt"), f4("product2.txt"), f5("product3.txt");
	istream_iterator<product> it3(f3), it4(f4), it5(f5);
	vector<product> temp3(it3, istream_iterator<product>()), temp4(it4, istream_iterator<product>()), temp5(it5, istream_iterator<product>());
	mset<product> ms3(temp3), ms4(temp4), ms5(temp5);
	f3.close(), f4.close(), f5.close();

	cout << "\nList Product 1\n" << ms3 << endl;
	cout << "\nList Product 2\n" << ms4 << endl;
	cout << "\nList Product 3\n" << ms5 << endl;

	int more_than = 0;
	cout << "\nCost more than 100 \t";
	more_than += count_if(ms3.begin(), ms3.end(), [](const product& p) {return p.get_price() >= 100; });
	more_than += count_if(ms4.begin(), ms4.end(), [](const product& p) {return p.get_price() >= 100; });
	more_than += count_if(ms5.begin(), ms5.end(), [](const product& p) {return p.get_price() >= 100; });
	cout << more_than; 
	more_than = 0;
	cout << "\nCost more than 200\t";
	more_than += count_if(ms3.begin(), ms3.end(), [](const product& p) {return p.get_price() >= 200; });
	more_than += count_if(ms4.begin(), ms4.end(), [](const product& p) {return p.get_price() >= 200; });
	more_than += count_if(ms5.begin(), ms5.end(), [](const product& p) {return p.get_price() >= 200; });
	cout << more_than;
	more_than = 0;
	cout << "\nCost more than 300\t";
	more_than += count_if(ms3.begin(), ms3.end(), [](const product& p) {return p.get_price() >= 300; });
	more_than += count_if(ms4.begin(), ms4.end(), [](const product& p) {return p.get_price() >= 300; });
	more_than += count_if(ms5.begin(), ms5.end(), [](const product& p) {return p.get_price() >= 300; });
	cout << more_than;

	cout << "\nList Product 1\n" << ms3 << endl;
	ms3.erase_if([](const product & p)->bool {return p.get_price() >= 100; });
	cout << "Erase all which cost more than 100\n" << ms3 << endl;

	system("pause");
}