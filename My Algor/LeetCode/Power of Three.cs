using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Power_of_Three
    {

        public static void Test()
        {
            int n = 8;
            Console.Write(IsPowerOfThree(n));
        }

        public static bool IsPowerOfThree(int n)
        {
            return (Math.Log10(n) / Math.Log10(3)) % 1 == 0;

        }
    }
}
