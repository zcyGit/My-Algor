using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Pow
    {

        public static void Test()
        {
            while (true)
            {
                Console.Write("请输入数字");
                var x = Console.ReadLine();
                Console.Write("请输入次方");
                var n = Console.ReadLine();

                Console.WriteLine(MyPow(Convert.ToInt32(x), Convert.ToInt32(n)));
            }

            Console.Write(MyPow(0, 1));
        }
        public static double MyPow(double x, int n)
        {
            long nLong = n;
            if (nLong == 0)
                return 1;
            if (nLong < 0)
            {
                nLong = -nLong;
                x = 1 / x;
            }
            return (nLong % 2 == 0) ? MyPow(x * x, Convert.ToInt32(nLong / 2)) : x * MyPow(x * x, Convert.ToInt32(nLong / 2));
        }

    }
}
