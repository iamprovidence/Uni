#include "Header.h"

SparseMatrix::SparseMatrix()
{
	i = 0;
	j = 0;
}
SparseMatrix::SparseMatrix(int q)
{
	i = q;
	j = q;

	rows = new Element*[i];
	for (size_t i = 0; i < this->i; i++)
	{
		rows[i] = nullptr;
	}
	cols = new Element*[j];
	for (size_t j = 0; j < this->j; j++)
	{
		cols[j] = nullptr;
	}
}
SparseMatrix::SparseMatrix(int n, int m)
{
	i = n;
	j = m;

	rows = new Element*[i];
	for (size_t i = 0; i < this->i; i++)
	{
		rows[i] = nullptr;
	}
	cols = new Element*[j];
	for (size_t j = 0; j < this->j; j++)
	{
		cols[j] = nullptr;
	}
}
SparseMatrix::SparseMatrix(const SparseMatrix& A)
{
	this->i = A.i;
	this->j = A.j;
	
	this->rows = new Element*[i];
	for (size_t i = 0; i < this->i; i++)
	{
		this->rows[i] = nullptr;
	}
	this->cols = new Element*[j];
	for (size_t j = 0; j < this->j; j++)
	{
		this->cols[j] = nullptr;
	}
	
	for (size_t i = 0; i < this->i; i++)
	{
		if (A.rows[i] != nullptr)
		{
			Element * copy = nullptr;
			Element * origin = A.rows[i];
			
			do
			{
				//створюю ланку із такими самими данними
				copy = new Element(origin->i, origin->j, origin->value);
				//пересуваю в оригіналі
				origin = origin->right;

				//приєднюю рядки
				if (rows[copy->i] == nullptr)
				{
					rows[copy->i] = copy;
					copy->right = rows[copy->i];
				}
				else
				{
					Element * find = rows[copy->i];//колонка
					while (find->right != rows[copy->i])//пошук перед ост
					{
						find = find->right;
					}
					find->right = copy;
					copy->right = rows[copy->i];
				}
				//приєднюю стовпчики
				if (cols[copy->j] == nullptr)
				{
					cols[copy->j] = copy;
					copy->down = cols[copy->j];
				}
				else
				{
					Element * find = cols[copy->j];
					while (find->down != cols[copy->j])
					{
						find = find->down;
					}
					find->down = copy;
					copy->down = cols[copy->j];
				}

			} while (origin != A.rows[i]);
		}
	}
}
SparseMatrix::~SparseMatrix()
{
	if (i<0)
	{
		for (size_t i = 0; i < this->i; i++)
		{
			delete[]rows[i];
		}
		delete[]rows;
	}
	if (j<0)
	{
		for (size_t j = 0; j < this->j; j++)
		{
			delete[]cols[j];
		}
		delete[]cols;
	}
}
SparseMatrix& SparseMatrix::operator=(const SparseMatrix &A)
{
	if (this != &A)
	{
		this->i = A.i;
		this->j = A.j;

		this->rows = new Element*[i];
		for (size_t i = 0; i < this->i; i++)
		{
			this->rows[i] = nullptr;
		}
		this->cols = new Element*[j];
		for (size_t j = 0; j < this->j; j++)
		{
			this->cols[j] = nullptr;
		}

		for (size_t i = 0; i < this->i; i++)
		{
			if (A.rows[i] != nullptr)
			{
				Element * copy = nullptr;
				Element * origin = A.rows[i];

				do
				{
					//створюю ланку із такими самими данними
					copy = new Element(origin->i, origin->j, origin->value);
					//пересуваю в оригіналі
					origin = origin->right;

					//приєднюю рядки
					if (rows[copy->i] == nullptr)
					{
						rows[copy->i] = copy;
						copy->right = rows[copy->i];
					}
					else
					{
						Element * find = rows[copy->i];//колонка
						while (find->right != rows[copy->i])//пошук перед ост
						{
							find = find->right;
						}
						find->right = copy;
						copy->right = rows[copy->i];
					}
					//приєднюю стовпчики
					if (cols[copy->j] == nullptr)
					{
						cols[copy->j] = copy;
						copy->down = cols[copy->j];
					}
					else
					{
						Element * find = cols[copy->j];
						while (find->down != cols[copy->j])
						{
							find = find->down;
						}
						find->down = copy;
						copy->down = cols[copy->j];
					}

				} while (origin != A.rows[i]);
			}
		}
	}
	return *this;
}

SparseMatrix::Element* SparseMatrix::get_ptr(int i, int j)const
{
	if (rows[i] != nullptr)
	{
		Element* find = rows[i];

		while (find->j < j && find->right != rows[i])
		{
			find = find->right;
		}
		if (find->j == j)
		{
			return find;
		}
	}
	return 0;
}
double SparseMatrix::get(int i, int j)const
{
	return get_ptr(i, j) ? get_ptr(i, j)->value : 0;
}
bool SparseMatrix::is_set(int i, int j)const
{
	return get(i, j);
}
bool SparseMatrix::set(int i, int j, double x)
{
	if (i >= 0 && i < this->i && j >= 0 && j < this->j)
	{
		if (Element *E = get_ptr(i,j) )
		{
			if (x == 0)
			{
				remove(E);
				return true;
			}
			else
			{
				change(x,E);
				return true;
			}
		}
		else
		{
			if (x == 0)
			{
				return true;
			}
			else
			{
				insert(i, j, x);
				return true;
			}
		}
	}
	return false;
}
//TODO
SparseMatrix SparseMatrix::fromUsualMatrix(double ** A, int i, int j)
{
	SparseMatrix SM(i, j);
	
	for (int i = 0; i < SM.i; i++)
	{
		for (int j = 0; j < SM.j; j++)
		{
			SM.set(i,j,A[i][j]);
		}
	}

	return SM;
}
void SparseMatrix::remove(Element* E)
{
	int i = E->i;
	int j = E->j;
	Element *victim = E;

	if (victim->right == victim)
	{
		rows[i] = nullptr;
	}
	else if(rows[i] == victim)
	{
		rows[i] = victim->right;
	}
	else
	{
		Element *find = rows[i];
		while (find->right != victim)
		{
			find = find->right;
		}
		find->right = victim->right;
	}

	if (victim->down == victim)
	{
		cols[j] = nullptr;
	}
	else if(cols[j] == victim)
	{
		cols[j] = victim->down;
	}
	else
	{
		Element *find = cols[j];
		while (find->down != victim)
		{
			find = find->down;
		}
		find->down = victim->down;
	}

	delete victim;
}
void SparseMatrix::change(double x, Element* &E)
{
	E->value = x;
}
void SparseMatrix::insert(int i, int j, double x)
{
	Element *place = new Element(i,j,x);
	
	if (rows[i] == nullptr)//якщо ряд пустий
	{
		rows[i] = place;
		place->right = rows[i];
	}
	if (cols[j] == nullptr)//якщо колонка пуста
	{	
		cols[j] = place;
		place->down = cols[j];
	}

	if (rows[i]->j > j)
	{
		Element* find = rows[i];//щоб ост ланка вказувала на перший
		while (find->right != rows[i])
		{
			find = find->right;
		}

		place->right = rows[i];
		rows[i] = place;
		find->right = rows[i];
	}
	else if (rows[i]->j < j)
	{
		Element* find = rows[i];
		while (find->right != rows[i] && find->right->j < j)
		{
			find = find->right;
		}
		place->right = find->right;
		find->right = place;
	}

	if (cols[j]->i > i)
	{
		Element* find = cols[j];
		while (find->down != cols[j])
		{
			find = find->down;
		}

		place->down = cols[j];
		cols[j] = place;
		find->down = cols[j];
	}
	else if(cols[j]->i < i)
	{
		Element* find = cols[j];
		while (find->down != cols[j] && find->down->i < i)
		{
			find = find->down;
		}
		place->down = find->down;
		find->down = place;
	}
}
SparseMatrix SparseMatrix::operator+=(const SparseMatrix & SM)
{
	if (this->i == SM.i && this->j == SM.j)
	{
		for (int i = 0; i < this->i; i++)
		{
			Element * origin = this->rows[i];
			Element * add = SM.rows[i];

			
			if (origin->j == add->j)
			{
				this->set(i, add->j, origin->value + add->value);
				origin = origin->right;
				add = add->right;
			}
			else if (origin->j < add->j)
			{
				this->set(i, origin->j, origin->value);
				add = add->right;
			}
			else if (origin->j > add->j)
			{
				this->set(i, add->j, add->value);
				origin = origin->right;
			}
		}

	}

	return *this;
}
SparseMatrix SparseMatrix::operator+=(double x)
{
	if (i == j)
	{
		for (size_t i = 0; i < this->i; i++)
		{
			size_t j = i;
			if (Element * position = get_ptr(i, j))
			{
				position->value += x;
			}
			else
			{
				this->set(i, j, x);
			}
		}
	}
	return *this;
}
SparseMatrix SparseMatrix::operator+(double x) const
{
	SparseMatrix SM = (*this);

	return SM += x;
}
SparseMatrix SparseMatrix::operator*=(double x)
{
	for (size_t i = 0; i < this->i; i++)
	{
		if (rows[i] != nullptr)
		{
			Element * Multiply = rows[i];
			
			do
			{
				Multiply->value *= x;
				Multiply = Multiply->right;
			} while (Multiply != rows[i]);

		}
	}

	return *this;
}
SparseMatrix SparseMatrix::operator*(double x)const
{
	SparseMatrix SM = *this;

	return SM *= x;
}
SparseMatrix operator+(double x, const SparseMatrix & SM)
{
	return SM + x;
}
SparseMatrix operator*(double x, const SparseMatrix & SM)
{
	return SM * x;
}

void SparseMatrix::print(ostream& os)const
{
	for (size_t i = 0; i < this->i; i++)
	{
		for (size_t j = 0; j < this->j; j++)
		{
			os << get(i, j) << ' ';
		}
		os << endl;
	}
}
ostream & operator<<(ostream& os, const SparseMatrix & SM)
{
	SM.print(os);
	return os;
}