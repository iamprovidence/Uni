#include "stack.h"

bool stack_test_1()
{
	stack stack_test;
	stack_test.push(1);
	stack_test.push(2);
	bool is_correct = stack_test.pop() == 2;
	is_correct = stack_test.pop() == 1;
	return is_correct;
}
bool stack_test_2()
{
	stack stack_test;
	bool is_correct = stack_test.is_empty();
	stack_test.push(1);
	is_correct &= !stack_test.is_empty();
	stack_test.pop();
	is_correct &= stack_test.is_empty();
	return is_correct;
}
bool stack_test_3()
{
	bool is_correct = true;
	stack stack_test;
	is_correct &= stack_test.is_empty();
	return is_correct;
}