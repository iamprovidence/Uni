#include <iostream>

using namespace std;

const int tria = 3;

struct Point
{
	double x;
	double y;

	Point()
	{
		x = 0;
		y = 0;
	}

	Point(double xco, double yco)
	{
		x = xco;
		y = yco;
	}
	Point& changeX(double X)
	{
		x += X;
		return *this;
	}
	Point& changeY(double Y)
	{
		y += Y;
		return *this;
	}
	Point& changeXandY(double X, double Y)
	{
		x += X;
		y += Y;
		return *this;
	}
	void print()
	{
		cout << x << " ";
		cout << y << endl;
	}
};

class Trianlge
{
public:
	Trianlge()
	{
		top = 0;
		n = -1;
	}
	Trianlge(int n)
	{
		this->n = n;
		top = new int[n];
		for (int i = 0; i < n; ++i)
		{
			top[i] = 0;
		}
	}
	void enter(int _n)
	{
		if (_n != 3)
		{
			cout << "Помилка\n";
		}
		else
		{
			top = new int[_n];
			for (int i = 0; i < _n; i++)
			{
				cin >> top[i];
			}
		}
	}
	Trianlge(const Trianlge&v)
	{
		this->n = v.n;
		top = new int[this->n];
		for (int i = 0; i < n; i++)
		{
			top[i] = v.top[i];
		}
	}
	/*
	void d(double x1, double y1, double x2, double y2, double x3, double y3)
	{
	top = new Point[3];
	Point k1(x1,y1);
	Point k2(x2,y2);
	Point k3(x3,y3);
	}
	void cop(Point k1, Point k2, Point k3)
	{
	top = new Point[3];
	top[0] = k1;
	top[1] = k2;
	top[2] = k3;
	} */
	void print()
	{
		for (int i = 0; i < n; i++)
		{
			cout << top[i] << " ";
		}
		cout << endl;
	}
	Trianlge& operator=(const Trianlge&v)
	{
		if (this != &v)
		{
			if (top != NULL)
			{
				delete[]top;
				n = v.n;
				top = new int[n];
				for (int i = 0; i < n; i++)
				{
					top[i] = v.top[i];
				}
			}
		}
		return *this;
	}
	double square()
	{
		return 0;
	}
	~Trianlge()
	{
		if (top != NULL)
		{
			delete[] top;
		}
	}
private:
	int n;
	int *top;
	//Point *top;
};

void main()
{
	Point coordinates[tria] = { Point(15,12),Point(1,18),Point(5,8) };
	Point A(15, 15);
	A.print();
	A.changeX(12).print();
	A.changeY(3).print();
	A.changeXandY(15, 10).print();
	Trianlge a(4);
	a.enter(3);

	system("pause");
}