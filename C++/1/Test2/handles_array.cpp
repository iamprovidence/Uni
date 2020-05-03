#include "head.h"
/*
Знаходить кількість елементів із певними властивостями b. (1-2)
Знаходить значення/місце найбільшого/найменшого елемента c. (3-4)
Перевіряє, чи містить масив певне значення (на якому місці) d. (5)
Перевіряє, чи масив впорядковано e. (6)
Впорядковує масив методом вибору/обміну/вставки (7-9) 
*/

void function_of_array_1(int A[], int n)
{
	cout<<"\The amount of element which divide by two(2) is(are) ";
	int count=0;
	for (int i = 0; i < n; i++)
	{
		if (A[i] % 2 == 0)
		{
			count++;
		}
	}
	cout<<count<<endl;
}
void function_of_array_2(int A[], int n)
{
	cout<<"\nThe amount of positive element is(are) ";
	int count=0;
	for (int i = 0; i < n; i++)
	{
		if (A[i] > 0)
		{
			count++;
		}
	}
	cout<<count<<endl;
}
void function_of_array_3(int A[], int n)
{
	cout<<"\nThe maximal element ";

	int MAX = A[0];
	for (int i = 0; i < n; i++)
	{
		if (MAX <= A[i])
		{
			MAX = A[i];
		}
	}
	cout<<MAX;

	cout<<"\nThe maximal element index is ";

	for (int i = 0; i < n; i++)
	{
		if (MAX==A[i])
		{
			cout<<i;
		}
	}
	cout<<endl;
}
void function_of_array_4(int A[], int n)
{
	cout<<"\nThe minimal element ";

	int MIN = A[0];
	for (int i = 0; i < n; i++)
	{
		if (MIN >= A[i])
		{
			MIN = A[i];
		}
	}
	cout<<MIN;

	cout<<"\nThe minimal element index is ";

	for (int i = 0; i < n; i++)
	{
		if (MIN==A[i])
		{
			cout<<i;
		}
	}
	cout<<endl;
}
void function_of_array_5(int A[], int n)
{
	int find, amount = 0, count = 0;
	cout<<"Input number that you want to show\n";
	cin>>find;

	for (int i = 0; i < n; i++)
	{
		if (A[i]!=find)
		{
			cout<<"There is no "<<find<<" on position " << i <<endl;
			amount++;
		}
		else
		{
			cout<<"There is "<<find<<" on position " << i <<endl;
			count++;
		}
	}
	if (amount==n)
	{
		cout<<"There is no " << find << " at all." <<endl;
	}
	if (count==1)
	{
		cout<<"There is "<< count <<" "<<find<<endl;
	}
	else if (count>1)
	{
		cout<<"There are "<< count <<" "<<find<<endl;
	}
}
void function_of_array_6(int A[], int n)
{
	int stature=0,decrease=0;
	for (int i = 0; i < n-1; i++)
	{
		if (A[i]<=A[i+1])
		{
			stature++;
		}
		if (A[i]>=A[i+1])
		{
			decrease++;
		}
	}
	if (stature==(n-1))
	{
		cout<<"The array is ordered\n";
	}
	else if (decrease==(n-1))
	{
		cout<<"The array is ordered\n";
	}
	else
	{
		cout<<"The array is not ordered\n";
	}
}
void function_of_array_7(int A[], int n)
{
	for (int i = 0; i < n; ++i)
	{
		int k;
		int last = i;
		k = A[i];
		for (int j = i + 1; j < n; ++j)
		{
			if (A[j] < k)
			{
				last = j;
				k = A[j];
			}
		}
		A[last] = A[i];
		A[i] = k;
	}
}
void function_of_array_8(int A[], int n)
{
	int k;
	for (int i = 0; i < n - 1; ++i)
	{
		for (int j = 0; j < n - 1; ++j)
		{
			if (A[j + 1] < A[j])
			{
				k = A[j + 1];
				A[j + 1] = A[j];
				A[j] = k;
			}
		}
	}
}
void function_of_array_9(int A[], int n)
{
    for (int i = 1; i < n; i++)
    {
		int t, index;
        t = A[i];
        index = i-1;
        while(index >= 0 && A[index] > t)
        {
            A[index + 1] = A[index];
            A[index] = t;
            index--;
        }
    }
}