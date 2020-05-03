#ifndef Header_H_
#define Header_H_
#include <iostream>
#include <string>
#include <ctime>

typedef unsigned short int uint;

using std::endl;
using std::cin;
using std::cout;
using std::swap;
using std::string;
using std::ostream;
using std::istream;

struct Node
{
	char letter;
	Node* next;
	Node* previous;

	Node();
	Node(char a, Node *n, Node *p);
};

class better_than_string
{
private:
	int length;
	Node* word;
	Node* the_end;

	int get_array_size(char*A);
	int get_array_size(const char*A);
	Node * find_shorter_way(int i, uint &counter);
public:
	//êîíñòğóêòîğ/äåñòğóêòîğ
	better_than_string();
	better_than_string(char * A);
	better_than_string(const char * A);
	better_than_string operator=(char * A);
	~better_than_string();
	//ïğèñâîºííÿ/êîï³şâàííÿ
	better_than_string(const better_than_string &S);
	better_than_string& operator =(const better_than_string &S);
	//ìåòîäè
	void remove();
	bool is_empty();
	int get_length()const;
	better_than_string substr(int i,int j);
	char* create_array();
	better_than_string& reverse();
	//find
	int find(char A);
	int find(char *A);
	int find(char A, int place);
	int find(char * A, int place);
	//replace
	better_than_string replace(int start_pos, int amount, char *B);
	better_than_string replace(int start_pos, int amount, better_than_string B);

	better_than_string replace(char A, char B);
	better_than_string replace(char A, char B, int place);
	better_than_string replace(char A, char B, bool is_only_some_need, int to);
	better_than_string replace(char A, char B, int place, int to);

	better_than_string replace(char A, char *B);
	better_than_string replace(char A, char *B, int place);
	better_than_string replace(char A, char *B, bool is_only_some_need, int to);
	better_than_string replace(char A, char *B, int place, int to);

	better_than_string replace(char *A, char B);
	better_than_string replace(char *A, char B, int place);
	better_than_string replace(char *A, char B, bool is_only_some_need, int to);
	better_than_string replace(char *A, char B, int place, int to);

	better_than_string replace(char *A, char *B);
	better_than_string replace(char *A, char *B, int place);
	better_than_string replace(char *A, char *B, bool is_only_some_need, int to);
	better_than_string replace(char *A, char *B, int place, int to);
	//îïåğàòîğè
	//äîñòóï
	char &operator[](int n);
	//ïîğ³âíÿííÿ
	bool operator<(const better_than_string &S)const;
	bool operator<=(const better_than_string &S)const;
	bool operator>(const better_than_string &S)const;
	bool operator>=(const better_than_string &S)const;
	bool operator==(const better_than_string &S)const;
	bool operator!=(const better_than_string &S)const;
	//âèâ³ä/ââ³ä
	friend ostream &operator<<(ostream&os, const better_than_string &S);
	friend istream &operator>>(istream&is, better_than_string &S);
	//êîíêàíòåíàö³ÿ
	better_than_string operator+(const better_than_string &S);
	better_than_string operator+=(const better_than_string &S);
	better_than_string operator+=(char A);
	better_than_string operator+(char A);	
	better_than_string operator+=(char *&A);
	better_than_string operator+(char *&A);
	friend better_than_string operator+(char A, const better_than_string &S);
	friend better_than_string operator+(const char *A, const better_than_string &S);
};

struct substitution
{
	char *antecedent;
	char *consequent;
	bool is_terminal;

	substitution()
	{
		antecedent = "";
		consequent = "";
		is_terminal = false;
	}
	substitution(char *a, char *b, bool t)
	{
		antecedent = a;
		consequent = b;
		is_terminal = t;
	}
};

template <class one_of_the_strings>
class MarkovAlgorithm
{
private:
	uint quantity;
	uint amount_setted;
	substitution *origin;
	bool is_set_amount;
	bool is_standart_string;
	one_of_the_strings str;

public:
	MarkovAlgorithm()
	{
		quantity = 0;
		amount_setted = 0;
		origin[quantity];
		is_set_amount = false;
		is_standart_string = false;
		str = "";
	}
	MarkovAlgorithm(one_of_the_strings A)
	{
		quantity = 0;
		amount_setted = 0;
		origin[quantity];
		is_set_amount = false;
		is_standart_string = (typeid(A) == typeid(string) ? true : false);
		str = A;
	}

	MarkovAlgorithm<one_of_the_strings>& set_amount(int n)
	{
		quantity = n;
		amount_setted = n;
		origin = new substitution[quantity];
		is_set_amount = true;
		return *this;
	}
	MarkovAlgorithm<one_of_the_strings>& set_substitution(char*u, char *w)
	{
		if (!is_set_amount)
		{
			throw "ÍÅ ÂÑÒÀÍÎÂËÅÍÎ Ê²ËÜÊ²ÑÒÜ ÏĞÎÄÓÊÖ²É";
		}
		if (!amount_setted)
		{
			throw "ÏÅĞÅÂÈÙÅÍÎ ÄÎÇÂÎËÅÍÓ Ê²ËÜÊ²ÑÒÜ ÏĞÎÄÓÊÖ²É";
		}

		if (amount_setted && is_set_amount)
		{
			substitution A(u, w, false);
			*origin = A;
			++origin;
			--amount_setted;
			return *this;
		}
	}
	MarkovAlgorithm<one_of_the_strings>& set_terminal_substitution(char*u, char *w)
	{
		if (!amount_setted)
		{
			throw "ÏÅĞÅÂÈÙÅÍÎ ÄÎÇÂÎËÅÍÓ Ê²ËÜÊ²ÑÒÜ ÏĞÎÄÓÊÖ²É";
		}
		else if (!is_set_amount)
		{
			throw "ÍÅ ÂÑÒÀÍÎÂËÅÍÎ Ê²ËÜÊ²ÑÒÜ ÏĞÎÄÓÊÖ²É";
		}

		if (amount_setted && is_set_amount)
		{
			substitution A(u, w, true);
			*origin = A;
			++origin;
			--amount_setted;
			return *this;
		}
	}
	one_of_the_strings run()
	{
		for (size_t i = 0; i < quantity; i++)
		{
			origin--;
		}
		int n = 0;
		one_of_the_strings A = str;

		while (n < quantity)
		{
			uint start_pos = 0;
			//ïåğåâ³ğêà ÷è º àíòåöåäåíò 
			bool finded = false;
			if (is_standart_string)
			{
				if (A.find(origin[n].antecedent) != string::npos)
				{
					start_pos = A.find(origin[n].antecedent);
					finded = true;
				}
			}
			else
			{
				if (A.find(origin[n].antecedent) != -1)//(start_pos = (A.find(origin[n].antecedent)) != -1)
				{
					start_pos = A.find(origin[n].antecedent);
					finded = true;
				}
			}

			if (finded)
			{
				if (is_standart_string)
				{
					//ïî÷àòîê ê³ëüê³ñòü ÷èì
					A.replace(start_pos, string(origin[n].antecedent).length(), origin[n].consequent);
				}
				else
				{
					A.replace(start_pos, better_than_string(origin[n].antecedent).get_length(), origin[n].consequent);
				}

				if (origin[n].is_terminal)
				{
					break;
				}
				n = 0;
			}
			else
			{
				++n;
			}
		}
		return A;
	}
};
#endif