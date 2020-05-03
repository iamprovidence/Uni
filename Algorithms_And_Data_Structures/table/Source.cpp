#include "phone_book.h"

void main()
{
	setlocale(0, "");

	Contact A(380976786432, "Petro", "Ivanov", 17, "Lviv"),
			B(380142184621, "Oleg", "Milen", 37, "Lviv"),
			C(380934412840, "Ivan", "Logan", 18, "Kyiv"),
			D,
			E(380986412880, "John", "Lennon", 40, "Liverpool"),
			F(E),
			G(380934412840, "Ringo", "Star", 76, "Dingle");
	F.number = 380976785886;

	const int n = 1000;
	
	Contact list[n] = { A,B,C,D,E,F };
	list[66] = G;

	cout << "Таблиця \" Телефонна книга \"" << endl;
	do
	{
		user_option(list, n);
	} while (true);

}