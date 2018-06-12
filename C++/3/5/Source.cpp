/*
�������� 5: (4 ����)

�������������� ����������� ��������� ������, ���������� ���������
��������� �������. �� �������� ��� ����������� ����� �������, ��
��������������, ���� ���� ������� �� �� �������.
*/

#include <iostream>
#include <fstream>
#include <list>
#include <utility>
#include <algorithm>

using namespace std;

template <typename Type>
class SparseMatrix
{
private:
	struct Element
	{
		pair<int, int> index;
		Type value;

		Element(int i, int j, Type v)
		{
			index.first = i;
			index.second = j;
			value = v;
		}
		Element()
		{
			index.first = NULL;
			index.second = NULL;
			value = NULL;
		}
	};

	list<Element> base;

	int N, M;

	auto get_closer_iter(int i, int j)
	{
		auto it = base.begin();

		while (it != base.end() && it->index.first <= i)
		{
			if (it->index.first == i && it->index.second >= j)
			{
				break;
			}
			++it;
		}
		return it;
	}
public:
	SparseMatrix(int N)
	{
		SparseMatrix(N, N);
	}
	SparseMatrix(int N, int M)
	{
		this->N = N;
		this->M = M;
	}
	SparseMatrix(const SparseMatrix & SM)
	{
		this->N = SM.N;
		this->M = SM.M;
		this->base.assign(SM.base.begin(),SM.base.end());
	}
	~SparseMatrix()
	{
		base.clear();
		N = M = 0;
	}
	void print(ostream & os)const
	{
		auto iter = base.begin();
		for (int i = 1; i <= N; ++i)
		{
			for (int j = 1; j <= M; ++j)
			{
				if (iter->index.first == i && iter->index.second == j)
				{
					cout << iter->value;
					++ iter;
				}
				else
				{
					cout << 0;
				}
				cout << '\t';
			}
			cout << endl;
		}
	}
	int get_size()const
	{
		return base.size();
	}
	auto get(int i, int j)
	{
		if (i <= N && i > 0 || j <= M && j > 0)//if in range
		{
			auto it = get_closer_iter(i, j);

			if (it != base.end() && it->index.first == i && it->index.second == j)
			{
				return it;
			}
			else
			{
				return base.end();
			}
		}
		throw "Bad Index";
	}
	bool set(int i, int j, Type v)
	{
		auto node = get_closer_iter(i, j);

		if (node != base.end() && node->index.first == i && node->index.second == j)
		{
			if (v == 0)
			{
				//delete
				base.erase(node);
			}
			else
			{
				//change
				node->value = v;
			}
		}
		else
		{
			if (v == 0)
			{
				//nothing
				return false;
			}
			else
			{
				//set
				base.emplace(node, i, j, v);
			}
		}
		 
		return true;
	}
	bool remove(int i, int j)
	{
		auto node = get(i,j);

		if (node != base.end())
		{
			base.erase(node);
			return true;
		}
		return false;
	}

	double get_norm()const
	{
		double S = 0;

		for (const Element & E: base)
		{
			S += E.value * E.value;
		}
		
		return sqrt(S);
	}
	SparseMatrix T()
	{
		SparseMatrix T(this->M, this->N);

		for (const Element & E : base)
		{
			T.set(E.index.second, E.index.first, E.value);
		}

		return T;
	}
	SparseMatrix operator+(const SparseMatrix & SM)
	{
		// ����������� ������� ������������� ������
		SparseMatrix SUM(
			this->N > SM.N ? this->N : SM.N,
			this->M > SM.M ? this->M : SM.M
		);
		
		auto startF = this->base.begin();
		auto endF = this->base.end();
		auto startS = SM.base.begin();
		auto endS = SM.base.end();

		while (startF != endF && startS != endS)
		{
			// ���� ������� ��� -> �������� ������
			if (startF->index.first == startS->index.first && startF->index.second == startS->index.second)
			{
				SUM.base.emplace_back(startF->index.first, startF->index.second, startF->value + startS->value);

				++startF;
				++startS;
			}
			// ���� ������� � ������ ������� ��� ����� -> �������� ������� �� ����� �������
			else if (startF->index.first == startS->index.first && startF->index.second < startS->index.second)
			{
				SUM.base.emplace_back(startF->index.first, startF->index.second, startF->value);

				++startF;
			}
			// ���� ������� � ����� ������� ��� ����� -> �������� ������� �� ����� �������
			else if (startF->index.first == startS->index.first && startF->index.second > startS->index.second)
			{
				SUM.base.emplace_back(startS->index.first, startS->index.second, startS->value);

				++startS;
			}
			// ���� ������� � ������ ������� �� ��� ����� -> �������� ������� �� ����� ������� ���� �� ���������� ����
			else if (startF->index.first > startS->index.first)
			{
				while (startF->index.first != startS->index.first)
				{
					SUM.base.emplace_back(startS->index.first, startS->index.second, startS->value);

					++startS;
				}
				
			}
			// ���� ������� � ����� ������� �� ��� ����� -> �������� ������� �� ������ ������� ���� �� ���������� ����
			else if (startF->index.first < startS->index.first)
			{
				while (startF->index.first != startS->index.first)
				{
					SUM.base.emplace_back(startF->index.first, startF->index.second, startF->value);

					++startF;
				}

			}

			// ������������ �����
			if (startF == endF && startS != endS)
			{
				SUM.base.emplace_back(startS->index.first, startS->index.second, startS->value);
				++startS;
			}
			else if (startF != endF && startS == endS)
			{
				SUM.base.emplace_back(startF->index.first, startF->index.second, startF->value);
				++startF;
			}
		}

		return SUM;
	}
	SparseMatrix operator*(SparseMatrix & SM)
	{
		// ����������� ������� ���������� ������
		SparseMatrix MULT(
			this->N < SM.N ? this->N : SM.N,
			this->M < SM.M ? this->M : SM.M
		);

		//����������� ����� �������, ��� ��������� ����� �� ��
		SparseMatrix Transpone = SM.T();

		//������ ������� ���� ����� �������
		list<int> i_index_L;
		for (auto i = this->base.begin(); i != this->base.end(); ++i)
		{
			i_index_L.push_back(i->index.first);
		}
		i_index_L.unique();
		//������ ������� ���� ����� �������
		list<int> i_index_L_TR;
		for (auto i = Transpone.base.begin(); i != Transpone.base.end(); ++i)
		{
			i_index_L_TR.push_back(i->index.first);
		}
		i_index_L_TR.unique();
		
		// ��� ������� ���� � ����� ������ �������� �� ����� �������
		for (auto I_T = i_index_L.begin(); I_T != i_index_L.end(); ++ I_T)
		{
			//��������� ��� ����������� ���� �������
			auto startF = this->base.begin();
			auto startS = Transpone.base.begin();
			
			//�������� ��� ��� ����� �������
			while (startF->index.first != *I_T) 
			{
				++startF;
			}
			//�����'������� �������� � ������� ���, ��� �������� ������� �������
			auto start_row = startF;

			// ��� ������� ���� � ����� ������ �������� �� ����� �������
			for (auto I_SM = i_index_L_TR.begin(); I_SM != i_index_L_TR.end(); ++I_SM)
			{
				Type S = 0;

				//�������� ��� ��� ����� �������
				while (startS->index.first != *I_SM)
				{
					++startS;
				}

				//���� �� ����� � ��� ����
				while (startS != Transpone.base.end() && startF != this->base.end() && startF->index.first == *I_T && startS->index.first == *I_SM)
				{
					// ���� ������� ��� -> �������� �����������, ������ �� �������� ����, ������� ���
					if (startF->index.second == startS->index.second)
					{
						S += startF->value * startS->value;
						++startF;
						++startS;
					}
					// ���� ������� � ������ ������� ��� ����� -> ���������� ������� �� ����� �������
					else if (startF->index.second < startS->index.second)
					{
						++startF;
					}
					// ���� ������� � ����� ������� ��� ����� -> ���������� ������� �� ����� �������
					else if (startF->index.second > startS->index.second)
					{
						++startS;
					}
				}

				//���������� ����, ���� ���� �
				if (S != 0)
				{
					MULT.base.emplace_back(*I_T, *I_SM, S);
				}

				//��������� �������� �� ������ ������� � ���
				startF = start_row;
			}

			//��������� �������� �� ������ ������� � ���
			startS = Transpone.base.begin();
		}



		return MULT;
	}
};

void main()
{
	SparseMatrix<int> SM(4,3);
	ifstream file;
	file.open("matrix.txt");
	while (!file.eof())
	{
		int i, j, v;
		file >> i >> j >> v;
		SM.set(i, j, v);
	}
	file.close();

	SparseMatrix<int> A(SM.T());

	cout << "THE MATRIX\n";
	SM.print(cout); cout << endl;

	cout << "GET NORM\n";
	cout << A.get_norm() << endl << endl;

	cout << "TRANSPONE MATRIX\n";
	A.print(cout);	cout << endl;
	
	cout << "SUM OF TWO MATRIX\n";
	SparseMatrix<int>(A + SM).print(cout); cout << endl;
	
	cout << "MULTIPLY TWO MATRIX\n";
	SparseMatrix<int>(SM * A).print(cout); cout << endl;
	SparseMatrix<int>(A * SM).print(cout); cout << endl;

	cin.get();
}