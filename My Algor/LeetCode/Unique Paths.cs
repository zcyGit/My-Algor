using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Unique_Paths
    {
        public static void Test()
        {
            //var sum = new char[,] { { 'A', 'B', 'C', 'E' }, { 'S', 'F', 'C', 'S' }, { 'A', 'D', 'E', 'E' } };
            //var word = "ABCB";


            Console.WriteLine(UniquePaths(3, 2));
        }

        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int UniquePaths(int m, int n)
        {
            if (m == 0 || n == 0)
            {
                return 0;
            }
            var listExist = new int[m, n];
            listExist[0, 0] = 1;
            for (int i = 0; i < m; i++)
            {
                listExist[i, 0] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                listExist[0, i] = 1;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    listExist[i, j] = listExist[i - 1, j] + listExist[i, j - 1];
                }
            }
            return listExist[m - 1, n - 1];
        }
    }
}
