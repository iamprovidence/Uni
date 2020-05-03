#include "stack.h"

void main()
{
	bool is_correct = true;

	 stack_test_1();
	 stack_test_2();
	 stack_test_3();

	 is_correct &= stack_test_1();
	 is_correct &= stack_test_2();
	 is_correct &= stack_test_3();
	 cout<<is_correct;

	 system("pause");
}