using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Length_of_Last_Word
    {

        public static void Test()
        {
            var s = " a";
            Console.Write(LengthOfLastWord(s));

        }

        public static int LengthOfLastWord(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }
            s = s.Trim();
            var length = s.Length;
            int number = length;
            for (; number > 0; number--)
            {
                if (s[number - 1] == ' ')
                {
                    return length - number;
                }
            }

            return length;

        }
    }
}
