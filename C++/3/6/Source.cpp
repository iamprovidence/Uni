/*
�������� 6: (5 ����)
(�� ���/�����)
���������� ��������-������� �������� ��������� �����. ���������� �������
������� ������ ����� �� ����������� ������� ������ ��� ������ � ������
����� ������ � ���������. ϳ��� ����� ������ �������� ��� ��������. 

��� ��������� ���������� ���� ������� 5 ������: 
allocate <num_cells> � ������� ���� ����� ������� <num_cells> ������ 
(������� �������� � ������� ����� ����� ������ ��������� ����� � <block_id>), 
free <block_id> � �������� ����, 
print � ������� ��������� ����� ����� � �������, 
exit � ��������� ������ ��������, 
help � ������� ������� ���������� ��� �������. 

���������� ����������� ������������� ��������� �������� �����.

������� ������ � ���������:
Please set memory size and max output width:
3
C:\>30 10
Type 'help' for additional info.
C:\>help
Available commands:
help - show this help
exit - exit this program
print - print memory blocks map
allocate <num> - allocate <num> cells. Returns
block first cell number
free <num> - free block with first cell number
<num>
C:\>print
|			|
|			|
|			|
C:\>allocate 5
0
C:\>print
|0xxxxxxxx|		|
|				|
|				|
C:\>allocate 3
5
C:\>print
|0xxxxxxxx|5xxxx|	|
|					|
|					|
C:\>allocate 4
8
C:\>allocate 10
12
C:\>print
|0xxxxxxxx|5xxxx|8xx|
|xxx|12xxxxxxxxxxxxx|
|xxx|				|
C:\>free 5
C:\>print
|0xxxxxxxx|     |8xx|
|xxx|12xxxxxxxxxxxxx|
|xxx|				|
C:\>free 8
C:\>print
|0xxxxxxxx|			|
| |12xxxxxxxxxxxxx	|
|xxx|				|
C:\>allocate 6
5
C:\>print
|0xxxxxxxx|5xxxxxxxx|
|x| |12xxxxxxxxxxxxx|
|xxx|				|
C:\>allocate 3
22
C:\>print
|0xxxxxxxx|5xxxxxxxx|
|x| |12xxxxxxxxxxxxx|
|xxx|22xxx|			|
C:\>exit

*/

#include <iostream>
#include <string>
#include <vector>
#include <list>
#include <algorithm>
#include <iterator>
#include <utility>
#define  is_two_digit(X) (X > 9 && X < 100)? true : false

using namespace std;

class memory_meneg
{
private:
	size_t size;//��������� �� ������ ����
	size_t memory_size;//����������� ���������
	size_t output_witdth;//������� ������ ��� ��������� � ������ ����� ������
	bool is_structured;//�� � ���� �����������, ��� �������, ���� �� �����

	struct data //���������� ��� ����� �����
	{ 
		size_t id; 
		size_t size;

		data(size_t id, size_t size)
		{
			this->id = id;
			this->size = size;
		}
	};

	list<data> block_inf;//������ ���������� ��� �����
	vector<char> memory;//���'��� � ��� ������� ���

	void show_help()const
	{
		cout << "Available commands: " << endl
			<< "help - show this help" << endl
			<< "size - get amount of free size" << endl
			<< "defragmentation - apply defragmentation" << endl
			<< "exit - exit this program" << endl
			<< "print - print memory blocks map" << endl
			<< "allocate <num> - allocate <num> cells. Returns block first cell number" << endl
			<< "free <num> - free block with first cell number <num>" << endl;
	}
	void change_number_of_printed(int &elem_printed)const
	{
		++elem_printed;

		if (elem_printed % (output_witdth * 2) == 0)
		{
			//cout << '\t';
			cout << '|';
			cout << endl;
			if (elem_printed != (memory_size*2) )//������� ������� �� ��� ����������
			{
				//++elem_printed;
				cout << '|';
			}

		}
	}
	void print_memory_map()const
	{
		if (block_inf.size() > 0)//���� � �������� 
		{
			/*
			int block_id = 0;//�������������� �����
			auto amount_in_block = block_size.begin();//�������� �� ����� �����
			int elem_printed = 0;//������� ������������ ��������

			cout << '|';
			while(elem_printed != memory_size)
			{
				if (amount_in_block != block_size.end())//���� � �������� � ���'��
				{
					cout << block_id; //elem_printed;//������� �������������� �����

					is_two_digit(block_id) ? elem_printed += 2 : ++elem_printed;

					//������� �������� �� �����
					for (int j = block_id; j != *amount_in_block + block_id; ++j)
					{
						cout << memory[j];//������� ������� �� ��������
						++elem_printed;//����������� �������

						if (elem_printed % output_witdth == 0)//���� ���������� ���
						{	
							//�������� ���� ����
							//cout << '\t';
							cout << '|';
							cout << endl;
							cout << '|';
						}
					}

					//�� �������� ����������, ������� ������ �� ����� ����� ���'��
					cout << '|';
					++elem_printed;
					//�������������� ��� ���������� �������� += ����� ����������� 
					block_id += *amount_in_block;
					//���������� �������� �� ��������� �������
					++amount_in_block;
				}
				else//���� ����
				{
					//������� ����� ��������, �� ����������
					for (int j = elem_printed; j != memory_size; ++j)
					{
						cout << ' ';
						++elem_printed;

						if (elem_printed % output_witdth == 0)
						{
							//cout << '\t';
							cout << '|';
							cout << endl;
							if (elem_printed != memory_size)//������� ������� �� ��� ����������
							{
								cout << '|';
							}
								
						}
					}
				}
			}
			*/

			int block_id = 0;//�������������� �����
			auto block_inf_iter = block_inf.begin();//�������� �� ����� �����
			int elem_printed = 0;//������� ������������ ��������

			cout << '|';
			while (elem_printed != memory_size*2)
			{
				if (block_inf_iter != block_inf.end())//���� � �������� � ���'��
				{
					if (block_id == block_inf_iter->id)//���� �������������� ������ => ������� ���� ��������
					{
						cout << block_id; //elem_printed;//������� �������������� �����

						elem_printed += (is_two_digit(block_id)) ?  2 : 1;

						// ������� ��� ������
						if (elem_printed % (output_witdth * 2) == 0)
						{
							//cout << '\t';
							cout << '|';
							cout << endl;
							if (elem_printed != (memory_size * 2))//������� ������� �� ��� ����������
							{
								cout << '|';
							}

						}

						if (!is_two_digit(block_id))
						{
							cout << "x";
							change_number_of_printed(elem_printed);
						}

						//������� �������� �� �����
						for (int j = block_id * 2; j != (block_inf_iter->size + block_id - 2) * 2; ++j)
						{
							cout << 'x';//������� ������� 
							change_number_of_printed(elem_printed);
						}

						//�� �������� ����������, ������� ������ �� ����� ����� ���'��
						cout << 'x';
						change_number_of_printed(elem_printed);
						cout << '|';
						change_number_of_printed(elem_printed);
						//�������������� ��� ���������� �������� += ����� ����������� 
						block_id += block_inf_iter->size;
						//���������� �������� �� ��������� �������
						++block_inf_iter;
					}
					else//�������������� �� ������ => ������� ����� ����
					{
						while (block_id != block_inf_iter->id - 1)
						{
							cout << ' ';
							change_number_of_printed(elem_printed);
							cout << ' ';
							change_number_of_printed(elem_printed);
							++block_id;
						}
						cout << ' ';
						change_number_of_printed(elem_printed);
						cout << '|';
						change_number_of_printed(elem_printed);
						++block_id;
					}
					
				}
				else//���� ����
				{
					//������� ����� ��������, �� ����������
					for (int j = elem_printed; j != memory_size * 2; ++j)
					{
						cout << ' ';
						change_number_of_printed(elem_printed);
					}
				}
			}
		}
		else//���� ���� �������� ������
		{
			//������� ���� = ������������ ����� / ������ ������
			int amount_of_row = int(ceil(double(memory_size) / output_witdth));
			//���� ����� �����
			for (int i = 0; i < amount_of_row; ++i)
			{
				cout << '|';
				for (int j = 0; j < output_witdth*2; ++j)
				{
					cout << ' ';
				}
				cout << '|' << endl;
			}
		}
	}
	int allocate(int num_cells)
	{
		// �������� �� ���������
		size += num_cells;
		if (size > memory_size)
		{
			throw "Memory is Full";
			abort();
		}

		//�������� �����
		
		//������� ������� ���� �� ������
		unsigned int all_free_space = 0;
		// ���� ������ �� ������������
		if (!is_structured)
		{
			int id = 0;
			int amount_of_free_space = 0;

			// �������� �� � ���� �� ������ � ���������� � ��������
			for (auto i = block_inf.begin(); i != block_inf.end(); ++i)
			{
				amount_of_free_space = amount_of_free_space - i->id;
				if (amount_of_free_space)
				{
					// ��������� ������� ���'�� �� ������
					all_free_space += abs(amount_of_free_space);
				}
					
				//���� � ���� => ����������
				if (abs(amount_of_free_space) >= num_cells)
				{
					// ������� �� �������� ���������� ��� �����
					block_inf.emplace(i, id, num_cells);
					// ������� ��������
					memory.insert(memory.begin() + id, num_cells, 'x');
					// ��������� ������
					return id;
				}
				
				amount_of_free_space = i->size + i->id;

				id += i->size;
			}

			// ���� ������ ���������, ��� �� ��������� ���� � ���� => �������������
			if (memory_size - (this->size - num_cells) - all_free_space < num_cells) 
			{
				defragmentation();	
				all_free_space = 0;//������� ���� ����� ����
			}			
		}

		//���� ������ ������������(���������������) => ������� � �����

		//�����'����� ��������������(����� ������ ����� + ����� ����) � ����� ������� �����
		block_inf.emplace_back(memory.size() + all_free_space, num_cells);
		
		//���������� �������� �� �����
		memory.insert(memory.end(),num_cells, 'x');

		//��������� �������������� ����������
		return block_inf.rbegin()->id;


		// �������� �����, ����� �����

		// ���� ������ �� ������������
		/*if (!is_structured)
		{
			int id = 0;
			int amount_of_free_space = 0;
			unsigned int all_free_space = 0;

			// �������� �� � ���� �� ������ � ���������� � ��������
			for (auto i = block_inf.begin(); i != block_inf.end(); ++i)
			{
				amount_of_free_space = amount_of_free_space - i->id;
				if (amount_of_free_space)
				{
					all_free_space += abs(amount_of_free_space);
				}

				//���� � ���� => ����������
				if (abs(amount_of_free_space) >= num_cells)
				{
					// ������� �� �������� ���������� ��� �����
					block_inf.emplace(i, id, num_cells);
					// ������� ��������
					memory.insert(memory.begin() + id, num_cells, 'x');
					// ��������� ������
					return id;
				}

				amount_of_free_space = i->size + i->id;

				id += i->size;
			}

			// ���� ��������� ���� � ���� => ������� � �����
			if (memory_size - (this->size - num_cells) - all_free_space >= num_cells)
			{
				//�����'����� ��������������(����� ������ �����) � ����� ������� �����
				block_inf.emplace_back(memory.size() + all_free_space, num_cells);

				//���������� �������� �� �����
				memory.insert(memory.end(), num_cells, 'x');

				//��������� �������������� ����������
				return block_inf.rbegin()->id;
			}

			//������ ���������, ��� �� ���� => �������������
			defragmentation();
		}
		//���� ������ ������������(���������������) => ������� � �����

		//�����'����� ��������������(����� ������ �����) � ����� ������� �����
		block_inf.emplace_back(memory.size(), num_cells);

		//���������� �������� �� �����
		memory.insert(memory.end(), num_cells, 'x');

		//��������� �������������� ����������
		return block_inf.rbegin()->id;*/
	}
	void free(int block_id)
	{
		// ������� � ������� ���������
		auto start = memory.begin();
		for (auto i = block_inf.begin(); i != block_inf.end(); ++i)//���� �� ��������
		{
			// ���� ������ ������ ��������� => �������� �������, ��������� ������
			if (i->id == block_id)
			{
				// ���� ��������� �� �� ���� => ������ ������� ���� �����������
				is_structured &= (i == --block_inf.end()) ? true : false;
				// �������� � ������� num[block_id (start), block_id + memory_occupied]
				memory.erase(start, start + i->size);
				// ������� �������� ���'�� � ������ ����
				size -= i->size;
				// ��������� �������� ������� ������� ���'��
				block_inf.erase(i);
				// ���� ���'��� �� ������� => ���'��� � �������������
				if (size == 0)
				{
					is_structured = true;
				}
				
				return;
			}

			start += i->size;
		}
		//���� �������� ����� �� ���� => ������ ������������ => �������� ������������
		cerr << "Bad Index" << endl;
	}
public:
	memory_meneg(int S, int W)
	{
		memory_size = S;
		output_witdth = W;
		is_structured = true;

		memory.reserve(S);
	}
	int get_size()const
	{
		return size;
	}
	void defragmentation()
	{
		int right_id = 0;
		is_structured = true;//���'��� ��� �������������

		//������ ������� �� ��������
		for (auto i = block_inf.begin(); i != block_inf.end(); ++i)
		{
			i->id = right_id;
			right_id += i->size;
		}

	}

	void run()
	{
		cout << "Type 'help' for additional info." << endl;
		
		while (true)
		{
			string command;
			cout << "C:\> ";
			cin >> command;
			if (command == "exit")
			{
				break;
			}
			else if (command == "help")
			{
				this->show_help();
			}
			else if (command == "print")
			{
				this->print_memory_map();
			}
			else if (command == "size")
			{
				cout << this->get_size() << endl;
			}
			else if (command == "defragmentation")
			{
				this->defragmentation();
				cout << "defragmented" << endl;
			}
			else if (command == "allocate")
			{
				int num_cells;
				cin >> num_cells;
				cout << allocate(num_cells) << endl;
			}
			else if (command == "free")
			{
				int block_id;
				cin >> block_id;
				this->free(block_id);
			}
			else
			{
				cout << "wrong command" << endl;
			}
	
		}
	}
};

void main()
{
	int S, W;
	cout << "Please set memory size and max output width:" << endl << "C:\> ";
	cin >> S >> W;
	memory_meneg MM(S, W);

	MM.run();
}