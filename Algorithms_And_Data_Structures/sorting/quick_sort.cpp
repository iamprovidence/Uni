#include "sort.h"
//O(n*log n)
void quick_sort(int arr[], int left, int right) 
{
      int i = left, j = right;

      int pivot = arr[(left + right) / 2];

      while (i <= j) {
            while (arr[i] < pivot)
                  i++;
            while (arr[j] > pivot)
                  j--;
            if (i <= j) 
			{
                 swap(arr[i],arr[j]);
                  i++;
                  j--;
            }
      };
 
      /* recursion */
      if (left < j)
            quick_sort(arr, left, j);
      if (i < right)
            quick_sort(arr, i, right);
}