/*
Завдання 4: (3 бали)

У рядках текстового файлу задано пари < слово, переклад > .

Написати консольний перекладач, що при запуску отримує дані із заданого файлу і після
цього дає змогу перекладати введені користувачем речення використовуючи
наявні переклади слів.

Додатково забезпечити можливість додавання власних
перекладів до невідомих слів(при цьому програма повинна доповнювати файл
новими перекладами).

При реалізації програми використовувати асоціативні контейнери STL.
*/
#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <map>
#include <Windows.h>

using namespace std;

class translater
{
private:
	string file_name;
	map<string, string> vocabulary;
public:
	translater(string f_name)
	{
		file_name = f_name;

		ifstream word_list;
		word_list.open(f_name);
		while (!word_list.eof())
		{
			pair<string, string> word;
			word_list >> word.first;
			word_list >> word.second;
			vocabulary.insert(word);
		}
		word_list.close();
	}
	void show()
	{
		char LetterOldValue = ' ';
		for (auto it = vocabulary.begin(); it != vocabulary.end(); ++it)
		{
			char LetterNewValue = it->first[0];
			if (LetterNewValue != LetterOldValue)
			{
				LetterOldValue = LetterNewValue;
				char print = __ascii_toupper(LetterOldValue);

				cout << "\t\t\t" << print << endl;
			}

			cout << it->first << " - " << it->second << endl;
		}
	}
	string translate(string text, bool need_to_add_word = false)
	{
		string output_text;
		stringstream ss(text);

		while (!ss.eof())
		{
			string word;
			ss >> word;
			string replace = vocabulary[word.c_str()];
			if (replace != "")
			{
				output_text += replace;
			}
			else
			{
				if (need_to_add_word)
				{
					add_new_word(word);
					output_text += vocabulary.find(word)->second;
				}
				else
				{
					output_text += word;
				}
			}
			output_text += ' ';
		}

		return output_text;
	}
	bool add_new_word(string unknown_word)
	{
		string unknown = vocabulary[unknown_word.c_str()];

		if (unknown != "")
		{
			cout << "СЛОВО ВЖЕ Є В СЛОВНИКУ" << endl;
			return false;
		}
		else
		{
			cout << "ВВЕДIТЬ ПЕРЕКЛАД ДЛЯ СЛОВА \"" << unknown_word << '\"' << endl;
			cout << "\"q\" ЩОБ ВІДМІНИТИ ВВІД" << endl;
			string meaning;
			cin >> meaning;

			if (meaning == "q")
			{
				return false;
			}

			vocabulary.find(unknown_word)->second = meaning;

			ofstream file;
			file.open(file_name, ios::app);  // відкрити файл для запису в кінець
			file << '\n' << unknown_word << ' ' << meaning;
			file.close();

			return true;
		}
	}
};

void main()
{
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	translater T("dictionary.txt");
	//T.show();

	cout << "ВВЕДІТЬ РЕЧЕННЯ ДЛЯ ПЕРЕКЛАДУ" << endl;
	string sentence;
	getline(cin, sentence);
	cout << T.translate(sentence) << endl;

	system("pause");
}