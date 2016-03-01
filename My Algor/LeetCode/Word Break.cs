using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a string s and a dictionary of words dict,
    /// determine if s can be segmented into a space-separated sequence of one or more dictionary words. 
    ///For example, given
    ///s = "leetcode",
    ///dict = ["leet", "code"]. 
    ///Return true because "leetcode" can be segmented as "leet code". 
    /// </summary>
    public class Word_Break
    {

        public static void Test()
        {
            HashSet<string> wordDict = new HashSet<string>();


            string s = "aaaaaa";

            wordDict.Add("aaaa");
            wordDict.Add("aa");


            Console.Write(WordBreak2(s, wordDict));


        }

        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public static bool WordBreak2(string s, ISet<string> wordDict)
        {
            var cha = s.ToArray();
            int[,] result = new int[cha.Length, cha.Length];


            for (int i = 0; i < cha.Length; i++)
            {
                if (wordDict.Contains(s.Substring(0, i + 1)))
                {
                    result[0, i + 1] = 1;
                }

                for (int j = 0; j < i; j++)
                {
                    if (wordDict.Contains(s.Substring(j, i - j)) && result[0, j] == 1)
                    {
                        result[0, i] = 1;
                    }


                }
            }
            return result[0, cha.Length - 1] == 1 ? true : false;
        }



        /// <summary>
        /// 540ms 比较慢了，换一种写法
        /// </summary>
        /// <param name="s"></param>
        /// <param name="wordDict"></param>
        /// <returns></returns>
        public static bool WordBreak(string s, ISet<string> wordDict)
        {

            foreach (var word in wordDict)
            {
                if (s.Contains(word))
                {
                    if (s == word)
                    {
                        return true;
                    }
                    else
                    {
                        var strs = System.Text.RegularExpressions.Regex.Split(s, word);
                        var res = true;
                        for (int i = 0; i < strs.Length; i++)
                        {
                            if (strs[i] != "" && !WordBreak(strs[i], wordDict))
                            {
                                res = false;
                                break;
                            }
                        }
                        if (res)
                            return res;
                    }
                }
            }

            return false;
        }
    }
}
