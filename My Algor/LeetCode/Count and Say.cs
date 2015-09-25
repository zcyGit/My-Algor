using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// The count-and-say sequence is the sequence of integers beginning as follows:
    /// 1, 11, 21, 1211, 111221, ... 
    /// 1 is read off as "one 1" or 11.
    ///11 is read off as "two 1s" or 21.
    ///21 is read off as "one 2, then one 1" or 1211.
    ///Given an integer n, generate the nth sequence.
    /// </summary>

    class Count_and_Say
    {
        public static void Test()
        {
            int n = 2;
            var sound = CountAndSay(n);

            Console.Write(sound);

        }
        public static string CountAndSay(int n)
        {
            StringBuilder sb = new StringBuilder();
            string first = "1";

            for (int i = 0; i < n; i++)
            {
                while (i + 1 < n)
                {
                    first = CountAndSayNext(first);
                    i++;
                }
            }

            return first;
        }

        /// <summary>
        /// 获取下一个数值
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string CountAndSayNext(string n)
        {
            char[] cha = n.ToArray();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cha.Length; i++)
            {
                int soundNumber = 1;

                while (i + 1 < cha.Length && cha[i] == cha[i + 1])
                {
                    i++;
                    soundNumber++;
                }
                sb.Append(soundNumber);
                sb.Append(cha[i]);
            }

            return sb.ToString();
        }



    }
}
