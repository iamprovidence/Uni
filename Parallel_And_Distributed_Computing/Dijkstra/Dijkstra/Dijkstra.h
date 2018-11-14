#pragma once

#include "Graph.h"
#include <exception>
#include <map>
#include <algorithm>
#include <vector>
#include <thread>

namespace CUDA
{
	template <typename GraphWeightType>
	class Dijkstra
	{
	private:
		Graph<GraphWeightType>* graph;
		std::map<int, GraphWeightType>* open_set;
		std::map<int, GraphWeightType>* closed_set;
		std::vector<int>* path;

	public:
		Dijkstra(Graph<GraphWeightType>* graph)
		{
			this->graph = graph;
			this->open_set = new std::map<int, GraphWeightType>();
			this->closed_set = new std::map<int, GraphWeightType>();
			this->path = new std::vector<int>;
		}
		~Dijkstra()
		{
			delete open_set;
			delete closed_set;
			delete path;
		}

		std::vector<int>* get_path()const
		{
			return path;
		}
		GraphWeightType get_distance_to_edge(int edge_index)const
		{
			return closed_set->at(edge_index);
		}
		
		void run(int from)
		{
			this->reset();
			open_set->insert(std::pair<int, GraphWeightType>(from, 0));// start position

			while (!open_set->empty())
			{
				// get closest edge							
				GraphWeightType closestEdge = std::min_element(open_set->cbegin(), open_set->cend(),
					[](const std::pair<int, GraphWeightType>& l, const std::pair<int, GraphWeightType>& r) -> bool { return l.second < r.second; })->second;
				
				std::pair<int, GraphWeightType> current_edge = *std::find_if(open_set->begin(), open_set->end(),
					[&closestEdge](const std::pair<int, GraphWeightType>& node) -> bool { return node.second == closestEdge; });
				// finding shorter path
				check_neighbours(graph->get_weight_to_neighbour(current_edge.first), current_edge.second, 0, graph->get_size());
				// remove processed edge
				open_set->erase(current_edge.first);
				closed_set->insert(std::make_pair(current_edge.first, current_edge.second));
				path->push_back(current_edge.first);
			}
		}
		void run(int from, int thread_amount)
		{
			this->reset();
			open_set->insert(std::pair<int, GraphWeightType>(from, 0));// start position

			while (!open_set->empty())
			{
				// get closest edge							
				GraphWeightType closestEdge = std::min_element(open_set->cbegin(), open_set->cend(),
					[](const std::pair<int, GraphWeightType>& l, const std::pair<int, GraphWeightType>& r) -> bool { return l.second < r.second; })->second;

				std::pair<int, GraphWeightType> current_edge = *std::find_if(open_set->begin(), open_set->end(),
					[&closestEdge](const std::pair<int, GraphWeightType>& node) -> bool { return node.second == closestEdge; });


				std::thread ** threads = new std::thread*[thread_amount];
				int row_amount_for_each_thread = graph->get_size() / thread_amount;

				for (size_t t = 0; t < thread_amount - 1; ++t)
				{					
					threads[t] = new std::thread(
						&Dijkstra::check_neighbours,
						this,
						graph->get_weight_to_neighbour(current_edge.first),
						current_edge.second,
						t * row_amount_for_each_thread,// from
						t * row_amount_for_each_thread + row_amount_for_each_thread // to
					);
				}
				threads[thread_amount - 1] = new std::thread(
					&Dijkstra::check_neighbours,
					this,
					graph->get_weight_to_neighbour(current_edge.first),
					current_edge.second,
					graph->get_size() - row_amount_for_each_thread - (graph->get_size() % thread_amount), // from
					graph->get_size()// to
				);
				// join
				for (size_t t = 0; t < thread_amount; ++t)
				{
					threads[t]->join();
				}
				// cleaning
				for (size_t t = 0; t < thread_amount; ++t)
				{
					delete threads[t];
				}
				delete[] threads;
				// remove processed edge
				open_set->erase(current_edge.first);
				closed_set->insert(std::make_pair(current_edge.first, current_edge.second));
				path->push_back(current_edge.first);
			}
		}
		private:
		void check_neighbours(GraphWeightType* neighbour_weight, GraphWeightType current_weight, int from_edge, int to_edge)
		{
			for (int edge_index = from_edge; edge_index < to_edge; ++edge_index)
			{
				// for each edge, if there vertex, edge is not processed, the shorter way has been found
				if (can_be_better(edge_index, neighbour_weight) && weight_is_shorter(edge_index, current_weight, neighbour_weight))
				{
					open_set->operator[](edge_index) = current_weight + neighbour_weight[edge_index];
				}
			}
		}
		void reset()
		{
			open_set->clear();
			closed_set->clear();
			path->clear();
		}
		bool can_be_better(int edge_index, GraphWeightType* weights)
		{
			return weights[edge_index] != 0 && closed_set->find(edge_index) == closed_set->end();
		}
		bool weight_is_shorter(int edge_index, GraphWeightType current_weight, GraphWeightType* weights)
		{
			return open_set->find(edge_index) == open_set->end() || open_set->at(edge_index) > weights[edge_index] + current_weight;
		}
	};
}