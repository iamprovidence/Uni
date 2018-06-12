/*
Завдання 6: (5 балів)
(на парі/вдома)
Реалізувати програму-імітатор простого менеджера пам’яті. Користувач вводить
кількість комірок пам’яті та максимальну кількість комірок для виводу в одному
рядку консолі з клавіатури. Після цього робота програми стає циклічною. 

Для виконання користувач може вводити 5 команд: 
allocate <num_cells> – виділити блок пам’яті розміром <num_cells> комірок 
(команда виводить в консоль номер першої комірки виділеного блоку – <block_id>), 
free <block_id> – звільнити блок, 
print – вивести структуру блоків пам’яті у консоль, 
exit – завершити роботу програми, 
help – вивести коротку інформацію про команди. 

Намагатись оптимізувати продуктивність алгоритму виділення блоків.

Приклад роботи з програмою:
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
	size_t size;//вмістимість на момент часу
	size_t memory_size;//максимальна вмістимість
	size_t output_witdth;//кількість комірок для виведення в одному рядку консолі
	bool is_structured;//чи є данні впорядковані, без розривів, один за одним

	struct data //інформація про блоки памяті
	{ 
		size_t id; 
		size_t size;

		data(size_t id, size_t size)
		{
			this->id = id;
			this->size = size;
		}
	};

	list<data> block_inf;//список інформацій про блоки
	vector<char> memory;//пам'ять в яку записані дані

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
			if (elem_printed != (memory_size*2) )//останній елемент не тре переносити
			{
				//++elem_printed;
				cout << '|';
			}

		}
	}
	void print_memory_map()const
	{
		if (block_inf.size() > 0)//якщо є елементи 
		{
			/*
			int block_id = 0;//індентифікатор блоку
			auto amount_in_block = block_size.begin();//вказівник на розмір блоку
			int elem_printed = 0;//кількість надрукованих елементів

			cout << '|';
			while(elem_printed != memory_size)
			{
				if (amount_in_block != block_size.end())//якщо є елементв в пам'яті
				{
					cout << block_id; //elem_printed;//вивисти індентифікатор блоку

					is_two_digit(block_id) ? elem_printed += 2 : ++elem_printed;

					//вивисти елементи із блоку
					for (int j = block_id; j != *amount_in_block + block_id; ++j)
					{
						cout << memory[j];//вивести елемент за індексом
						++elem_printed;//надруковано елемент

						if (elem_printed % output_witdth == 0)//якщо надрукував ряд
						{	
							//закінчуємо друк ряду
							//cout << '\t';
							cout << '|';
							cout << endl;
							cout << '|';
						}
					}

					//всі елементи надруковані, друкуємо символ як кінець блоку пам'яті
					cout << '|';
					++elem_printed;
					//індентифікатор для наступного елемента += розмір теперішнього 
					block_id += *amount_in_block;
					//пересуваємо вказівник на наступний елемент
					++amount_in_block;
				}
				else//якщо немає
				{
					//друкуємо решту елементів, що залишилось
					for (int j = elem_printed; j != memory_size; ++j)
					{
						cout << ' ';
						++elem_printed;

						if (elem_printed % output_witdth == 0)
						{
							//cout << '\t';
							cout << '|';
							cout << endl;
							if (elem_printed != memory_size)//останній елемент не тре переносити
							{
								cout << '|';
							}
								
						}
					}
				}
			}
			*/

			int block_id = 0;//індентифікатор блоку
			auto block_inf_iter = block_inf.begin();//вказівник на розмір блоку
			int elem_printed = 0;//кількість надрукованих елементів

			cout << '|';
			while (elem_printed != memory_size*2)
			{
				if (block_inf_iter != block_inf.end())//якщо є елементв в пам'яті
				{
					if (block_id == block_inf_iter->id)//якщо індентифікатор співпав => друкуємо його елементи
					{
						cout << block_id; //elem_printed;//вивисти індентифікатор блоку

						elem_printed += (is_two_digit(block_id)) ?  2 : 1;

						// перенос при потребі
						if (elem_printed % (output_witdth * 2) == 0)
						{
							//cout << '\t';
							cout << '|';
							cout << endl;
							if (elem_printed != (memory_size * 2))//останній елемент не тре переносити
							{
								cout << '|';
							}

						}

						if (!is_two_digit(block_id))
						{
							cout << "x";
							change_number_of_printed(elem_printed);
						}

						//вивисти елементи із блоку
						for (int j = block_id * 2; j != (block_inf_iter->size + block_id - 2) * 2; ++j)
						{
							cout << 'x';//вивести елемент 
							change_number_of_printed(elem_printed);
						}

						//всі елементи надруковані, друкуємо символ як кінець блоку пам'яті
						cout << 'x';
						change_number_of_printed(elem_printed);
						cout << '|';
						change_number_of_printed(elem_printed);
						//індентифікатор для наступного елемента += розмір теперішнього 
						block_id += block_inf_iter->size;
						//пересуваємо вказівник на наступний елемент
						++block_inf_iter;
					}
					else//індентифікатор не співпав => друкуємо пусте місце
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
				else//якщо немає
				{
					//друкуємо решту елементів, що залишилось
					for (int j = elem_printed; j != memory_size * 2; ++j)
					{
						cout << ' ';
						change_number_of_printed(elem_printed);
					}
				}
			}
		}
		else//якщо немає елементів взагалі
		{
			//кількість рядів = максимальний розмір / ширину виводу
			int amount_of_row = int(ceil(double(memory_size) / output_witdth));
			//друк пустої карти
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
		// перевірка на вмістимість
		size += num_cells;
		if (size > memory_size)
		{
			throw "Memory is Full";
			abort();
		}

		//виділення блоків
		
		//кількість пустого місця між рядами
		unsigned int all_free_space = 0;
		// якщо память не впорядкована
		if (!is_structured)
		{
			int id = 0;
			int amount_of_free_space = 0;

			// перевірка чи є місця між рядами і вставлення в середину
			for (auto i = block_inf.begin(); i != block_inf.end(); ++i)
			{
				amount_of_free_space = amount_of_free_space - i->id;
				if (amount_of_free_space)
				{
					// врахомуємо кількість пам'яті між рядами
					all_free_space += abs(amount_of_free_space);
				}
					
				//якщо є місце => вставляємо
				if (abs(amount_of_free_space) >= num_cells)
				{
					// вставка до елемента інформації про нього
					block_inf.emplace(i, id, num_cells);
					// вставка елементів
					memory.insert(memory.begin() + id, num_cells, 'x');
					// завершуємо роботу
					return id;
				}
				
				amount_of_free_space = i->size + i->id;

				id += i->size;
			}

			// якщо розміру достатньо, але не достатньо місця у кінці => дефрагментуємо
			if (memory_size - (this->size - num_cells) - all_free_space < num_cells) 
			{
				defragmentation();	
				all_free_space = 0;//пустого місця більше немає
			}			
		}

		//якщо память впорядкована(дефрагментована) => вставка у кінець

		//запам'ятати індентифікатор(рівний розміру памяті + пусте місце) і розмір данного блоку
		block_inf.emplace_back(memory.size() + all_free_space, num_cells);
		
		//вставляємо елементи на кінець
		memory.insert(memory.end(),num_cells, 'x');

		//повертаємо індентифікатор останнього
		return block_inf.rbegin()->id;


		// виділення блоків, стара версія

		// якщо память не впорядкована
		/*if (!is_structured)
		{
			int id = 0;
			int amount_of_free_space = 0;
			unsigned int all_free_space = 0;

			// перевірка чи є місця між рядами і вставлення в середину
			for (auto i = block_inf.begin(); i != block_inf.end(); ++i)
			{
				amount_of_free_space = amount_of_free_space - i->id;
				if (amount_of_free_space)
				{
					all_free_space += abs(amount_of_free_space);
				}

				//якщо є місце => вставляємо
				if (abs(amount_of_free_space) >= num_cells)
				{
					// вставка до елемента інформації про нього
					block_inf.emplace(i, id, num_cells);
					// вставка елементів
					memory.insert(memory.begin() + id, num_cells, 'x');
					// завершуємо роботу
					return id;
				}

				amount_of_free_space = i->size + i->id;

				id += i->size;
			}

			// якщо достатньо місця у кінці => вставка у кінець
			if (memory_size - (this->size - num_cells) - all_free_space >= num_cells)
			{
				//запам'ятати індентифікатор(рівний розміру памяті) і розмір данного блоку
				block_inf.emplace_back(memory.size() + all_free_space, num_cells);

				//вставляємо елементи на кінець
				memory.insert(memory.end(), num_cells, 'x');

				//повертаємо індентифікатор останнього
				return block_inf.rbegin()->id;
			}

			//розміру достатньо, але не місця => дефрагментуємо
			defragmentation();
		}
		//якщо память впорядкована(дефрагментована) => вставка у кінець

		//запам'ятати індентифікатор(рівний розміру памяті) і розмір данного блоку
		block_inf.emplace_back(memory.size(), num_cells);

		//вставляємо елементи на кінець
		memory.insert(memory.end(), num_cells, 'x');

		//повертаємо індентифікатор останнього
		return block_inf.rbegin()->id;*/
	}
	void free(int block_id)
	{
		// початок в діапазоні видалення
		auto start = memory.begin();
		for (auto i = block_inf.begin(); i != block_inf.end(); ++i)//цикл по індексах
		{
			// якщо індекс задано правильно => видаляєм елемент, завершуємо роботу
			if (i->id == block_id)
			{
				// якщо видалення не із кінця => память перестає бути впорядковаю
				is_structured &= (i == --block_inf.end()) ? true : false;
				// видалити в діапазоні num[block_id (start), block_id + memory_occupied]
				memory.erase(start, start + i->size);
				// змінюємо значення пам'яті в момент часу
				size -= i->size;
				// видаляємо значення виділеної кількості пам'яті
				block_inf.erase(i);
				// якщо пам'ять не зайнята => пам'ять є впорядкованою
				if (size == 0)
				{
					is_structured = true;
				}
				
				return;
			}

			start += i->size;
		}
		//якщо ітератор дійшов до кінця => індекс неправильний => сповіщаємо користувачеві
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
		is_structured = true;//пам'ять стає впорядкованою

		//міняємо індекси на правильні
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