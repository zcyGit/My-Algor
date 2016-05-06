using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{

    /// <summary>
    /// Convert a non-negative integer to its english words representation. Given input is guaranteed to be less than 231 - 1. 
    //For example,
    //123 -> "One Hundred Twenty Three"
    //12345 -> "Twelve Thousand Three Hundred Forty Five"
    //1234567 -> "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
    /// </summary>
    class NumberToWords
    {
        public static void Test()
        {

            int nums = 1000000;
            var solveLists = NumberToWordsStr(nums);

            Console.Write(solveLists);
        }



        public static string NumberToWordsStr(int num)
        {
            var chars = num.ToString();
            var list = new List<string>();

            var length = chars.Length;
            var sum = (length - 1) / 3;

            for (int i = 0; i <= sum; i++)
            {
                var tempNum = string.Empty;
                if (i == 0)
                {
                    tempNum = chars.Substring(0, length - sum * 3);
                }
                else
                {
                    tempNum = chars.Substring((i - 1) * 3 + length - sum * 3, 3);
                }

                num2str(tempNum, list);

                if (sum > 0 && tempNum != "000")
                {
                    list.Add(tbl[sum - i]);
                }
            }

            return string.Join(" ", list).Trim();
        }

        static string[] hsh = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        static string[] hsh1 = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        static string[] hsh2 = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        static string[] tbl = new string[] { "", "Thousand", "Million", "Billion" };

        public static void num2str(string num, List<string> list)
        {
            var len = num.Length;

            if (len == 3)
            {
                if (num[0] > '0')
                {
                    list.Add(hsh[Convert.ToInt32(num[0]) - 48]);
                    list.Add("Hundred");
                }
                if (num[1] > '1')
                {
                    list.Add(hsh2[Convert.ToInt32(num[1]) - 48]);
                    if (num[2] > '0')
                        list.Add(hsh[Convert.ToInt32(num[2]) - 48]);
                }
                else if (num[1] == '1')
                {
                    list.Add(hsh1[Convert.ToInt32(num[2]) - 48]);
                }
                else
                {
                    if (num[2] > '0')
                        list.Add(hsh[Convert.ToInt32(num[2]) - 48]);
                }
            }
            else if (len == 2)
            {
                if (num[0] > '1')
                {
                    list.Add(hsh2[Convert.ToInt32(num[0]) - 48]);
                    if (num[1] > '0')
                        list.Add(hsh[Convert.ToInt32(num[1] - 48)]);

                }
                else if (num[0] == '1')
                {
                    list.Add(hsh1[Convert.ToInt32(num[1] - 48)]);
                }
                else
                {
                    if (num[1] > '0')
                        list.Add(hsh[Convert.ToInt32(num[1] - 48)]);
                }
            }
            else
            {
                list.Add(hsh[Convert.ToInt32(num[0]) - 48]);
            }
        }


    }
}
