/*
1. Оголосіть шаблон класу "Точка декартового простору", параметризований типом координат
(це міг би бути будь-який числовий тип). Об’єкти класу вміють виводити себе в потік,
повідомляти свої координати, обчислювати відстань до іншої точки. Для точок визначено
покоординатне додавання та віднімання, множення на скаляр. (8)
2. Введіть з клавіатури три точки (координати задані цілими числами), що є вершинами деякого
трикутника. Обчисліть і надрукуйте периметр і площу цього трикутника. Чи є серед заданих
точок «особливі» (особливою є точка, що лежить в ε-околі початку координат). (7)
3. За допомогою алгоритмів STL прочитайте з текстового файла в контейнер декілька точок з
дійсними координатами. Виведіть їх на екран. Визначте, скільки точок належить
концентричним сферам з центром в початку системи координат і радіусами 1, 2, 3. Обчисліть
довжину ламаної, послідовними вузлами якої є задані точки. (10)
4. Використайте один з патернів проектування (5):
a. «Стан» – точка, що в результаті зміни координат потрапляє в ε-окіл початку координат,
стає особливою
b. «Декоратор» – декоровані точки виводять себе в потік у особливий спосіб
c. «Спостерігач» – точки повідомляють про виконання дій з ними
d. «Адаптер» – щоб працювати з проекціями точок тривимірного простору на площину
e. «Ланцюжок відповідальності» – вибір способу опрацювання запиту користувача на
виконання дій з точкою
f. Власний варіант
*/

#include <string>
#include <iostream>
#include <fstream>
#include <vector>
#include <algorithm>
#include <iterator>
#include <numeric>
#include <set>

using namespace std;

//декорації підлягає метод show()
struct I
{
	virtual ~I() {}
	virtual ostream& show(ostream& os)const = 0;
};
class Decoration : public I
{
private:
	I* m_wrappee;

public:
	//декоратор приховує всередині обгорнутий "справжній" об'єкт
	//і перенаправляє йому запити щось зробити
	Decoration(I* inner) : m_wrappee(inner) {}
	~Decoration()
	{
		delete m_wrappee;
	}
	virtual ostream& show(ostream& os)const
	{
		return m_wrappee->show(os);
	}
};
// конкретні реалізації обгорток: спочатку працює вкладений об'єкт, потім - обгортка
struct Super : public Decoration
{
	Super(I* core) : Decoration(core) {}
	~Super(){	}
	virtual ostream& show(ostream& os)const
	{
		Decoration::show(os);
		return os << " *Super Point* ";
	}
};struct Mega : public Decoration
{
	Mega(I* core) : Decoration(core) {}
	~Mega() {	}
	virtual ostream& show(ostream& os)const
	{
		Decoration::show(os);
		return os << " *Mega Point* ";
	}
};

template<typename T>
class Point : public I
{

private:
	// Стан
	class basic_point
	{
	protected:
		T x;
		T y;
	public:
		basic_point(T xi = 0, T yi = 0) : x(xi), y(yi) { }
		basic_point(const basic_point& p) : x(p.x), y(p.y) {  }
		virtual basic_point* clone() const = 0;

		T get_x()const
		{
			return x;
		}
		T get_y()const
		{
			return y;
		}
		
		istream& read(istream& is)
		{
			return is >> x >> y;
		}

		virtual ostream& print(ostream& os)const = 0;

	};
	struct Special :public basic_point
	{
		Special(T xi, T yi) :basic_point(xi, yi) {}
		virtual basic_point* clone() const
		{
			return new Special(*this);
		}
		virtual ostream& print(ostream& os)const
		{
			return os << " *SPECIAL* " << " x = " << x << " y = " << y;
		}
	};
	struct Simple :public basic_point 
	{
		Simple(T xi, T yi) :basic_point(xi, yi) {}
		virtual basic_point* clone() const
		{
			return new Simple(*this);
		}
		virtual ostream& print(ostream& os)const
		{
			return os << " x = " << x << " y = " << y;
		}
	};
	
	basic_point * state;

private:
	static bool special(T xi, T yi)
	{
		return xi >= 0 && xi < 1 && yi >= 0 && yi < 1;
	}
	void set_state(T xi, T yi)
	{
		if (special(xi, yi))
		{
			if (dynamic_cast<Special*>(state)) return;
			else delete state;

			state = new Special(xi, yi);
		}
		else
		{
			if (dynamic_cast<Simple*>(state)) return;
			else delete state;
			state = new Simple(xi, yi);
		}
	}

public:
	Point(T xi = 0 , T yi = 0) : state(new Simple(xi, yi))
	{ 
		set_state(xi, yi);
	}
	Point(const Point& p) :state(p.state->clone()){ }
	~Point()
	{
		delete state;
	}
	Point& operator=(const Point& r)
	{
		if (&r == this) return *this;

		delete state;
		state = r.state->clone();
		return *this;
	}
	
	virtual ostream& show(ostream& os)const override
	{
		return state->print(os);
	}
	istream& read(istream& is)
	{
		return this->state->read(is);
	}

	T distance(const Point& b)const
	{
		return T(sqrt((b.state->get_x() - state->get_x())*(b.state->get_x() - state->get_x())
			+ 
			(b.state->get_y() - state->get_y())*(b.state->get_y() - state->get_y())));
	}

	Point& operator+(const Point& b)const
	{
		return Point(state->get_x() + b.state->get_x(), state->get_y() + b.state->get_y());
	}
	Point& operator-(const Point& b)const
	{
		return Point(state->get_x() - b.state->get_x(), state->get_y() - b.state->get_y());
	}

	template<typename Y>
	Point& operator*(const Y s)const
	{
		return Point(s * state->get_x(), s * state->get_y());
	}
};
template<typename T>
istream& operator >> (istream& is, Point<T>& p)
{
	return p.read(is);
}
ostream& operator<< (ostream& os, const I& p)
{
	return p.show(os);
}


void main()
{
	// під час считування, викликається конструктор за замовчуванням
	// потім виклик методу read
	// отже стан буде спеціальним, для всіх точок
	// як поправити?
	Point<int> A(1, 2), B(0, 0), C(1, 3);
	//cin >> A >> B >> C;// !!!
	cout << A << endl << B << endl << C << endl;

	int c = A.distance(B), a = B.distance(C), b = C.distance(a);
	cout << "P = " << a + b + c << endl;
	cout << "S = " << a * b * c << endl;

	system("pause");
	
	/*
	// та сама помилка, що і в першому завданні
	ifstream fin("points.txt");
	istream_iterator<Point<float>> file(fin);
	vector<Point<float>> V(file, istream_iterator<Point<float>>());
	fin.close();
	*/
	
	ifstream fin("points.txt");
	vector<Point<float>> V;
	while (!fin.eof())
	{
		float x, y;
		fin >> x >> y;
		V.emplace_back(x, y);
	}
	fin.close();

	copy(V.begin(), V.end(), ostream_iterator <Point<float>> (cout, "\n"));
	
	int amount = count_if(V.begin(), V.end(),
		[](const Point<float>& p)->bool 
	{
		float dis = p.distance(Point<float>(0, 0)); 
		return dis <= 3 && dis >= 0; 
	});

	cout << "Amount in the center " << amount << endl;
	float lenght_of_curve = accumulate(V.begin(), V.end(), 0.0,
		[lenght_of_curve](const Point<float>& a, const Point<float>& b) {return abs(a.distance(b)); });
	cout << "Length of curve " << lenght_of_curve << endl;
	
	// DECORATOR

	vector<I *> Vptr;
	for (auto i = V.begin(); i != V.end(); ++i)
	{
		Vptr.push_back(new Point<float>(*i));
	}

	Vptr[1] = new Mega(new Super(Vptr[1]));


	for (int i = 0; i < Vptr.size(); ++i)
	{
		cout << *Vptr[i] << endl;
	}

	for (auto i = Vptr.begin(); i != Vptr.end(); ++i)
	{
		delete *i;
	}
		
	system("pause");
}