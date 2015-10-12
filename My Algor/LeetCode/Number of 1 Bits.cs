using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Write a function that takes an unsigned integer and returns the number of ’1' bits it has (also known as the Hamming weight).
    ///For example, the 32-bit integer ’11' has binary representation 00000000000000000000000000001011, so the function should return 3.
    /// </summary>
    public class Number_of_1_Bits
    {
        public static void Test()
        {
            uint n = 4;
            var solveLists = HammingWeight(n);

            Console.WriteLine(solveLists);
        }

        public static int HammingWeight(uint n)
        {
            var number = 0;
            if (n == 0)
            {
                return 0;
            }
            while (n > 0)
            {
                ++number;
                n = (n - 1) & n;
            }

            return number;
        }
    }
}
