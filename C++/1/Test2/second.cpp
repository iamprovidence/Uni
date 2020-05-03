#include "head.h"

void second()
{
	srand( time( 0 ) );
	int n, l;

	cout<<"Input n :\n";
	cin>> n;

	int *A= new int [n];

	ArraysFunction F[9]={function_of_array_1,function_of_array_2,function_of_array_3,
						 function_of_array_4,function_of_array_5,function_of_array_6,
						 function_of_array_7,function_of_array_8,function_of_array_9};

	for (int i = 0; i < n; i++)
	{
		A[i] = -80 + rand() % 120;
	}

	print(A, n);
	do
	{
		cout<<"Input function number l (1-9) :\n";
		cin>> l;
	}while(l<1 || l>9);
	l-=1;

	F[l](A,n);
	
	print(A, n);
}