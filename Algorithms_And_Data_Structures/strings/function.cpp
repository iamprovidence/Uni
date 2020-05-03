#include "Header.h"

Node::Node()
{
	letter = 0;
	next = nullptr;
	previous = nullptr;
};
Node::Node(char a, Node *n = nullptr, Node *p = nullptr)
{
	letter = a;
	next = n;
	previous = p;
}

int better_than_string::get_array_size(char*A)
{
	int counter = 0;
	for (uint i = 0; A[i] != '\0' ; i++)
	{
		++counter;
	}
	return counter;
}
int better_than_string::get_array_size(const char*A)
{
	int counter = 0;
	for (uint i = 0; A[i] != '\0'; i++)
	{
		++counter;
	}
	return counter;
}
Node * better_than_string::find_shorter_way(int i, uint & counter)
{
	Node * finder = word;
	//якщо користувач вказав позицію поза діапазоном, то завжди починати з початку
	if (i < this->length && i >= 0)
	{
		if (i < length / 2) //пошук з початку
		{
			counter = 0;
			finder = word;

			while (i != counter)
			{
				++counter;
				finder = finder->next;
			}
		}
		else//пошук з кінця
		{
			counter = length - 1;
			finder = the_end;

			while (i != counter)
			{
				--counter;
				finder = finder->previous;
			}
		}
	}
	
	return finder;
}
int better_than_string::get_length()const
{
	return length;
}
better_than_string better_than_string::substr(int i, int j)
{
	if (j >= i && i + 1 <= length && j + 1 <= length)
	{
		uint counter_i;
		Node * finder_i = find_shorter_way(i, counter_i);
		uint counter_j;
		Node * finder_j = find_shorter_way(j, counter_j);

		length = j - i + 1;

		Node * victim = word;
		word = finder_i;

		//очистити букви, що лишились
		while (victim != word)
		{
			Node * buffer = victim;
			victim = victim->next;
			delete buffer;
		}
		finder_i->previous = nullptr;

		victim = the_end;
		the_end = finder_j;
		while (victim != the_end)
		{
			Node * buffer = victim;
			victim = victim->previous;
			delete buffer;
		}
		finder_j->next = nullptr;
	}
	return *this;
}
char * better_than_string::create_array()
{
	int n = length;
	char *result = new char[n];
	result[n] = '\0';
	Node * letter = the_end;
	char c;

	while (n > 0)
	{
		c = letter->letter;
		result[--n] = c;
		letter = letter->previous;
	}

	return result;
}
int better_than_string::find(char A)
{
	uint counter = 0;
	Node * finder = word;
	while (finder->letter != A)
	{
		++counter;
		finder = finder->next;
		if (!finder)
		{
			return -1;
		}
	}
	return counter;
}
int better_than_string::find(char * A)
{
	int counter = 0;
	int position = -1;
	uint i = 0;
	uint size = get_array_size(A);
	Node * finder = word;
	bool triggered = false;

	while (finder)
	{
		//якщо літера співпадає по шаблону
		if (finder->letter == A[i])
		{
			triggered = true;
			position = counter;
		}
		else
		{
			triggered = false;
			position = -1;
		}
		//якщо є співпадіння по першій літері шаблону, то перевіряє наступну
		if (triggered)
		{
			++i;
		}
		else//нема співпадіння, повертається на першу літеру
		{
			i = 0;
		}

		if (i == size)
		{
			//повертаю позицію в місце де починається шаблон
			position = position - size + 1;
			return position;
		}

		++counter;
		finder = finder->next;
	}
	
	return -1;
}
int better_than_string::find(char A, int place)
{
	if (place+1 <= length)
	{
		uint counter;
		Node * finder = find_shorter_way(place, counter);
		//пошук
		while (finder->letter != A)
		{
			++counter;
			finder = finder->next;
			if (!finder)
			{
				return -1;
			}
		}

		return counter;
	}
	return -1;
	
}
int better_than_string::find(char * A, int place)
{
	uint counter = 0;
	int position = -1;
	uint i = 0;
	uint size = get_array_size(A);
	Node * finder = find_shorter_way(place, counter);
	bool triggered = false;

	while (finder)
	{
		//якщо літера співпадає по шаблону
		if (finder->letter == A[i])
		{
			triggered = true;
			position = counter;
		}
		else
		{
			triggered = false;
			position = -1;
		}
		//якщо є співпадіння по першій літері шаблону, то перевіряє наступну
		if (triggered)
		{
			++i;
		}
		else//нема співпадіння, повертається на ппершу літеру
		{
			i = 0;
		}

		if (i == size)
		{
			//повертаю позицію в місце де починається шаблон
			position = position - size + 1;
			return position;
		}

		++counter;
		finder = finder->next;
	}

	return -1;
}
//підстановка
//'A'->'B'		'A'->'B',from		'A'->'B', to		'A'->'B',from,to
//'A'->"BC"		'A'->"BC",from		'A'->"BC", to		'A'->"BC",from,to
//"AC"->'B'		"AC"->'B',from		"AC"->'B', to		"AC"->'B',from,to
//"AB"->"CD"	"AB"->"CD",from		"AB"->"CD", to		"AB"->"CD",from,to
better_than_string better_than_string::replace(int start_pos, int amount, char * B)
{
	Node * current = word;
	uint size = get_array_size(B);
	uint position = 0;

	bool end = false;
	bool start = false;

	if (start_pos >= length)
	{
		throw "Not in range";
	}

	if (start_pos == 0)
	{
		start = true;
	}
	if (start_pos >= length - amount)
	{
		end = true;
	}

	while (position != start_pos)
	{
		current = current->next;
		++position;
	}

	//ств. список який буде вставлятись без заголовної ланки
	Node * change = new Node(B[0]);
	Node * bottom = change;

	for (uint i = 1; i < size; i++)
	{
		bottom->next = new Node(B[i]);
		Node *prev = bottom;
		bottom = bottom->next;
		bottom->previous = prev;
	}
	Node * victim = current;
	//звязки
	//з початку
	if (start)
	{
		goto next;
	}
	else if (end)
	{
		current->previous->next = change;
		change->previous = current->previous;
		the_end = bottom;
	}
	else
	{
		current->previous->next = change;
		change->previous = current->previous;
	}
next:
	//переміщуюсь на ост букву шаблону
	for (uint i = 0; i < amount - 1; i++)
	{
		current = current->next;
	}
	//з кінця
	if (!end)
	{
		current->next->previous = bottom;
		bottom->next = current->next;
	}
	//виходжу за межі шаблону
	if (current->next)
	{
		current = current->next;
	}
	if (start)
	{
		word = change;
	}
	//кінець звязків
	//видалення  букв, що міняли
	for (uint i = 0; i < amount - 1; i++)
	{
		Node * add_victim = victim;
		victim = victim->next;
		delete add_victim;
	}
	change = nullptr;
	bottom = nullptr;
	delete victim;

	//розмір
	if (B != "")
	{
		length += size - amount;
	}
	else
	{
		length -= amount;
	}
	

	//якщо міняли на пустий символ
	current = word;
	uint pos = 0;
	while (current)
	{
		if (current->letter == '\0')
		{
			Node * victim = current;
			if (pos == 0)
			{
				word = current->next;
				current = current->next;
			}
			else if (pos == length)
			{
				the_end = current->previous;
				//--length;
			}
			else
			{
				current->previous->next = current->next;
				current->next->previous = current->previous;
			}

			current = current->next;
			delete victim;
			word->previous = nullptr;
			the_end->next = nullptr;
			++pos;
		}
		else
		{
			current = current->next;
			++pos;
		}
	}


	return *this;
}
better_than_string better_than_string::replace(int start_pos, int amount, better_than_string B)
{
	return replace(start_pos, amount, B.create_array());
}
better_than_string better_than_string::replace(char A, char B)
{
	Node * current = word;

	while (current)
	{
		if (current->letter == A)
		{
			current->letter = B;
		}
		
		current = current->next;
	}

	return *this;
}
better_than_string better_than_string::replace(char A, char * B)
{
	Node * current = word;
	uint size = get_array_size(B);
	uint position = 0;

	while (current)
	{
		bool end = false;
		bool start = false;
		if (current->letter == A)
		{
			//+розмір - 1 буква яку забираю
			length += size - 1;
			//ств. список який буде вставлятись без заголовної ланки
			Node * change = new Node(B[0]);
			Node * bottom = change;

			for (uint i = 1; i < size; i++)
			{
				bottom->next = new Node(B[i]);
				Node *prev = bottom;
				bottom = bottom->next;
				bottom->previous = prev;
			}
			
			if (current->previous == nullptr)
			{
				start = true;
			}

			//звязки
			bottom->next = current->next;
			change->previous = current->previous;
			if (start)
			{
				word = change;
			}
			else
			{
				current->previous->next = change;
			}
			
			Node * victim = current;

			if (position == length - size)
			{
				end = true;
			}

			if (!end)
			{
				current = current->next;
				current->previous = bottom;
				++position;
			}
			else
			{
				the_end = bottom;
			}
			
			delete victim;
			change = nullptr;
			bottom = nullptr;

			if (end)
			{
				break;
			}
		}
		else
		{
			current = current->next;
			++position;
		}
	}

	return *this;
}
better_than_string better_than_string::replace(char A, char * B, int place)
{
	uint score;
	Node * current = find_shorter_way(place, score);
	uint size = get_array_size(B);

	while (current)
	{
		if (current->letter == A)
		{
			//+розмір - 1 буква яку забираю
			length += size - 1;
			//ств. список який буде вставлятись без заголовної ланки
			Node * change = new Node(B[0]);
			Node * bottom = change;
			for (uint i = 1; i < size; i++)
			{
				bottom->next = new Node(B[i]);
				Node *prev = bottom;
				bottom = bottom->next;
				bottom->previous = prev;
			}

			bottom->next = current->next;
			change->previous = current->previous;
			current->previous->next = change;
			Node * victim = current;
			current = current->next;
			current->previous = bottom;

			delete victim;
			change = nullptr;
			bottom = nullptr;
		}
		else
		{
			current = current->next;
		}
	}

	return *this;
}
better_than_string better_than_string::replace(char A, char * B, bool is_only_some_need, int to)
{
	return	is_only_some_need ? this->replace(A, B, 0, to) : *this;
}
better_than_string better_than_string::replace(char A, char * B, int place, int to)
{
	uint score;
	Node * current = find_shorter_way(place, score);
	uint size = get_array_size(B);
	if (place <= to)
	{
		while (current)
		{
			if (current->letter == A)
			{
				//+розмір - 1 буква яку забираю
				length += size - 1;
				//ств. список який буде вставлятись без заголовної ланки
				Node * change = new Node(B[0]);
				Node * bottom = change;
				for (uint i = 1; i < size; i++)
				{
					bottom->next = new Node(B[i]);
					Node *prev = bottom;
					bottom = bottom->next;
					bottom->previous = prev;
				}

				bottom->next = current->next;
				change->previous = current->previous;
				current->previous->next = change;
				Node * victim = current;
				current = current->next;
				current->previous = bottom;

				delete victim;
				change = nullptr;
				bottom = nullptr;

			}
			else
			{
				current = current->next;
			}

			if (score == to)
			{
				break;
			}
			++score;
		}
	}

	return *this;
}
better_than_string better_than_string::replace(char * A, char B)
{
	Node * current = word;
	uint position = 0;
	while (current)
	{
		if (find(A,position) != -1)
		{
			//якщо перша/остання ланка, то інші звязки
			bool start = false;
			bool end = false;
			//співпадіння по шаблону
			uint start_template = find(A,position);

			uint amount = get_array_size(A) - 1;
			length -= amount;
			//пошук початку шаблону
			
			while (position != start_template)
			{
				current = current->next;
				++position;
			}
			
			Node *change = new Node(B);

			if (position != 0)
			{
				current->previous->next = change;
				change->previous = current->previous;
				current->previous = nullptr;//victim
				position -= amount;
			}
			else
			{
				start = true;
			}
			
			if (amount + start_template == length)
			{
				end = true;
			}

			//переміщуюсь на ост букву шаблону
			for (uint i = 0; i < amount; i++)
			{
				current = current->next;
				++position;
			}

			Node * victim = current;
			//виходжу за межі шаблону
			if (current->next && !end)
			{
				current = current->next;
				++position;
			}

			if (start)
			{
				current->previous = nullptr;
				word = change;
				position -= amount;
			}
			if (end)
			{
				the_end = change;
				current = nullptr;
			}
			if (current)
			{
				current->previous = change;
				change->next = current;
			}
			
			for (uint i = 0; i < amount; i++)
			{
				Node * add_victim = victim;
				victim = victim->previous;
				delete add_victim;
			}
			change = nullptr;
			delete victim;
		}
		else
		{
			current = current->next;
			++position;
		}
	}
	return *this;
}
better_than_string better_than_string::replace(char A, char B, int place)
{
	uint counter;
	Node * current = find_shorter_way(place, counter);

	while (current)
	{
		if (current->letter == A)
		{
			current->letter = B;
		}

		current = current->next;
	}

	return *this;
}
better_than_string better_than_string::replace(char A, char B, bool is_only_some_need, int to)
{
	return	is_only_some_need ? this->replace(A,B,0,to) : *this;
}
better_than_string better_than_string::replace(char A, char B, int place, int to)
{
	uint counter;
	Node * current = find_shorter_way(place, counter);

	if (place <= to)
	{
		while (current)
		{
			if (current->letter == A)
			{
				current->letter = B;
			}

			current = current->next;

			if (counter == to)
			{
				break;
			}
			++counter;
		}
	}
	
	return *this;
}
better_than_string better_than_string::replace(char * A, char B, int place)
{
	uint position;
	Node * current = find_shorter_way(place,position);
	while (current)
	{
		if (find(A, position) != -1)
		{
			//якщо перша/остання ланка, то інші звязки
			bool start = false;
			bool end = false;
			//співпадіння по шаблону
			uint start_template = find(A, position);

			uint amount = get_array_size(A) - 1;
			length -= amount;
			//пошук початку шаблону

			while (position != start_template)
			{
				current = current->next;
				++position;
			}

			Node *change = new Node(B);

			if (position != 0)
			{
				current->previous->next = change;
				change->previous = current->previous;
				current->previous = nullptr;//victim
				position -= amount;
			}
			else
			{
				start = true;
			}

			if (amount + start_template == length)
			{
				end = true;
			}

			//переміщуюсь на ост букву шаблону
			for (uint i = 0; i < amount; i++)
			{
				current = current->next;
				++position;
			}

			Node * victim = current;
			//виходжу за межі шаблону
			if (current->next && !end)
			{
				current = current->next;
				++position;
			}

			if (start)
			{
				current->previous = nullptr;
				word = change;
				position -= amount;
			}
			if (end)
			{
				the_end = change;
				current = nullptr;
			}
			if (current)
			{
				current->previous = change;
				change->next = current;
			}

			for (uint i = 0; i < amount; i++)
			{
				Node * add_victim = victim;
				victim = victim->previous;
				delete add_victim;
			}
			change = nullptr;
			delete victim;
		}
		else
		{
			current = current->next;
			++position;
		}
	}
	return *this;
}
better_than_string better_than_string::replace(char * A, char B, bool is_only_some_need, int to)
{
	return	is_only_some_need ? this->replace(A, B, 0, to) : *this;
}
better_than_string better_than_string::replace(char * A, char B, int place, int to)
{
	uint position;
	Node * current = find_shorter_way(place, position);
	if (place <= to)
	{
		while (current)
		{
			if (find(A, position) != -1)
			{
				//якщо перша/остання ланка, то інші звязки
				bool start = false;
				bool end = false;
				//співпадіння по шаблону
				uint start_template = find(A, position);

				uint amount = get_array_size(A) - 1;
				length -= amount;
				//пошук початку шаблону

				while (position != start_template)
				{
					current = current->next;
					++position;
				}

				Node *change = new Node(B);

				if (position != 0)
				{
					current->previous->next = change;
					change->previous = current->previous;
					current->previous = nullptr;//victim
					position -= amount;
				}
				else
				{
					start = true;
				}

				if (amount + start_template == length)
				{
					end = true;
				}

				//переміщуюсь на ост букву шаблону
				for (uint i = 0; i < amount; i++)
				{
					current = current->next;
					++position;
				}

				Node * victim = current;
				//виходжу за межі шаблону
				if (current->next && !end)
				{
					current = current->next;
					++position;
				}

				if (start)
				{
					current->previous = nullptr;
					word = change;
					position -= amount;
				}
				if (end)
				{
					the_end = change;
					current = nullptr;
				}
				if (current)
				{
					current->previous = change;
					change->next = current;
				}

				for (uint i = 0; i < amount; i++)
				{
					Node * add_victim = victim;
					victim = victim->previous;
					delete add_victim;
				}
				change = nullptr;
				delete victim;
			}
			else
			{
				current = current->next;
				++position;
			}

			if (position == to)
			{
				break;
			}
		}
	}
	return *this;
}
better_than_string better_than_string::replace(char * A, char * B)
{
	Node * current = word;
	uint size_a = get_array_size(A);
	uint size_b = get_array_size(B);
	uint position = 0;

	while (current)
	{
		if (find(A, position) != -1)
		{
			bool end = false;
			bool start = false;
			//пошук початку шаблону
			uint start_template = find(A, position);
			while (position != start_template)
			{
				current = current->next;
				++position;
			}
			//перевіряю чи вставка міняє початок або кінець
			if (position == 0)
			{
				start = true;
			}
			if (position == length - size_a)
			{
				end = true;
			}
			Node * victim = current;
			//ств. список який буде вставлятись без заголовної ланки
			Node * change = new Node(B[0]);
			Node * bottom = change;
			for (uint i = 1; i < size_b; i++)
			{
				bottom->next = new Node(B[i]);
				Node *prev = bottom;
				bottom = bottom->next;
				bottom->previous = prev;
			}
			//звязки
				//з початку
			if (start)
			{
				goto next;
			}
			else if (end)
			{
				current->previous->next = change;
				change->previous = current->previous;
				the_end = bottom;
			}
			else
			{
				current->previous->next = change;
				change->previous = current->previous;
			}
			next:
				//переміщуюсь на ост букву шаблону
			for (uint i = 0; i < size_a - 1; i++)
			{
				current = current->next;
			}
				//з кінця
			if (!end)
			{
				current->next->previous = bottom;
				bottom->next = current->next;
			}
				//виходжу за межі шаблону
			if (current->next)//!end
			{
				current = current->next;
				//++position;
			}
			if (start)
			{
				word = change;
			}
			//кінець звязків
			//видалення  букв, що міняли
			for (uint i = 0; i < size_a - 1; i++)
			{
				Node * add_victim = victim;
				victim = victim->next;
				delete add_victim;
			}
			change = nullptr;
			bottom = nullptr;
			delete victim;
			//змінити розмір
			if (B == "")
			{
				--length;
				++position;
			}
			else
			{
				length += size_b - size_a;
				position += size_b;
			}
			
			if (end)
			{
				break;
			}
			
		}
		else
		{
			break;
		}
	}

	//якщо міняли на пустий символ
	current = word;
	uint pos = 0;
	while (current)
	{
		if (current->letter == '\0')
		{
			Node * victim = current;
			if (pos == 0)
			{
				word = current->next;
				current = current->next;
			}
			else if (pos == length - 1)
			{
				the_end = current->previous;
			}
			else
			{
				current->previous->next = current->next;
				current->next->previous = current->previous;
			}
			
			current = current->next;
			delete victim;
			word->previous = nullptr;
			the_end->next = nullptr;
			++pos;
			--length;
		}
		else
		{
			current = current->next;
			++pos;
		}
	}

	return *this;
}
better_than_string better_than_string::replace(char * A, char * B, int place)
{
	uint position;
	Node * current = find_shorter_way(place, position);
	uint size_a = get_array_size(A);
	uint size_b = get_array_size(B);

	while (current)
	{
		if (find(A, position) != -1)
		{
			bool end = false;
			bool start = false;
			//пошук початку шаблону
			uint start_template = find(A, position);
			while (position != start_template)
			{
				current = current->next;
				++position;
			}
			//перевіряю чи вставка міняє початок або кінець
			if (position == 0)
			{
				start = true;
			}
			if (position == length - size_a)
			{
				end = true;
			}
			Node * victim = current;
			//ств. список який буде вставлятись без заголовної ланки
			Node * change = new Node(B[0]);
			Node * bottom = change;
			for (uint i = 1; i < size_b; i++)
			{
				bottom->next = new Node(B[i]);
				Node *prev = bottom;
				bottom = bottom->next;
				bottom->previous = prev;
			}
			//звязки
			//з початку
			if (start)
			{
				goto next;
			}
			else if (end)
			{
				current->previous->next = change;
				change->previous = current->previous;
				the_end = bottom;
			}
			else
			{
				current->previous->next = change;
				change->previous = current->previous;
			}
		next:
			//переміщуюсь на ост букву шаблону
			for (uint i = 0; i < size_a - 1; i++)
			{
				current = current->next;
			}
			//з кінця
			if (!end)
			{
				current->next->previous = bottom;
				bottom->next = current->next;
			}
			//виходжу за межі шаблону
			if (current->next)//!end
			{
				current = current->next;
				//++position;
			}
			if (start)
			{
				word = change;
			}
			//кінець звязків
			//видалення  букв, що міняли
			for (uint i = 0; i < size_a - 1; i++)
			{
				Node * add_victim = victim;
				victim = victim->next;
				delete add_victim;
			}
			change = nullptr;
			bottom = nullptr;
			delete victim;
			//змінити розмір
			if (B == "")
			{
				--length;
				++position;
			}
			else
			{
				length += size_b - size_a;
				position += size_b;
			}

			if (end)
			{
				break;
			}

		}
		else
		{
			break;
		}
	}

	//якщо міняли на пустий символ
	current = word;
	uint pos = 0;
	while (current)
	{
		if (current->letter == '\0')
		{
			Node * victim = current;
			if (pos == 0)
			{
				word = current->next;
				current = current->next;
			}
			else if (pos == length - 1)
			{
				the_end = current->previous;
			}
			else
			{
				current->previous->next = current->next;
				current->next->previous = current->previous;
			}

			current = current->next;
			delete victim;
			++pos;
			--length;
		}
		else
		{
			current = current->next;
			++pos;
		}
	}

	return *this;
}
better_than_string better_than_string::replace(char * A, char * B, bool is_only_some_need, int to)
{
	return	is_only_some_need ? this->replace(A, B, 0, to) : *this;
}
better_than_string better_than_string::replace(char * A, char * B, int place, int to)
{
	uint position;
	Node * current = find_shorter_way(place, position);
	uint size_a = get_array_size(A);
	uint size_b = get_array_size(B);

	while (current)
	{
		if (find(A, position) != -1)
		{
			bool end = false;
			bool start = false;
			//пошук початку шаблону
			uint start_template = find(A, position);
			while (position != start_template)
			{
				current = current->next;
				++position;
			}
			//перевіряю чи вставка міняє початок або кінець
			if (position == 0)
			{
				start = true;
			}
			if (position == length - size_a)
			{
				end = true;
			}
			Node * victim = current;
			//ств. список який буде вставлятись без заголовної ланки
			Node * change = new Node(B[0]);
			Node * bottom = change;
			for (uint i = 1; i < size_b; i++)
			{
				bottom->next = new Node(B[i]);
				Node *prev = bottom;
				bottom = bottom->next;
				bottom->previous = prev;
			}
			//звязки
			//з початку
			if (start)
			{
				goto next;
			}
			else if (end)
			{
				current->previous->next = change;
				change->previous = current->previous;
				the_end = bottom;
			}
			else
			{
				current->previous->next = change;
				change->previous = current->previous;
			}
		next:
			//переміщуюсь на ост букву шаблону
			for (uint i = 0; i < size_a - 1; i++)
			{
				current = current->next;
			}
			//з кінця
			if (!end)
			{
				current->next->previous = bottom;
				bottom->next = current->next;
			}
			//виходжу за межі шаблону
			if (current->next)//!end
			{
				current = current->next;
				//++position;
			}
			if (start)
			{
				word = change;
			}
			//кінець звязків
			//видалення  букв, що міняли
			for (uint i = 0; i < size_a - 1; i++)
			{
				Node * add_victim = victim;
				victim = victim->next;
				delete add_victim;
			}
			change = nullptr;
			bottom = nullptr;
			delete victim;
			//змінити розмір
			if (B == "")
			{
				--length;
				++position;
			}
			else
			{
				length += size_b - size_a;
				position += size_b;
			}

			if (end || position == to)
			{
				break;
			}

		}
		else
		{
			break;
		}
	}

	//якщо міняли на пустий символ
	current = word;
	uint pos = 0;
	while (current)
	{
		if (current->letter == '\0')
		{
			Node * victim = current;
			if (pos == 0)
			{
				word = current->next;
				current = current->next;
			}
			else if (pos == length - 1)
			{
				the_end = current->previous;
			}
			else
			{
				current->previous->next = current->next;
				current->next->previous = current->previous;
			}

			current = current->next;
			delete victim;
			++pos;
			--length;
		}
		else
		{
			current = current->next;
			++pos;
		}
	}

	return *this;
}

better_than_string & better_than_string::reverse()
{
	Node * reverse = word;

	while (reverse != nullptr)
	{
		swap(reverse->previous, reverse->next);
		
		reverse = reverse->previous;
	}

	swap(word, the_end);

	return *this;
}
better_than_string::better_than_string()
{
	length = 0;
	word = nullptr;
	the_end = nullptr;
}
better_than_string::better_than_string(char * A)
{
	//без заголовної ланки
	length = get_array_size(A);
	word = new Node(A[0]);
	the_end = word;
	for (uint i = 1; i < length; i++)
	{
		the_end->next = new Node(A[i]);
		Node *prev = the_end;
		the_end = the_end->next;
		the_end->previous = prev;
	}
}
better_than_string::better_than_string(const char * A)
{
	//без заголовної ланки
	length = get_array_size(A);
	word = new Node(A[0]);
	the_end = word;
	for (uint i = 1; i < length; i++)
	{
		the_end->next = new Node(A[i]);
		Node *prev = the_end;
		the_end = the_end->next;
		the_end->previous = prev;
	}
}
better_than_string better_than_string::operator=(char * A)
{
	//без заголовної ланки
	length = get_array_size(A);
	word = new Node(A[0]);
	the_end = word;
	for (uint i = 1; i < length; i++)
	{
		the_end->next = new Node(A[i]);
		Node *prev = the_end;
		the_end = the_end->next;
		the_end->previous = prev;
	}
	return better_than_string();
}
better_than_string::better_than_string(const better_than_string & S)
{
	length = S.length;
	if (S.length > 0)
	{
		word = new Node(S.word->letter);
		the_end = word;
		Node * bottom = S.word->next;
		for (uint i = 1; i < length; i++)
		{
			the_end->next = new Node(bottom->letter);

			Node *prev = the_end;
			the_end = the_end->next;
			the_end->previous = prev;

			bottom = bottom->next;
		}
	}
	else
	{
		word = nullptr;
		the_end = nullptr;
	}
}
better_than_string & better_than_string::operator=(const better_than_string & S)
{
	if (this != &S)
	{
		length = S.length;
		if (S.length > 0)
		{
			word = new Node(S.word->letter);
			the_end = word;
			Node * bottom = S.word->next;
			for (uint i = 1; i < length; i++)
			{
				the_end->next = new Node(bottom->letter);

				Node *prev = the_end;
				the_end = the_end->next;
				the_end->previous = prev;

				bottom = bottom->next;
			}
		}
		else
		{
			word = nullptr;
			the_end = nullptr;
		}
	}
	return *this;
}
better_than_string::~better_than_string()
{
	this->remove();
}
void better_than_string::remove()
{
	Node * victim;

	while (word != nullptr)
	{
		victim = word;
		word = word->next;
		delete victim;
	}
	the_end = nullptr;
	length = NULL;
}
bool better_than_string::is_empty()
{
	return length == 0 ? true : false;
}
ostream &operator<<(ostream&os, const better_than_string &S)
{
	if (S.length > 0)
	{
		Node * print = S.word;
		while (print != nullptr)
		{
			if (print->letter == '\0')
			{
				return os;
			}
			os << print->letter;
			print = print->next;
		}
	}
	return os;
}
istream &operator>>(istream & is, better_than_string & S)
{
	char BUFF[2048];

	is.getline(BUFF, sizeof BUFF);
	S = BUFF;

	return is;
}
char& better_than_string::operator[](int n)
{
	if (n < 0 || n > length - 1)
	{
		abort();
	}
	uint counter;
	Node * current = find_shorter_way(n, counter);

	return current->letter;
}
//A == A	A != a	A > a	A > B	a > b	Z > a
//A != abc	aBc > abA	abc >= abc
bool better_than_string::operator<(const better_than_string &S)const
{
	if (length == S.length)
	{
		Node * first = word;
		Node * second = S.word;

		do
		{
			if (first->letter > second->letter)
			{
				return true;
			}
			else if (first->letter == second->letter)
			{
				first = first->next;
				second = second->next;
			}
			else
			{
				return false;
			}

		} while (first != nullptr);
	}
	return false;
}
bool better_than_string::operator<=(const better_than_string &S)const
{
	if (length == S.length)
	{
		Node * first = word;
		Node * second = S.word;

		do
		{
			if (first->letter >= second->letter)
			{
				first = first->next;
				second = second->next;
			}
			else
			{
				return false;
			}

		} while (first != nullptr);

		return true;
	}
	return false;
}
bool better_than_string::operator>(const better_than_string &S)const
{
	if (length == S.length)
	{
		Node * first = word;
		Node * second = S.word;

		do
		{
			if (first->letter < second->letter)
			{
				return true;
			}
			else if(first->letter == second->letter)
			{
				first = first->next;
				second = second->next;
			}
			else
			{
				return false;
			}

		} while (first != nullptr);
	}
	return false;
}
bool better_than_string::operator>=(const better_than_string &S)const
{
	if (length == S.length)
	{
		Node * first = word;
		Node * second = S.word;

		do
		{
			if (first->letter <= second->letter)
			{
				first = first->next;
				second = second->next;
			}
			else
			{
				return false;
			}

		} while (first != nullptr);

		return true;
	}
	return false;
}
bool better_than_string::operator==(const better_than_string &S)const
{
	if (length == S.length)
	{
		Node * first = word;
		Node * second = S.word;

		do
		{
			//усі рівні
			if (first->letter == second->letter)
			{
				first = first->next;
				second = second->next;
			}
			else
			{
				return false;
			}

		} while (first != nullptr);

		return true;
	}
	return false;
}
bool better_than_string::operator!=(const better_than_string &S)const
{
	if (length == S.length)
	{
		Node * first = word;
		Node * second = S.word;

		do
		{
			//хоча б 1 не збігається
			if (first->letter != second->letter)
			{
				return true;
			}
			else
			{
				first = first->next;
				second = second->next;
			}

		} while (first != nullptr);

		return false;
	}
	//різні роміри, не рівні
	return true;
}
//конкантенація
//C = A + B; C+=A; 
//C = A + 'a'; C = 'a' + A;  C+= 'a';
//C = A + "ab"; C = "ab" + A; C+= "ab";
better_than_string better_than_string::operator+(const better_than_string & S)
{
	better_than_string kon = *this;
	better_than_string add_kon = S;

	kon.length = length + S.length;
	kon.the_end->next = add_kon.word;
	add_kon.word->previous = kon.the_end;
	kon.the_end = add_kon.the_end;

	add_kon.word = nullptr;
	add_kon.the_end = nullptr;

	return kon;
}
better_than_string better_than_string::operator+=(const better_than_string & S)
{
	length += S.length;
	better_than_string additional = S;

	the_end->next = additional.word;
	additional.word->previous = the_end;
	the_end = additional.the_end;

	additional.word = nullptr;
	additional.the_end = nullptr;

	return *this;
}
better_than_string better_than_string::operator+=(char A)
{
	++length;
	the_end->next = new Node(A);
	Node *temp = the_end;
	the_end = the_end->next;
	the_end->previous = temp;

	return *this;
}
better_than_string better_than_string::operator+(char A)
{
	better_than_string kon = *this;

	++kon.length;
	kon.the_end->next = new Node(A);
	Node *temp = kon.the_end;
	kon.the_end = kon.the_end->next;
	kon.the_end->previous = temp;
	
	return kon;
}
better_than_string better_than_string::operator+=(char *& A)
{
	better_than_string C = A;
	(*this) += C;

	return *this;
}
better_than_string better_than_string::operator+(char *& A)
{
	better_than_string C = A;
	better_than_string T = *this;

	return T + C;
}
better_than_string operator+(char A, const better_than_string & S)
{
	better_than_string kon = S;

	++kon.length;
	kon.word->previous = new Node(A);
	Node *temp = kon.word;
	kon.word = kon.word->previous;
	kon.word->next = temp;

	return kon;
}
better_than_string operator+(const char * A, const better_than_string & S)
{
	better_than_string C = A;
	better_than_string T = S;

	return C + T;
}