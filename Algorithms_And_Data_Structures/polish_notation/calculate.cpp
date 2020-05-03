#include "infix.h"

double calculate(string prefix)
{
	stack ST;
	string s;

	int i = 0;
	while (prefix.length() != 0)
	{
		//якщо перше число відємне + зчитування
		if (!is_operation(prefix[1]) && prefix[0] != ' ' && prefix[i + 1] != ' ')
		{
			i++;
		}
		if(prefix[i + 1] == ' ')//зчитує число до пропуска
		{
			s = prefix.substr(0, i+1);
			ST.push(make_double(s));
			if (is_operation(prefix[i + 2]) && prefix[i + 3] == ' ')//якщо наступний знак
			{
				prefix.erase(0, i + 1);
				i = 0;
			}
			else
			{
				prefix.erase(0, i + 2);
				i = 0;
			}
		}
		else if ( prefix[0] == ' ' && is_operation(prefix[1]) )//якщо знак
		{
			double right = ST.peek(); ST.pop();
			double left = ST.peek(); ST.pop();
			switch (prefix[1])
			{
				case '*':ST.push(left * right); break;
				case '/':ST.push(left / right); break;
				case '+':ST.push(left + right); break;
				case '-':ST.push(left - right); break;
			}
			if (!is_operation(prefix[3]) || ( is_operation(prefix[3]) && prefix[4] != ' ' ) )
			{
				prefix.erase(0, 3);
			}
			else//якщо два знаки підряд
			{
				prefix.erase(0, 2);
			}
		}
	}
	
	return ST.peek();
}