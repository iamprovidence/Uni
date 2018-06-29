using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horse_Tour
{
    class Board
    {
        int BoardSize;
        int[][] board;
        bool success;// bad move
        int LastValue;

        // possible moves
        static int[] dx = new int[8] { 2, 1, -1, -2, -2, -1, 1, 2 };
        static int[] dy = new int[8] { 1, 2, 2, 1, -1, -2, -2, -1 };

        public Board(int boardSize)
        {
            BoardSize = boardSize;
            board = new int[BoardSize][];
            for(int i = 0; i < BoardSize; ++i)
            {
                board[i] = new int[BoardSize];
            }

            LastValue = (int)Math.Pow(BoardSize, 2);
            success = false;
        }
        private void NextMove(int i, int x, int y)
        {
            int k = 0;// move counter
            int u, v; // next move

            while(success != true && k != 8)
            {
                // possible next move
                u = x + dx[k];
                v = y + dy[k];

                if (0 <= u && u < BoardSize &&// if move on board
                    0 <= v && v < BoardSize &&
                    board[u][v] == 0)// if cell is unvisited
                {
                    board[u][v] = i;// moving
                    if (i < LastValue)
                    {
                        NextMove(i + 1, u, v);
                        // backtracking
                        if (!success)
                        {
                            board[u][v] = 0;
                        }
                    }
                    else success = true;
                }
                ++k;
            }

        }
        private void Print()
        {
            for (int k = 0; k < BoardSize; ++k)
            {
                for (int l = 0; l < BoardSize; ++l)
                {
                    Console.Write(board[k][l].ToString() + '\t');
                }
                Console.WriteLine();
            }
        }
        public void Run(int i, int j)
        {
            board[i][j] = 1;
            NextMove(2, i, j);

            if(success)
            {
                Console.WriteLine("Done");

                Print();
            }
            else
            {
                Console.WriteLine("Impossible");

                Print();
            }
        }
    }
}
