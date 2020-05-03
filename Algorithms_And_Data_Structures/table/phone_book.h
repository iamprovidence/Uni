#pragma once
#include <iostream>
#include <string>

using namespace std;

struct Contact
{
	long long int number;
	string name;
	string fname;
	int age;
	string address;

	Contact()
	{
		number = 0;
		name = "";
		fname = "";
		age = 0;
		address = "";
	}

	Contact(long long int num, string  n, string f, int a, string add)
	{
		number = num;
		name = n;
		fname = f;
		age = a;
		address = add;
	}

	friend ostream& operator<<(ostream& os, const Contact&c);
	friend bool operator==(const Contact&l, const Contact&r);
};

void user_option(Contact a[], int n);
//Пошук
void find(Contact a[], int n);
void find_by_number(Contact a[], int n);
void find_by_name(Contact a[], int n);
void find_by_fname(Contact a[], int n);
void find_by_age(Contact a[], int n);
void find_by_address(Contact a[], int n);
//Додати запис
void add(Contact a[], int n);
//Замiнити запис
void replace(Contact a[], int n);
//Перевiрити наявнiсть
void present(Contact a[], int n);
bool is_exist(Contact a[], int n, long long exit_number);
//Вилучити запис
void execute(Contact a[], int n);
//Сортувати
void sort(Contact a[], int n);
void shell_sort_by_number(Contact a[], int n);
void shell_sort_by_name(Contact a[], int n);
//Вивести запис
void show(Contact A[], int n);
void show_by_number(Contact A[], int n);
void show_by_index(Contact A[], int n);
void show_all(Contact A[], int n);