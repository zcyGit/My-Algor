using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    //数独 9*9的九宫格游戏
    //    Determine if a Sudoku is valid, according to: Sudoku Puzzles - The Rules.
    //The Sudoku board could be partially filled, where empty cells are filled with the character '.'.

    class Valid_Sudoku
    {

        public static void Test()
        {

            var chars = CreatSudokuTemp();

            //chars[0, 1] = '3';
            //chars[3, 0] = '1';
            //chars[4, 0] = '5';

            chars[0, 1] = '1';
            chars[1, 3] = '1';



            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(chars[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(IsValidSudoku(chars));

        }

        public static char[,] CreatSudokuTemp()
        {
            char[] car = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[,] sudoku = new char[9, 9];

            var beginCharNumber = 1;


            for (int i = 0; i < 9; i++)
            {
                var charNumber = beginCharNumber - 1;
                for (int j = 0; j < 9; j++)
                {
                    if (charNumber % 3 == 0)
                    {
                        sudoku[i, j] = '.';

                    }
                    else
                    {
                        sudoku[i, j] = car[charNumber % 9];
                    }

                    charNumber++;

                }
                beginCharNumber = beginCharNumber + 3;
                if (beginCharNumber > 9)
                {
                    beginCharNumber = beginCharNumber - 9 + 1;
                }
            }

            return sudoku;
        }

        public static bool IsValidSudoku(char[,] board)
        {
            int[,] alphabetsRow = new int[9, 9];
            int[,] alphabetsCol = new int[9, 9];

            //行列重复判断
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row, col] != '.')
                    {
                        alphabetsRow[row, board[row, col] - '1']++;
                        if (alphabetsRow[row, board[row, col] - '1'] >= 2)
                        {
                            return false;
                        }

                    }

                    if (board[col, row] != '.')
                    {
                        alphabetsCol[board[col, row] - '1', row]++;
                        if (alphabetsCol[board[col, row] - '1', row] >= 2)
                        {
                            return false;
                        }
                    }
                }
            }

            int rowMatrix = 0;
            int colMatrix = 0;
            while (rowMatrix < 9 && colMatrix < 9)
            {
                int[,] threeMatrix = new int[3, 3];

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (board[row + rowMatrix, col + colMatrix] != '.')
                        {
                            threeMatrix[(board[row + rowMatrix, col + colMatrix] - '1') / 3, (board[row + rowMatrix, col + colMatrix] - '1') % 3]++;
                            if (threeMatrix[(board[row + rowMatrix, col + colMatrix] - '1') / 3, (board[row + rowMatrix, col + colMatrix] - '1') % 3] >= 2)
                            {
                                return false;
                            }
                        }
                    }
                }

                rowMatrix += 3;
                if (rowMatrix == 9 && colMatrix < 9)
                {
                    rowMatrix = 0;
                    colMatrix += 3;
                }

            }


            return true;
        }
    }



}
