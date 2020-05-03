#include "Header.h"

void main()
{
	SparseMatrix A(3, 4);
	SparseMatrix B(3);
	
	A.set(0, 0, 1);
	A.set(1, 1, 6);
	A.set(1, 2, 7);
	A.set(1, 3, 8);
	A.set(2, 2, 11);
	A.set(2, 3, 12);
	
	SparseMatrix C(A);
	




	cout << C << endl;


	/*
	SparseMatrix R[] = { A,C,B };

	for (size_t i = 0; i < 3; i++)
	{
		cout << R[i] << endl;
	}*/

	//A.set(1, 3, 8);
	//cout << A.get(1, 3);
	//cout << endl;

	//A.print(cout);
	//cout << endl;
	//B.print(cout);
	//cout << endl;
	//C.print(cout);
	//cout << endl;

	//cout << A.get(1, 2);
	//cout << endl;

	//cout << A;

	system("pause");
}