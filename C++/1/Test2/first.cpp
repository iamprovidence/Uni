#include "head.h"

void first()
{
	unsigned int n;
	int s,c,ex;
	double x, e;
	double r,a,b;

	cout<<"Input n, x, e (e>0) :\n";
	cin>> n >> x;
	do
	{
		cin>>e;
	} while (e<=0);

	simple_repetition S[4]={simple_repetition_1,simple_repetition_2,simple_repetition_3,simple_repetition_1};
	calculate_to_the_nearest C[2]={calculate_to_the_nearest_1,calculate_to_the_nearest_2};
	expression E[2]={expression_1, expression_2};

	do
	{
		cout<<"Input Simple Repetition (1-4) :\n";
		cin>>s;
	}while(s<1 || s>4);
	do
	{
		cout<<"Input Calculate to the Nearest (1-2) :\n";
		cin>>c;
	}while (c<1 || c>2);
	do
	{
		cout<<"Input Expression (1-2) :\n";
		cin>>ex;
	}while (ex<1 || ex>2);
	s-=1;c-=1;ex-=1;

	a = S[s](x,n);
	b = C[c](x,e);
	r = E[ex](a,b);
	
	cout<<r<<endl;
}