using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given an input string, reverse the string word by word. 

    ///For example,
    ///Given s = "the sky is blue",
    ///return "blue is sky the". 

    /// </summary>
    public class Reverse_Words_in_a_String
    {
        public static void Test()
        {
            var s = "the sky  is blue";

            Console.WriteLine(ReverseWords(s));

        }

        public static string ReverseWords(string s)
        {
            var res = string.Empty;
            var temp = string.Empty;

            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            foreach (var cha in s.Trim().ToArray())
            {
                if (cha != ' ')
                    temp = temp + cha;
                else if (cha == ' ')
                {
                    if (temp != string.Empty)
                        res = temp + " " + res;
                    temp = string.Empty;
                }
            }

            if (temp != string.Empty)
            {
                res = temp + " " + res;
            }

            return res.Trim();

        }
    }
}
