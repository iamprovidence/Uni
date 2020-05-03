#include "infix.h"

void stack::push(double el)
{
	if (quantity < SIZE)
	{
		array[quantity] = el;
		quantity++;
	}
}
void stack::pop()
{
	if (quantity>0)
	{
		--quantity;
	}
}
double stack::peek()
{
	int q = quantity;
	return array[--q];
}
bool stack::is_empty()
{
	return quantity == 0;
}