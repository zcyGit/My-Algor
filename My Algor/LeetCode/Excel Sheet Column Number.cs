using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Excel_Sheet_Column_Title
    {
        public static void Test()
        {
            var n = 100;

            //Console.WriteLine(ConvertToTitle(0));
            //Console.WriteLine(ConvertToTitle(1));
            //Console.WriteLine(ConvertToTitle(26));
            //Console.WriteLine(ConvertToTitle(27));
            //Console.WriteLine(ConvertToTitle(28));
            //Console.WriteLine(ConvertToTitle(52));
            //Console.WriteLine(ConvertToTitle(53));
            Console.WriteLine(ConvertToTitle(703));


        }

        public static string[] Title = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

        public static string ConvertToTitle(int n)
        {
            string result = "";

            if (n <= 0)
            {
                return "";
            }
            if (n < 27)
            {
                return Title[n - 1];
            }
            var temp = n;

            if (temp <= 26)
            {
                result += Title[temp - 1];
            }
            else
            {
                temp = (temp - 1) / 26;
                result += ConvertToTitle(temp);
            }

            result += Title[(n - 1) % 26];
            return result;
        }
    }
}
