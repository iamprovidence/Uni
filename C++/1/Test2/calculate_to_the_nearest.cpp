#include "head.h"

double calculate_to_the_nearest_1(double x, double e)
{
	double result = 0;
	double result_r = 0;
	int k=0;
	
	do
	{
		result += (power(-1,k) * power(x,2*k)) / factorial(2*k);
		k++;
		result_r += (power(-1,k) * power(x,2*k)) / factorial(2*k);
	}while(abs(result_r - result) >= e);

	return result;
}

double calculate_to_the_nearest_2(double x, double e)
{
	double result = 0;
	int k=1;
	
	do
	{
		result = u(x, k) - u(x, k - 1);
		++k;
	}while (abs(result) >= e);

	return result;
}

double u(double x, int k )
{
	double uk;
	if (k == 0)
	{
		return 1;
	}
	else
	{
		uk = ( (x /u(x,k-1)) + u(x,k-1) )/2.;
	}
	return uk;
}