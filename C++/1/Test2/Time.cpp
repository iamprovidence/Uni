#include "head.h"

Time :: Time()
{
	hour = 0;
	min = 0;
	day = 0;
	month = 0; 
	year = 0;
	for (int i = 0; i < 3; i++)
	{
		calendar[i]=0;
	}
}
Time::Time(int h, int m)
{
	hour = h+ m/60;
	min = m % 60;
}
Time::Time(int d, int mn, int y)
{
	day = d % 30;
	month = mn % 12 + d/30;
	year = y + mn/12 + d/30;
	
	calendar[0]=day;
	calendar[1]=month;
	calendar[2]=year;
}