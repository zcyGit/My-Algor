using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Determine whether an integer is a palindrome. Do this without extra space.
    /// </summary>
    public class Palindrome_Number
    {

        public static void Test()
        {
            int x = 2147483647;
            Console.Write(IsPalindrome(x));

        }

        public static bool IsPalindrome(int x)
        {
            var result = true;
            if (x < 0)
            {
                return false;
            }
            if (x >= 0 && x <= 9)
            {
                return result;
            }
            int dupx = x;
            int revsx = 0;
            while (dupx != 0)
            {
                revsx = revsx * 10 + dupx % 10;
                dupx = dupx / 10;
            }

            return revsx == x;

        }

        //public static bool IsPalindrome2(int x)
        //{
        //    var result = true;
        //    if (x < 0)
        //    {
        //        return false;
        //    }
        //    if (x >= 0 && x <= 9)
        //    {
        //        return result;
        //    }

        //    return x == Convert.ToInt64(string.Join("", x.ToString().Reverse()));
        //}
    }
}
