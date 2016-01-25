using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
    /// The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.
    /// </summary>
    public class Valid_Parentheses
    {

        public static void Test()
        {
            string s = "]";
            //s = "[()]";
            //  s = "([)]";
            // s = "{[()]}";
       //     s = "[{()}]";
         ////   s = "[([[[]]])]{}[}]";



            Console.WriteLine(IsValid2(s));
        }

        /// <summary>
        /// 栈的解法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValid2(string s)
        {

            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            var arrChr = s.ToArray();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < arrChr.Length; i++)
            {
                switch (arrChr[i])
                {
                    case '(':
                        stack.Push('(');
                        break;
                    case ')':
                        if (stack.Count>0&&stack.Pop() != '(')
                            return false;
                        break;
                    case '{':
                        stack.Push('{');

                        break;
                    case '}':
                        if (stack.Count > 0 && stack.Pop() != '{')
                            return false;
                        break;
                    case '[':
                        stack.Push('[');

                        break;
                    case ']':
                        if (stack.Count > 0 && stack.Pop() != '[')
                            return false;
                        break;
                }
            }

            if (stack.Count == 0)
            {
                return true;
            }
            else
                return false;

        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValid(string s)
        {

            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            var arrChr = s.ToArray();
            int[] cha = new int[3];
            List<int> list0 = new List<int>();
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            for (int i = 0; i < arrChr.Length; i++)
            {
                switch (arrChr[i])
                {
                    case '(':
                        cha[0]++;
                        list0.Add(i);
                        break;
                    case ')':
                        if (cha[0] == 0)
                            return false;
                        if (cha[1] != 0 && list1[0] > list0.Last())
                            return false;
                        if (cha[2] != 0 && list2[0] > list0.Last())
                            return false;
                        cha[0]--;
                        list0.RemoveAt(cha[0]);
                        break;
                    case '{':
                        cha[1]++;
                        list1.Add(i);
                        break;
                    case '}':
                        if (cha[1] == 0)
                            return false;
                        if (cha[0] != 0 && list0[0] > list1.Last())
                            return false;
                        if (cha[2] != 0 && list2[0] > list1.Last())
                            return false;
                        cha[1]--;
                        list1.RemoveAt(cha[1]);
                        break;
                    case '[':
                        cha[2]++;
                        list2.Add(i);
                        break;
                    case ']':
                        if (cha[2] == 0)
                            return false;
                        if (cha[0] != 0 && list0[0] > list2.Last())
                            return false;
                        if (cha[1] != 0 && list1[0] > list2.Last())
                            return false;
                        cha[2]--;
                        list2.RemoveAt(cha[2]);

                        break;
                }
            }

            if (cha[0] == 0 && cha[1] == 0 && cha[2] == 0)
            {
                return true;
            }
            else
                return false;

        }


    }
}
