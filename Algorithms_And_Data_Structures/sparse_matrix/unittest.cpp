#include "stdafx.h"
#include "CppUnitTest.h"
#include "../sparse_matrix/Header.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace sparse_matrix
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		
		TEST_METHOD(set_get)
		{
			SparseMatrix A(6,9);

			Assert::IsFalse(A.set(6, 0, 1));
			Assert::IsFalse(A.set(4, 9, 1));
			//insert
			Assert::IsTrue(A.set(0, 0, 1));
			Assert::IsTrue(A.set(1, 1, 11));
			Assert::IsTrue(A.set(1, 1, 11));
			Assert::IsTrue(A.set(2, 2, 21));
			Assert::IsTrue(A.set(0, 1, 2));
			Assert::IsTrue(A.set(1, 7, 17));
			Assert::IsTrue(A.set(2, 8, 27));
			Assert::IsTrue(A.set(3, 5, 33));
			Assert::IsTrue(A.set(5, 8, 54));
			Assert::IsTrue(A.set(4, 1, 38));
			Assert::IsTrue(A.set(5, 4, 50));
			Assert::IsTrue(A.set(1, 4, 14));
			Assert::IsTrue(A.set(3, 0, 28));
			Assert::IsTrue(A.set(3, 4, 0));
			Assert::IsTrue(A.set(3, 1, 29));

			//get
			Assert::IsTrue(A.get(0, 1) == 2);
			Assert::IsTrue(A.get(3, 1) == 29);
			Assert::IsTrue(A.get(5, 8) == 54);
			Assert::IsTrue(A.get(3, 5) == 33);
			Assert::IsTrue(A.get(4, 1) == 38);
			Assert::IsTrue(A.get(2, 8) == 27);
			Assert::IsTrue(A.get(1, 4) == 14);
			Assert::IsTrue(A.get(6, 4) == 0);
			Assert::IsTrue(A.get(4, 7) == 0);
			
			//change
			Assert::IsTrue(A.set(1, 4, 14.14));
			Assert::IsTrue(A.set(5, 4, 50.50));
			Assert::IsTrue(A.set(2, 8, 27.27));
			Assert::IsTrue(A.set(2, 2, 21.21));
			Assert::IsTrue(A.set(3, 0, 28.28));

			//get
			Assert::IsTrue(A.get(1, 4) == 14.14 );
			Assert::IsTrue(A.get(5, 9) == 54);
			Assert::IsTrue(A.get(5, 4) == 50.50);
			Assert::IsTrue(A.get(3, 0) == 28.28);

			//remove
			Assert::IsTrue(A.set(1, 1, 0));//11
			Assert::IsTrue(A.set(3, 1, 0));//29
			Assert::IsTrue(A.set(5, 8, 0));//54
			Assert::IsTrue(A.set(1, 7, 0));//17
			Assert::IsTrue(A.set(3, 4, 0));//0
			Assert::IsTrue(A.set(3, 1, 29));//29
			
			//get
			Assert::IsTrue(A.get(1, 1) == 0);
			Assert::IsTrue(A.get(1, 4) == 14);
			Assert::IsTrue(A.get(4, 1) == 38);
			Assert::IsTrue(A.get(3, 4) == 0);
			Assert::IsTrue(A.get(3, 1) == 29);
		}

	};
}