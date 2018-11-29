#include <iostream>
#include <thread>
#include <ctime>
#include <string>
#include <CL\cl.h>

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
	delete[] matrix[0];
	delete[] matrix;
}

void simple_sum_matrix(int** first_matrix, int** second_matrix, int** sum_matrix_result, size_t size, size_t index_column = 0, size_t threads_step = 1)
{
	for (size_t i = 0; i < size; ++i)
	{
		for (size_t j = index_column; j < size; j += threads_step)
		{
			sum_matrix_result[i][j] = first_matrix[i][j] + second_matrix[i][j];
		}
	}
}

void parallel_sum_matrix(int** first_matrix, int** second_matrix, int** sum_matrix_result, size_t size, size_t threads_amount = 1)
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

void sum_matrix_OpenCL(int* first_matrix, int* second_matrix, int* sum_matrix_result, size_t size)
{
	const char *source_code =
		"__kernel void matrix_sum_openCL(__global int* a, __global int* b, __global int* result, const int quantity)"
		"{"
		"int index = get_global_id(0);"
		"result[index] = a[index] + b[index];"
		"}";


	size_t matrix_size = sizeof(int) * size * size;
	cl_platform_id platform_id;
	cl_device_id device_id;
	cl_uint num_platforms;
	cl_uint num_devices;

	if (clGetPlatformIDs(1, &platform_id, &num_platforms) != CL_SUCCESS)
	{
		std::cout << "Unable to get platform id" << std::endl;
	}

	// CL_DEVICE_TYPE_GPU - All calculations will be on GPU.
	if (clGetDeviceIDs(platform_id, CL_DEVICE_TYPE_GPU, 1, &device_id, &num_devices) != CL_SUCCESS)
	{
		std::cout << "Unable to get device id" << std::endl;
	}
	// CONFIG
	cl_context_properties properties[3];
	properties[0] = CL_CONTEXT_PLATFORM;
	properties[1] = (cl_context_properties)platform_id;
	properties[2] = 0;

	cl_int err;
	cl_context context = clCreateContext(properties, 1, &device_id, NULL, NULL, &err);
	cl_command_queue commandQueue = clCreateCommandQueue(context, device_id, 0, &err);
	cl_program program = clCreateProgramWithSource(context, 1, (const char **)&source_code, NULL, &err);

	// BUILD IT
	if (clBuildProgram(program, 0, NULL, NULL, NULL, NULL) != CL_SUCCESS)
	{
		std::cout << "Error building program\n" << std::endl;
	}

	cl_kernel kernel = clCreateKernel(program, "matrix_sum_openCL", &err);

	// ALLOC MEMORY ON GPU
	cl_mem first_matrix_buffer = clCreateBuffer(context, CL_MEM_READ_WRITE, matrix_size, NULL, NULL);
	cl_mem second_matrix_buffer = clCreateBuffer(context, CL_MEM_READ_WRITE, matrix_size, NULL, NULL);
	cl_mem third_matrix_buffer = clCreateBuffer(context, CL_MEM_READ_WRITE, matrix_size, NULL, NULL);

	clEnqueueWriteBuffer(commandQueue, first_matrix_buffer, CL_TRUE, 0, matrix_size, first_matrix, 0, NULL, NULL);
	clEnqueueWriteBuffer(commandQueue, second_matrix_buffer, CL_TRUE, 0, matrix_size, second_matrix, 0, NULL, NULL);
	clEnqueueWriteBuffer(commandQueue, third_matrix_buffer, CL_TRUE, 0, matrix_size, sum_matrix_result, 0, NULL, NULL);

	// pass value to kernal method
	size_t arraySize = size * size;
	clSetKernelArg(kernel, 0, sizeof(cl_mem), &first_matrix_buffer);
	clSetKernelArg(kernel, 1, sizeof(cl_mem), &second_matrix_buffer);
	clSetKernelArg(kernel, 2, sizeof(cl_mem), &third_matrix_buffer);
	clSetKernelArg(kernel, 3, sizeof(int), &arraySize);

	cl_uint work_dim = 1;
	size_t global_work_offset = 0;
	size_t global_work_size = size * size;
	size_t local_work_size = size;

	// work is goin on
	clock_t begin_time = clock();
	clEnqueueNDRangeKernel(commandQueue, kernel, work_dim, NULL, &global_work_size, &local_work_size, 0, NULL, NULL);
	// copy result from GPU to CPU
	clEnqueueReadBuffer(commandQueue, third_matrix_buffer, CL_TRUE, 0, matrix_size, sum_matrix_result, 0, NULL, NULL);
	std::cout << std::endl << "OpenCL sum matrices time: " << ((float)(clock() - begin_time)) / CLOCKS_PER_SEC << " s" << std::endl;


	// CLEAN UP
	clReleaseMemObject(first_matrix_buffer);
	clReleaseMemObject(second_matrix_buffer);
	clReleaseMemObject(third_matrix_buffer);

	clReleaseKernel(kernel);
	clReleaseCommandQueue(commandQueue);
	clReleaseProgram(program);
	clReleaseContext(context);
}



void main()
{
	// INITIALIZE VALUES
	std::cout << "Show Matrixes?(Yes)" << std::endl;
	std::string show_matrix_user_answer;	std::cin >> show_matrix_user_answer;

	std::cout << "Input size of matrices: ";
	size_t size;	std::cin >> size;

	std::cout << "Input amount of threads: ";
	size_t threads_amount;	std::cin >> threads_amount;

	// CREATE MATRIXES
	int** first_matrix = create_matrix<int>(size); fill_matrix(first_matrix, size);
	int** second_matrix = create_matrix<int>(size); fill_matrix(second_matrix, size);

	int** sum_matrix_result = create_matrix<int>(size);
	int** parallel_sum_matrix_result = create_matrix<int>(size);
	int** opencl_sum_matrix_result = create_matrix<int>(size);

	// CALC BY DIFFERENCE METHODS
	srand(time(NULL));

	clock_t begin_time = clock();
	simple_sum_matrix(first_matrix, second_matrix, sum_matrix_result, size);
	std::cout << std::endl << "Simple sum matrices time: " << (float)(clock() - begin_time) / CLOCKS_PER_SEC << "s" << std::endl;

	begin_time = clock();
	parallel_sum_matrix(first_matrix, second_matrix, parallel_sum_matrix_result, size, threads_amount);
	std::cout << std::endl << "Parallel sum matrices time: " << (float)(clock() - begin_time) / CLOCKS_PER_SEC << "s" << std::endl;

	// All matrices are to one-dimensional arrays with size = row_size*columns_size,
	// because GPU (Graphics Proccesing Unit) computes such arrays the best.
	sum_matrix_OpenCL(first_matrix[0], second_matrix[0], opencl_sum_matrix_result[0], size);

	// SHOW MATRIXES
	if (show_matrix_user_answer == "Yes")
	{
		std::cout << std::endl << "First matrix: " << std::endl;
		show_matrix(first_matrix, size);

		std::cout << "Second matrix: " << std::endl;
		show_matrix(second_matrix, size);

		std::cout << "Parallel sum matrices: " << std::endl;
		show_matrix(parallel_sum_matrix_result, size);

		std::cout << "Simple sum matrices: " << std::endl;
		show_matrix(sum_matrix_result, size);

		std::cout << "OpenCL sum matrices: " << std::endl;
		show_matrix(opencl_sum_matrix_result, size);
	}

	// CLEANING UP
	purge(first_matrix);
	purge(second_matrix);
	purge(sum_matrix_result);
	purge(parallel_sum_matrix_result);
	purge(opencl_sum_matrix_result);

	system("pause");
}
