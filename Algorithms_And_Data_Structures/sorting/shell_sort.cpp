#include "sort.h"
//O(n*log2 n)
void sort_shell(int *a,int N)
{
	for(int d=N/2; d >= 1; d/=2)
	{
		for(int i=d; i < N; i++)
		{
			for(int j = i; j>=d && a[j - d] > a[j]; j -= d)
			{
				swap(a[j], a[j-d]);
			}
		}
	}
 }