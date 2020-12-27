using System;
using System.Collections.Generic;
using System.Text;

namespace KCK_Console_project
{
    class GameBoard
    {
        public static char[,] board = new char[15, 10]; //wiersze, kolumny

        //getter
        public char[,] GetBoard()
        {
            return board;
        }

        public void CreateBoard()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = '.';
                    if (i == 10)
                        board[i, j] = '#';
                }
            }
            board[14, 0] = 'v';
            board[14, 9] = 's';
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(board[i, j]);
                }
                Console.WriteLine();
            }
        }


    }
}
