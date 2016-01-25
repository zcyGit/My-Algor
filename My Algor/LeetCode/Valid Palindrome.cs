using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases. 

    ///For example,
    ///"A man, a plan, a canal: Panama" is a palindrome.
    ///"race a car" is not a palindrome. 

    /// </summary>
    public class Valid_Palindrome
    {
        public static void Test()
        {
            string s = " apG0i4maAs::sA0m4i0Gp0";

            Console.Write(IsPalindrome(s));

        }

        /// <summary>
        /// 判断是否是回文字符串
        /// </summary>
        /// <returns></returns>
        public static bool IsPalindrome(string s)
        {

            if (string.IsNullOrWhiteSpace(s))
            {
                return true;
            }
            if (s.Length <= 1)
            {
                return true;
            }
            s = s.Trim().ToLower();

            int begin = 0;
            int end = s.Length - 1;


            while (begin <= end)
            {
                if (begin == end)
                    return true;

                if ((s[begin] >= 'a' && s[begin] <= 'z') || (s[begin] >= '0' && s[begin] <= '9'))
                {
                    if ((s[end] >= 'a' && s[end] <= 'z') || (s[end] >= '0' && s[end] <= '9'))
                    {
                        if (s[begin] == s[end] && end == begin + 1)
                        {
                            return true;
                        }
                        else if (s[begin] == s[end])
                        {
                            begin++;
                            end--;
                            continue;
                        }
                        else
                            return false;
                    }
                    else
                    {
                        end--;
                    }
                }
                else
                {
                    begin++;
                }
            }
            return false;
        }
    }
}
