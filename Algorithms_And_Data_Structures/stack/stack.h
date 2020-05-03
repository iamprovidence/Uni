#include <iostream>

using namespace std;

bool stack_test_1();
bool stack_test_2();
bool stack_test_3();

class stack
{
	private:
		int quantity;
		const static int size = 100;
		int array[size];
	public:
		stack();
		~stack();
		void push(int number);
		bool is_empty();
		int pop();
};
