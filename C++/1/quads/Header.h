#pragma once
#include <iostream>
#include <string>

using namespace std;

class Figure
{
public:
	Figure() :name("") {};
	Figure(string n);
	Figure(const Figure& F);
	virtual void show(ostream&os)const;
	virtual void print()const
	{
		cout << name << endl;
	}
protected:
	string name;
};

class Quadrilateral: virtual public Figure
{
public:
	//using використовуємо для використання name в main без помилки ( в public)
	using Figure::name;
	Quadrilateral() :Figure(),a(1.), b(1.), c(1.), d(1.) {};
	Quadrilateral(string n,double x, double y, double z, double w);
	Quadrilateral(const Quadrilateral& Q);
	virtual void show(ostream&os)const;
	virtual void print()const
	{
		cout << name << endl;
		cout << a << ' ' << b << ' ' << c << ' ' << d << endl;
	}
protected:
	double a, b, c, d;
};

class Parallelogram : public Quadrilateral
{
public:
	Parallelogram() : Quadrilateral() {};
	Parallelogram(string n, double x, double y) : Quadrilateral(n, x, y, x, y) {};
	Parallelogram(const Parallelogram& P);
	virtual void show(ostream&os)const;
	double S(double a);
	double P(double a)const;
	virtual void print()const
	{
		cout << name << endl;
		cout << a << ' ' << b << ' ' << c << ' ' << d << endl;
	}
};

class Rhombus : public Quadrilateral
{
public:
	Rhombus() :Quadrilateral(){};
	Rhombus(string n, double x) : Quadrilateral(n, x, x, x, x) {};
	Rhombus(const Rhombus& R);
	virtual void show(ostream&os)const;
	double S(int a);
	double P(double a)const;
	virtual void print()const
	{
		cout << name << endl;
		cout << a << ' ' << b << ' ' << c << ' ' << d << endl;
	}
};

class Square :public Rhombus, public Parallelogram
{
public:
	//using використовуємо для використання name в main без помилки ( в public)
	using Figure::name;
	Square() :Parallelogram() {};
	Square(string n,double x) : Rhombus(n,x) {};
	Square(const Rhombus& S);
	~Square() {};
	virtual void show(ostream&os)const;
//	using Rhombus::S;
//	using Parallelogram::S;
	virtual void print()const
	{
		cout << name << endl;
		cout << Quadrilateral::a << ' ' << Rhombus::b << ' ' << Parallelogram::c << ' ' << Quadrilateral::d << endl;
	}
};