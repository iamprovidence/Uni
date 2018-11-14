#pragma once
#include "random.h"

namespace CUDA
{
	template <typename Type>
	class Graph
	{
	private:
		Type** graph;
		unsigned int size;
	public:
		Graph(unsigned int size)
		{
			this->size = size;
			this->graph = new Type*[size];
			for (size_t i = 0; i < size; ++i)
			{
				graph[i] = new Type[size];
			}
		};
		~Graph() 
		{
			for (size_t i = 0; i < size; ++i)
			{
				delete[] graph[i];
			}
			delete[] graph;
		};

		unsigned int get_size() const
		{
			return size;
		}
		Type get(unsigned int i, unsigned int j) const
		{
			return graph[i][j];
		}
		void set(unsigned int i, unsigned int j, Type value)
		{
			graph[i][j] = value;
		}
		Graph* generate(float noPathRate = 0.35)
		{
			for (size_t i = 0; i < size; ++i)
			{
				for (size_t j = 0; j < size; ++j)
				{
					if (get_double_rand(0.0, 1.0) < noPathRate) graph[i][j] = 0;
					else graph[i][j] = get_rand<-100, 100>();
				}
			}
			return this;
		}
		Type* get_weight_to_neighbour(unsigned int edgeIndex) const
		{
			return graph[edgeIndex];
		}
	};
}

