#include "stdafx.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest1
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		
		TEST_METHOD(is_stack_empty_from_a_start)
		{
			stack ST;

			Assert::IsTrue(ST.is_empty());
		}

		TEST_METHOD(is_push_work)
		{
			stack ST;
			ST.push(2);

			Assert::IsFalse(ST.is_empty());
		}

		TEST_METHOD(is_pop_work)
		{
			stack ST;
			ST.push(1);
			ST.push(2);
			ST.pop();
			ST.pop();

			Assert::IsTrue(ST.is_empty());
		}

		TEST_METHOD(is_peek_work)
		{
			stack ST;
			ST.push(8);
			int a = ST.peek();

			Assert::IsTrue(a == 8);
		}

		TEST_METHOD(is_test_empty_work)
		{
			bool is_correct;
			stack ST;

			is_correct = ST.is_empty();
			ST.push(1);
			is_correct &= !ST.is_empty();
			ST.pop();
			is_correct &= ST.is_empty();

			Assert::IsTrue(ST.is_empty());
		}

		TEST_METHOD(is_allmethod_work)
		{
			bool is_correct;
			stack ST;

			is_correct = ST.is_empty();
			ST.push(5);
			ST.push(80);
			is_correct &= !ST.is_empty();
			is_correct &= (ST.peek() == 80);
			ST.pop();
			is_correct &= (ST.peek() == 5);
			ST.pop();
			is_correct &= ST.is_empty();

			Assert::IsTrue(is_correct);
		}

		TEST_METHOD(simple_prefix)
		{
			string A = "3+2";
			string B = "3 2 + ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}

		TEST_METHOD(complex_prefix)
		{

			string A = "3+2-4";
			string B = "3 2 + 4 - ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}

		TEST_METHOD(prefix_start_with_minus)
		{

			string A = "-3+2";;
			string B = "-3 2 + ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}

		TEST_METHOD(prefix_with_minus)
		{
			string A = "3/-2";;
			string B = "3 -2 / ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}

		TEST_METHOD(prefix_with_multi_in_the_start)
		{

			string A = "3*2+4";
			string B = "3 2 * 4 + ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}
		
		TEST_METHOD(prefix_with_multi_in_the_end)
		{

			string A = "3+2*4";
			string B = "3 2 4 * + ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}

		TEST_METHOD(prefix_from_lecture)
		{
			string A = "3+7-2*4/5";
			string B = "3 7 + 2 4 * 5 / - ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}

		TEST_METHOD(simple_prefix_with_brackets)
		{
			string A = "(3+2)*4";
			string B = "3 2 + 4 * ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}

		TEST_METHOD(another_simple_prefix_with_brackets)
		{
			string A = "3+(2*4)";
			string B = "3 2 4 * + ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}

		TEST_METHOD(prefix_with_brackets)
		{
			string A = "3+2*(4+3)";
			string B = "3 2 4 3 + * + ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}

		TEST_METHOD(prefix_with_brackets_and_minus)
		{
			string A = "3*4+(-5+2)";
			string B = "3 4 * -5 2 + - ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}

		TEST_METHOD(prefix_with_difficult_brackets)
		{
			string A = "3*4+(8-5/2+2+9*3)";
			string B = "3 4 * 8 5 2 / - 2 + 9 3 * + + ";
			A = prefix(A);
			bool test = A == B;

			Assert::IsTrue(test);
		}

		TEST_METHOD(calculate_prefix_from_lecture)
		{
			string A = "3 7 + 2 4 * 5 / - ";
			double B;
			B = calculate(A);
			bool test = B == 8.4;

			Assert::IsTrue(test);
		}

		TEST_METHOD(calculate_prefix_with_multi_in_the_end)
		{
			string A = "3 2 4 * + ";
			double B;
			B = calculate(A);
			bool test = B == 11;

			Assert::IsTrue(test);
		}
		TEST_METHOD(calculate_prefix_start_with_minus)
		{

			string A = "-3 2 + ";
			double B;
			B = calculate(A);
			bool test = B == -1;

			Assert::IsTrue(test);
		}

		TEST_METHOD(calculate_prefix_with_float)
		{

			string A = "3.5 2 + ";
			double B;
			B = calculate(A);
			bool test = B == 5.5;

			Assert::IsTrue(test);
		}

		TEST_METHOD(calculate_prefix_with_minus)
		{
			string A = "3 -2 / ";
			double B;
			B = calculate(A);
			bool test = B == -1.5;

			Assert::IsTrue(test);
		}
	};
}