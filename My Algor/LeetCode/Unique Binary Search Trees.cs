using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Unique_Binary_Search_Trees
    {

        public static void Test()
        {
            int n = 4;

            Console.Write(NumTrees(n));
        }

        /// <summary>
        /// UniqueTrees的递推公式为UniqueTrees[i] = ∑ UniqueTrees[0...k] * [i-1-k]     k取值范围 0<= k <=(i-1) 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int NumTrees(int n)
        {
            int sum = 0;
            if (n == 1 || n == 0)
            {
                return 1;
            }

            if (solve.ContainsKey(n))
            {
                return solve[n];
            }

            for (int i = n - 1, j = 0; i >= 0 && j < n; i--, j++)
            {
                sum += NumTrees(j) * NumTrees(i);
            }

            if (!solve.ContainsKey(n))
            {
                solve.Add(n, sum);
            }
            return sum;

        }

        private static Dictionary<int, int> solve = new Dictionary<int, int>();
    }
}
