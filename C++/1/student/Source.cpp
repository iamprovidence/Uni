#include <iostream>
#include <fstream>
#include <string>

using namespace std;

class Student
{
private:
	string name;
	double usp;
	const static int amount_of_subject = 5;
	int amout_hours_for_subject[amount_of_subject];

public:
	Student() : name(""), usp(0), amout_hours_for_subject() {};
	Student(string n, double u, int* ahfs)
	{
		name = n;
		usp = u;
		for (int i = 0; i < 5; i++)
		{
			amout_hours_for_subject[i] = ahfs[i];
		}
	}

	string getName()
	{
		return name;
	}
	double getUsp()
	{
		return usp;
	}
	int* getHours()
	{
		for (int i = 0; i < amount_of_subject; i++)
		{
			amout_hours_for_subject[i];
		}
		return amout_hours_for_subject;
	}
	int getSize()
	{
		int array_size = sizeof(int) * amount_of_subject;
		return  name.length() + 1 + sizeof(double) + array_size;
	}

	void show()
	{
		cout << endl;
		cout << "name = " << name << endl;
		cout << "usp = " << usp << endl;
		cout << "hours = ";
		for (int i = 0; i < amount_of_subject; i++)
		{
			cout << amout_hours_for_subject[i] << ' ' << 'h' << ' ';
		}
		cout << endl;
	}

	void input(istream &in)
	{
		int name_length;
		in.read((char*)&name_length, sizeof(name_length));

		char* buffer = new char[name_length];
		in.read(buffer, name_length);
		name = buffer;

		in.read((char*)&usp, sizeof(usp));

		for (int i = 0; i < amount_of_subject; i++)
		{
			in.read((char*)&amout_hours_for_subject[i], sizeof(int));
		}
	}
	void output(ostream &out)
	{
		int len = (int)name.length() + 1;
		out.write((char*)&len, sizeof(len));
		out.write(name.c_str(), name.length() + 1);

		out.write((char*)&usp, sizeof(int));

		for (int i = 0; i < amount_of_subject; i++)
		{
			out.write((char*)&amout_hours_for_subject[i], sizeof(int));
		}
	}

	Student findMax(ifstream& is, int size)
	{
		int array_size = sizeof(int) * amount_of_subject;

		int max = 0;
		int str_size = 0;
		int m_position = 0;

		is.read((char*)&str_size, sizeof(str_size));
		max = str_size;

		for (int i = 1; i < size; ++i)
		{
			is.seekg(str_size + array_size + sizeof(double), ios_base::cur);
			is.read((char*)&str_size, sizeof(int));

			if (max < str_size)
			{
				m_position += (sizeof(max) + max + array_size + sizeof(double));
				max = str_size;
			}
		}

		is.seekg(m_position);
		(*this).input(is);
		return *this;
	}

};

int main()
{
	int n;
	cout << "Quantity of arrays:";
again:
	cin >> n;
	if (n <= 0)
	{
		goto again;
	}

	Student *A;
	A = new Student[n];
	int standart_hours[5] = { 2 , 1 };
	A[0] = Student("name", 18, standart_hours);

	for (int i = 0; i < n; i++)
	{
		A[i].show();
	}

	ofstream fout("test.txt");
	for (int i = 0; i < n; i++)
	{
		A[i].output(fout);
	}
	fout.close();

	ifstream fin("test.txt");
	for (int i = 0; i < n; i++)
	{
		A[i].show();
	}
	for (int i = 0; i < n; i++)
	{
		A[i].input(fin);
	}
	fin.close();
	delete[]A;

	ifstream fin("test.txt");
	Student max;
	max.findMax(fin, n);
	fin.close();
	max.show();

	system("pause");
}