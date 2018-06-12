#include "template_classes.h"
//8 4 10 2 6 9 11 5 7


void main()
{
	cout << "\tADD\tREMOVE\tFIND\tPRINT" << endl;
	LinkedList myList;
	myList.add(8);
	myList.add(4);
	myList.add(10);
	myList.add(2);
	myList.add(6);
	myList.add(9);
	myList.add(11);
	myList.add(5);
	myList.add(7);
	//forEach(myList, make_bigger);
	myList.prettyPrint(cout);
	cout << endl;
	
	myList.remove(8);
	myList.remove(0);
	myList.remove(3);
	myList.remove(2);
	myList.prettyPrint(cout);
	cout << endl;
	


	BinaryTree myTree;
	myTree.add(8);
	myTree.add(4);
	myTree.add(10);
	myTree.add(2);
	myTree.add(6);
	myTree.add(9);
	myTree.add(11);
	myTree.add(5);
	myTree.add(7);

	//forEach(myTree, make_bigger);
	myTree.printPretty(cout);
	cout << endl;

	//myTree.remove(8);
	//myTree.printPretty(cout);
	//cout << endl;

	BinaryTree myTreeNum2;
	myTreeNum2.add(8);
	myTreeNum2.add(8);
	myTreeNum2.add(1);
	myTreeNum2.add(25);
	myTreeNum2.add(16);
	myTreeNum2.add(985);
	myTreeNum2.add(11);
	myTreeNum2.add(4);
	myTreeNum2.add(7);
	//myTreeNum2.printPretty(cout);
	//cout << endl;

	system("pause");
	system("cls");




	cout << "\tCOMPARER" << endl;

	LinkedList myListNum2;
	myListNum2.add(8);
	myListNum2.add(4);
	myListNum2.add(10);
	myListNum2.add(2);
	myListNum2.add(6);
	myListNum2.add(9);
	myListNum2.add(1);
	myListNum2.add(5);
	myListNum2.add(7);

	myList.add(8);
	myList.add(0);
	myList.add(3);
	myList.add(2);

	myTree.add(8);

	cout << "2 Tree - " << (Compare(myTree, myTreeNum2) ? "the same" : "not the same") << endl;
	cout << "2 Tree and List - " << (Compare(myTree, myList) ? "the same" : "not the same") << endl;
	cout << "2 List - " << (Compare(myList, myListNum2) ? "the same" : "not the same") << endl;
	cout << "2 List - " << (Compare(myList, myList) ? "the same" : "not the same") << endl;

	system("pause");
}