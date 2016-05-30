using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Regular_Expression_Matching
    {

        public static void Test()
        {
            //var s = "aaa";
            //var p = "ab*a*c*a";

            var s = "";
            var p = "c*a*";

            Console.Write(IsMatch(s, p));

        }


        public static bool IsMatch(string s, string p)
        {
            var sList = s.ToArray();
            var pList = p.ToArray();


            return IsMatchRegular(sList, pList);
        }


        public static bool IsMatchRegular(char[] s, char[] p)
        {
            if (p.Length == 0)
            {
                if (s.Length == 0)
                    return true;
            }
            else if (p.Length == 1)
            {
                if (s.Length == 0 && p[0] == '*')
                {
                    return true;
                }
                else if (s.Length == 1 && (p[0] == '.' || p[0] == s[0]))
                {
                    return true;
                }
            }
            else
            {

                if (s.Length == 0)
                {
                    if (p[1] == '*')
                    {
                        if (IsMatchRegular(s, Building(p, 2)))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (p[1] == '*')
                    {
                        if (IsMatchRegular(s, Building(p, 2)))
                        {
                            return true;
                        }

                        if ((p[0] == '.' || p[0] == s[0]))
                        {                            
                            return IsMatchRegular(Building(s, 1), p);
                        }
                        else
                        {
                            return IsMatchRegular(s, Building(p, 2));
                        }
                    }
                    else if (p[0] == '.' || p[0] == s[0])
                    {
                        return IsMatchRegular(Building(s, 1), Building(p, 1));
                    }
                }
            }

            return false;

        }

        public static char[] Building(char[] old, int number)
        {
            if (old.Length < number)
            {
                number -= 1;
            }

            var temp = new char[old.Length - number];
            var tempNumber = 0;
            for (int i = number; i < old.Length; i++)
            {
                temp[tempNumber] = old[i];
                tempNumber++;
            }

            return temp;
        }
    }
}
