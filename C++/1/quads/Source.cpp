#include <iostream>

using namespace std;

class Quadrilateral
{
public:
	Quadrilateral() :a(1.), b(1.), c(1.), d(1.) {};
	Quadrilateral(double x, double y, double z, double w);

	virtual void show(ostream&os)const
	{
		os << "Quadrilateral=(" << a << 'x' << b << 'x' << c << 'x' << d << ")\n";
	}

	double P()const
	{
		return a + b + c + d;
	}

protected:
	double a, b, c, d;
};

class Parallelogram :public Quadrilateral
{
public:
	Parallelogram() : Quadrilateral() {};
	Parallelogram(double x, double y) : Quadrilateral(x, y, x, y) {};

	virtual void show(ostream&os)const
	{
		os << "Parallelogram=(" << a << 'x' << b << ")\n";
	}
};

class Rectangle
{
public:
	Rectangle() :e(1.), b(1.) {};
	Rectangle(double x, double y);
	virtual double S()const
	{
		return e*b;
	}

protected:
	double e, b;
};

class Square :public Rectangle, public Parallelogram
{
public:
	Square() :Parallelogram() {};
	Square(double x) : Parallelogram(x, x) {};

	virtual void show(ostream&os)const
	{
		os << "Square=(" << a << ")\n";
	}

	virtual double S()const
	{
		return a*a;
	}
};

Rectangle::Rectangle(double x, double y)
{
	e = x > 0.1 ? x : 0.1;
	b = y > 0.1 ? y : 0.1;
}

Quadrilateral::Quadrilateral(double x, double y, double z, double w)
{
	a = x > 0.1 ? x : 0.1;
	b = y > 0.1 ? y : 0.1;
	c = z > 0.1 ? z : 0.1;
	d = w > 0.1 ? w : 0.1;
}

void main()
{
	Quadrilateral Q(1, 2, 2.5, 4);
	Parallelogram P(2, 3);
	Rectangle R(3.5, 2);
	Square S(5);

	cout << endl << "----SHOW----" << endl;
	Q.show(cout);
	P.show(cout);
	//R.show(cout);
	S.show(cout);

	cout << endl << "----P----" << endl;
	cout << Q.P() << endl;
	cout << P.P() << endl;
	//cout << R.P() << endl;
	cout << S.P() << endl;

	cout << endl << "----S----" << endl;
	//cout << Q.S() << endl;
	//cout << P.S() << endl;
	cout << R.S() << endl;
	cout << S.S() << endl;

	system("pause");
}