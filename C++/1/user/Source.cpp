#include <iostream>
#include <fstream>

using namespace std;

class reg_User
{
private:
	int age;
	int password;
	int repeat_password;
public:
	reg_User() : age(0), password(0), repeat_password(0) {};
	reg_User(const reg_User&x)
	{
		if (this != &x)
		{
			age = x.age;
			password = x.password;
			repeat_password = x.repeat_password;
		}
	}
	reg_User&operator =(const reg_User&x)
	{
		if (this != &x)
		{
			age = x.age;
			password = x.password;
			repeat_password = x.repeat_password;
		}
		return *this;
	}
	reg_User(int a, int p, int r_p)
	{
		age = a;
		password = p;
		repeat_password = r_p;
	}
	void write_in()
	{
		ofstream file("text.txt", ios_base::app);
		if (file.is_open())
		{
			file << "age = " << age << endl;
			file << "password = " << password << endl;
			file << "repeat_password = " << repeat_password << endl;

		}
		file.close();
	}
	void read_only()
	{
		ifstream file("text.txt");
		if (file.is_open())
		{
			const int MAX_LENGTH = 5000;
			char text[MAX_LENGTH];
			file.getline(text, MAX_LENGTH, '\0');
			cout << text << endl;
		}
		else
		{
			cout << "Error";
		}
		file.close();
	}
};

void main()
{
	reg_User Me(18, 1234, 1234);
	reg_User Friend(12, 1111, 1111);
	reg_User Another;
	reg_User Array[] = { Me, Friend,Another };
	for (int i = 0; i < 3; i++)
	{
		Array[i].write_in();
	}
	Array[0].read_only();

	system("pause");
}