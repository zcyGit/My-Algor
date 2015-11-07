using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a string s, partition s such that every substring of the partition is a palindrome. 
    /// 所谓回文字符串，就是一个字符串，从左到右读和从右到左读是完全一样的，比如"aba
    /// </summary>
    public class Palindrome_Partitioning
    {
        public static void Test()
        {
            string s = "amanaplanacanalpanama";
            //s = "aabaa";

            //var list = Partition(s);

            var solveLists = Partition1(s);

            foreach (var solveList in solveLists)
            {
                foreach (var solve in solveList)
                {
                    Console.Write(solve + " ");
                }
                Console.WriteLine();
            }
        }

        private static List<IList<string>> Partitionlist = new List<IList<string>>();
        private static int slength = 0;


        public static IList<IList<string>> Partition1(string s)
        {
            Partitionlist = new List<IList<string>>();

            if (string.IsNullOrEmpty(s))
            {
                return Partitionlist;
            }
            int[,] palindrome_map = new int[s.Length, s.Length];

            BulidingPalindromeMap(s, palindrome_map);
            PartitionRecursive(s, 0, new List<string>(), palindrome_map);

            return Partitionlist;
        }

        /// <summary>
        /// 生成标志回文字符串的数组，partitioning_map[i][j]=1的话，表明：string[i..j]是一个回文字符串  
        /// </summary>
        /// <param name="s"></param>
        /// <param name="palindrome_map"></param>
        public static void BulidingPalindromeMap(string s, int[,] palindrome_map)
        {
            for (int i = s.Length - 1; i >= 0; i--)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if (i == j)
                    {
                        palindrome_map[i, j] = 1;
                    }
                    else
                    {
                        if (s[i] == s[j])
                        {
                            if (j == i + 1 || palindrome_map[i + 1, j - 1] == 1)
                            {
                                palindrome_map[i, j] = 1;
                            }
                        }
                    }
                }
            }
        }


        public static void PartitionRecursive(string s, int number, List<string> list, int[,] palindrome_map)
        {

            if (s.Length == number)
            {
                Partitionlist.Add(list);
                return;
            }

            int begin = number;
            while (begin < s.Length)
            {

                if (palindrome_map[number, begin] == 1)
                {

                    List<string> innerList = new List<string>(list.ToArray());

                    innerList.Add(s.Substring(number, begin + 1 - number));

                    PartitionRecursive(s, begin + 1, innerList, palindrome_map);


                }
                begin++;

            }

        }



        /// <summary>
        /// 方法超时
        /// 改进方法（空间换时间，我可以把字符串中的可以构成 回文字符串 的字符记录下来，这样就不用一次次的判断了）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static IList<IList<string>> Partition2(string s)
        {
            Partitionlist = new List<IList<string>>();

            if (string.IsNullOrEmpty(s))
            {
                return Partitionlist;
            }


            int number = 1;
            slength = s.Length;
            while (number <= s.Length)
            {
                List<string> innerList = new List<string>();
                PartitionRecursive(s, number, innerList);
                if (!IsExist(innerList))
                {
                    Partitionlist.Add(innerList);
                }
                number++;

            }

            return Partitionlist;
        }

        public static bool PartitionRecursive(string s, int number, List<string> list)
        {
            if (number > s.Length)
            {
                return true;
            }

            if (s.Length == 1)
            {
                list.Add(s);
                return true;
            }
            string prePart = s.Substring(0, number);

            if (IsPalindrome(prePart))
            {
                list.Add(prePart);
            }
            else
            {
                PartitionRecursive(prePart, 1, list);
            }

            string nextPart = s.Substring(number, s.Length - number);
            if (nextPart == "")
            {
                return true;
            }

            if (IsPalindrome(nextPart))
            {
                var templist = new List<string>(list.ToArray());
                templist.Add(nextPart);
                if (!IsExist(templist))
                {
                    Partitionlist.Add(templist);

                    PartitionRecursive(nextPart, 1, list);

                }
   
            }
            else
            {
                int begin = 1;
                while (begin < nextPart.Length)
                {
                    var templist = new List<string>(list.ToArray());

                    PartitionRecursive(nextPart, begin, templist);
                    begin++;

                }
            }

            return true;

        }

        public static bool IsExist(List<string> list)
        {
            int numberLength = 0;
            foreach (var s in list)
            {
                numberLength += s.Length;
            }

            if (numberLength != slength)
            {
                return true;
            }

            foreach (var solution in Partitionlist)
            {
                if (solution.Count != list.Count)
                {
                    continue;
                }
                int number = 0;
                foreach (var s in list)
                {
                    if (solution[number] != s)
                    {
                        break;
                    }
                    else
                        number++;
                }
                if (list.Count == number)
                {
                    return true;
                }

            }

            return false;

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
    }
}
