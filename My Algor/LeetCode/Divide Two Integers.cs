using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.

    //If the fractional part is repeating, enclose the repeating part in parentheses.

    //For example, 
    //•Given numerator = 1, denominator = 2, return "0.5".
    //•Given numerator = 2, denominator = 1, return "2".
    //•Given numerator = 2, denominator = 3, return "0.(6)".
    /// </summary>
    public class Divide_Two_Integer
    {
        public static void Test()
        {

            int dividend = -2147483648;
            int divisor = 1;

            Console.WriteLine(Divide(dividend, divisor));

        }

        public static int Divide(int dividend, int divisor)
        {
            long x = dividend;
            long y = divisor;
            bool flag = true;


            if (x < 0)
            {
                x = Math.Abs(x);
                flag = !flag;
            }
            if (y < 0)
            {
                y = Math.Abs(y);
                flag = !flag;
            }

            if (x < y)
            {
                return 0;
            }
            long temp = y;

            long divide = 1;
            long totalDivide = 0;
            while (x > y)
            {
                if (x > y + y)
                {
                    y += y;
                    divide += divide;
                }
                else
                {
                    x = x - y;
                    y = temp;

                    totalDivide += divide;
                    divide = 1;
                }
            }
            totalDivide += divide;

            while (x < y)
            {
                y -= temp;
                totalDivide--;
            }

            totalDivide = flag ? totalDivide : -totalDivide;

            if (totalDivide > Int32.MaxValue)
            {
                return Int32.MaxValue;
            }
            else
                return (int)totalDivide;

        }
    }
}
