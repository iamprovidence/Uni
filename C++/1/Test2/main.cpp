#include "head.h"

void main()
{
	int n;
	again:
	cout<<"Show solution (1-3) ";
	cin>>n;

	switch (n)
	{
		case 1 :first();break;
		case 2 :second();break;
		case 3 :third();break;
		default: goto again;break;
	}

	system("pause");
}