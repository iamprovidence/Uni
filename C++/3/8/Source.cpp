/*
Завдання 8: (12 балів)
(на парі/вдома)
Створити простий компілятор та віртуальну машину для виконання програм, що
є послідовностями арифметичних виразів.

Розглянемо синтаксис мови.
Програма являє собою послідовність команд із можливими умовними
операторами та операторами циклу. Команди розділяються символом «;»:
<COMMAND_1>;
<COMMAND_2>;
<COMMAND_3>;
if[<EXPRESSION_1>]
{
<COMMAND_4>;
<COMMAND_5>;
}
<COMMAND_6>;
ifnot[<EXPRESSION_2>]
{
<COMMAND_7>;
}
while[<EXPRESSION_3>]
{
<COMMAND_8>;
<COMMAND_9>;
while[<EXPRESSION_4>]
{
ifnot[<EXPRESSION_5>]
{
<COMMAND_10>;
}
<COMMAND_11>;
}
}
В програмі допускаються глобальні змінні (імена лише складені з букв a-z, A-Z і
не співпадають із ключовими словами while, whilenot, if, ifnot, read,
write).

Вирази <EXPRESSION_i> є арифметичними виразами, що складені з
чисел, змінних з використанням операцій +, -, *, / та дужок (, ).

Кожна з команд <COMMAND_i> має один з трьох форматів:
<VARIABLE>=<EXPRESSION>;
read> <VARIABLE>;
write> <VARIABLE>;
Останні дві команди використовуються для зчитування введених з клавіатури
даних та виводу у консоль.

В умовних операторах та операторах циклу значення виразу вважається
істинним, якщо воно є більшим за 0. Програма повинна транслюватись у
послідовність елементарних команд, кожна з яких здійснює лише одну операцію
(арифметичну, перехід до іншої команди і т.д.).

Розглянемо приклад програми:
read> a;
read> b;
read> c;
d=c*a;
if[d*2-3.5]
{
while[b-5]
{
a=a+2*c;
b=b-1;
}
}
write> a;

Результатом компіляції є набір команд для віртуальної машини (tN – додаткові
змінні для проміжних результатів):
READ a
READ b
READ c
MUL a c d
MUL d 2 t1
SUB t1 3.5 t2
GOTOIFNOT t2 13
SUB b 5 t3
GOTOIFNOT t3 13
MUL 2 c t4
ADD a t4 a
SUB b 1 b
GOTO 7
WRITE a

Машина підтримує:
- команди арифметичних операцій +, -, *, /: ADD, SUB, MUL, DIV. Кожна з
команд має 3 аргументи, що розділені пробілом. Перші два є операндами і
можуть бути числами або змінними, третій аргумент є змінною в якій
зберігатиметься результат операції;
- команди вводу/виводу READ, WRITE;
- команди умовних переходів: GOTOIFNOT, GOTOIF. Команди мають два
аргументи. Перший це число чи змінна, а другий є номером команди програми
на яку потрібно здійснити перехід;
- команду безумовного переходу GOTO. Команда має один аргумент – номер
команди на яку потрібно здійснити перехід;
- команду COPY. Команда має два аргументи. Перший є числом або змінною,
другий є змінною в яку потрібно помістити число, що визначене першим
аргументом.

Компілятор читає текст програми з файлу і записує результат компіляції теж у
текстовий файл.

Віртуальна машина отримує набір команд з файлу і виконує їх. Значення
змінних зберігається у асоціативному контейнері (ключами виступають назви
змінних).
*/

#include <iostream>
#include <fstream>
#include <string>
#include <sstream>

#include <vector>
#include <list>
#include <map>
#include <set>

#include <stack>

using namespace std;

class compiler
{
private:
	size_t temp_count;//підрахунок тимчасових змінних

	string input_file_name;//ім'я вхідного фалй
	string output_file_name;//фм'я вихідного файлу
	size_t number_of_current_line_in_file;//номер рядка у вихідному файлі

	ofstream out_file_stream;//потік для запису у файл
	
	stack<streampos, list<streampos>> need_to_rechange;// стек позицій, які варто буде змінити, для GOTOIF[NOT]
	stack<size_t, list<size_t>> line_where_loop_start;// стек позицій де починається цикл, для GOTO

	list<string> tokens;//черга токенів

	map<string, string> key_words{ //ключові слова і їх представлення для віртуальної машини
		{ "while", "GOTOIFNOT" },
		{ "whilenot", "GOTOIF" },
		{ "if","GOTOIFNOT" },
		{ "ifnot", "GOTOIF" },
		{ "read>", "READ" },
		{ "write>", "WRITE" } };
	set<char> symbols{ ';','=','*','/','+','-','(',')','{','}','[',']' };//множина символів

	// чи є заразервованим символом
	bool is_symbol(const char el)const
	{
		for (auto sym_iter = symbols.cbegin(); sym_iter != symbols.cend(); ++sym_iter)
		{
			if (el == *sym_iter)
			{
				return true;
			}
		}
		return false;
		//return symbols.find(el) == symbols.end();
	}
	// чи є виразом (має містити змінні і СИМВОЛИ)
	bool is_expression(list<string>::iterator begin, list<string>::iterator end)const
	{
		while (begin != end)
		{
			if (is_symbol((*begin)[0]))
			{
				return true;
			}
			++begin;
		}
		return false;
	}
	// пріорітетність операцій
	int getPriority(const char op)const
	{
		if (op == '*' || op == '/') return 2;
		else if (op == '+' || op == '-') return 1;
		else if (op == '(' || op == ')' || op == '=') return 0;

		return 10;
	}

	// створити набір токенів із стрічки
	void create_tokens(string file)
	{
		file.reserve(file.size() * 2);
		auto str_iter = file.begin();

		while (str_iter != file.end())
		{
			//вставлення пропусків між символами
			if (*str_iter == '>')
			{
				file.insert(++str_iter, ' ');
			}
			else if (is_symbol(*str_iter))//якщо це символ
			{
				//вставити пропуски
				file.insert(str_iter, ' ');
				str_iter++;
				file.insert(++str_iter, ' ');
				str_iter++;
			}
			else
			{
				++str_iter;
			}
		}

		//запис значень між пропусками у токени
		stringstream ss(file);

		while (!ss.eof())
		{
			string token;
			ss >> token;
			tokens.emplace_back(token);
		}
		tokens.pop_back();
	}
	// опрацювати токени
	void handle_tokens()
	{
		while (!tokens.empty())//допоки черга токенів не порожня
		{
			if (key_words.find(tokens.front()) != key_words.end())//якщо це стандартна команда
			{
				handle_command();//опрацьовуємо командку
			}
			else if (tokens.front() == "}")//кінець команди
			{
				if (line_where_loop_start.top() != -1)//якщо це був цикл
				{
					//потбрібно повернутись назад і перевірити знову умову, повідомимо пр оце віртуальну машину
					out_file_stream << "GOTO " << line_where_loop_start.top() << endl;
					++number_of_current_line_in_file;
				}
				line_where_loop_start.pop();

				tokens.pop_front();//видаляємо "}"
				//перемістити вказівник у файлі на позицію яку варто змінити
				streampos position = need_to_rechange.top();
				need_to_rechange.pop();
				position.operator-=(8);//8 місце під змінну
				out_file_stream.seekp(position);
				//дописуємо куди варто перейти, якщо команда завершується
				out_file_stream << number_of_current_line_in_file;
				//переміщуємо вказівник на кінець файлу
				out_file_stream.seekp(ios::beg, ios::end);
			}
			else//якщо це вираз
			{
				//знайти кінець виразу
				auto find_expression_end = tokens.begin();
				while (*find_expression_end != ";" && find_expression_end != tokens.end())
				{
					++find_expression_end;
				}

				handle_expression(tokens.begin(), find_expression_end);//обробити вираз
				tokens.erase(tokens.begin(), ++find_expression_end);//видалити вираз із токенів та символ ';'
			}
		}
	}
	// опрацювати команди
	void handle_command()
	{
		string original_command = tokens.front();
		string command = key_words[tokens.front()];//отримаємо відображення команди для віртуальної машини
		tokens.pop_front();//видалимо команду із токенів

		if (command == "READ" || command == "WRITE")//read> || write>
		{
			command += " " + tokens.front();//дописуємо до команди елемент
			tokens.pop_front();//викидаємо елемент
			tokens.pop_front();//викидаємо ';'
			write_output(command);//записуємо команду у файл
		}
		else if (command == "GOTOIFNOT" || command == "GOTOIF") // if || while || ifnot || whilenot
		{
			//номер лінії до команди
			size_t line_before_command = number_of_current_line_in_file;
			tokens.pop_front();//викидаємо елемент [

			//знайти кінець виразу
			auto find_expression_end = tokens.begin();
			while (*find_expression_end != "]" && find_expression_end != tokens.end())
			{
				++find_expression_end;
			}

			//якщо це цілий вираз, а не одна змінна
			if (is_expression(tokens.begin(), find_expression_end))
			{
				handle_expression(tokens.begin(), find_expression_end);//обробити вираз
				tokens.erase(tokens.begin(), find_expression_end);//видалити вираз із токенів
				command += " t" + to_string((temp_count - 1)) + "         ";//місце для змінної
			}
			else
			{
				command += " " + tokens.front() + "         ";//місце для змінної
				tokens.pop_front();//викидаємо умову
			}
			tokens.pop_front();//викидаємо ']'
			tokens.pop_front();//викидаємо '{'

			//в стек запам'ятовується значення місця яке потрібно замінити, а також у файл виводиться команда
			need_to_rechange.emplace(write_output(command));

			//якщо це був цикл
			if (original_command == "while")
			{
				//варто запам'ятати на якій лінійці він починався
				line_where_loop_start.emplace(line_before_command);
			}
			else
			{
				line_where_loop_start.emplace(-1);//для умов -1
			}
		}
	}
	// опрацювати вираз
	void handle_expression(list<string>::iterator begin, list<string>::iterator end)
	{
		//перетворення в польський вираз
		stack<string> OP;// стек операторів
		vector<string> postfixExpr;// постфіксне представлення

		for (auto i = begin; i != end; ++i)
		{
			string c = *i;// данний символ

			if (symbols.find(c[0]) == symbols.end())//якщо це число
			{
				postfixExpr.emplace_back(c);//добавити у постфіксну форму
			}
			//якщо це оператор і не дужки
			else if (symbols.find(c[0]) != symbols.end() && *symbols.find(c[0]) != '(' && *symbols.find(c[0]) != ')')
			{
				while (!OP.empty() && getPriority(OP.top()[0]) >= getPriority(c[0]))//поки не зрівняємо пріорітет
				{
					postfixExpr.emplace_back(OP.top());//оператор із стеку йде в постфіксну форму
					OP.pop();
				}

				OP.emplace(c);//закидую оператор в стек
			}
			else if (c == "(")
			{
				OP.emplace(c);//'(' в стек
			}
			else /* c == ')' */
			{
				while (OP.top() != "(")//поки не зустрінемо '('
				{
					postfixExpr.emplace_back(OP.top());//оператори із стеку в постфіксну форму
					OP.pop();
				}
				OP.pop();//'(' забираємо із стеку
			}
		}

		while (!OP.empty())//поки в стеку містяться оператори
		{
			postfixExpr.emplace_back(OP.top());//оператори із стеку в постфіксну форму
			OP.pop();
		}

		// перетворення завершено
		// рахуємо
		stack<string> ARG; // стек операндів
		for (auto i = postfixExpr.begin(); i != postfixExpr.end(); ++i)
		{
			// символ із постфіксного виразу шукаємо серед операторів
			auto op = symbols.find(i->operator[](0));
			if (op == symbols.end())//якщо це число, а не оператор
			{
				ARG.emplace(*i);// заносимо в стек операндів
			}
			else//якщо це оператор
			{
				//присвоюємо йому ім'я яке зрозуміє віртуальна машина
				string op_name;
				if (*op == '+')op_name = "ADD";
				else if (*op == '-')op_name = "SUB";
				else if (*op == '*')op_name = "MUL";
				else if (*op == '/')op_name = "DIV";
				else if (*op == '=')op_name = "COPY";

				//отримуємо другий операнд
				string second_operand = ARG.top();
				ARG.pop();

				//a + b
				//SUM b a t1
				//формуємо команду
				string command = op_name + ' ' + ARG.top() + ' ' + second_operand + ' ';
				ARG.pop();//викидуємо перший операнд із стеку

				if (*i != "=")//результат операції зберегти в тимчасову змінну tN
				{
					// розкоментувати, якщо потрібно одразу заносити змінні а не створювати копію
					if ((i + 1) != postfixExpr.end() && (*(i + 1)) == "=")
					{
						command += ARG.top();
						ARG.pop();

						//записуємо у файл
						write_output(command);
						break;
					}
					else
					{

						command += "t" + to_string(temp_count);//доповнюємо команду тимчасовою змінною
						if ((i + 1) != postfixExpr.end())//якщо ще не кінець виразу і будуть операції
						{
							ARG.emplace("t" + to_string(temp_count));//заносимо цю змінну в стек
						}
						++temp_count;//збільшуємо перелік тимчасових змін
					}
				}

				//записуємо у файл
				write_output(command);
			}
		}

		//якщо стек операндів не пустий, значить вираз записаний неправильно
		if (!ARG.empty())
		{
			throw "bad expression";
			abort();
		}

	}
	// занесення у файл
	// @return streampos позицію кінця рядка, який був занесений
	streampos write_output(const string &output)
	{
		out_file_stream << output;//записати в файл і перейти на інший рядок
		streampos last_pos_in_line = out_file_stream.tellp();//запам'ятовує позицію кінця рядка
		out_file_stream << '\n';//перехід на нову лінійку
		++number_of_current_line_in_file;//змінити у пам'яті номер останньої лінійки файла

		return last_pos_in_line;//повертаємо позицію кінця щойнозаписаного рядка
	}
public:
	compiler(string i_f_n = "executive.txt", string o_f_n = "compile_result.txt")
	{
		temp_count = 1;
		number_of_current_line_in_file = 0;

		input_file_name = i_f_n;
		output_file_name = o_f_n;
	}

	string compile()
	{
		ifstream fin(input_file_name, ios_base::in);//відкрити файл для читання коду
		out_file_stream.open(output_file_name, ios_base::trunc);//відкрити файл для запису результату
		string file;//файл представлений однією стрічкою
		while (!fin.eof())
		{
			string temp;
			fin >> temp;
			file += temp;

		}
		fin.close();//файл для читання закрити
		create_tokens(file);//створити токени
		handle_tokens();//обробити токени
		out_file_stream.close();//закрити файл для запису

		return output_file_name;
	}

};

class virtual_machine
{
private:
	map<string, float> Variables;

	struct instruction
	{
		string command;
		string parameters;

		instruction(string c, string p)
		{
			command = c;
			parameters = p;
		}
	};

public:

	void execute(string ex_f)
	{
		ifstream file_read(ex_f, ios_base::in);
		vector < instruction > V;

		//зчитую файл і кожний рядок заношу у вектор(команда, параметри команди)
		while (!file_read.eof())
		{
			string command, parameters;
			file_read >> command;
			file_read.get();
			getline(file_read, parameters);

			V.emplace_back(command, parameters);
		}

		//проглядаю весь вектор по індексу і шукаю співпадіння по командах
		int i = 0;
		while (i < V.size())
		{
			//розглянемо параметри команд як потік
			stringstream split_param(V[i].parameters);
			/*- команди вводу/виводу READ, WRITE;*/
			if (V[i].command == "READ")
			{
				string variable_name;
				split_param >> variable_name;
				float value;
				cin >> value;

				Variables.emplace(variable_name, value);
			}
			else if (V[i].command == "WRITE")
			{
				string variable_name;
				split_param >> variable_name;

				if (variable_name == "ENDL")
				{
					cout << endl;
					++i;
					continue;
				}

				cout << Variables[variable_name];
			}
			/*
			- команди арифметичних операцій +, -, *, /: ADD, SUB, MUL, DIV. Кожна з
			команд має 3 аргументи, що розділені пробілом. Перші два є операндами і
			можуть бути числами або змінними, третій аргумент є змінною в якій
			зберігатиметься результат операції;
			*/
			else if (V[i].command == "ADD")
			{
				string operand1, operand2, var;
				float num1, num2;
				split_param >> operand1 >> operand2 >> var;
				num1 = (Variables.find(operand1) != Variables.end()) ? Variables[operand1] : atof(operand1.c_str());
				num2 = (Variables.find(operand2) != Variables.end()) ? Variables[operand2] : atof(operand2.c_str());

				Variables[var] = num1 + num2;
			}
			else if (V[i].command == "SUB")
			{
				string operand1, operand2, var;
				float num1, num2;
				split_param >> operand1 >> operand2 >> var;
				num1 = (Variables.find(operand1) != Variables.end()) ? Variables[operand1] : atof(operand1.c_str());
				num2 = (Variables.find(operand2) != Variables.end()) ? Variables[operand2] : atof(operand2.c_str());

				Variables[var] = num1 - num2;
			}
			else if (V[i].command == "MUL")
			{
				string operand1, operand2, var;
				float num1, num2;
				split_param >> operand1 >> operand2 >> var;
				num1 = (Variables.find(operand1) != Variables.end()) ? Variables[operand1] : atof(operand1.c_str());
				num2 = (Variables.find(operand2) != Variables.end()) ? Variables[operand2] : atof(operand2.c_str());

				Variables[var] = num1 * num2;
			}
			else if (V[i].command == "DIV")
			{
				string operand1, operand2, var;
				float num1, num2;
				split_param >> operand1 >> operand2 >> var;
				num1 = (Variables.find(operand1) != Variables.end()) ? Variables[operand1] : atof(operand1.c_str());
				num2 = (Variables.find(operand2) != Variables.end()) ? Variables[operand2] : atof(operand2.c_str());

				Variables[var] = num1 / num2;
			}
			/*
			- команди умовних переходів: GOTOIFNOT, GOTOIF. Команди мають два
			аргументи. Перший це число чи змінна, а другий є номером команди програми
			на яку потрібно здійснити перехід;
			*/
			else if (V[i].command == "GOTOIFNOT")
			{
				string var;
				float value, index;
				split_param >> var >> index;
				value = (Variables.find(var) != Variables.end()) ? Variables[var] : atof(var.c_str());

				if (!(value > 0))
				{
					i = index;
					continue;
				}
			}
			else if (V[i].command == "GOTOIF")
			{
				string var;
				float value, index;
				split_param >> var >> index;
				value = (Variables.find(var) != Variables.end()) ? Variables[var] : atof(var.c_str());

				if (value > 0)
				{
					i = index;
					continue;
				}
			}
			/*
			- команду безумовного переходу GOTO. Команда має один аргумент – номер
			команди на яку потрібно здійснити перехід;
			*/
			else if (V[i].command == "GOTO")
			{
				float index;
				split_param >> index;

				i = index;
				continue;
			}
			/*
			- команду COPY. Команда має два аргументи. Перший є числом або змінною,
			другий є змінною в яку потрібно помістити число, що визначене першим
			аргументом.
			*/
			else if (V[i].command == "COPY")
			{
				string operand, var;
				float num;
				split_param >> var >> operand;
				num = (Variables.find(operand) != Variables.end()) ? Variables[operand] : atof(operand.c_str());

				Variables[var] = num;
			}

			++i;
		}
	}

};

int main()
{
	compiler C("exe_test.txt", "comp_file.txt");
	virtual_machine VM;

	string res_file = C.compile();
	VM.execute(res_file);

	system("pause");
	return 0;
}