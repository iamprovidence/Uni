#include "sort.h"
//O(n^2)
void bubble_sort(int* array, int size)
{

    for (int i = 1; i <= size; ++i)
    {
        for (int j = 0; j < size - i; ++j)
        {
            if (array[j] > array[j + 1])
            {
                swap(array[j], array[j + 1]);
            }
        }
    }
}