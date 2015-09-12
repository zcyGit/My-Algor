using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    class Plus_One
    {

        public static int[] PlusOne(int[] digits)
        {
            int one = 1;


            for (int i = digits.Length - 1; i >= 0; i--)
            {
                digits[i] = digits[i] + one;

                if (digits[i] <10)
                {
                    one = 0;
                    return digits;
                }
                digits[i] -= 10;

            }

            int[] res = new int[digits.Length + 1];
            res[0] = 1;

            for (int j = 0; j < digits.Length; j++)
            {
                res[j + 1] = digits[j];
            }
            return res;

        }
    }
}
