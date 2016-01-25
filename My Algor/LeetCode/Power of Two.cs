using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given an integer, write a function to determine if it is a power of two. 
    /// </summary>
    class Power_of_Two
    {
        public static void Test()
        {
            int n = 8;
            Console.WriteLine(IsPowerOfTwo(-2147483648));
            Console.WriteLine(IsPowerOfTwo(2));

        }

        public static bool IsPowerOfTwo(int n)
        {
            //如果是power of two, 则2进制表达中,有且仅有一个1.  可以通过移位来数1的个数, 这里用了一个巧妙的办法, 即判断   N & (N-1) 是否为0. 
            //return n > 0 && ((n & (n - 1)) == 0 );  

            if (n < 1)
            {
                return false;
            }

            return Number.Contains(n);
        }


        public static List<int> _number;
        public static List<int> Number
        {
            get
            {

                if (_number != null && _number.Count() > 0)
                {
                    return _number;
                }
                else
                {
                    _number = new List<int>();
                    _number.Add(1);
                    for (int i = 1; i < 32; i++)
                    {
                        _number.Add(2 * _number[i - 1]);
                    }

                    return _number;
                }

            }
        }

    }
}
