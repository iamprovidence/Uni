#include <iostream>
using namespace std;

// FIBONACCI
template<int n> 
struct Fib 
{
	enum { val = Fib<n-1>::val + Fib<n-2>::val };
};
template<> struct Fib<1> { enum { val = 1 }; };
template<> struct Fib<0> { enum { val = 1 }; };

// POWER
template<int N, int P> 
struct Power 
{
	enum { val = N * Power<N, P-1>::val };
};
template<int N> 
struct Power<N,0> 
{
	enum { val = 1 }; 
};
// MAX
template<int a, int b> 
struct Max 
{
	enum { val = a>b ? a : b }; 
};
// CONDITION
template<bool cond> struct Select {};

template<> struct Select<false> 
{
	static inline void f() 
	{
		cout << "False statement executing\n";
	}
};
template<> struct Select<true> 
{
	static inline void f() 
	{
		cout << "True statement executing\n";
	}
};
template<bool cond> void execute() 
{
	Select<cond>::f();
}
// SUM FROM TO
template<unsigned current, unsigned goal>
struct adder
{
	unsigned static const sub_goal = (current + goal) / 2;
	unsigned static const tmp = adder<current, sub_goal>::value;
	unsigned static const value = tmp + adder <sub_goal + 1, goal>::value;
};

template<unsigned goal>
struct adder<goal, goal>
{
	unsigned static const value = goal;
};


template<unsigned start>
struct sum_from
{
	template<unsigned goal>
	struct to
	{
		static int const result = adder<start, goal>::value;
	};

};

int main()
{

	cout << "\tF( 5) = " << Fib<5>::val << endl;
	cout << "\tF(35) = " << Fib<35>::val << endl << endl;

	cout << "\t2^5 = " << Power<2,5>::val << endl;
	cout << "\t2^10 = " << Power<2,10>::val << endl << endl;

	cout << "\tmax(10,20) = " << Max<10,20>::val << endl;
	cout << "\tmax(F(10),2^10) = " << Max<Fib<10>::val,Power<2,10>::val>::val << endl << endl;

	cout << "\tif 2>5 then - "; Select<(2>5)>::f(); cout << endl;
	cout << "\tif sizeof(int)=4 then - "; execute<sizeof(int)==4>(); cout << endl << endl;

	cout << "\tS(5-8) = " << sum_from<5>::to<8>::result << endl;
	cout << "\tS(1-128) = " << sum_from<1>::to<128>::result << endl << endl;
	return 0;
}
