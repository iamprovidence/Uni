#pragma once
#include <stdlib.h>

namespace CUDA
{
	// повертаЇ випадкове число ≥з д≥апазону [min, max)
	template<int min, int max>
	int get_rand()
	{
		//формула rand() % (р≥зниц€ м≥ж границ€ми) + л≥ва границ€
		return rand() % (max - min) + min;
	}

	double get_double_rand(double min, double max)
	{
		return min + (double)rand() / RAND_MAX * (max - min);
	}
}