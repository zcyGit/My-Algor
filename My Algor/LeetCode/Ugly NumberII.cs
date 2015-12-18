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
    public class Ugly_NumberII
    {
        public static void Test()
        {

            for (int i = 0; i < 12; i++)
                Console.WriteLine(NthUglyNumber(i));

        }

        protected static List<int> uglyList = new List<int>();

        public static int NthUglyNumber(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            if (uglyList.Count == 0)
            {
                uglyList.Add(1);
                uglyList.Add(2);
            }

            if (uglyList.Count >= n)
            {
                return uglyList[n - 1];
            }

            int lastHasUglyNumber = uglyList.Count;
            int tempUgly2 = 0;
            int tempUgly3 = 0;
            int tempUgly5 = 0;
            int min = 0;

            for (int i = lastHasUglyNumber - 1; i < n; i++)
            {
                tempUgly2 = tempUglyList(uglyList, 2, uglyList[i]);
                tempUgly3 = tempUglyList(uglyList, 3, uglyList[i]);
                tempUgly5 = tempUglyList(uglyList, 5, uglyList[i]);
                min = tempUgly2;
                if (min > tempUgly3)
                {
                    min = tempUgly3;
                }                
                if (min > tempUgly5)
                {
                    min = tempUgly5;
                }
                uglyList.Add(min);
            }

            return uglyList[n - 1];
        }

        public static int tempUglyList(List<int> uglyList, int multiple, int max)
        {
            var tempList = new List<int>();

            foreach (var num in uglyList)
            {
                if (max < num * multiple)
                    return num * multiple;
            }

            return 0;

        }
    }
}
