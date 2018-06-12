#include <iostream>

using namespace std;

double funct(double x);
double rectangle(double a, double b, double h);
double trapeze(double a, double b, double h);
double parabola(double a, double b, double h, double n);

void main()
{
	setlocale(LC_ALL, "ukr");

	int choice, n;
	double a, b, h, eps;
	double S1, S2, S3, S4;
	bool exit = false;

	cout << "������� ���i i��������:\n";
	cout << "a = ";
	cin >> a;
	cout << "b = ";
	cin >> b;
	cout << "�i���i��� �i��i��i� = ";
	cin >> n;
	cout << "������� ����i��� ������� = ";
	cin >> eps;

	h = (b - a) / n;

	do
	{
		S1 = rectangle(a, b, h);
		S2 = rectangle(a, b, h / 2);
		h /= 2;
	} while (abs(S1 - S2) >= eps);
	h = (b - a) / n;
	do
	{
		S3 = trapeze(a, b, h);
		S4 = trapeze(a, b, h / 2);
		h /= 2;
	} while (abs(S3 - S4) >= eps);
	h = (b - a) / n;
again:
	cout << "�����i�� ����i� ����������:\n"
		<< "1. �����������\n"
		<< "2. ������i�\n"
		<< "3. ��������\n";

	while (!exit)
	{
		cin >> choice;
		switch (choice)
		{
		case 1:cout << S2; break;
		case 2:cout << S4; break;
		case 3:cout << parabola(a, b, h, n); break;
		default: goto again;
		}
		cout << "\n��� ������� ����� ����i�� 0, 1 - ��� ������:";
		cin >> exit;
	}
}

double rectangle(double a, double b, double h)//����� ������������
{
	double S = 0;
	for (double i = a; i < b; i += h)
	{
		S += h*funct(i);
	}
	return S;
}

double trapeze(double a, double b, double h)//����� ��������
{
	double S = 0;
	for (double i = a; i < b; i += h)
	{
		S += ((funct(i) + funct(i + h)) / 2)*h;
	}
	return S;
}

double parabola(double a, double b, double h, double n)//����� �������
{
	double FXk = 0, fxk = 0;
	for (int k = 1; k <= n - 1; k++)
	{
		double xk = a + h * k;
		fxk += funct(xk);
	}

	for (int k = 1; k <= n; k++)
	{
		double xk = a + h * k;
		double xk_1 = a + h * k - h;
		double Xk = (xk + xk_1) / 2;
		FXk += funct(Xk);
	}

	double S;
	S = (h / 3)*(0.5*funct(a) + fxk + 2 * FXk + 0.5*funct(b));
	return S;
}

//������ �������
double funct(double x)
{
	return x;
}