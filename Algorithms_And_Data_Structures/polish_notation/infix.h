#pragma once
#include <iostream>
#include <string>

using namespace std;


string prefix(string infix);
double calculate(string prefix);
void full_polish(string f);

int identify_priority(char p);
bool is_operation(char o);
double make_double(string s);

class stack
{
private:
	const static int SIZE = 50;
	int quantity;
	double array[SIZE];

public:
	stack() :quantity(0) {};

	void push(double el);
	void pop();
	double peek();
	bool is_empty();
};