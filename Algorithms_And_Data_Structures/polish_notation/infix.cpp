#include "infix.h"

string prefix(string infix)
{
	stack operation;
	string g;
	int amount_to_delete = 0, startpos = 0;

	while (infix.length() != 0)
	{
		for (int i = 0; i < infix.length(); i++)
		{
			if (infix[i] == '(' )
			{
				operation.push(infix[i]);
				++startpos;
			}
			if (infix[i] == ')' )
			{
				while (operation.peek() != '(')
				{
					g += operation.peek();
					g += ' ';
					operation.pop();
				}
				operation.pop();
				break;
			}

			if (infix[0] == '-' && i == 0)
			{
				continue;
			}
			//якщо число
			while (i != infix.length() && !is_operation(infix[i]) && infix[i] != ')')
			{
				i++;
				amount_to_delete = i;
			}
			//попадають тільки цифри
			startpos == 0 ? g += infix.substr(startpos, amount_to_delete) : g += infix.substr(startpos, amount_to_delete - 1);
			g += ' ';
			startpos = 0;

			if (operation.is_empty() || identify_priority(infix[i]) > identify_priority(operation.peek()))
			{
				operation.push(infix[i]);

				++amount_to_delete;
				break;
			}
			else if (identify_priority(infix[i]) <= identify_priority(operation.peek()) && is_operation(infix[i]))
			{

				while (!operation.is_empty() && identify_priority(infix[i]) <= identify_priority(operation.peek()))
				{
					int s = operation.peek();
					operation.pop();
					g += s;
					g += ' ';
				}
				operation.push(infix[i]);
				++amount_to_delete;
				break;
			}
		}
		infix.erase(startpos, amount_to_delete);
	}

	while (!operation.is_empty())
	{
		int s = operation.peek();
		operation.pop();
		g += s;
		g += ' ';
	}

	return  g;
}