#include "head.h"

Game::Game()
{
	number_of_Playing_Card = 2;

	Dominos_number_1 = 1;
	Dominos_number_2 = 1;

	Domino[0]=Dominos_number_1;
	Domino[1]=Dominos_number_2;
	
	Chessboard[0]=Chessboard_x;
	Chessboard[1]=Chessboard_y;
}
Game::Game(int N, char name, char suite)
{}
Game::Game(int N1, int N2)
{}
Game::Game(char X, char Y)
{}