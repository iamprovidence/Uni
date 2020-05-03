#ifndef head
#define head

#include <iostream>
#include <cmath>
#include <ctime>
#include <stdlib.h>

using namespace std;

void first();
void second();
void third();

double u(double x, int k );
double power(double Z, int n);
double factorial(int k);
void print(int A[], int n);

typedef double (*expression)(double a, double b);

double expression_1(double a, double b);
double expression_2(double a, double b);

typedef double (*simple_repetition)(double x, int n);

double simple_repetition_1(double x, int n);
double simple_repetition_2(double x, int n);
double simple_repetition_3(double x, int n);
double simple_repetition_4(double x, int n);

typedef double(*calculate_to_the_nearest)(double x, double e);

double calculate_to_the_nearest_1(double x, double e);
double calculate_to_the_nearest_2(double x, double e);

typedef void(*ArraysFunction)(int A[],int n);

void function_of_array_1(int A[], int n);
void function_of_array_2(int A[], int n);
void function_of_array_3(int A[], int n);
void function_of_array_4(int A[], int n);
void function_of_array_5(int A[], int n);
void function_of_array_6(int A[], int n);
void function_of_array_7(int A[], int n);
void function_of_array_8(int A[], int n);
void function_of_array_9(int A[], int n);


/* Оголосіть структуру, що моделює вказану сутність реального світу 


Визначте конструктори, 
методи (якщо потрібно), 
оператори введення, 
виведення порівняння/додавання/множення. 
Утворіть масив п’яти елементів оголошеного типу, 
введіть їх з клавіатури, 
знайдіть найбільший з них, 
або обчисліть їхню суму,
або збільшіть кожен з них удвічі, або … 
Результат виведіть на екран. (10 балів) */

struct Time
{
	int hour, min;
	int day, month, year;
	int calendar[3];

	Time();
	Time(int h, int m);
	Time(int d, int mn, int y);
};

struct Game
{
	int number_of_Playing_Card;
	char Name_Playing_Card[2];
	char Suite_Playing_Card[2];

	int Domino[2];
	int Dominos_number_1, Dominos_number_2;

	int Chessboard[2];
	char Chessboard_x, Chessboard_y;

	Game();
	Game(int N, char name, char suite);
	Game(int N1, int N2);
	Game(char X, char Y);
};

struct Digit
{
	int Complex_Number;
	int Rational_Number;

	Digit();
};

#endif