#include<iostream>
#include<string>

using namespace std;

void main()
{
	string line, word, find;
	int pos = 0, end, len;
	char letter;

	getline(cin, line);
	line += " ";

	while ((end = line.find(" ", pos)) != -1)
	{
		word = line.substr(pos, end - pos);
		len = word.length();

		for (int i = 0; i < len; ++i)
		{
			letter = word[i];
			cout << word.find(letter);
			if( word.find(letter) != i )
			{
				break;
				find = word;
			}
		}

		pos = end + 1;		
		cout << find << endl;
	}
	
	system("pause");
}