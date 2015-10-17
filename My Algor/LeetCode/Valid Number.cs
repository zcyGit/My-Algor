using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// 这道题主要是针对用例来进行编程
    /// 比如判断的条件就有很多模糊的地方
    /// Validate if a given string is numeric.
    //Some examples:
    //"0" => true
    //" 0.1 " => true
    //"abc" => false
    //"1 a" => false
    //"2e10" => true
    //Note: It is intended for the problem statement to be ambiguous. You should gather all requirements up front before implementing one.
    /// </summary>
    public class Valid_Number
    {

        public static void Test()
        {
            string[] ss = new string[] { "32.e-80123"," 005047e+6", "6ee69", "0e0", "46.e3", "+.8", "-.", "-1.", "1e01", "1e.", "1 4", "2e0", "7e69e", "5e", "..", " 0", "01", ".", ".1", "0", "0.1", "abc", "1 a", "2e10" };

            foreach (var s in ss)
            {
                Console.WriteLine(s + ":" + IsNumber(s) + " ");

            }

        }


        public static bool IsNumber(string s)
        {
            s = s.Trim();
            if (s == null || string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            var chars = s.ToArray();

            var decSep = '.';
            int number = 0;
            int decSepNumber = 0;
            int expNumber = 0;
            int Length = s.Length;
            int charsIndex = 0;

            if (chars[charsIndex] == '+' || chars[charsIndex] == '-')
            {
                charsIndex++;
            }
            else if (chars[charsIndex] != '.' && chars[charsIndex] != '+' && chars[charsIndex] != '-')
            {
                if (!(chars[charsIndex] >= '0' && chars[charsIndex] <= '9'))
                {
                    return false;
                }
            }

            while (charsIndex < Length)
            {
                //判断小数点个数
                if (decSepNumber > 1 || expNumber > 1)
                {
                    return false;
                }

                if (chars[charsIndex] == decSep)
                {
                    decSepNumber++;
                    charsIndex++;
                    continue;
                }

                //保存数字个数
                if (chars[charsIndex] >= '0' && chars[charsIndex] <= '9')
                {
                    number++;
                    charsIndex++;
                    continue;
                }

                if (chars[charsIndex] == 'e' || chars[charsIndex] == 'E')
                {
                    //e前面只能为数字
                    if (number == 0)
                    {
                        return false;
                    }

                    //e后面只能为数字，且不能出现.
                    return IsPositive(chars, charsIndex + 1, Length);

                }

                return false;
            }

            //判断小数点个数
            if (decSepNumber > 1 || expNumber > 1 || number == 0)
            {
                return false;
            }

            return true;

        }

        public static bool Is0To9Number(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return true;
            }
            return false;
        }

        public static bool IsPositive(char[] c, int index, int length)
        {
            int number = 0;

            if (index == length)
            {
                return false;
            }
            if (index == length - 1 && !Is0To9Number(c[index]))
            {
                return false;
            }

            if (c[index] == '+' || c[index] == '-')
            {
                index++;
            }

            while (index < length)
            {
                //保存数字个数
                if (c[index] >= '0' && c[index] <= '9')
                {
                    index++;
                    number++;
                    continue;
                }
                return false;
            }
            if (number==0)
            {
                return false;
            }

            return true;

        }





        #region Unsafe

        //public unsafe static bool IsNumberUnsafe(string s)
        //{
        //    if (s == null || string.IsNullOrWhiteSpace(s))
        //    {
        //        return false;
        //    }

        //    fixed (char* p = s)
        //    {
        //        return IsNumber(p, s.Length);
        //    }
        //}

        //public unsafe static bool IsNumberUnsafe(char* str, int length)
        //{

        //    var decSep = '.';
        //    var exp = 'e';
        //    int number = 0;
        //    int zimuNumber = 0;
        //    int decSepNumber = 0;
        //    if (*str == decSep || !(*str >= '0' && *str <= '9'))
        //    {
        //        return false;
        //    }

        //    while (*str != 0x00)
        //    {
        //        //判断小数点个数
        //        if (decSepNumber > 1)
        //        {
        //            return false;
        //        }

        //        if (*str == decSep)
        //        {
        //            decSepNumber++;
        //            str++;
        //            continue;
        //        }
        //        //空格直接返回false
        //        if ((*str == '\u00A0') || (*str == '\u0020'))
        //        {
        //            return false;
        //        }
        //        //保存数字个数
        //        if (*str >= '0' && *str <= '9')
        //        {
        //            number++;
        //            str++;
        //            continue;
        //        }

        //        if (*str >= 'A' && *str <= 'F')
        //        {
        //            zimuNumber++;
        //            str++;
        //            continue;

        //        }
        //        if (*str >= 'a' && *str <= 'f')
        //        {
        //            zimuNumber++;
        //            str++;
        //            continue;
        //        }

        //        return false;
        //    }

        //    return true;
        //}

        #endregion
    }
}
