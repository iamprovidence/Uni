#include <ctime>
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <mpi.h>
#include <string>
#include <thread>
#define TAG 1

template <typename Type>
void show_matrix(Type** matrix, size_t size)
{
	for (size_t i = 0; i < size; ++i)
	{
		for (size_t j = 0; j < size; ++j)
		{
			std::cout << matrix[i][j] << "\t";
		}
		std::cout << std::endl;
	}
	std::cout << std::endl;
}

template <typename Type>
Type ** create_matrix(size_t size)
{
	/*
	Type ** res = (Type **) malloc(size * sizeof(Type*));
	res[0] = (Type*)malloc(size *size * sizeof(Type));
	*/
	Type ** res = new Type*[size];
	res[0] = new Type[size * size];
	for (size_t i = 1; i < size; ++i)
	{
		// next address == previous address + length
		res[i] = res[i - 1] + size;
	}
	return res;
}
// get random number [min, max)
template<int min = 1, int max = 5 >
int get_rand()
{
	// R = rand() % (difference between bounds) + left bound
	return rand() % (max - min) + min;
}

void fill_matrix(int ** matrix, size_t size)
{
	for (size_t i = 0; i < size; ++i)
	{
		for (size_t j = 0; j < size; ++j)
		{
			matrix[i][j] = get_rand<1, 200>();
		}
	}
}

template <typename Type>
void purge(Type ** matrix)
{
	/*
	free(matrix[0]);
	free(matrix);
	*/
	delete[] matrix[0];
	delete[] matrix;
}

void simple_sum_matrix(int** first_matrix, int** second_matrix, int** sum_matrix_result, 
					   size_t size, size_t index_column = 0, size_t threads_step = 1)
{
	for (size_t i = 0; i < size; ++i)
	{
		for (size_t j = index_column; j < size; j += threads_step)
		{
			sum_matrix_result[i][j] = first_matrix[i][j] + second_matrix[i][j];
		}
	}
}
void parallel_sum_matrix(int** first_matrix, int** second_matrix, int** sum_matrix_result, 
						 size_t size, size_t threads_amount = 1)
{
	std::thread* thread_arr = new std::thread[threads_amount];
	for (size_t i = 0; i < threads_amount; ++i)
	{
		thread_arr[i] = std::thread(simple_sum_matrix, first_matrix, second_matrix, sum_matrix_result, size, i, threads_amount);
	}
	for (size_t i = 0; i < threads_amount; ++i)
	{
		thread_arr[i].join();
	}
	delete[] thread_arr;
}


int main(int argc, char * argv[]) 
{
	int processes, id;
	int portion;

	double MPI_START_TIME;
	// Initialize some value
	// MPI start work
	MPI_Init(&argc, &argv);
	MPI_Comm_size(MPI_COMM_WORLD, &processes);
	MPI_Comm_rank(MPI_COMM_WORLD, &id);

	MPI_Status status;

	if (id == 0) // work for main process
	{
		// initialize values
		int matrix_size;
		std::cout << "Matrix size - ";
		std::cin >> matrix_size;

		std::cout << "Show matrix?(Yes) - ";
		std::string user_answer;	std::cin >> user_answer;
		bool show_matrix_user = user_answer == "Yes";

		int **first_matrix = create_matrix<int>(matrix_size);	fill_matrix(first_matrix, matrix_size);
		int **second_matrix = create_matrix<int>(matrix_size);	fill_matrix(second_matrix, matrix_size);
		int **res_matrix = nullptr;

		// SIMPLE
		res_matrix = create_matrix<int>(matrix_size);

		MPI_START_TIME = MPI_Wtime();
		simple_sum_matrix(first_matrix, second_matrix, res_matrix, matrix_size);
		std::cout << "Simple sum matrices time: " << MPI_Wtime() - MPI_START_TIME << std::endl;
		
		if (show_matrix_user)
		{
			show_matrix<int>(first_matrix, matrix_size);	std::cout << std::endl;
			show_matrix<int>(second_matrix, matrix_size);	std::cout << std::endl;
			show_matrix<int>(res_matrix, matrix_size);		std::cout << std::endl;
		}
		purge(res_matrix);



		// THREAD
		res_matrix = create_matrix<int>(matrix_size);
		std::cout << "Input thread amount " << std::endl;
		int thread_amount; std::cin >> thread_amount; 
		
		MPI_START_TIME = MPI_Wtime();
		parallel_sum_matrix(first_matrix, second_matrix, res_matrix, matrix_size, thread_amount);
		std::cout << "Thread sum matrices time: " << MPI_Wtime() - MPI_START_TIME << std::endl;
		
		if (show_matrix_user)
		{
			show_matrix<int>(first_matrix, matrix_size);	 std::cout << std::endl;
			show_matrix<int>(second_matrix, matrix_size);	 std::cout << std::endl;
			show_matrix<int>(res_matrix, matrix_size);		 std::cout << std::endl;
		}
		purge(res_matrix);



		// MPI
		MPI_Request requests;
		portion = matrix_size*matrix_size / (processes - 1);// f*ck the remainder
		res_matrix = create_matrix<int>(matrix_size);
		

		MPI_START_TIME = MPI_Wtime();
		// send part matrix to all process
		for (int p = 1; p < processes; ++p)
		{
			int shift = (p - 1) * portion;
			int *pointer_a = first_matrix[0] + shift;
			int *pointer_b = second_matrix[0] + shift;
			
			// send to other process his portion...
			MPI_Isend(&portion, 1		, MPI_INT, p, TAG, MPI_COMM_WORLD, &requests);
			// ... Matrix A part...
			MPI_Isend(pointer_a, portion, MPI_INT, p, TAG, MPI_COMM_WORLD, &requests);
			// ... Matrix B part
			MPI_Isend(pointer_b, portion, MPI_INT, p, TAG, MPI_COMM_WORLD, &requests);
		}

		// receive part matrix from all process
		for (int p = 1; p < processes; ++p)
		{
			int *pointer_res = res_matrix[0] + (p - 1) * portion;
			MPI_Recv(pointer_res, portion, MPI_INT, p, TAG, MPI_COMM_WORLD, &status);
		}
		std::cout<< "MPI take " << MPI_Wtime() - MPI_START_TIME << std::endl;
		

		if (show_matrix_user)
		{
			show_matrix<int>(first_matrix, matrix_size);	std::cout << std::endl;
			show_matrix<int>(second_matrix, matrix_size);	std::cout << std::endl;
			show_matrix<int>(res_matrix, matrix_size);		std::cout << std::endl;
		}

		// clean up
		purge(first_matrix);
		purge(second_matrix);
		purge(res_matrix);
	}
	else
	{
		// get work portion
		MPI_Recv(&portion, 1, MPI_INT, 0, TAG, MPI_COMM_WORLD, &status);
		// process has no access to each other memory, so allocate memory itself
		int * arr_a = new int[portion];
		int * arr_b = new int[portion];

		int * res	= new int[portion];
		// get work item
		MPI_Recv(arr_a, portion, MPI_INT, 0, TAG, MPI_COMM_WORLD, &status);
		MPI_Recv(arr_b, portion, MPI_INT, 0, TAG, MPI_COMM_WORLD, &status);
		// work
		for (int i = 0; i < portion; ++i)
		{
			res[i] = arr_a[i] + arr_b[i];
		}
		// send back to main process
		MPI_Send(res, portion, MPI_INT, 0, TAG, MPI_COMM_WORLD);
		// clean up
		delete[] arr_a;
		delete[] arr_b;
		delete[] res;
	}

	// mpi end work
	MPI_Finalize();
	return 0;
}