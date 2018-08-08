// +
template<int x, int y>
struct Plus
{
	enum { val = Plus<x, y - 1>::val + 1 };
};
template<int x>
struct Plus<x, 0>
{
	enum { val = x };
};

// -
template<int x, int y>
struct Minus
{
	enum { val = Minus<x, y - 1>::val - 1 };
};
template<int x>
struct Minus<x, 0>
{
	enum { val = x };
};

// -. (x - y) (x > y)
template<int x,int y>
struct CMinus
{
	enum { val = x>y? Minus<x,y>::val :0 };
};


// *
template<int x, int y>
struct Mult
{
	enum { val = Plus<Mult<x, y-1>::val, x>::val };
};
template<int x>
struct Mult<x, 0>
{
	enum { val = 0 };
};

// max
template<int x, int y>
struct Max
{
	enum { val = Plus<y,CMinus<x,y>::val>::val };
};

// min
template<int x, int y>
struct Min
{
	enum { val = CMinus<x, CMinus<x, y>::val>::val };
};

// MinusModul
template<int x, int y>
struct MinusModul
{
	enum { val = CMinus<x, y>::val + CMinus<y, x>::val };
};

// !
template<int n>
struct Fact
{
	enum { val = n * Fact<n-1>::val };
};
template<>
struct Fact<0>
{
	enum { val = 1 };
};

