#include<iostream>
#include<fstream>
using namespace std;

class cube
{
private:
	int length;
	int width;
	int height;
public:
	cube() : length(0), width(0), height(0) {};
	cube(int length_1, int width_1, int height_1)
	{
		length = length_1;
		width = width_1;
		height = height_1;
	}
	cube(const cube& k)
	{
		length = k.length;
		width = k.width;
		height = k.height;
	}
	cube& operator=(const cube& k)
	{
		if (this != &k)
		{
			length = k.length;
			width = k.width;
			height = k.height;
		}
		return *this;
	}
	void write_in_file()
	{
		ofstream fout("test.txt");
		if (!fout.is_open())
		{
			cout << "Неможливо відкрити файл!!!";
		}
		else
		{
			fout << "length=" << length << endl
				<< "width=" << width << endl
				<< "height=" << height << endl;
		}
		fout.close();
	}

	void read()
	{
		ifstream fin("test.txt");
		if (!fin.is_open())
		{
			cout << "Неможливо відкрити файл!!!";
		}
		else
		{
			fin >> length
				>> width
				>> height;
		}
		fin.close();
	}

	friend ostream& operator<<(ostream & os, const cube& k);
	friend istream& operator >> (istream& is, cube& k);
};
ostream& operator<<(ostream & os, const cube& k)
{
	os << "length=" << k.length << endl
		<< "width=" << k.width << endl
		<< "height=" << k.height << endl;
	return os;
}
istream& operator >> (istream& is, cube& k)
{
	is >> k.length
		>> k.width
		>> k.height;
	return is;
}
void main()
{
	setlocale(LC_ALL, "ukr");
	cube cube_1;
	cin >> cube_1;
	cube_1.write_in_file();
	cube_1.read();
	cout << cube_1;
	system("pause");
}