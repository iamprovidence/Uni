#include "infix.h"

void full_polish(string f)
{
	if (f.length() == 1)
	{
		cout<<f;
		return;
	}
	
	cout << f << endl;
	cout << "Польський вираз: " << endl;
	cout << prefix(f) << endl;
	cout << "Результат: " << endl;
	cout << calculate(prefix(f)) << endl;
}

int identify_priority(char p)
{
	switch (p)
	{
		case '+':case '-':return 1;
		case '*':case '/':return 2;
		case '(':case ')':return 0;
	}
}

bool is_operation(char o)
{
	if (o == '+' || o == '-' || o == '*' || o == '/')
	{
		return true;
	}
	else
	{
		return false;
	}
}

double make_double(string s)
{
	double d;
	int i;
	d = atof(s.c_str());
	return d;
}