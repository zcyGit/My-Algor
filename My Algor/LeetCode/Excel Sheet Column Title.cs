using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Excel_Sheet_Column_Number
    {
        public static void Test()
        {
            var s = "AAA";

            Console.WriteLine(TitleToNumber(s));

        }

        public static int TitleToNumber(string s)
        {
            int result = 0;
            var chrs = s.ToArray();

            for (int i = 0; i < chrs.Length; i++)
            {
                result = result * 26 + chrs[i] - 'A' + 1;
            }

            return result;
        }
    }
}
