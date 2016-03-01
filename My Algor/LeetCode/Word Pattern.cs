using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a pattern and a string str, find if str follows the same pattern.

    /// Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in str.
    //    Examples:

    //1.pattern = "abba", str = "dog cat cat dog" should return true.
    //2.pattern = "abba", str = "dog cat cat fish" should return false.
    //3.pattern = "aaaa", str = "dog cat cat dog" should return false.
    //4.pattern = "abba", str = "dog dog dog dog" should return false.
    /// </summary>
    public class Word_Pattern
    {
        public static void Test()
        {
            var str = "dog cat cat dog";
            var pattern = "abba";

            Console.Write(WordPattern(pattern, str));
        }

        /// <summary>
        /// 可以改进为用hashset,用char变成int，然后value
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool WordPattern(string pattern, string str)
        {
            if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(str))
            {
                return false;
            }

            Dictionary<char, string> dic = new Dictionary<char, string>();
            Dictionary<string, char> dicTwo = new Dictionary<string, char>();


            var strs = str.Split(' ');
            var patterns = pattern.ToArray();

            if (strs.Length != patterns.Length)
            {
                return false;
            }
            int number = 0;
            foreach (var chr in patterns)
            {
                if (dic.ContainsKey(chr))
                {
                    if (dic[chr] != strs[number])
                    {
                        return false;
                    }
                }
                else
                    dic.Add(chr, strs[number]);

                if (dicTwo.ContainsKey(strs[number]))
                {
                    if (dicTwo[strs[number]] != chr)
                    {
                        return false;
                    }
                }
                else
                    dicTwo.Add(strs[number], chr);

                number++;
            }

            return true;
        }
    }
}
