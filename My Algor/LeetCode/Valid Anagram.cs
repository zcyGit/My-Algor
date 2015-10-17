using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    // Given two strings s and t, write a function to determine if t is an anagram of s.
    // For example,
    // s = "anagram", t = "nagaram", return true.
    // s = "rat", t = "car", return false. 

    public class Valid_Anagram
    {
        public static void Test()
        {
            string s = "anagram";
            string t = "nabaram";
            Console.Write(IsAnagram(s, t));

        }
        public static bool IsAnagram(string s, string t)
        {
            //26个英语小写单词
            int[] alphabets = new int[26];

            if (s.Length != t.Length)
            {
                return false;
            }
            for (int i = 0; i < s.Length; i++)
            {
                alphabets[s[i] - 'a'] += 1;
                alphabets[t[i] - 'a'] -= 1;
            }
            for (int i = 0; i < alphabets.Length; i++)
            {
                if (alphabets[i] != 0)
                {
                    return false;
                }
            }

            return true;

        }
    }
}
