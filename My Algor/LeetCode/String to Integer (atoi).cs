using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class String_to_Integer_atoi
    {
        public static void Test()
        {
            var strs = new string[] { "-2147483647","2147483648", "-9223372036854775809", "1a", "      +1t0789622140", "-a1", "+a1", "-1", "+-2", "+1" };

            foreach (var str in strs)
                Console.WriteLine(MyAtoi(str));

        }

        public static int MyAtoi(string str)
        {
            str = ValNumber(str);

            if ((str[0] == '+' && str.Length > 11) || (str[0] != '-' && str.Length > 10))
            {
                return Int32.MaxValue;
            }
            else if ((str[0] == '-' && str.Length > 11))
            {
                return Int32.MinValue;
            }

            long result = 0;
            Int64.TryParse(str, out result);

            if (result > Int32.MaxValue)
            {
                return Int32.MaxValue;
            }
            else if (result < Int32.MinValue)
            {
                return Int32.MinValue;
            }

            return (int)result;
        }

        public static string ValNumber(string str)
        {
            str = str.Trim();
            string resultString = string.Empty;
            List<char> chars = str.ToArray().ToList();
            int charsIndex = 0;
            while (chars.Count > 0 && chars.Count > charsIndex)
            {
                if (charsIndex == 0 && (chars[charsIndex] != '-' && chars[charsIndex] != '+' && !Is0To9Number(chars[charsIndex])))
                {
                    return "0";
                }
                else if (charsIndex != 0 && !Is0To9Number(chars[charsIndex]))
                {
                    break;
                }
                charsIndex++;

            }

            if (charsIndex >= 1)
            {
                for (int i = 0; i < charsIndex; i++)
                {
                    resultString += chars[i];
                }
            }
            else
                resultString = "0";

            return resultString;
        }

        public static bool Is0To9Number(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return true;
            }
            return false;
        }

        public static bool IsPositive(char[] c, int index, int length)
        {
            int number = 0;

            if (index == length)
            {
                return false;
            }
            if (index == length - 1 && !Is0To9Number(c[index]))
            {
                return false;
            }

            if (c[index] == '+' || c[index] == '-')
            {
                index++;
            }

            while (index < length)
            {
                //保存数字个数
                if (c[index] >= '0' && c[index] <= '9')
                {
                    index++;
                    number++;
                    continue;
                }
                return false;
            }
            if (number == 0)
            {
                return false;
            }

            return true;

        }
    }
}
