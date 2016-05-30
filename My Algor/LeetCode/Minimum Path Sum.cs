using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// 动态规划
    /// 问题地址
    /// https://leetcode.com/problems/minimum-path-sum/
    /// </summary>
    public class Minimum_Path_Sum
    {
        public static void Test()
        {
            var sum = new int[,] { { 1, 2, 3 }, { 1, 2, 3 } };

            Console.Write(MinPathSum(sum));

        }

        public static int MinPathSum(int[,] grid)
        {
            var res = 0;

            if (grid == null)
            {
                return res;
            }

            var n = grid.GetLength(0);
            var m = grid.GetLength(1);

            var solve = new int[n, m];
            solve[0, 0] = grid[0, 0];

            for (int i = 1; i < n; i++)
                solve[i, 0] = solve[i - 1, 0] + grid[i, 0];

            for (int i = 1; i < m; i++)
                solve[0, i] = solve[0, i - 1] + grid[0, i];


            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    solve[i, j] = Math.Min(solve[i - 1, j], solve[i, j - 1]) + grid[i, j];
                }
            }

            return solve[n - 1, m - 1];

        }

    }
}
