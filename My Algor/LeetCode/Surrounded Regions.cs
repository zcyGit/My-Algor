using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.
    /// A region is captured by flipping all 'O's into 'X's in that surrounded region. 
    /// For example,
    /// </summary>
    public class Surrounded_Regions
    {

        public static void Test()
        {

            var row = 4;
            var col = 4;
            char[,] board = new char[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    board[i, j] = 'x';
                }
            }

            board[1, 1] = '0';
            board[1, 2] = '0';
            board[2, 2] = '0';
            board[3, 1] = '0';


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }

            new Surrounded_Regions().Solve(board);

            Console.WriteLine("经过方法之后的：");

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }


        }

        int[,] solve;
        int row, col;

        public void Solve(char[,] board)
        {
            row = board.GetLength(0);
            col = board.GetLength(1);

            if (row <= 2 || col <= 2)
            {
                return ;
            }

            solve = new int[row, col];

            int i = 0;
            for (int j = 0; j < col; j++)
            {
                if (board[i, j] == '0')
                {
                    solve[i, j] = 1;
                }
            }
            for (int j = 0; j < row; j++)
            {
                if (board[j, i] == '0')
                {
                    solve[j, i] = 1;
                }
            }

            i = row - 1;
            for (int j = 0; j < col; j++)
            {
                if (board[i, j] == '0')
                {
                    solve[i, j] = 1;
                }
            }

            i = col - 1;
            for (int j = 0; j < row; j++)
            {
                if (board[j, i] == '0')
                {
                    solve[j, i] = 1;
                }
            }


            for (i = 1; i < row - 1; i++)
            {
                for (int j = 1; j < col - 1; j++)
                {
                    //判断四个方向是不是有个0
                    if (board[j, i] == '0')
                    {
                        bfsBoundary(board, j, i);
                    }
                }
            }
        }


        public int bfsBoundary(char[,] board, int i, int j)
        {
            if (j >= col - 1 || i >= row - 1 || i <= 0 || j <= 0)
            {
                return 0;
            }
            board[i, j] = 'd';
            if (solve[i - 1, j] == 1 || solve[i, j - 1] == 1 || solve[i, j + 1] == 1 || solve[i + 1, j] == 1)
            {
                solve[i, j] = 1;
            }
            if (board[i - 1, j] == '0')
            {
                solve[i - 1, j] = bfsBoundary(board, i - 1, j);
            }
            if (board[i + 1, j] == '0')
            {
                solve[i + 1, j] = bfsBoundary(board, i + 1, j);
            }
            if (board[i, j + 1] == '0')
            {
                solve[i + 1, j] = bfsBoundary(board, i, j + 1);
            }
            if (board[i, j - 1] == '0')
            {
                solve[i, j - 1] = bfsBoundary(board, i, j - 1);
            }

            if (solve[i - 1, j] == 1 || solve[i, j - 1] == 1 || solve[i, j + 1] == 1 || solve[i + 1, j] == 1)
            {
                solve[i, j] = 1;
                solve[i, j] = '0';

                return 1;
            }
            board[i - 1, j] = 'x';
            board[i + 1, j] = 'x';
            board[i, j + 1] = 'x';
            board[i, j - 1] = 'x';

            return 0;

        }


    }
}
