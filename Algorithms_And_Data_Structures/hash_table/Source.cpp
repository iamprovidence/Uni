#include "Table.h"

void main()
{
	HashTable AbonentBook;

	abonent A("Taras", 380976785886);
	abonent B("Oleg", 380945813486);
	abonent C("Igor", 380505692956);
	abonent D("Ivan", 380676530302);
	abonent E("Olga", 380676530579);
	abonent F("Olga", 380876530579);
	abonent G("Olya", 380676530302);
	abonent H("Olya", 380676533002);

	AbonentBook.push(A);
	AbonentBook.push(B);
	AbonentBook.push(C);
	AbonentBook.push(D);
	AbonentBook.push(E);
	//AbonentBook.push(F);
	AbonentBook.push(G);
	AbonentBook.push(H) ? cout << "yes\n" : cout << "no\n";

	cout << "FIND" << endl;

	AbonentBook.find("Taras",380946785886,false) ? cout << "yes\n" : cout << "no\n";//no
	AbonentBook.find("Taras", 380976785886, false) ? cout << "yes\n" : cout << "no\n";//yes

	cout << "IS_PRESENT" << endl;

	AbonentBook.is_present(A) ? cout << "yes\n" : cout << "no\n";//yes
	AbonentBook.is_present(F) ? cout << "yes\n" : cout << "no\n";//no

	cout << "RECHANGE" << endl;

	AbonentBook.is_present(E) ? cout << "yes\n" : cout << "no\n";//yes
	AbonentBook.is_present(F) ? cout << "yes\n" : cout << "no\n";//no
	AbonentBook.rechange(E, F);
	AbonentBook.is_present(E) ? cout << "yes\n" : cout << "no\n";//no
	AbonentBook.is_present(F) ? cout << "yes\n" : cout << "no\n";//yes

	cout << "REMOVE" << endl;

	AbonentBook.is_present(B) ? cout << "yes\n" : cout << "no\n";//yes
	AbonentBook.remove(B);
	AbonentBook.is_present(B) ? cout << "yes\n" : cout << "no\n";//no

	cout << "PRINT" << endl;

	int s = AbonentBook.print();
	cout << s << endl;

	system("pause");
}