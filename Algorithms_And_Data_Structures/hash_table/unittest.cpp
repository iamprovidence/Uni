#include "stdafx.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace UnitTest1
{		
	TEST_CLASS(UnitTest1)
	{
	public:
		// HASH
		TEST_METHOD(hash_test)
		{
			HashTable AbonentBook;
			abonent A("Taras", 380976785886);
			int A_hash = AbonentBook.hash(A);
			Assert::IsTrue(A_hash == 32);
		}
		TEST_METHOD(hash_equal)
		{
			HashTable AbonentBook;
			abonent A("Taras", 380976785886);
			abonent B("Taras", 380796785886);
			int A_hash = AbonentBook.hash(A);
			int B_hash = AbonentBook.hash(B);
			Assert::IsTrue(A_hash == B_hash);
		}
		TEST_METHOD(not_equal_hash)
		{
			HashTable AbonentBook;
			abonent A("Oleg", 380976780086);
			abonent B("Taras", 380796785886);
			int A_hash = AbonentBook.hash(A);
			int B_hash = AbonentBook.hash(B);
			Assert::IsTrue(A_hash != B_hash);
		}

		// PUSH
		TEST_METHOD(push_when_no_element)
		{
			HashTable AbonentBook;
			abonent A("Igor", 380976785886);
			Assert::IsTrue(AbonentBook.push(A));
		}
		
		TEST_METHOD(push_another_element)
		{
			HashTable AbonentBook;
			abonent A("Igor", 380976785886);
			abonent B("Petro", 380654400842);
			AbonentBook.push(A);
			Assert::IsTrue(AbonentBook.push(B));
		}
		TEST_METHOD(push_with_same_name)
		{
			HashTable AbonentBook;
			abonent A("Igor", 380876785886);
			abonent B("Igor", 380654400842);
			AbonentBook.push(A);
			Assert::IsTrue(AbonentBook.push(B));
		}
		TEST_METHOD(push_with_same_number)
		{
		HashTable AbonentBook;
		abonent A("Igor", 380876785886);
		abonent B("Pavlo", 380876785886);
		AbonentBook.push(A);
		Assert::IsTrue(AbonentBook.push(B));
		}
		TEST_METHOD(push_existed_element)
		{
			HashTable AbonentBook;
			abonent A("Igor", 380976785886);
			AbonentBook.push(A);
			Assert::IsFalse(AbonentBook.push(A));
		}

		// IS_PRESENT
		TEST_METHOD(is_present_existed_element)
		{
		HashTable AbonentBook;
		abonent A("Igor", 380976785886);
		AbonentBook.push(A);
		Assert::IsTrue(AbonentBook.is_present(A));
		}
		TEST_METHOD(is_present_not_existed_element)
		{
		HashTable AbonentBook;
		abonent A("Igor", 380976785886);
		Assert::IsFalse(AbonentBook.is_present(A));
		}
		TEST_METHOD(is_present_in_a_list)
		{
		HashTable AbonentBook;
		abonent A("Igor", 380976785886);
		abonent B("Igor", 380977856886);
		AbonentBook.push(A);
		AbonentBook.push(B);
		Assert::IsTrue(AbonentBook.is_present(B));
		}

		// FIND
		TEST_METHOD(find_existed_element)
		{
		HashTable AbonentBook;
		abonent A("Igor", 380976785886);
		AbonentBook.push(A);
		Assert::IsTrue(AbonentBook.find("Igor", 380976785886,false));
		}
		TEST_METHOD(find_not_existed_element)
		{
		HashTable AbonentBook;
		abonent A("Igor", 380976785886);
		Assert::IsFalse(AbonentBook.find("Igor", 380976785886, false));
		}
		TEST_METHOD(find_in_a_list)
		{
		HashTable AbonentBook;
		abonent A("Igor", 380976785886);
		abonent B("Igor", 380977856886);
		AbonentBook.push(A);
		AbonentBook.push(B);
		Assert::IsTrue(AbonentBook.find("Igor", 380977856886, false));
		}

		// RECHANGE
		TEST_METHOD(rechange_before_rechange_is_old_exist)
		{
			HashTable AbonentBook;
			abonent A("Igor", 380976785886);
			abonent B("Igor", 380967858286);
			AbonentBook.push(A);
			//AbonentBook.rechange(A, B);
			Assert::IsTrue(AbonentBook.is_present(A));
		}
		TEST_METHOD(rechange_before_rechange_is_new_exist)
		{
			HashTable AbonentBook;
			abonent A("Igor", 380976785886);
			abonent B("Igor", 380967858286);
			AbonentBook.push(A);
			//AbonentBook.rechange(A, B);
			Assert::IsFalse(AbonentBook.is_present(B));
		}
		TEST_METHOD(rechange_is_old_still_exist)
		{
		HashTable AbonentBook;
		abonent A("Igor", 380976785886);
		abonent B("Igor", 380967858286);
		AbonentBook.push(A);
		AbonentBook.rechange(A,B);
		Assert::IsFalse(AbonentBook.is_present(A));
		}
		TEST_METHOD(rechange_is_new_exist)
		{
		HashTable AbonentBook;
		abonent A("Igor", 380976785886);
		abonent B("Igor", 380967858286);
		AbonentBook.push(A);
		AbonentBook.rechange(A, B);
		Assert::IsTrue(AbonentBook.is_present(B));
		}

		// REMOVE
		TEST_METHOD(remove_one)
		{
			HashTable AbonentBook;
			abonent A("Igor", 380976785886);
			AbonentBook.push(A);
			Assert::IsTrue(AbonentBook.remove(A));
		}
		TEST_METHOD(remove_whith_first_when_there_is_second)
		{
		HashTable AbonentBook;
		abonent A("Igor", 380976785886);
		abonent B("Igor", 380977858866);
		AbonentBook.push(A);
		AbonentBook.push(B);
		Assert::IsTrue(AbonentBook.remove(A));
		}
		TEST_METHOD(remove_in_list)
		{
			HashTable AbonentBook;
			abonent A("Igor", 380976785886);
			abonent B("Igor", 380977858866);
			abonent C("Igor", 380978588667);
			AbonentBook.push(A);
			AbonentBook.push(B);
			AbonentBook.push(C);
			Assert::IsTrue(AbonentBook.remove(B));
		}

		// PRINT
		TEST_METHOD(print_when_empty)
		{
		HashTable AbonentBook;
		int amount_of_records = 0;
		Assert::IsTrue(AbonentBook.print() == amount_of_records);
		}
		TEST_METHOD(print_with_few_records)
		{
		HashTable AbonentBook;
		abonent A("Igor", 380976785886);
		abonent B("Taras", 380976785846);
		AbonentBook.push(A);
		AbonentBook.push(B);
		int amount_of_records = 2;
		Assert::IsTrue(AbonentBook.print() == amount_of_records);
		}
		TEST_METHOD(print_with_list_same)
		{
			HashTable AbonentBook;
			abonent A("Igor", 380976785886);
			abonent B("Taras", 380976785846);
			abonent C("Taras", 380976785846);
			AbonentBook.push(A);
			AbonentBook.push(B);
			AbonentBook.push(C);
			int amount_of_records = 3;
			Assert::IsFalse(AbonentBook.print() == amount_of_records);
		}
		TEST_METHOD(print_with_list)
		{
			HashTable AbonentBook;
			abonent A("Igor", 380976785886);
			abonent B("Taras", 380976785846);
			abonent C("Maria", 380745858469);
			AbonentBook.push(A);
			AbonentBook.push(B);
			AbonentBook.push(C);
			int amount_of_records = 3;
			Assert::IsTrue(AbonentBook.print() == amount_of_records);
		}
		TEST_METHOD(test_all)
		{
			HashTable AbonentBook;

			abonent A("Taras", 380976785886);
			abonent B("Oleg", 380945813486);
			abonent C("Igor", 380505692956);
			abonent D("Ivan", 380676530302);
			abonent E("Olga", 380676530579);
			abonent F("Olga", 380876530579);
			abonent G("Olya", 380676530302);

			AbonentBook.push(A);
			AbonentBook.push(B);
			AbonentBook.push(C);
			AbonentBook.push(D);
			AbonentBook.push(E);
			//AbonentBook.push(F);
			AbonentBook.push(G);


			Assert::IsFalse(AbonentBook.find("Taras", 380946785886, false)); 
			Assert::IsTrue(AbonentBook.find("Taras", 380976785886, false));

			//cout << "IS_PRESENT" << endl;

			Assert::IsTrue(AbonentBook.is_present(A)); 
			Assert::IsFalse(AbonentBook.is_present(F)); 

			//cout << "RECHANGE" << endl;

			Assert::IsTrue(AbonentBook.is_present(E));
			Assert::IsFalse(AbonentBook.is_present(F));
			AbonentBook.rechange(E, F);
			Assert::IsFalse(AbonentBook.is_present(E));
			Assert::IsTrue(AbonentBook.is_present(F));

			//cout << "REMOVE" << endl;

			Assert::IsTrue(AbonentBook.is_present(B));
			AbonentBook.remove(B);
			Assert::IsFalse(AbonentBook.is_present(B));

			//cout << "PRINT" << endl;

			int s = AbonentBook.print();

			Assert::IsTrue(s == 5);
		}


	};
}