#include "stdafx.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace string_test
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		
		TEST_METHOD(find)
		{
			//"1"	"1", place
			//"123"		"123",place
			better_than_string A = "abcd";
			//find("1")
			Assert::IsTrue(A.find("a") == 0);
			Assert::IsTrue(A.find('b') == 1);
			Assert::IsTrue(A.find("d") == 3);
			Assert::IsTrue(A.find("v") == -1);

			better_than_string B = "abababa";
			//find("1", place)
			Assert::IsTrue(B.find("a",-1) == 0);
			Assert::IsTrue(B.find("a",25) == 0);
			Assert::IsTrue(B.find("a",0) == 0);
			Assert::IsTrue(B.find('a', 1) == 2);
			Assert::IsTrue(B.find('a',4) == 4);
			Assert::IsTrue(B.find("a", 6) == 6);

			better_than_string C = "abcAbcabzD";
			//find("123")
			Assert::IsTrue(C.find("abc") == 0);
			Assert::IsTrue(C.find("Abc") == 3);
			Assert::IsTrue(C.find("abz") == 6);
			Assert::IsTrue(C.find("zD") == 8);
			Assert::IsTrue(C.find("abcAbcabzD") == 0);
			Assert::IsTrue(C.find("abv") == -1);

			better_than_string D = "abaBabaZaba";
			//find("123", place)
			Assert::IsTrue(D.find("aba", -1) == 0);
			Assert::IsTrue(D.find("aba", 25) == 0);
			Assert::IsTrue(D.find("aba", 0) == 0);
			Assert::IsTrue(D.find("aba", 3) == 4);
			Assert::IsTrue(D.find("abaZ", 4) == 4);
			Assert::IsTrue(D.find("aba", 7) == 8);
			Assert::IsTrue(D.find("aba", 9) == -1);
			Assert::IsTrue(D.find("abaBabaZaba", 0) == 0);
		}

		TEST_METHOD(bool_operator)
		{
			//A == A	A != a	A > a	A > B	a > b	Z > a
			//A != abc	aBc > abA	abc >= abc
			better_than_string A("ABC");
			better_than_string B = "A";
			better_than_string C = "abc";
			better_than_string D = "Abc";
			better_than_string E = "cde";
			better_than_string F = "cDe";
			better_than_string G = "ABC";
			better_than_string H = "Bbc";

			Assert::IsTrue(A == G);
			Assert::IsFalse(A == B);
			Assert::IsTrue(C < D);
			Assert::IsFalse(H <= C);
			Assert::IsTrue(D > H);
			Assert::IsFalse(E > D);
			Assert::IsTrue(C > E);
			Assert::IsFalse(B <= G);
			Assert::IsTrue(F >= E);
			Assert::IsTrue(B != A);
			Assert::IsFalse(A != G);
			Assert::IsTrue(G != C);
			Assert::IsTrue(A >= G);
			Assert::IsFalse(C >= G);
		}

		TEST_METHOD(concatenation)
		{
			//C = A + B; C+=A; 
			//C = A + 'a'; C = 'a' + A;  C+= 'a';
			//C = A + "ab"; C = "ab" + A; C+= "ab";
			better_than_string A = "ABC";
			better_than_string B = "DEF";
			better_than_string C;

			C = A + B;
			Assert::IsTrue(C == "ABCDEF");
			A += C;
			Assert::IsTrue(A == "ABCABCDEF");

			A = "ABC";
			C = A + 'a';
			Assert::IsTrue(C == "ABCa");
			C = 'a' + A;
			Assert::IsTrue(C == "aABC");
			C += 'a';
			Assert::IsTrue(C == "aABCa");

			C = A + "ab";
			Assert::IsTrue(C == "ABCab");
			C = "ab" + A;
			Assert::IsTrue(C == "abABC");
			C += "ab";
			Assert::IsTrue(C == "abABCab");
		}
	};
}