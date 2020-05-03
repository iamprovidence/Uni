#include "stack.h"

stack::stack()
{
	quantity=0;
}

stack::~stack()
{
	cout<<"Bye\n";
}

void stack::push(int number)
{
	array[quantity] = number;
	quantity++;
}

int stack::pop()
{
	array[quantity] = 0;
	quantity--;
	return array[quantity];
}

bool stack::is_empty()
{
	return quantity == 0;
}