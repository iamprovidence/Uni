//Кізло Тарас ПМі-14

#include <iostream>

using namespace std;

typedef int**(*FunType)(int,int**);

class vector
{
public:
	//конструктор за замовчуанням
	vector()
	{
		mas=0;
		n=-1;
		//cout<<"Спрацював конструктор за замовчуванням\n";
	}
	//конструктор з парамерами
	vector(int _n)
	{
		//cout<<"Спрацював конструктор з параметрами\n";
		mas=new int[_n];
		for (int i = 0; i < _n; i++)
		{
			mas[i]=0;
		}
		n=_n;
	}
	void resize(int _n)
	{
		if(_n>=n)
		{
			for (int i = n; i < _n; i++)
			{
				mas[i]=0;
			}
			n=_n;
		}
		else if(_n>0 && _n<n)
		{
			for (int i = 0; i < _n; i++)
			{
				mas[i]=mas[i];
			}
			n=_n;
		}
	}
	void enter(int _n)
	{
		if(_n!=n)
		{
			cout<<"Розмiр вектора неправильний\n";
		}
		else
		{
			mas=new int[_n];
			cout<<"Заповнiть вектор розмiром "<<_n<<endl;
			for (int i = 0; i < _n; i++)
			{
				cin>>mas[i];
			}
		}
	}
	//вставлення
	void insert(int v, int ind)
	{
		if(ind<0||ind>=n)
		{
			return;
		}
		mas[ind]=v;
		//cout<<"Спрацював конструктор вставлення\n";
	}
	//вектор / розмір вектора / елемент в векторі по індексі
	void print() 
    {
		cout<<"Вектор має вигляд\n";
		for (int i = 0; i < n; i++)
		{
			cout<<mas[i]<<" ";
		}
		cout<<endl;	
    }
	int getSize()
	{
		cout<<"Розмiр вектора\n";
		return n;
	}
	void getElementByIndex(int N) 
    {
		if(N<=n-1 && N>=0)
		{
			cout<<"Елемент за iндексом "<<N<<endl;
			cout<<mas[N]<<endl;
		}
		else
		{
			cout<<"Взяти елемент за iндексом не вдалось."<<endl;
		}
    }
	//конструктор копіювання / присвоєння
	vector(const vector&v)
	{
		this->n=v.n;
		mas=new int[this->n];
		for (int i = 0; i < n; i++)
		{
			mas[i]=v.mas[i];
		}
		//cout<<"Спрацював конструктор копiювання\n";
	}
	vector& operator=(const vector&v)
	{
		if(this!=&v)
		{
			if(mas!=NULL)
			{
				delete[]mas;
				n=v.n;
				mas= new int[n];
				for (int i = 0; i < n; i++)
				{
					mas[i]=v.mas[i];
				}
			}
		}
		return *this;
		//cout<<"Спрацював конструктор присвоєння\n";
	}
	//перевантажені оператори
	vector operator+(const vector&V)
	{
		if(n!= V.n)
		{
			cout<<"Вектори рiзної довжини\n";
			return 0;
		}
		else
		{
			vector result(n);
			for (int i = 0; i < n; i++)
			{
				result.mas[i] = mas[i] + V.mas[i];
			}
			return result;
		}
	}
	vector operator+=(const vector&V)const
	{
		if(n!= V.n)
		{
			cout<<"Вектори рiзної довжини\n";
			return 0;
		}
		else
		{
			for (int i = 0; i < n; i++) 
			{
				V.mas[i] = mas[i] + V.mas[i];
			}
			return V;
		}
	}
	
	vector operator-(const vector&V)const
	{
		if(n!= V.n)
		{
			cout<<"Вектори рiзної довжини\n";
			return 0;
		}
		else
		{
			vector result(n);
			for (int ix = 0; ix < n; ix++)
			{
				result.mas[ix] = mas[ix] - V.mas[ix];
			}
			return result;
		}
	}
	vector operator-=(const vector&V)const
	{
		if(n!= V.n)
		{
			cout<<"Вектори рiзної довжини\n";
			return 0;
		}
		else
		{
			for (int i = 0; i < n; i++) 
			{
				V.mas[i] = mas[i] - V.mas[i];
			}
			return V;
		}
	}
	
	vector operator*(const vector&V)const
	{
		if(n!= V.n)
		{
			cout<<"Вектори рiзної довжини\n";
			return 0;
		}
		else
		{
			vector result(n);
			for (int ix = 0; ix < n; ix++)
			{
				result.mas[ix] = mas[ix] * V.mas[ix];
			}
			return result;
		}
	}
	vector operator*=(const vector&V)const
	{
		if(n!= V.n)
		{
			cout<<"Вектори рiзної довжини\n";
			return 0;
		}
		else
		{
			for (int i = 0; i < n; i++) 
			{
				V.mas[i] = mas[i] * V.mas[i];
			}
			return V;
		}
	}

	vector operator*(int d)const
	{
		vector result(n);
		for (int ix = 0; ix < n; ix++)
		{
			result.mas[ix] = mas[ix] * d;
		}
		return result;
	}

	vector operator/(const vector&V)const
	{
		if(n!= V.n)
		{
			cout<<"Вектори рiзної довжини\n";
			return 0;
		}
		else
		{
			vector result(n);
			for (int ix = 0; ix < n; ix++)
			{
				result.mas[ix] = mas[ix] / V.mas[ix];
			}
			return result;
		}
	}
	vector operator/=(const vector&V)const
	{
		if(n!= V.n)
		{
			cout<<"Вектори рiзної довжини\n";
			return 0;
		}
		else
		{
			for (int i = 0; i < n; i++) 
			{
				V.mas[i] = mas[i] / V.mas[i];
			}
			return V;
		}
	}

	vector operator/(int d)const
	{
		vector result(n);
		for (int ix = 0; ix < n; ix++)
		{
			result.mas[ix] = mas[ix] / d;
		}
		return result;
	}	

	int Suma(const vector&V)const
	{
		int s;
		for (int i = 0; i < n; i++)
		{
			 s+=mas[i];
		}
		return s;
	}

	//деструктор
	~vector()
	{
		if(mas!=NULL)
		{
			delete[] mas;
		}
		//cout<<"Спрацював деструктор\n";
	}

private:
	int *mas;
	int n;
};

class theMatrix
{
public:
	theMatrix()
	{
		arr=0;
		size=-1;
		//cout<<"Спрацював конструктор за замовчуванням\n";
	}

	theMatrix(int n)
	{
		size = n;
		arr = new int*[n];
		for (int i = 0; i < n; ++i)
		{
			arr[i] = new int[n];
			for (int j = 0; j < n; ++j)
			{
				arr[i][j]=0;
			}
		}	
	}
	//методи
	void print() 
    {
		cout<<"Матриця має вигляд\n";
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				cout<<arr[i][j]<<" ";
			}
			cout<<endl;
		}
		cout<<endl;	
    }
	void resize(int _n)
	{
		if(_n>=size)
		{
			for (int i = size; i < _n; i++)
			{
				for (int j = size; j < _n; j++)
				{
					arr[i][j]=0;
				}
			}
			size=_n;
		}
		else if(_n>0 && _n<size)
		{
			for (int i = size; i < _n; i++)
			{
				for (int j = size; j < _n; j++)
				{
					arr[i][j]=arr[i][j];
				}
			}
			size=_n;
		}
	}
	void enter(int _n)
	{
		if(_n!=size)
		{
			cout<<"Розмiр матрицi неправильний\n";
		}
		else
		{
			cout<<"Заповнiть матрицю розмiром "<<_n<<endl;
			for (int i = 0; i < _n; i++)
			{
				for (int j = 0; j < _n; j++)
				{
					cin>>arr[i][j];
				}
			}
		}
	}
	void insert(int v, int In, int Jn)
	{
		if((In<0 || In>=size) && (Jn<0 || Jn>=size))
		{
			return;
		}
		arr[In][Jn]=v;
		//cout<<"Спрацював конструктор вставлення\n";
	}
	int getSize()
	{
		cout<<"Розмiр квадратної матрицi\n";
		return size;
	}
	void getElementByIndex(int N, int M) 
    {
		if((N<=size-1 && N>=0) && (M<=size-1 && M>=0))
		{
			cout<<"Елемент за iндексами "<<N<<endl;
			cout<<arr[N][M]<<endl;
		}
		else
		{
			cout<<"Взяти елемент за iндексами не вдалось."<<endl;
		}
    }
	void getHorizontalLineByIndex(int N) 
	{
		if(N<=size-1 && N>=0)
		{
			cout<<"Рядок за iндексом "<<N<<endl;

				for (int j = 0; j < size; j++)
				{
					cout<<arr[N][j]<<" ";
				}
				cout<<endl;
			
		}
		else
		{
			cout<<"Взяти рядок за iндексом не вдалось."<<endl;
		}
    }
	void getVerticalLineByIndex(int N) 
	{
		if(N<=size-1 && N>=0)
		{
			cout<<"Рядок за iндексом "<<N<<endl;

				for (int j = 0; j < size; j++)
				{
					cout<<arr[j][N]<<" ";
				}
				cout<<endl;	
		}
		else
		{
			cout<<"Взяти рядок за iндексом не вдалось."<<endl;
		}
    }
	void getDiagonalMain()
	{
		if(size!=0)
		{
			cout<<"Головна дiагональ"<<endl;

				for (int j = 0; j < size; j++)
				{
					cout<<arr[j][j]<<" ";
				}
				cout<<endl;
			
		}
		else
		{
			cout<<"Взяти дiагональ не вдалось."<<endl;
		}
	}
	void getDiagonalSide()
	{
		if(size!=0)
		{
			cout<<"Побiчна дiагональ"<<endl;
			for(int i= 0, j = size - 1;j >= 0, i<size;i++,j--)
			{
				cout<<arr[i][j]<<" ";	
			}
			cout<<endl;
		}
		else
		{
			cout<<"Взяти дiагональ не вдалось."<<endl;
		}
	}
	int Suma()
	{
		int s;
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				s+=arr[i][j];
			}
		}
		return s;
	}
	//копіювання
	theMatrix(const theMatrix&v)
	{
		this->size=v.size;
		arr=new int*[this->size];
		for (int i = 0; i < size; i++)
		{
			arr[i]= new int [size];
			for (int j = 0; j < size;j++)
			{
				arr[i][j]=v.arr[i][j];
			}
		}
		//cout<<"Спрацював конструктор копiювання\n";
	}
	theMatrix& operator=(const theMatrix&v)
	{
		if(this!=&v)
		{
			if(arr!=NULL)
			{
				for (int i = 0; i < size; i++)
				{
					delete[] arr[i];
				}
				delete[] arr;
				
				size=v.size;
				arr= new int*[size];
				for (int i = 0; i < size; i++)
				{
					arr[i]= new int [size];
					for (int j = 0; j < size;j++)
					{
						arr[i][j]=v.arr[i][j];
					}
				}
			}
		}
		return *this;
		//cout<<"Спрацював конструктор присвоєння\n";
	}
	//перевантажені оператори
	theMatrix operator+(const theMatrix&V)
	{
		if(size!= V.size)
		{
			cout<<"Матрицi рiзних розмiрiв\n";
			return 0;
		}
		else
		{
			theMatrix result(size);
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					result.arr[i][j] = arr[i][j] + V.arr[i][j];
				}
			}
			return result;
		}
	}
	theMatrix operator+=(const theMatrix&V)const
	{
		if(size!= V.size)
		{
			cout<<"Матрицi рiзних розмiрiв\n";
			return 0;
		}
		else
		{
			for (int i = 0; i < size; i++) 
			{
				for (int j = 0; j < size; j++)
				{
					V.arr[i][j] = arr[i][j] + V.arr[i][j];
				}	
			}
			return V;
		}
	}	
	theMatrix operator-(const theMatrix&V)
	{
		if(size!= V.size)
		{
			cout<<"Матрицi рiзних розмiрiв\n";
			return 0;
		}
		else
		{
			theMatrix result(size);
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					result.arr[i][j] = arr[i][j] - V.arr[i][j];
				}
			}
			return result;
		}
	}
	theMatrix operator-=(const theMatrix&V)const
	{
		if(size!= V.size)
		{
			cout<<"Матрицi рiзних розмiрiв\n";
			return 0;
		}
		else
		{
			for (int i = 0; i < size; i++) 
			{
				for (int j = 0; j < size; j++)
				{
					V.arr[i][j] = arr[i][j] - V.arr[i][j];
				}	
			}
			return V;
		}
	}
	theMatrix operator*(const theMatrix&V)
	{
		if(size!= V.size)
		{
			cout<<"Матрицi рiзних розмiрiв\n";
			return 0;
		}
		else
		{
			theMatrix result(size);
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					result.arr[i][j] += arr[i][j] * V.arr[j][i];
				}
			}
			return result;
		}
	}
	theMatrix operator*=(const theMatrix&V)const
	{
		if(size!= V.size)
		{
			cout<<"Матрицi рiзних розмiрiв\n";
			return 0;
		}
		else
		{
			for (int i = 0; i < size; i++) 
			{
				for (int j = 0; j < size; j++)
				{
					V.arr[i][j] += arr[i][j] * V.arr[j][i];
				}	
			}
			return V;
		}
	}
	theMatrix operator*(int d)
	{
		theMatrix result(size);
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				result.arr[i][j] = arr[i][j] * d;
			}
		}
		return result;
	}
	theMatrix operator+(int d)
	{
		theMatrix result(size);
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				result.arr[i][j] = arr[i][j];
				result.arr[i][i] = arr[i][i] + d;
			}
		}
		return result;
	}	
	theMatrix transposition(const theMatrix&T)
		{
			theMatrix matrix=T;

			for(int i = 0; i < size; ++i)
			{
				for(int j = i; j < size; ++j)
				{
					T.arr[i][j] = matrix.arr[i][j];
					matrix.arr[i][j] = matrix.arr[j][i];
					matrix.arr[j][i] = T.arr[i][j];
				}
			}
			return matrix;
		}

	theMatrix modufication(int l,FunType* op)
	{
		for (int i = 0; i < l; i++)
		{
			op[i](size,arr);
		}
		return 0;
	}

	~theMatrix()
	{
		for (int i = 0; i < size; i++)
		{
			delete[] arr[i];
		}
		delete[] arr;
		//cout<<"Спрацював деструктор\n";
	}
		
private:
	int **arr;
	int size;
};

	int** mod_1(int size, int **arr)
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				arr[i][j] *= 20;
			}
		}
		return arr;
	}
	int** mod_2(int size, int **arr)
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				 arr[i][j] += 20;
			}
		}
		return arr;
	}
	int** mod_3(int size, int **arr)
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				arr[i][j] -= 20;
			}
		}
		return arr;
	}

void main()
{
	setlocale(0,"");
	FunType op[3]={mod_1,mod_2,mod_3};

	cout<<"-------------Вектори-------------\n";

	vector a(3);
	vector b(4);
	vector c=a;
	vector d;
	cout<<"---------------------------------\n";
	a.enter(3);
	c=a;
	a.resize(2);
	a.print();
	cout<<"Вставлення"<<endl;
	a.insert(10,2);
	a.getElementByIndex(2);
	cout<<"---------------------------------\n";
	a.print();
	b.print();
	c.print();
	d.print();
	cout<<"---------------------------------\n";
	cout<<"Сума"<<endl;
	(a+c).print();
	c=a;
	cout<<"Сума"<<endl;
	(a+=c).print();
	cout<<"---------------------------------\n";
	c.enter(3);
	cout<<"Рiзниця"<<endl;
	(a-c).print();
	cout<<"Рiзниця"<<endl;
	(a-=c).print();
	cout<<"---------------------------------\n";
	cout<<"Добуток"<<endl;
	(a*c).print();
	cout<<"Добуток"<<endl;
	(a*=c).print();
	cout<<"---------------------------------\n";
	cout<<"Добуток на число"<<endl;
	(a*4).print();

	cout<<"\n\n-------------Матриця-------------\n";

	theMatrix A(3);
	theMatrix В(4);
	theMatrix C=A;
	theMatrix D(2);
	cout<<"---------------------------------\n";
	A.print();
	C.print();
	A.enter(3);
	A.print();
	A.getHorizontalLineByIndex(2);
	A.getVerticalLineByIndex(2);
	A.getDiagonalMain();
	A.getDiagonalSide();
	cout<<"---------------------------------\n";
	C=A;
	C.print();
	(A+A).print();
	cout<<"Транспонована матриця"<<endl;
	A.transposition(A).print();
	cout<<"---------------------------------\n";
	cout<<"Сума"<<endl;
	(A+C).print();
	C=A;
	cout<<"Сума"<<endl;
	(A+=C).print();
	cout<<"---------------------------------\n";
	D.enter(2);
	D.print();
	cout<<"Рiзниця"<<endl;
	(A-C).print();
	cout<<"Рiзниця"<<endl;
	(A-=C).print();
	cout<<"---------------------------------\n";
	cout<<"Добуток"<<endl;
	(A*C).print();
	cout<<"Добуток"<<endl;
	(A*=C).print();
	cout<<"---------------------------------\n";
	cout<<"Добуток на число"<<endl;
	(A*2).print();
	cout<<"Сума на число"<<endl;
	(A+2).print();
	cout<<"---------------------------------\n";
	cout<<"Операцiя з масиву функцiй"<<endl;
	A.modufication(2,op);
	A.print();

	system("pause");
}
