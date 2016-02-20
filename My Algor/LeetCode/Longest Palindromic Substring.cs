using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a string S, find the longest palindromic substring in S.
    /// You may assume that the maximum length of S is 1000, and there exists one unique longest palindromic substring.
    /// </summary>
    public class Longest_Palindromic_Substring
    {
        public static void Test()
        {
            string s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabcaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            s = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";

       //     s = "aaabcccc1";
         //   s = "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";
            //  s = "aaaa";
            s = "tattarrattat";
           s = "hpyyphyqharjvzriosrdnwmaxtgriivdqlmugtagvsoylqfwhjpmjxcysfujdvcqovxabjdbvyvembfpahvyoybdhweikcgnzrdqlzusgoobysfmlzifwjzlazuepimhbgkrfimmemhayxeqxynewcnynmgyjcwrpqnayvxoebgyjusppfpsfeonfwnbsdonucaipoafavmlrrlplnnbsaghbawooabsjndqnvruuwvllpvvhuepmqtprgktnwxmflmmbifbbsfthbeafseqrgwnwjxkkcqgbucwusjdipxuekanzwimuizqynaxrvicyzjhulqjshtsqswehnozehmbsdmacciflcgsrlyhjukpvosptmsjfteoimtewkrivdllqiotvtrubgkfcacvgqzxjmhmmqlikrtfrurltgtcreafcgisjpvasiwmhcofqkcteudgjoqqmtucnwcocsoiqtfuoazxdayricnmwcg";
           s = "ccccc";
            var solveLists = LongestPalindrome3(s);

            Console.Write(solveLists);


        }

        /// <summary>
        /// 解法3 中心扩展法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LongestPalindrome3(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length <= 2)
            {
                return s;
            }

            int length = s.Length;
            int begin = 1;
            int left = 0;
            int right = 2;
            int maxLengthOdd = 0;
            int maxBeginOdd = 0;
            int maxLengthEven = 0;
            int maxBeginEven = 0;
            //奇数
            while (begin < length)
            {
                while (left >= 0 && right < length)
                {
                    if (s[left] != s[right])
                        break;

                    left--;
                    right++;
                }
                var tempLength = right - left - 1;
                if (tempLength > maxLengthOdd)
                {
                    maxBeginOdd = left + 1;
                    maxLengthOdd = tempLength;
                }
                begin++;
                left = begin - 1;
                right = begin + 1;
            }
            begin = 0;
            left = -1;
            right = 1;
            //偶数
            while (begin < length)
            {
                while (left >= -1 && right < length)
                {
                    if (s[begin] == s[right] && right - begin == 1)
                    {
                        right++;
                    }
                    else if (left >= 0 && s[left] == s[right])
                    {
                        right++;
                        left--;
                    }
                    else
                        break;
                }

                var tempLength = right - left - 1;

                if (tempLength > maxLengthEven)
                {
                    maxBeginEven = left + 1;
                    maxLengthEven = tempLength;
                }
                begin++;
                left = begin - 1;
                right = begin + 1;
            }

            if (maxLengthEven > maxLengthOdd)
            {
                return s.Substring(maxBeginEven, maxLengthEven);
            }
            else
                return s.Substring(maxBeginOdd, maxLengthOdd);

        }



        #region 改进一次的
        public static string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
            {
                return s;
            }

            return BulidingPalindromeMap(s);
        }

        /// <summary>
        /// Memory Limit Exceeded(超出内存上限) 
        /// 生成标志回文字符串的数组，partitioning_map[i][j]=1的话，表明：string[i..j]是一个回文字符串  
        /// </summary>
        /// <param name="s"></param>
        /// <param name="palindrome_map"></param>
        public static string BulidingPalindromeMap(string s)
        {

            Dictionary<int, HashSet<int>> list = new Dictionary<int, HashSet<int>>();

            int maxLength = 0;
            int begin = 0;
            int tempLength = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if (i == j)
                    {
                        if (list.ContainsKey(i))
                        {
                            list[i].Add(j);
                        }
                        else
                        {
                            var value = new HashSet<int>();
                            value.Add(j);
                            list.Add(i, value);
                        }
                    }
                    else
                    {
                        if (s[i] == s[j])
                        {
                            if (j == i + 1 || (list.ContainsKey(i + 1) && list[i].Contains(j - 1)))
                            {
                                if (list.ContainsKey(i))
                                {
                                    list[i].Add(j);
                                }
                                else
                                {
                                    var value = new HashSet<int>();
                                    value.Add(j);
                                    list.Add(i, value);
                                }

                                tempLength = i - j < 0 ? j - i : i - j;
                                if (maxLength < tempLength)
                                {
                                    maxLength = tempLength;
                                    begin = i;
                                }
                            }
                        }
                    }
                }
            }

            return s.Substring(begin, maxLength + 1);
        }

        #endregion

        #region 牺牲空间换时间
        //public static string LongestPalindrome(string s)
        //{
        //    if (string.IsNullOrEmpty(s) || s.Length == 1)
        //    {
        //        return s;
        //    }

        //    return BulidingPalindromeMap(s);
        //}

        ///// <summary>
        ///// Memory Limit Exceeded(超出内存上限)
        ///// 生成标志回文字符串的数组，partitioning_map[i][j]=1的话，表明：string[i..j]是一个回文字符串  
        ///// </summary>
        ///// <param name="s"></param>
        ///// <param name="palindrome_map"></param>
        //public static string BulidingPalindromeMap(string s)
        //{
        //    int maxLength = 0;
        //    int begin = 0;
        //    int tempLength = 0;
        //    Int16[,] palindrome_map = new Int16[s.Length, s.Length];

        //    for (int i = s.Length - 1; i >= 0; i--)
        //    {
        //        for (int j = i; j < s.Length; j++)
        //        {
        //            if (i == j)
        //            {
        //                palindrome_map[i, j] = 1;
        //            }
        //            else
        //            {
        //                if (s[i] == s[j])
        //                {
        //                    if (j == i + 1 || palindrome_map[i + 1, j - 1] == 1)
        //                    {
        //                        palindrome_map[i, j] = 1;
        //                        tempLength = i - j < 0 ? j - i : i - j;
        //                        if (maxLength < tempLength)
        //                        {
        //                            maxLength = tempLength;
        //                            begin = i;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return s.Substring(begin, maxLength + 1);
        //}

        #endregion

        #region
        /// <summary>
        /// 解法2
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LongestPalindrome2(string s)
        {
            if (string.IsNullOrEmpty(s) || s.Length == 1)
            {
                return s;
            }
            var temps = "";
            var tempA = "";
            var tempB = "";

            int begin = 0;
            int length = s.Length;
            while (begin < length)
            {
                temps = s.Substring(begin, length - begin);
                if (IsPalindrome(temps))
                {
                    tempA = temps;
                    break;
                }

                begin++;
            }
            begin = length;
            while (begin >= 0)
            {
                temps = s.Substring(0, begin);
                if (IsPalindrome(temps))
                {
                    tempB = temps;
                    break;
                }

                begin--;
            }

            return tempA.Length > tempB.Length ? tempA : tempB;
        }


        /// <summary>
        /// 判断是否是回文字符串
        /// </summary>
        /// <returns></returns>
        public static bool IsPalindrome(string chas)
        {
            if (chas.Length <= 1)
            {
                return true;
            }

            if (chas[0] == chas[chas.Length - 1] && chas.Length == 2)
            {
                return true;
            }
            if (chas[0] == chas[chas.Length - 1])
            {
                return IsPalindrome(chas.Substring(1, chas.Length - 2));
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}
