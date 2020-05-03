#include "Header.h"

ostream& operator<<(ostream& out, const Figure& F)
{
	F.show(out);
	return out;
}

Figure::Figure(string n)
{
	this->name = n;
}
Figure::Figure(const Figure& F)
{
	this->name = F.name;
}
Figure&Figure::operator=(const Figure&F)
{
	if (this != &F)
	{
		this->name = F.name;
	}
	return *this;
}
void Figure::show(ostream&os)const
{
	os << "Figure name is " << name << endl;
}

Quadrilateral::Quadrilateral(string n, double x, double y, double z, double w)
{
	name = n;
	a = x > 0.1 ? x : 0.1;
	b = y > 0.1 ? y : 0.1;
	c = z > 0.1 ? z : 0.1;
	d = w > 0.1 ? w : 0.1;
}
Quadrilateral::Quadrilateral(const Quadrilateral& Q)
{
	this->name = Q.name;
	this->a = Q.a;
	this->b = Q.b;
	this->c = Q.c;
	this->d = Q.d;
}
Quadrilateral& Quadrilateral::operator=(const Quadrilateral&Q)
{
	if (this!=&Q)
	{
		this->name = Q.name;
		this->a = Q.a;
		this->b = Q.b;
		this->c = Q.c;
		this->d = Q.d;
	}
	return *this;
}
void Quadrilateral::show(ostream&os)const
{
	
	os << name << endl;
	os << "Quadrilateral=(" << a << 'x' << b << 'x' << c << 'x' << d << ")\n";
}


Parallelogram::Parallelogram(const Parallelogram& P)
{
	this->name = P.name;
	this->a = P.a;
	this->b = P.b;
	this->c = P.c;
	this->d = P.d;
}
Parallelogram& Parallelogram::operator=(const Parallelogram&P)
{
	if (this != &P)
	{
		this->name = P.name;
		this->a = P.a;
		this->b = P.b;
		this->c = P.c;
		this->d = P.d;
	}
	return *this;
}
void Parallelogram::show(ostream&os)const
{
	os << name << endl;
	os << "Parallelogram=(" << a << 'x' << b << ")\n";
}/*
double Parallelogram::S(double a)
{
	return 4 * a;
}*/
double Parallelogram::P(double a)const
{
	return a * a;
}

Rhombus::Rhombus(const Rhombus& R)
{
	this->name = R.name;
	this->a = R.a;
	this->b = R.b;
	this->c = R.c;
	this->d = R.d;
}
Rhombus& Rhombus::operator=(const Rhombus&R)
{
	if (this != &R)
	{
		this->name = R.name;
		this->a = R.a;
		this->b = R.b;
		this->c = R.c;
		this->d = R.d;
	}
	return *this;
}
void Rhombus::show(ostream&os)const
{
	os << name << endl;
	os << "Rhombus=(" << a << ")\n";
}
double Rhombus::S(int a)
{
	return a*a;
}
double Rhombus::P(double a)const
{
	return a*4;
}

void Square::show(ostream&os)const
{
	os << name << endl;
	os << "Square=(" << Rhombus::a << ")\n";
}