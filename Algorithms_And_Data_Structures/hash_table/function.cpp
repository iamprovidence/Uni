#include "Table.h"

abonent::abonent()
{
	this->name = "";
	this->number = 0;
}
abonent::abonent(string name, long long number)
{
	this->name = name;
	this->number = number;
}
bool operator!=(abonent left, abonent right)
{
	return left.name != right.name && left.number != right.number;
}

HashTable::Node::Node()
{
	data.name = "";
	data.number = 0;
	next = nullptr;
}
HashTable::Node::Node(string name, long long number, Node* next = nullptr)
{
	this->data.name = name;
	this->data.number = number;
	this->next = next;
}

HashTable::HashTable()
{
	for (int i = 0; i < PRIME_SIZE; i++)
	{
		table[i] = nullptr;
	}
}

HashTable::~HashTable()
{
	for (int i = 0; i < PRIME_SIZE; i++)
	{
		delete table[i];
	}
}

int HashTable::hash(abonent current)
{
	int asciisum = 0;
	int sum = 0;
	string name = current.name;
	long long number = current.number;

	for (int i = 0; i < name.length(); i++)
	{
		asciisum += name[i];
	}
	
	while (number > 0)
	{
		sum += number % 10;
		number /= 10;
	}
	sum %= 50;

	asciisum += sum;

	return asciisum % PRIME_SIZE;
}

bool HashTable::push(abonent abonent_push)
{
	int hashNumber = hash(abonent_push);
	Node *add_abonent = new Node(abonent_push.name, abonent_push.number);

	if (table[hashNumber] == nullptr)
	{
		table[hashNumber] = add_abonent;
		return true;
	}
	else if(!is_present(abonent_push))//вставка на початок
	{
		add_abonent->next = table[hashNumber];
		table[hashNumber] = add_abonent;
		return true;
	}
	return false;
}

bool HashTable::remove(abonent abonent_remove)
{
	if (Node * current = find(abonent_remove.name, abonent_remove.number, false))
	{
		if (current->next == nullptr)
		{
			abonent Cur = current->data;
			int hashNumber = hash(Cur);
			delete current;
			table[hashNumber] = nullptr;
			return true;
		}
	}
	if(Node * previous = find(abonent_remove.name, abonent_remove.number,true))
	{
		if(Node * victim = previous->next)
		{ 
			previous->next = victim->next;
			delete victim;
			return true;
		}
		return false;
	}
	else
	{
		return false;
	}
}

bool HashTable::is_present(abonent is_present)
{
	return find(is_present.name, is_present.number,false) ? true : false;
}

bool HashTable::rechange(abonent &find_to_change, abonent change_to)
{
	abonent Change(find_to_change.name, find_to_change.number);
	
	if (remove(Change) && push(change_to))
	{
		return true;
	}
	return false;
}

HashTable::Node* HashTable::find(string name, long long number, bool need_previous = false)
{
	abonent abonent_find(name, number);
	int hashNumber = hash(abonent_find);
	Node *result = table[hashNumber];

	if (!result)
	{
		return false;
	}

	while (result->data != abonent_find)
	{
		if (!result->next)
		{
			return false;
		}
		if (need_previous && !(result->next->data != abonent_find))
		{
			return result;
		}
		result = result->next;
	}
	return result;
}

int HashTable::print()
{
	int counter = 0;
	for (size_t i = 0; i < PRIME_SIZE; i++)
	{
		if (table[i])
		{
			Node * Pick = table[i];
			while (Pick)
			{
				cout << Pick->data.name << ' ' << Pick->data.number << endl;
				++counter;

				if (!Pick->next)
				{
					break;
				}
				
				Pick = Pick->next;
			}
		}
	}
	return counter;
}


void HashTable::doeach(funcptr f)
{
	for (size_t i = 0; i < PRIME_SIZE; i++)
	{
		if (table[i])
		{
			Node * Pick = table[i];
			while (Pick)
			{
				f(Pick->data);

				if (!Pick->next)
				{
					break;
				}

				Pick = Pick->next;
			}
		}
	}
}