#include <iostream>

using namespace std;

typedef double(*FunType)(double*, int);
typedef double**(*BFunType)(double **, double**, int);
double **Conv(double ***data, FunType * op, BFunType s, int n, int m, int l);

FunType zaminadiagonali(double **, int);
FunType zaminamaxsumal(double**, int);
BFunType dodavana(double **, double**, int);


void main()
{
	double **A, **B;
	int n, l, m;
	cin >> n >> l >> m;
	A = new double *[n];
	B = new double *[n];
	//масив матриць
	double ***data = new double **[m];
	for (int i = 0; i<m; i++)
	{
		data[i] = new double *[n];
		for (int j = 0; j<n; j++)
		{
			data[i][j] = new double[n];
		}
	}
	//матриц€
	for (int i = 0; i<n; i++)
	{
		A[i] = new double[n];
	}

	for (int i = 0; i<n; i++)
	{
		for (int j = 0; j<n; j++)
		{
			A[i][j] = rand() % 100;
			cout << '\t';
			cout << A[i][j];
		}
		cout << endl;
	}

	for (int i = 0; i<n; i++)
	{
		B[i] = new double[n];
	}

	for (int i = 0; i<n; i++)
	{
		for (int j = 0; j<n; j++)
		{
			B[i][j] = rand() % 100;
			cout << '\t';
			cout << B[i][j];
		}
		cout << endl;
	}


	FunType *op = new FunType[l];






	for (int i = 0; i<n; ++i)
	{
		delete[]A[i];
	}
	delete[]A;

	for (int i = 0; i<n; ++i)
	{
		delete[]B[i];
	}
	delete[]B;


	system("pause");
}

FunType zaminadiagonali(double **A, int n)
{
	double ** C = new double*[n];
	for (int i = 0; i<n; i++)
	{
		C[i] = new double[n];
	}

	for (int i = 0; i<n; i++)
	{
		for (int j = 0; j<n; j++)
		{
			C[i][j] = A[i][j];
		}
	}

	for (int i = 0, j = n - 1; i<n, j >= 0; i++, j--)
	{
		C[i][j] = C[i][i];
	}
}

FunType zaminamaxsumal(double**A, int n)
{
	double max = 0;
	double ** C = new double*[n];
	for (int i = 0; i<n; i++)
	{
		C[i] = new double[n];
	}

	for (int i = 0; i<n; i++)
	{
		for (int j = 0; j<n; j++)
		{
			if (max<A[i][j])
			{
				max = A[i][j];
			}
		}
	}

	for (int i = 0, j = n - 1; i<n, j >= 0; i++, j--)
	{
		C[i][i] = max;
		C[i][j] = max;
	}
}

BFunType dodavana(double **A, double**B, int n)
{
	double ** C = new double*[n];
	for (int i = 0; i<n; i++)
	{
		C[i] = new double[n];
	}


	for (int i = 0; i<n; i++)
	{
		for (int j = 0; j<n; j++)
		{
			C[i][j] = A[i][j];
			C[i][j] += B[i][j];
		}
		C[i][i] += 1;
	}
}