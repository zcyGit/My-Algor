using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    //The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.
    //Given an integer n, return all distinct solutions to the n-queens puzzle.
    //Each solution contains a distinct board configuration of the n-queens' placement, where 'Q' and '.' both indicate a queen and an empty space respectively.
    //http://blog.csdn.net/hackbuteer1/article/details/6657109
    class N_Queens
    {

        public static void Test()
        {
            int n = 4;
            var solveLists = SolveNQueens(n);

            foreach (var solveList in solveLists)
            {
                foreach (var solve in solveList)
                {
                    Console.Write(solve);
                }
                Console.WriteLine();
            }
        }

        public static IList<IList<string>> SolveNQueens(int n)
        {
            var matrixQueens = NQueensInitialize(n);
            return Solve(matrixQueens, n);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string[,] NQueensInitialize(int n)
        {
            string[,] matrixQueens = new string[n, n];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    matrixQueens[i, j] = ".";
                }
            }

            return matrixQueens;

        }

        /// <summary>
        /// 解决方法(无递归回溯法)
        /// </summary>
        /// <param name="matrixQueens"></param>
        /// <returns></returns>
        public static IList<IList<string>> Solve(string[,] matrixQueens, int n)
        {
            //下标代表行，值代表列
            List<int> queens = new List<int>();

            IList<IList<string>> solveLists = new List<IList<string>>();
            int row = 0;
            queens.Add(0);
            //循环行
            while (row >= 0)
            {
                if (row < n && queens[row] < n)
                {

                    if (IsAllowInsertQueen(queens, row))
                    {
                        //如果是可以插入的，则在当前位置放置皇后
                        matrixQueens[row, queens[row]] = "Q";
                        //然后查找下一行
                        row++;
                        //下一行的第一列开始
                        queens.Add(0);
                    }
                    else
                    {
                        //如果不能插入
                        //那就查找第二列
                        queens[row] = queens[row] + 1;
                    }
                }
                else
                {
                    if (row >= n)
                    {
                        solveLists.Add(InsertSolveList(matrixQueens,n));
                    }
                    //回溯上一行

                    queens.RemoveAt(row);
                    row--;
                    if (row < 0)
                    {
                        break;
                    }
                    matrixQueens[row, queens[row]] = ".";

                    //上一列的下一列
                    queens[row]++;
                }

            }

            return solveLists;
        }

        /// <summary>
        /// 是否允许插入
        /// </summary>
        /// <param name="matrixQueens"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static bool IsAllowInsertQueen(List<int> queens, int row)
        {

            for (int i = 0; i < row; i++)
            {
                //不能再同一列
                if (queens[i] == queens[row])
                {
                    return false;
                }

                var number = Math.Abs(queens[row] - queens[i]);

                if (Math.Abs(i - row) == number)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// 保存一个正解
        /// </summary>
        /// <param name="matrixQueens"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IList<string> InsertSolveList(string[,] matrixQueens,int n)
        {
            IList<string> SolveList = new List<string>();
            string solveString = string.Empty;

            for (int i = 0; i < n; i++)
            {
                solveString = "";
                for (int j = 0; j < n; j++)
                {
                    solveString += matrixQueens[i, j];
                }
                SolveList.Add(solveString);
            }

            return SolveList;
        }



    }
}
