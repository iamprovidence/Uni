#include "Header.h"

set::set()
{
	fullset = 0;
}

set::set(char X)
{
	fullset = transform(X);
}

set::set(const char * X)
{
	fullset = 0;
	for (size_t i = 0; X[i] != '\0'; i++)
	{
		fullset |= transform(X[i]);
	}
}

set::set(__int32 N)
{
	fullset = N;
}

set & set::operator=(set S)
{
	if (this != &S)
	{
		fullset = S.fullset;
	}
	return *this;
}

void set::show(ostream&os)
{
	os << "{ ";
	char letter = 'a';

	for (size_t i = 0; i < 26; i++)
	{
		if (this->is_present(letter))
		{
			os << letter;
			os << ' ';
		}
		++letter;
	}

	os << '}';
}

bool set::is_present(char X) const
{
	return fullset & transform(X);
}

set& set::insert(char X)
{
	fullset |= transform(X);
	return *this;
}

set& set::remove(char X)
{
	fullset &= ~transform(X);
	return *this;
}

set& set::toggle(char X)
{
	fullset ^= transform(X);
	return *this;
}

set set::U(set A, set B)
{
	return set(A.fullset | B.fullset);
}

set set::U(set A)
{
	return *this = U(*this, A);
}

set set::Ï(set A, set B)
{
	return set(A.fullset & B.fullset);
}

set set::Ï(set A)
{
	return *this = Ï(*this, A);
}

set set::l(set A, set B)
{
	return (A.fullset & ~B.fullset);// A && !B
}

set set::l(set A)
{
	return this->l(*this, A);
}

set set::divide(char X)
{
	int n = 1 - ('a' - X);
	char letter = 'a';
	set A;
	
	for (int i = 0; i < n; i++)
	{
		if (this->is_present(letter))
		{
			A.insert(letter);
			this->remove(letter);
		}
		++letter;
	}

	return A;
}

char set::find_the_smallest()const
{
	char letter = 'a';

	for (size_t i = 0; i < 26; i++)
	{
		if (this->is_present(letter))
		{
			return letter;
		}
		++letter;
	}

	return 0;
}

__int32 set::transform(char X) const
{
	if (!__ascii_isalpha(X))
	{
		throw "not allowed";
	}
	else
	{
		X = __ascii_tolower(X);
	}

	return 1 << (X - 'a');
}

ostream & operator<<(ostream & os, set A)
{
	A.show(os);
	return os;
}

bool operator==(set A, set B)
{
	return A.fullset == B.fullset;
}
