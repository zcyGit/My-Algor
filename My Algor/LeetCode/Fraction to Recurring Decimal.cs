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
    public class Fraction_to_Recurring_Decimal
    {
        public static void Test()
        {
            int numerator = -3;
            int denominator = 3;


            Console.WriteLine(FractionToDecimal(numerator, denominator));


            //Console.WriteLine(FindRepeat(str));

        }

        public static string FractionToDecimal(int numerator, int denominator)
        {
            if(denominator==0)
            {
                return "0";
            }

            long x = numerator;
            long y = denominator;

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

            long result = x / y;

            var str = result.ToString();

            var remainder = x % y;

            if (remainder == 0)
            {
                if (result == 0)
                    return "0";
                return flag ? str : "-" + str;
            }

            return string.Format("{0}.{1}", flag ? str : "-" + str, FindRepeat(remainder, y));
        }


        public static string FindRepeat(long x, long y)
        {
            Dictionary<long, int> dic = new Dictionary<long, int>();
            int i = 0;
            StringBuilder sb = new StringBuilder();

            while (x != 0 && !dic.ContainsKey(x))
            {
                dic.Add(x, i);
                ++i;
                x *= 10;
                sb.Append(x / y);
                x %= y;
            }

            if (x != 0)
            {
                sb.Insert(dic[x], '(');
                sb.Append(')');

            }

            return sb.ToString();
        }



        //public static string FindRepeat(string str)
        //{
        //    var chars = str.ToArray();

        //    if (chars.Length >= 27)
        //    {
        //        for (int i = 0; i < chars.Length; i++)
        //        {
        //            int repeatIndex = -1;
        //            int repeatLength = 0;

        //            for (int j = i + 1; j < chars.Length; j++)
        //            {
        //                if (chars[i] == chars[j])
        //                {
        //                    if (i == j - 1 && chars[i] == chars[j + 1])
        //                    {
        //                        if (chars[i] != '0')
        //                        {
        //                            return string.Format("{0}({1})", str.Substring(0, i), chars[i]);
        //                        }
        //                        else
        //                            return string.Format("{0}", str.Substring(0, i));

        //                    }

        //                    repeatIndex = i;


        //                }
        //                if (repeatIndex != -1)
        //                {
        //                    int z = i;
        //                    int x = j;
        //                    while (chars[z] == chars[x])
        //                    {


        //                        if (z == j)
        //                        {
        //                            return string.Format("{0}({1})", str.Substring(0, repeatIndex), str.Substring(repeatIndex, repeatLength));
        //                        }
        //                        z++;
        //                        x++;
        //                        repeatLength++;

        //                        if (x >= chars.Length - 1)
        //                        {
        //                            return string.Format("{0}({1})", str.Substring(0, repeatIndex), str.Substring(repeatIndex, j - i));
        //                        }


        //                    }
        //                    repeatIndex = -1;
        //                    repeatLength = 0;
        //                }
        //            }
        //        }
        //    }

        //    return str;

        //}

    }
}
