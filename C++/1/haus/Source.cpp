#include <iostream>
#include <stdlib.h>
#include <time.h>

using namespace std;

void display_equation(int n, int m, double **R);
void theMatrix(int n, int m, double **M);
void permutation(double **P, int n, int k, int maxI);
void null(int n, double **ZeroCondition);
void maximal_element(int n, int k, int m, double max, double **Max);
void deduct_rows(double **V, int m, int r1, int r2);
void normalize(double **L, int n, int m, int k, double index);
void answer(int n, double **xx);
double enterS(int n, int m, double **entS);
double enterR(int n, int m, double **entR);


int main()
{
	setlocale(LC_ALL, "Ukr");

	int n, m, k = 0, P = 0;
	double max = 0, index = 0;

	cout << "\t\tПокроковий алгоритм Гаусса\n";
	cout << "Введiть число рiвнянь: ";
	cin >> n;
	cout << "Введiть число невiдомих: ";
	cin >> m;

	if (n>0 && m>0 && n == m)
	{
		m += 1;
		double *X = new double[m];
		double **matrix = new double *[n];
		for (int i = 0; i<n; i++)
		{
			matrix[i] = new double[m];
		}
		cin.get();
		//вести масив
		int a;
	again:
		cout << "Виберiть спосiб вводу данних:\n"
			<< "Для ручного вводу нажмiть : 1\n"
			<< "Для автоматичного вводу нажмiть : 2\n";
		cin >> a;
		if (a != 1 && a != 2)
		{
			cout << "Спробуйте ще раз\n";
			goto again;
		}
		if (a == 1)
		{
			enterS(n, m, matrix);
			cin.get();
		}
		else
			if (a == 2)
			{
				enterR(n, m, matrix);
				cin.get();
			}
		cin.get();
		display_equation(n, m, matrix);
		theMatrix(n, m, matrix);
		null(n, matrix);
		//алгоритм Гаусса
		do
		{
			maximal_element(n, k, m, max, matrix);
			theMatrix(n, m, matrix);
			normalize(matrix, n, m, k, index);
			theMatrix(n, m, matrix);
			cout << "Вираховуємо найвищий рядок рiвняння iз наступних\n\n";
			cin.get();
			for (int k = P + 1; k < n; k++)
			{
				deduct_rows(matrix, n, k, P);
			}
			theMatrix(n, m, matrix);
			P++;
			k++;
		} while (k<m - 1 || P < n - 1);
		answer(n, matrix);
	}
	else
	{
		if (n <= 0 || m <= 0)
		{
			cout << "\n\t\tTакого рiвняння не iснує.\n";
		}
		else
		{
			if (m != n)
			{
				cout << "\n\t\tРiшення отримати неможливо.\n";
			}
		}
	}
	system("pause");
}

//вивід рівняння
void display_equation(int n, int m, double **R)
{
	cout << "\nРiвняння має вигляд:\n\n";
	for (int i = 0; i<n; ++i)
	{
		for (int j = 0; j<m - 1; ++j)
		{
			cout << R[i][j] << " * " << "X [" << j + 1 << "]";
			if (j<m - 2)
			{
				cout << " + ";
			}
		}
		for (int j = m - 1; j<m; ++j)
		{
			cout << " = " << R[i][j];
		}
		cout << endl;
	}
	cout << endl;
	cin.get();
}
//вивід матриці
void theMatrix(int n, int m, double **M)
{
	cout << "Матриця має вигляд:\n\n";
	cout.precision(4);
	for (int i = 0; i<n; ++i)
	{
		for (int j = 0; j<m - 1; ++j)
		{
			cout << M[i][j] << " ";
		}
		for (int j = 0; j<1; ++j)
		{
			cout << "\tХ [" << i + 1 << "]";
		}
		for (int j = m - 1; j<m; ++j)
		{
			cout << "\t" << M[i][j];
		}
		cout << endl;
	}
	cin.get();
}
//перестановка
void permutation(double **P, int n, int k, int maxI)
{
	double *temp = new double[n];
	for (int i = k; i<n + 1; i++)
	{
		for (int j = k; j<k + 1; ++j)
		{
			temp[i] = P[j][i];
			P[j][i] = P[maxI][i];
			P[maxI][i] = temp[i];
		}
	}
}
//пошук нуля
void null(int n, double **ZeroCondition)
{
	int findZero = 0;
	for (int zero = 0; zero<n; zero++)
	{
		//cтовпчики
		for (int j = zero; j<n; j++)
		{
			for (int i = 0; i<n; ++i)
			{
				if (ZeroCondition[i][j] == 0)
				{
					findZero++;
					if (findZero >= n)
					{
						cout << "\n\t\tРiшення отримати неможливо.\n";
						system("pause");
						exit(1);
					}
				}
			}
			findZero = 0;
		}
		//рядки
		for (int i = 0; i<n; ++i)
		{
			for (int j = zero; j<n; j++)
			{
				if (ZeroCondition[i][j] == 0)
				{
					findZero++;
					if (findZero >= n)
					{
						cout << "\n\t\tРiшення отримати неможливо.\n";
						system("pause");
						exit(1);
					}
				}
			}
			findZero = 0;
		}
	}
}
//пошук максимального
void maximal_element(int n, int k, int m, double max, double **Max)
{
	int N = 0;
	int max_i = 0;
	cout << "Вибираємо рядок з максимальним елементом Ai i мiняємо його з попереднiм.\n\n";
	for (int i = k; i<n; i++)
	{
		for (int j = k; j<k + 1; ++j)
		{
			if (Max[i][j] > max)
			{
				max = Max[i][j];
				max_i = i;
			}
		}
	}
	for (int i = 0; i<k + 1; i++)
	{
		N++;
	}
	cout << "Максимальний елемент " << N << " стовпчика: " << max << endl;
	max = 0;
	cin.get();
	permutation(Max, n, k, max_i);
}
//віднімання
void deduct_rows(double **V, int m, int r1, int r2)
{
	for (int i = 0; i<m + 1; ++i)
	{
		if (r1 == r2)
		{
			continue;
		}
		else
		{
			V[r1][i] = V[r1][i] - V[r2][i];
		}
	}
}
//нормування
void normalize(double **L, int n, int m, int k, double index)
{
	for (int i = k; i<n; i++)
	{
		for (int j = k; j<k + 1; ++j)
		{

			index = L[i][j];

		}
		for (int j = k; j<m; j++)
		{
			if (L[i][j] == k) continue;
			else L[i][j] /= index;
		}
	}
	cout << "Нормуємо кожне рiвняння вiдносно коефiцiєнта при Xi\n";
	cin.get();
}
//вивід відповіді
void answer(int n, double **xx)
{
	double s = 0, d;
	double *x = new double[n];
	for (int i = n - 1; i >= 0; --i)
	{
		for (int j = n; j>n - 1; --j)
		{
			d = xx[i][j];//++
		}
		for (int j = n - 1; j > i; j--)
		{
			s += x[j] * xx[i][j];
		}
		x[i] = d - s;
		cout << "x [" << i + 1 << "]: " << x[i] << endl;
	}
}
//ввід матриці самостійно
double enterS(int n, int m, double **entS)
{
	for (int i = 0; i<n; i++)
	{
		for (int j = 0; j<m - 1; j++)
		{
			cout << "Невiдомий елемент рiвняння " << "[" << i + 1 << " , " << j + 1 << "]: ";
			cin >> entS[i][j];
		}
		for (int j = m - 1; j<m; j++)
		{
			cout << "Pезультат рiвняння " << "[" << i + 1 << "]: ";
			cin >> entS[i][j];
		}
	}
	return **entS;
}
//ввід матриці рандомом
double enterR(int n, int m, double **entR)
{
	int vid, dia;
again2:
	cout << "Оберiть дiапазон значень чисел:\n"
		<< "вiд ";
	cin >> vid;
	cout << "до ";
	cin >> dia;
	if (dia<vid)
	{
		cout << "Значення \"до\" не може бути меншим за значення \"вiд\"!\n";
		goto again2;
	}
	dia -= vid;
	srand(time(NULL));
	for (int i = 0; i<n; i++)
	{
		for (int j = 0; j<m - 1; j++)
		{
			cout << "Невiдомий елемент рiвняння " << "[" << i + 1 << " , " << j + 1 << "]: ";
			entR[i][j] = rand() % (dia + 1) + vid;
			cout << entR[i][j] << endl;
		}
		for (int j = m - 1; j<m; j++)
		{
			cout << "Pезультат рiвняння " << "[" << i + 1 << "]: ";
			entR[i][j] = rand() % (dia + 1) + vid;
			cout << entR[i][j] << endl;
		}
	}
	return **entR;
}