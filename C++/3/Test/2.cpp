#include <iostream>
#include <vector>
#include <list>

using namespace std;

template <typename Iter>
void print(Iter begin, Iter end)
{
	while (begin != end)
	{
		cout << *begin++ << ' ';
	}
	cout << endl;
}

bool is_perfect_square(int n)
{
	int c = sqrt(n);
	return (c*c) == n;
}

bool is_fibonacci(int n)
{
	return is_perfect_square(5 * n*n + 4) || is_perfect_square(5 * n*n - 4);
}

int main()
{
	//	1
	vector<int> A{4,8,9,4,2,3,45,6,1,2,3,4,5,6,48,7,546,54,4987,657};
	size_t counter = 0;

	for (const int & N : A)
	{
		if (is_fibonacci(N))
		{
			++counter;
		}
	}
	print(A.begin(), A.end());
	cout << "AMOUNT OF FIBONACCI NUMBER: " << counter << endl;

	cin.get();

	//2
	vector<double> B{ 1.5,2,3,5.5,21,55 };
	vector<double> C{ 2,3,21,55 };
	vector<double> D;
	
	print(B.begin(), B.end());
	print(C.begin(), C.end());
	cout << "ELEMENT IN FIRST VECTOR THAT ARE NOT IN THE SECOND" << endl;
	for (auto i = B.begin(); i != B.end(); ++i)
	{
		auto j = C.begin();
		for (; j != C.end(); ++j)
		{
			if (*j == *i)
			{
				break;
			}
		}
		if (j == C.end())
		{
			D.emplace_back(*i);
			cout << *i << " ";
		}
	}
	cout << endl;
	cout << "SAME BY PRINT" << endl;
	print(D.begin(), D.end()); 

	cin.get();
	//3

	vector<int> E{1,2,3,4,8,465,-5,6,48,465,1,3,-84,48,4,9}, F, G;

	auto find_negative = E.begin();

	while (find_negative != E.end() && *find_negative > 0)
	{
		++find_negative;
	}

	F.assign(E.begin(), find_negative);
	G.assign(find_negative, E.end());

	cout << "DIVIDED BY NEGATIVE" << endl;
	print(E.begin(), E.end());
	print(F.begin(), F.end());
	print(G.begin(), G.end());

	cin.get();

	return 0;
}