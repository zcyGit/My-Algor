using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Write a program to find the n-th ugly number. 
    /// Ugly numbers are positive numbers whose prime factors only include 2, 3, 5. For example, 1, 2, 3, 4, 5, 6, 8, 9, 10, 12 is the sequence of the first 10 ugly numbers. 

    /// Note that 1 is typically treated as an ugly number. 

    /// </summary>
    public class Super_Ugly_Number
    {
        public static void Test()
        {
            int[] nums = new int[] { 7, 19, 29, 37, 41, 47, 53, 59, 61, 79, 83, 89, 101, 103, 109, 127, 131, 137, 139, 157, 167, 179, 181, 199, 211, 229, 233, 239, 241, 251 };
            Console.WriteLine(NthSuperUglyNumber(100000, nums));

        }


        public static int NthSuperUglyNumber(int n, int[] primes)
        {
            int[] uglyList =new int[n];
            int[] count = new int[primes.Length];
            if (n <= 0)
            {
                return 0;
            }
            uglyList[0] = 1;

            int tempNum = 0;
            int min = 0;
            for (int i = 1; i < n; i++)
            {
                min = tempUglyList(uglyList, primes[0],count[0], uglyList[i-1]);
                for (int j = 1; j < primes.Length; j++)
                {
                    tempNum = tempUglyList(uglyList, primes[j], count[j], uglyList[i - 1]);
                    if (min > tempNum)
                    {
                        min = tempNum;
                    }
                }

                for (int j = 0; j < count.Length; j++)
                {
                    // 所有符合条件的，都需增加对应prime index, 避免重复
                    if (tempUglyList(uglyList, primes[j], count[j], uglyList[i - 1]) == min)
                    {
                        count[j]++;
                    }
                }

                uglyList[i]=min;
            }

            return uglyList.LastOrDefault();
        }

        /// <summary>
        /// 这是一个演化的过程
        /// </summary>
        /// <param name="uglyList"></param>
        /// <param name="multiple"></param>
        /// <param name="count"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int tempUglyList(int[] uglyList, int multiple, int count, int max)
        {
            var tempList = new List<int>();

            for (int i = count; i < uglyList.Length;i++ )
            {
                if (max < uglyList[i] * multiple)
                    return uglyList[i] * multiple;
            }

            return 0;
        }
    }
}
