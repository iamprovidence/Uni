#include "stdafx.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace sorttests
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		TEST_METHOD(one_element_buble_sort)
		{
			int b[SIZE] = { 2,2,2,2,2 };
			int a[SIZE] = { 2,2,2,2,2 };
			bubble_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(one_element_quick_sort)
		{
			int b[SIZE] = { 2,2,2,2,2 };
			int a[SIZE] = { 2,2,2,2,2 };
			quick_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(one_element_shell_sort)
		{
			int b[SIZE] = { 2,2,2,2,2 };
			int a[SIZE] = { 2,2,2,2,2 };
			shell_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(ordered_buble_sort)
		{
			int b[SIZE] = { 1,2,3,4,5 };
			int a[SIZE] = { 1,2,3,4,5 };
			bubble_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(ordered_quick_sort)
		{
			int b[SIZE] = { 1,2,3,4,5 };
			int a[SIZE] = { 1,2,3,4,5 };
			quick_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(ordered_shell_sort)
		{
			int b[SIZE] = { 1,2,3,4,5 };
			int a[SIZE] = { 1,2,3,4,5 };
			shell_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}

		TEST_METHOD(reverse_ordered_bubble_sort)
		{
			int b[SIZE] = { 5,4,3,2,1 };
			int a[SIZE] = { 1,2,3,4,5 };
			bubble_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(reverse_ordered_quick_sort)
		{
			int b[SIZE] = { 5,4,3,2,1 };
			int a[SIZE] = { 1,2,3,4,5 };
			quick_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(reverse_ordered_shell_sort)
		{
			int b[SIZE] = { 5,4,3,2,1 };
			int a[SIZE] = { 1,2,3,4,5 };
			shell_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}

		TEST_METHOD(not_ordered_bubble_sort)
		{
			int b[SIZE] = { 2,4,1,5,3 };
			int a[SIZE] = { 1,2,3,4,5 };
			bubble_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(not_ordered_quick_sort)
		{
			int b[SIZE] = { 2,4,1,5,3 };
			int a[SIZE] = { 1,2,3,4,5 };
			quick_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(not_ordered_shell_sort)
		{
			int b[SIZE] = { 2,4,1,5,3 };
			int a[SIZE] = { 1,2,3,4,5 };
			shell_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}


		TEST_METHOD(with_same_elements_bubble_sort)
		{
			int b[SIZE] = { 3,4,1,4,1 };
			int a[SIZE] = { 1,1,3,4,4 };
			bubble_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(with_same_elements_quick_sort)
		{
			int b[SIZE] = { 3,4,1,4,1 };
			int a[SIZE] = { 1,1,3,4,4 };
			quick_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(with_same_elements_shell_sort)
		{
			int b[SIZE] = { 3,4,1,4,1 };
			int a[SIZE] = { 1,1,3,4,4 };
			shell_sort(b, SIZE);
			for (int i = 0; i < SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}

		TEST_METHOD(big_one_bubble_sort)
		{
			int b[BIG_SIZE];
			int a[BIG_SIZE];
			for (int i = 0; i < BIG_SIZE; ++i)
			{
				b[i] = rand();
			}
			bubble_sort(b, BIG_SIZE);
			for (int i = 0; i < BIG_SIZE; ++i)
			{
				a[i] = b[i];
			}

			bubble_sort(b, BIG_SIZE);
			for (int i = 0; i < BIG_SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(big_one_quick_sort)
		{
			int b[BIG_SIZE];
			int a[BIG_SIZE];
			for (int i = 0; i < BIG_SIZE; ++i)
			{
				b[i] = rand();
			}
			quick_sort(b, BIG_SIZE);
			for (int i = 0; i < BIG_SIZE; ++i)
			{
				a[i] = b[i];
			}
			quick_sort(b, BIG_SIZE);
			for (int i = 0; i < BIG_SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}
		TEST_METHOD(big_one_shell_sort)
		{
			int b[BIG_SIZE];
			int a[BIG_SIZE];
			for (int i = 0; i < BIG_SIZE; ++i)
			{
				b[i] = rand();
			}
			shell_sort(b, BIG_SIZE);
			for (int i = 0; i < BIG_SIZE; ++i)
			{
				a[i] = b[i];
			}

			shell_sort(b, BIG_SIZE);
			for (int i = 0; i < BIG_SIZE; ++i)
			{
				Assert::AreEqual(b[i], a[i]);
			}
		}

	};
}