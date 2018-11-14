#include "stdafx.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace CUDA;

namespace Test
{
	TEST_CLASS(ThreadMiddle)
	{
	public:

		TEST_METHOD(small_size_thread_middle)
		{
			Graph<double> *graph = new Graph<double>(SMALL_SIZE);
			Dijkstra<double> *dijkstra = new Dijkstra<double>(graph);
			dijkstra->run(0, MIDDLE_THREAD);
			delete graph;
			delete dijkstra;
		}
		TEST_METHOD(middle_size_thread_middle)
		{
			Graph<double> *graph = new Graph<double>(MIDDLE_SIZE);
			Dijkstra<double> *dijkstra = new Dijkstra<double>(graph);
			dijkstra->run(0, MIDDLE_THREAD);
			delete graph;
			delete dijkstra;
		}
		TEST_METHOD(big_size_thread_middle)
		{
			Graph<double> *graph = new Graph<double>(BIG_SIZE);
			Dijkstra<double> *dijkstra = new Dijkstra<double>(graph);
			dijkstra->run(0, MIDDLE_THREAD);
			delete graph;
			delete dijkstra;
		}

	};
}