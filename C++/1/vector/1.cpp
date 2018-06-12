#include <iostream>

using namespace std;

class vector
{
public:
	//����������� �� ������������
	vector()
	{
		mas = 0;
		n = -1;
		//cout<<"��������� ����������� �� �������������\n";
	}
	//����������� � ����������
	vector(int _n)
	{
		//cout<<"��������� ����������� � �����������\n";
		mas = new int[_n];
		for (int i = 0; i < _n; i++)
		{
			mas[i] = 0;
		}
		n = _n;
	}
	void resize(int _n)
	{
		if (_n >= n)
		{
			for (int i = n; i < _n; i++)
			{
				mas[i] = 0;
			}
			n = _n;
		}
		else if (_n>0 && _n<n)
		{
			for (int i = 0; i < _n; i++)
			{
				mas[i] = mas[i];
			}
			n = _n;
		}
	}
	void enter(int _n)
	{
		if (_n != n)
		{
			cout << "����i� ������� ������������\n";
		}
		else
		{
			mas = new int[_n];
			cout << "������i�� ������ ����i��� " << _n << endl;
			for (int i = 0; i < _n; i++)
			{
				cin >> mas[i];
			}
		}
	}
	//����������
	void insert(int v, int ind)
	{
		if (ind<0 || ind >= n)
		{
			return;
		}
		mas[ind] = v;
		//cout<<"��������� ����������� ����������\n";
	}
	//������ / ����� ������� / ������� � ������ �� ������
	void print()
	{
		cout << "������ �� ������\n";
		for (int i = 0; i < n; i++)
		{
			cout << mas[i] << " ";
		}
		cout << endl;
	}
	int getSize()
	{
		cout << "����i� �������\n";
		return n;
	}
	void getElementByIndex(int N)
	{
		if (N <= n - 1 && N >= 0)
		{
			cout << "������� �� i������� " << N << endl;
			cout << mas[N] << endl;
		}
		else
		{
			cout << "����� ������� �� i������� �� �������." << endl;
		}
	}
	//����������� ��������� / ���������
	vector(const vector&v)
	{
		this->n = v.n;
		mas = new int[this->n];
		for (int i = 0; i < n; i++)
		{
			mas[i] = v.mas[i];
		}
		//cout<<"��������� ����������� ���i������\n";
	}
	vector& operator=(const vector&v)
	{
		if (this != &v)
		{
			if (mas != NULL)
			{
				delete[]mas;
				n = v.n;
				mas = new int[n];
				for (int i = 0; i < n; i++)
				{
					mas[i] = v.mas[i];
				}
			}
		}
		return *this;
		//cout<<"��������� ����������� ���������\n";
	}
	//������������ ���������
	vector operator+(const vector&V)
	{
		if (n != V.n)
		{
			cout << "������� �i��� �������\n";
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
		if (n != V.n)
		{
			cout << "������� �i��� �������\n";
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
		if (n != V.n)
		{
			cout << "������� �i��� �������\n";
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
		if (n != V.n)
		{
			cout << "������� �i��� �������\n";
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
		if (n != V.n)
		{
			cout << "������� �i��� �������\n";
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
		if (n != V.n)
		{
			cout << "������� �i��� �������\n";
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
		if (n != V.n)
		{
			cout << "������� �i��� �������\n";
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
		if (n != V.n)
		{
			cout << "������� �i��� �������\n";
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
			s += mas[i];
		}
		return s;
	}

	//����������
	~vector()
	{
		if (mas != NULL)
		{
			delete[] mas;
		}
		//cout<<"��������� ����������\n";
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
		arr = 0;
		size = -1;
		//cout<<"��������� ����������� �� �������������\n";
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
				arr[i][j] = 0;
			}
		}
	}
	//������
	void print()
	{
		cout << "������� �� ������\n";
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				cout << arr[i][j] << " ";
			}
			cout << endl;
		}
		cout << endl;
	}
	void resize(int _n)
	{
		if (_n >= size)
		{
			for (int i = size; i < _n; i++)
			{
				for (int j = size; j < _n; j++)
				{
					arr[i][j] = 0;
				}
			}
			size = _n;
		}
		else if (_n>0 && _n<size)
		{
			for (int i = size; i < _n; i++)
			{
				for (int j = size; j < _n; j++)
				{
					arr[i][j] = arr[i][j];
				}
			}
			size = _n;
		}
	}
	void enter(int _n)
	{
		if (_n != size)
		{
			cout << "����i� ������i ������������\n";
		}
		else
		{
			cout << "������i�� ������� ����i��� " << _n << endl;
			for (int i = 0; i < _n; i++)
			{
				for (int j = 0; j < _n; j++)
				{
					cin >> arr[i][j];
				}
			}
		}
	}
	void insert(int v, int In, int Jn)
	{
		if ((In<0 || In >= size) && (Jn<0 || Jn >= size))
		{
			return;
		}
		arr[In][Jn] = v;
		//cout<<"��������� ����������� ����������\n";
	}
	int getSize()
	{
		cout << "����i� ��������� ������i\n";
		return size;
	}
	void getElementByIndex(int N, int M)
	{
		if ((N <= size - 1 && N >= 0) && (M <= size - 1 && M >= 0))
		{
			cout << "������� �� i�������� " << N << endl;
			cout << arr[N][M] << endl;
		}
		else
		{
			cout << "����� ������� �� i�������� �� �������." << endl;
		}
	}
	void getHorizontalLineByIndex(int N)
	{
		if (N <= size - 1 && N >= 0)
		{
			cout << "����� �� i������� " << N << endl;

			for (int j = 0; j < size; j++)
			{
				cout << arr[N][j] << " ";
			}
			cout << endl;

		}
		else
		{
			cout << "����� ����� �� i������� �� �������." << endl;
		}
	}
	void getVerticalLineByIndex(int N)
	{
		if (N <= size - 1 && N >= 0)
		{
			cout << "����� �� i������� " << N << endl;

			for (int j = 0; j < size; j++)
			{
				cout << arr[j][N] << " ";
			}
			cout << endl;
		}
		else
		{
			cout << "����� ����� �� i������� �� �������." << endl;
		}
	}
	void getDiagonalMain()
	{
		if (size != 0)
		{
			cout << "������� �i�������" << endl;

			for (int j = 0; j < size; j++)
			{
				cout << arr[j][j] << " ";
			}
			cout << endl;

		}
		else
		{
			cout << "����� �i������� �� �������." << endl;
		}
	}
	void getDiagonalSide()
	{
		if (size != 0)
		{
			cout << "���i��� �i�������" << endl;
			for (int i = 0, j = size - 1; j >= 0, i<size; i++, j--)
			{
				cout << arr[i][j] << " ";
			}
			cout << endl;
		}
		else
		{
			cout << "����� �i������� �� �������." << endl;
		}
	}
	int Suma()
	{
		int s;
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				s += arr[i][j];
			}
		}
		return s;
	}
	//���������
	theMatrix(const theMatrix&v)
	{
		this->size = v.size;
		arr = new int*[this->size];
		for (int i = 0; i < size; i++)
		{
			arr[i] = new int[size];
			for (int j = 0; j < size; j++)
			{
				arr[i][j] = v.arr[i][j];
			}
		}
		//cout<<"��������� ����������� ���i������\n";
	}
	theMatrix& operator=(const theMatrix&v)
	{
		if (this != &v)
		{
			if (arr != NULL)
			{
				for (int i = 0; i < size; i++)
				{
					delete[] arr[i];
				}
				delete[] arr;

				size = v.size;
				arr = new int*[size];
				for (int i = 0; i < size; i++)
				{
					arr[i] = new int[size];
					for (int j = 0; j < size; j++)
					{
						arr[i][j] = v.arr[i][j];
					}
				}
			}
		}
		return *this;
		//cout<<"��������� ����������� ���������\n";
	}
	//������������ ���������
	theMatrix operator+(const theMatrix&V)
	{
		if (size != V.size)
		{
			cout << "������i �i���� ����i�i�\n";
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
		if (size != V.size)
		{
			cout << "������i �i���� ����i�i�\n";
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
		if (size != V.size)
		{
			cout << "������i �i���� ����i�i�\n";
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
		if (size != V.size)
		{
			cout << "������i �i���� ����i�i�\n";
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
		if (size != V.size)
		{
			cout << "������i �i���� ����i�i�\n";
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
		if (size != V.size)
		{
			cout << "������i �i���� ����i�i�\n";
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
		theMatrix matrix = T;

		for (int i = 0; i < size; ++i)
		{
			for (int j = i; j < size; ++j)
			{
				T.arr[i][j] = matrix.arr[i][j];
				matrix.arr[i][j] = matrix.arr[j][i];
				matrix.arr[j][i] = T.arr[i][j];
			}
		}
		return matrix;
	}

	~theMatrix()
	{
		for (int i = 0; i < size; i++)
		{
			delete[] arr[i];
		}
		delete[] arr;
		//cout<<"��������� ����������\n";
	}

private:
	int **arr;
	int size;
};

void main()
{
	setlocale(0, "");

	cout << "-------------�������-------------\n";

	vector a(3);
	vector b(4);
	vector c = a;
	vector d;
	cout << "---------------------------------\n";
	a.enter(3);
	c = a;
	a.resize(2);
	a.print();
	cout << "����������" << endl;
	a.insert(10, 2);
	a.getElementByIndex(2);
	cout << "---------------------------------\n";
	a.print();
	b.print();
	c.print();
	d.print();
	cout << "---------------------------------\n";
	cout << "����" << endl;
	(a + c).print();
	c = a;
	cout << "����" << endl;
	(a += c).print();
	cout << "---------------------------------\n";
	c.enter(3);
	cout << "�i�����" << endl;
	(a - c).print();
	cout << "�i�����" << endl;
	(a -= c).print();
	cout << "---------------------------------\n";
	cout << "�������" << endl;
	(a*c).print();
	cout << "�������" << endl;
	(a *= c).print();
	cout << "---------------------------------\n";
	cout << "������� �� �����" << endl;
	(a * 4).print();


	cout << "\n\n-------------�������-------------\n";

	theMatrix A(3);
	theMatrix �(4);
	theMatrix C = A;
	theMatrix D(2);
	cout << "-------------------------------------\n";
	A.print();
	C.print();
	A.enter(3);
	A.print();
	A.getHorizontalLineByIndex(2);
	A.getVerticalLineByIndex(2);
	A.getDiagonalMain();
	A.getDiagonalSide();
	cout << "-------------------------------------\n";
	C = A;
	C.print();
	(A + A).print();
	cout << "������������� �������" << endl;
	A.transposition(A).print();
	cout << "-------------------------------------\n";
	cout << "����" << endl;
	(A + C).print();
	C = A;
	cout << "����" << endl;
	(A += C).print();
	cout << "---------------------------------\n";
	D.enter(2);
	D.print();
	cout << "�i�����" << endl;
	(A - C).print();
	cout << "�i�����" << endl;
	(A -= C).print();
	cout << "---------------------------------\n";
	cout << "�������" << endl;
	(A*C).print();
	cout << "�������" << endl;
	(A *= C).print();
	cout << "---------------------------------\n";
	cout << "������� �� �����" << endl;
	(A * 2).print();
	cout << "���� �� �����" << endl;
	(A + 2).print();

	system("pause");
}