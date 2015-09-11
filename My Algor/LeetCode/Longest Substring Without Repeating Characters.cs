using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a string, find the length of the longest substring without repeating characters. 
    /// For example, the longest substring without repeating letters for "abcabcbb" is "abc", 
    /// which the length is 3. For "bbbbb" the longest substring is "b", with the length of 1.
    /// </summary>
    class Longest_Substring_Without_Repeating_Characters
    {

        public static void Test()
        {

            string s = "pwwkew";
            var length = LengthOfLongestSubstring(s);
            Console.WriteLine(length);
        }



        public static int LengthOfLongestNoRepeatSubstring(string s)
        {
            List<char> charList = new List<char>();

            foreach (var cha in s.ToCharArray())
            {
                if (!charList.Contains(cha))
                {
                    charList.Add(cha);
                }
            }

            return charList.Count;
        }


        public static int LengthOfLongestSubstring(string s)
        {
            List<char> charList = new List<char>();
            int length = 0;
            foreach(var cha in s.ToCharArray())
            {
                if (!charList.Contains(cha))
                {
                    charList.Add(cha);
                }
                else
                {
                    if (length < charList.Count)
                    {
                        length = charList.Count;
                    }

                    charList.RemoveRange(0, charList.IndexOf(cha)+1);
                    
                    charList.Add(cha);
                }
            }

            if (length < charList.Count)
            {
                length = charList.Count;
            }
            return length;
        }

    }
}
