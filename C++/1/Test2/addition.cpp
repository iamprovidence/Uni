#include "head.h"

double power(double Z, int n)
{
	double P = 1;
	for (int i = 0; i < n; i++)
	{
		P *= Z;
	}
	return P;
}

double factorial(int k)
{
	return(k==0) ? 1:k * factorial(k-1);
}

void print(int A[], int n)
{
	for (int i = 0; i < n; i++)
	{
		cout<< A[i]<<" ";
	}
	cout<<endl;
}