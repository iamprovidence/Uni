#pragma once
#include <iostream>

using namespace std;

class SparseMatrix
{
private:
	struct Element
	{
		int i;
		int j;
		double value;
		Element *down;
		Element *right;
		Element()
		{
			i = NULL;
			j = NULL;
			value = NULL;
			right = nullptr;
			down = nullptr;
		}
		Element(int i, int j, double value, Element *down = nullptr, Element *right = nullptr)
		{
			this->i = i;
			this->j = j;
			this->value = value;
			this->right = right;
			this->down = down;
		}
	};
	int i;
	int j;
	Element **rows;
	Element **cols;
public:
	SparseMatrix();
	SparseMatrix(int q);
	SparseMatrix(int n, int m);
	SparseMatrix(const SparseMatrix& A);
	SparseMatrix& operator=(const SparseMatrix &A);
	//TODO
	~SparseMatrix();
	double get(int i, int j) const;
	bool set(int i, int j, double x);
	//TODO
	double **toUsualMatrix();
	//TODO
	SparseMatrix fromUsualMatrix(double **A,int i, int j);
	//TODO
	SparseMatrix operator+(const SparseMatrix &SM)const;
	//TODO
	SparseMatrix operator+=(const SparseMatrix &SM);
	SparseMatrix operator+=(double x);
	SparseMatrix operator+(double x)const;
	friend SparseMatrix operator+(double x, const SparseMatrix &SM);
	SparseMatrix operator*=(double x);
	SparseMatrix operator*(double x)const;
	friend SparseMatrix operator*(double x, const SparseMatrix &SM);
	//TODO
	SparseMatrix operator*(SparseMatrix X);
	void print(ostream& os) const;
	friend ostream & operator<<(ostream& os, const SparseMatrix & SM);
private:
	bool is_set(int i, int j)const;
	void remove(Element* E);
	void insert(int i, int j, double x);
	void change(double x, Element* &E);
	Element* get_ptr(int i, int j)const;
};
