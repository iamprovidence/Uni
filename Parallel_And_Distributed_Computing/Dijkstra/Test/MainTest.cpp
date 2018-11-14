#include "stdafx.h"
#include "CppUnitTest.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;
using namespace CUDA;

namespace Test
{		
	TEST_CLASS(MainTest)
	{
	public:
		
		TEST_METHOD(main_method)
		{
			const int SIZE = 100;
			const int START_FROM = 0;
			const int THREAD_AMOUNT = 3;

			Graph<double> *graph = new Graph<double>(SIZE);
			Dijkstra<double> *dijkstra = new Dijkstra<double>(graph);
			dijkstra->run(START_FROM, THREAD_AMOUNT);
			delete graph;
			delete dijkstra;
		}

	};
}