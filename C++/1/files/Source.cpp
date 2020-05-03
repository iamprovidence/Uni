#include <iostream>
#include <fstream>
#include <string>

using namespace std;

class User
{
private:
	char name[20];
	char fname[20];
	char password[20];
	int age;
public:
	User(): name("user"), fname("fname"), password("password"), age(0) {};
	User(const User&x)
	{
		if (this != &x)
		{
			name[20] = x.name[20];
			fname[20] = x.fname[20];
			password[20] = x.password[20];
			age = x.age;
		}
	}
	User&operator =(const User&x)
	{
		if (this != &x)
		{
			delete[]name;
			delete[]fname;
			delete[]password;

			name[20] = x.name[20];
			fname[20] = x.fname[20];
			password[20] = x.password[20];
			age = x.age;
		}
		return *this;
	}
	void write_in()
	{
		ofstream file("text.txt", ios_base::app);
		if (file.is_open())
		{
			file << name << endl;
			file << fname << endl;
			file << password << endl;
			file << age << endl;
		}
		file.close();
	}
	void read_only()
	{
		ifstream file("text.txt");
		if (file.is_open())
		{
			file >> name;
			file >> fname;
			file >> password;
			file >> age;
		}
		file.close();
	}
};

void main()
{
	User Me;
	Me.write_in();
	Me.read_only();
	system("pause");
}