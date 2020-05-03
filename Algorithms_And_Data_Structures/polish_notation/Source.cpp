#include "infix.h"

void main()
{
	setlocale(0, "");

	string A = "8.8+5*4-12";
	string B = "-8.4+2+6-3*4/8";
	string C = "3+7-2*4/5";
	string D;
	cout << "¬ведiть вираз: ";
	cin >> D;

	full_polish(D);

	system("pause");
}