#pragma once
#include <iostream>
#include <string>
class HashTable;
struct abonent;
struct Node;
typedef void(*funcptr)(abonent A);

const int PRIME_SIZE = 500;// використане просте число

using namespace std;

struct abonent // інформація про людину
{
	string name;
	long long number;
	
	abonent();
	abonent(string name, long long number);
	friend bool operator!=(abonent left, abonent right);
};

class HashTable // Хеш-таблиця,масив списків
{
private:
	struct Node
	{
		abonent data;
		Node *next;

		Node();
		Node(string name, long long number, Node* next);
	};
	Node*table[PRIME_SIZE];
	// Хеш-функція
	// рахує сумму ASCII кодів + сума цифр номера
	// і шукає остачу від ділення на константне просте число
public:
	int hash(abonent current);
public:
	HashTable();
	~HashTable();
	// пошук
	Node* find(string name, long long number, bool need_previous);
	// перевірка наявності
	bool is_present(abonent is_present);
	// додавання
	bool push(abonent abonent_push);
	//заміна
	bool rechange(abonent &find_to_change, abonent change_to);
	//вилучення
	bool remove(abonent abonent_remove);
	//перебір
	void doeach(funcptr f);
	int print();
};