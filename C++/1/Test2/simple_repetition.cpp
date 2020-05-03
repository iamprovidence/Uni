#include "head.h"

double simple_repetition_1(double x, int n)
{
	double result = 0;

	for (int i = 1; i <= n; i++)
	{
		result += power(sin (x),i);
	}

	return result;
}
double simple_repetition_2(double x, int n)
{
	double result = 0;

	for (int i = n+1; i >= 1; i--)
	{
		result += i * power(x,i-1);
	}

	return result;
}
double simple_repetition_3(double x, int n)
{
	double result=0;

	for (int i = 1; i <= n; i++)
	{
		result = sqrt(result + i*3);
	}

	return result;
}
double simple_repetition_4(double x, int n)
{
	double result=0;

	for (int i = n; i >= 2; i--)
	{
		result = 1 / (result + i);
	}

	return result;
}