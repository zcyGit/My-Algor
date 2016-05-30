using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Sqrt_x_
    {
        public static void Test()
        {
            while (true)
            {
                var x = Console.ReadLine();
                Console.WriteLine(MySqrt(Convert.ToInt32(x)));
            }

            //var x =int.MaxValue;
            //Console.WriteLine(MySqrt(Convert.ToInt32(x)));


        }


        public static int MySqrt(int x)
        {
            if (x <= 1)
            {
                return x;
            }

            int left = 1;
            int right = x;

            while (left < right)
            {
                var mid = left + (right - left) / 2;
                var divison = x / mid;

                if (divison == mid)
                {
                    return mid;
                }
                else if (divison > mid)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left - 1;
        }
    }
}
