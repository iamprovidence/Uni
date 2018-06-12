/*
�������� 8: (12 ����)
(�� ���/�����)
�������� ������� ��������� �� ��������� ������ ��� ��������� �������, ��
� �������������� ������������ ������.

���������� ��������� ����.
�������� ����� ����� ����������� ������ �� ��������� ��������
����������� �� ����������� �����. ������� ����������� �������� �;�:
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
� ������� ������������ �������� ���� (����� ���� ������� � ���� a-z, A-Z �
�� ���������� �� ��������� ������� while, whilenot, if, ifnot, read,
write).

������ <EXPRESSION_i> � ������������� ��������, �� ������� �
�����, ������ � ������������� �������� +, -, *, / �� ����� (, ).

����� � ������ <COMMAND_i> �� ���� � ����� �������:
<VARIABLE>=<EXPRESSION>;
read> <VARIABLE>;
write> <VARIABLE>;
������ �� ������� ���������������� ��� ���������� �������� � ���������
����� �� ������ � �������.

� ������� ���������� �� ���������� ����� �������� ������ ���������
��������, ���� ���� � ������ �� 0. �������� ������� ������������� �
����������� ������������ ������, ����� � ���� ������� ���� ���� ��������
(�����������, ������� �� ���� ������� � �.�.).

���������� ������� ��������:
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

����������� ��������� � ���� ������ ��� ��������� ������ (tN � ��������
���� ��� �������� ����������):
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

������ �������:
- ������� ������������ �������� +, -, *, /: ADD, SUB, MUL, DIV. ����� �
������ �� 3 ���������, �� ������� �������. ����� ��� � ���������� �
������ ���� ������� ��� �������, ����� �������� � ������ � ���
�������������� ��������� ��������;
- ������� �����/������ READ, WRITE;
- ������� ������� ��������: GOTOIFNOT, GOTOIF. ������� ����� ���
���������. ������ �� ����� �� �����, � ������ � ������� ������� ��������
�� ��� ������� �������� �������;
- ������� ����������� �������� GOTO. ������� �� ���� �������� � �����
������� �� ��� ������� �������� �������;
- ������� COPY. ������� �� ��� ���������. ������ � ������ ��� ������,
������ � ������ � ��� ������� �������� �����, �� ��������� ������
����������.

��������� ���� ����� �������� � ����� � ������ ��������� ��������� ��� �
��������� ����.

³�������� ������ ������ ���� ������ � ����� � ������ ��. ��������
������ ���������� � ������������� ��������� (������� ���������� �����
������).
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
	size_t temp_count;//��������� ���������� ������

	string input_file_name;//��'� �������� ����
	string output_file_name;//��'� ��������� �����
	size_t number_of_current_line_in_file;//����� ����� � ��������� ����

	ofstream out_file_stream;//���� ��� ������ � ����
	
	stack<streampos, list<streampos>> need_to_rechange;// ���� �������, �� ����� ���� ������, ��� GOTOIF[NOT]
	stack<size_t, list<size_t>> line_where_loop_start;// ���� ������� �� ���������� ����, ��� GOTO

	list<string> tokens;//����� ������

	map<string, string> key_words{ //������ ����� � �� ������������� ��� ��������� ������
		{ "while", "GOTOIFNOT" },
		{ "whilenot", "GOTOIF" },
		{ "if","GOTOIFNOT" },
		{ "ifnot", "GOTOIF" },
		{ "read>", "READ" },
		{ "write>", "WRITE" } };
	set<char> symbols{ ';','=','*','/','+','-','(',')','{','}','[',']' };//������� �������

	// �� � �������������� ��������
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
	// �� � ������� (�� ������ ���� � �������)
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
	// ����������� ��������
	int getPriority(const char op)const
	{
		if (op == '*' || op == '/') return 2;
		else if (op == '+' || op == '-') return 1;
		else if (op == '(' || op == ')' || op == '=') return 0;

		return 10;
	}

	// �������� ���� ������ �� ������
	void create_tokens(string file)
	{
		file.reserve(file.size() * 2);
		auto str_iter = file.begin();

		while (str_iter != file.end())
		{
			//���������� �������� �� ���������
			if (*str_iter == '>')
			{
				file.insert(++str_iter, ' ');
			}
			else if (is_symbol(*str_iter))//���� �� ������
			{
				//�������� ��������
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

		//����� ������� �� ���������� � ������
		stringstream ss(file);

		while (!ss.eof())
		{
			string token;
			ss >> token;
			tokens.emplace_back(token);
		}
		tokens.pop_back();
	}
	// ���������� ������
	void handle_tokens()
	{
		while (!tokens.empty())//������ ����� ������ �� �������
		{
			if (key_words.find(tokens.front()) != key_words.end())//���� �� ���������� �������
			{
				handle_command();//����������� ��������
			}
			else if (tokens.front() == "}")//����� �������
			{
				if (line_where_loop_start.top() != -1)//���� �� ��� ����
				{
					//�������� ����������� ����� � ��������� ����� �����, ��������� �� ��� ��������� ������
					out_file_stream << "GOTO " << line_where_loop_start.top() << endl;
					++number_of_current_line_in_file;
				}
				line_where_loop_start.pop();

				tokens.pop_front();//��������� "}"
				//���������� �������� � ���� �� ������� ��� ����� ������
				streampos position = need_to_rechange.top();
				need_to_rechange.pop();
				position.operator-=(8);//8 ���� �� �����
				out_file_stream.seekp(position);
				//�������� ���� ����� �������, ���� ������� �����������
				out_file_stream << number_of_current_line_in_file;
				//��������� �������� �� ����� �����
				out_file_stream.seekp(ios::beg, ios::end);
			}
			else//���� �� �����
			{
				//������ ����� ������
				auto find_expression_end = tokens.begin();
				while (*find_expression_end != ";" && find_expression_end != tokens.end())
				{
					++find_expression_end;
				}

				handle_expression(tokens.begin(), find_expression_end);//�������� �����
				tokens.erase(tokens.begin(), ++find_expression_end);//�������� ����� �� ������ �� ������ ';'
			}
		}
	}
	// ���������� �������
	void handle_command()
	{
		string original_command = tokens.front();
		string command = key_words[tokens.front()];//�������� ����������� ������� ��� ��������� ������
		tokens.pop_front();//�������� ������� �� ������

		if (command == "READ" || command == "WRITE")//read> || write>
		{
			command += " " + tokens.front();//�������� �� ������� �������
			tokens.pop_front();//�������� �������
			tokens.pop_front();//�������� ';'
			write_output(command);//�������� ������� � ����
		}
		else if (command == "GOTOIFNOT" || command == "GOTOIF") // if || while || ifnot || whilenot
		{
			//����� �� �� �������
			size_t line_before_command = number_of_current_line_in_file;
			tokens.pop_front();//�������� ������� [

			//������ ����� ������
			auto find_expression_end = tokens.begin();
			while (*find_expression_end != "]" && find_expression_end != tokens.end())
			{
				++find_expression_end;
			}

			//���� �� ����� �����, � �� ���� �����
			if (is_expression(tokens.begin(), find_expression_end))
			{
				handle_expression(tokens.begin(), find_expression_end);//�������� �����
				tokens.erase(tokens.begin(), find_expression_end);//�������� ����� �� ������
				command += " t" + to_string((temp_count - 1)) + "         ";//���� ��� �����
			}
			else
			{
				command += " " + tokens.front() + "         ";//���� ��� �����
				tokens.pop_front();//�������� �����
			}
			tokens.pop_front();//�������� ']'
			tokens.pop_front();//�������� '{'

			//� ���� �����'��������� �������� ���� ��� ������� �������, � ����� � ���� ���������� �������
			need_to_rechange.emplace(write_output(command));

			//���� �� ��� ����
			if (original_command == "while")
			{
				//����� �����'����� �� ��� ����� �� ���������
				line_where_loop_start.emplace(line_before_command);
			}
			else
			{
				line_where_loop_start.emplace(-1);//��� ���� -1
			}
		}
	}
	// ���������� �����
	void handle_expression(list<string>::iterator begin, list<string>::iterator end)
	{
		//������������ � ��������� �����
		stack<string> OP;// ���� ���������
		vector<string> postfixExpr;// ���������� �������������

		for (auto i = begin; i != end; ++i)
		{
			string c = *i;// ������ ������

			if (symbols.find(c[0]) == symbols.end())//���� �� �����
			{
				postfixExpr.emplace_back(c);//�������� � ���������� �����
			}
			//���� �� �������� � �� �����
			else if (symbols.find(c[0]) != symbols.end() && *symbols.find(c[0]) != '(' && *symbols.find(c[0]) != ')')
			{
				while (!OP.empty() && getPriority(OP.top()[0]) >= getPriority(c[0]))//���� �� �������� �������
				{
					postfixExpr.emplace_back(OP.top());//�������� �� ����� ��� � ���������� �����
					OP.pop();
				}

				OP.emplace(c);//������� �������� � ����
			}
			else if (c == "(")
			{
				OP.emplace(c);//'(' � ����
			}
			else /* c == ')' */
			{
				while (OP.top() != "(")//���� �� ��������� '('
				{
					postfixExpr.emplace_back(OP.top());//��������� �� ����� � ���������� �����
					OP.pop();
				}
				OP.pop();//'(' �������� �� �����
			}
		}

		while (!OP.empty())//���� � ����� �������� ���������
		{
			postfixExpr.emplace_back(OP.top());//��������� �� ����� � ���������� �����
			OP.pop();
		}

		// ������������ ���������
		// ������
		stack<string> ARG; // ���� ��������
		for (auto i = postfixExpr.begin(); i != postfixExpr.end(); ++i)
		{
			// ������ �� ������������ ������ ������ ����� ���������
			auto op = symbols.find(i->operator[](0));
			if (op == symbols.end())//���� �� �����, � �� ��������
			{
				ARG.emplace(*i);// �������� � ���� ��������
			}
			else//���� �� ��������
			{
				//���������� ���� ��'� ��� �����쳺 ��������� ������
				string op_name;
				if (*op == '+')op_name = "ADD";
				else if (*op == '-')op_name = "SUB";
				else if (*op == '*')op_name = "MUL";
				else if (*op == '/')op_name = "DIV";
				else if (*op == '=')op_name = "COPY";

				//�������� ������ �������
				string second_operand = ARG.top();
				ARG.pop();

				//a + b
				//SUM b a t1
				//������� �������
				string command = op_name + ' ' + ARG.top() + ' ' + second_operand + ' ';
				ARG.pop();//�������� ������ ������� �� �����

				if (*i != "=")//��������� �������� �������� � ��������� ����� tN
				{
					// ��������������, ���� ������� ������ �������� ���� � �� ���������� ����
					if ((i + 1) != postfixExpr.end() && (*(i + 1)) == "=")
					{
						command += ARG.top();
						ARG.pop();

						//�������� � ����
						write_output(command);
						break;
					}
					else
					{

						command += "t" + to_string(temp_count);//���������� ������� ���������� ������
						if ((i + 1) != postfixExpr.end())//���� �� �� ����� ������ � ������ ��������
						{
							ARG.emplace("t" + to_string(temp_count));//�������� �� ����� � ����
						}
						++temp_count;//�������� ������ ���������� ���
					}
				}

				//�������� � ����
				write_output(command);
			}
		}

		//���� ���� �������� �� ������, ������� ����� ��������� �����������
		if (!ARG.empty())
		{
			throw "bad expression";
			abort();
		}

	}
	// ��������� � ����
	// @return streampos ������� ���� �����, ���� ��� ���������
	streampos write_output(const string &output)
	{
		out_file_stream << output;//�������� � ���� � ������� �� ����� �����
		streampos last_pos_in_line = out_file_stream.tellp();//�����'����� ������� ���� �����
		out_file_stream << '\n';//������� �� ���� �����
		++number_of_current_line_in_file;//������ � ���'�� ����� �������� ����� �����

		return last_pos_in_line;//��������� ������� ���� ��������������� �����
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
		ifstream fin(input_file_name, ios_base::in);//������� ���� ��� ������� ����
		out_file_stream.open(output_file_name, ios_base::trunc);//������� ���� ��� ������ ����������
		string file;//���� ������������� ���� �������
		while (!fin.eof())
		{
			string temp;
			fin >> temp;
			file += temp;

		}
		fin.close();//���� ��� ������� �������
		create_tokens(file);//�������� ������
		handle_tokens();//�������� ������
		out_file_stream.close();//������� ���� ��� ������

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

		//������ ���� � ������ ����� ������ � ������(�������, ��������� �������)
		while (!file_read.eof())
		{
			string command, parameters;
			file_read >> command;
			file_read.get();
			getline(file_read, parameters);

			V.emplace_back(command, parameters);
		}

		//��������� ���� ������ �� ������� � ����� ��������� �� ��������
		int i = 0;
		while (i < V.size())
		{
			//���������� ��������� ������ �� ����
			stringstream split_param(V[i].parameters);
			/*- ������� �����/������ READ, WRITE;*/
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
			- ������� ������������ �������� +, -, *, /: ADD, SUB, MUL, DIV. ����� �
			������ �� 3 ���������, �� ������� �������. ����� ��� � ���������� �
			������ ���� ������� ��� �������, ����� �������� � ������ � ���
			�������������� ��������� ��������;
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
			- ������� ������� ��������: GOTOIFNOT, GOTOIF. ������� ����� ���
			���������. ������ �� ����� �� �����, � ������ � ������� ������� ��������
			�� ��� ������� �������� �������;
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
			- ������� ����������� �������� GOTO. ������� �� ���� �������� � �����
			������� �� ��� ������� �������� �������;
			*/
			else if (V[i].command == "GOTO")
			{
				float index;
				split_param >> index;

				i = index;
				continue;
			}
			/*
			- ������� COPY. ������� �� ��� ���������. ������ � ������ ��� ������,
			������ � ������ � ��� ������� �������� �����, �� ��������� ������
			����������.
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