#pragma once
#include <iostream>

using std::cout;
using std::endl;
using std::ostream;

class set
{
public:
	set();
	set(char X);
	set(const char* X);
	set(__int32 N);
	set& operator=(set S);
	void show(ostream&os);
	friend ostream& operator<<(ostream&os, set A);
	friend bool operator==(set A, set B);

	bool is_present(char X)const;//перевірити наявність
	set& insert(char X);//вставити
	set& remove(char X);//видалити
	set& toggle(char X);//переключити
	set U(set A, set B);//об'єднання
	set U(set A);
	set П(set A, set B);//перетин
	set П(set A);
	set l(set A, set B);//різниця
	set l(set A);
	set divide(char X);//поділ за елементом
	char find_the_smallest()const;//пошук найменшого
	
private:
	__int32 transform(char X)const;
	__int32 fullset;
	
};

