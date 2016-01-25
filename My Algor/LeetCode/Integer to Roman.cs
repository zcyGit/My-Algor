using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given an integer, convert it to a roman numeral. 
    /// Input is guaranteed to be within the range from 1 to 3999.
    /// </summary>
    public class Integer_to_Roman
    {
        public static void Test()
        {
            int num = 1888;

            Console.Write(IntToRoman(num));
        }

        //1. 基本数字 Ⅰ、X 、C 中的任何一个、自身连用构成数目、或者放在大数的右边连用构成数目、都不能超过三个；放在大数的左边只能用一个；
        //2. 不能把基本数字 V 、L 、D 中的任何一个作为小数放在大数的左边采用相减的方法构成数目；放在大数的右边采用相加的方式构成数目、只能使用一个；
        //3. V 和 X 左边的小数字只能用 Ⅰ；
        //4.L 和 C 左边的小数字只能用X；
        //5. D 和 M 左边的小数字只能用 C。
        public static string IntToRoman(int num)
        {
            List<char> charList = new List<char>();

            if (num / 1000 != 0)
            {
                for (int i = 0; i < num / 1000; i++)
                {
                    charList.Add('M');
                }
            }

            int hundred = num / 100 % 10;

            if (hundred != 0)
            {
                if (hundred >= 5 && hundred < 9)
                {
                    charList.Add('D');

                    for (int i = 0; i < hundred - 5; i++)
                    {
                        charList.Add('C');
                    }
                }
                else if (hundred == 4)
                {
                    charList.Add('C');
                    charList.Add('D');
                }
                else if (hundred == 9)
                {
                    charList.Add('C');
                    charList.Add('M');
                }
                else
                {
                    for (int i = 0; i < hundred; i++)
                    {
                        charList.Add('C');
                    }
                }
            }

            int ten = num / 10 % 10;
            if (ten != 0)
            {

                if (ten >= 5 && ten < 9)
                {
                    charList.Add('L');

                    for (int i = 0; i < ten - 5; i++)
                    {
                        charList.Add('X');
                    }
                }
                else if (ten == 4)
                {
                    charList.Add('X');
                    charList.Add('L');
                }
                else if (ten == 9)
                {
                    charList.Add('X');
                    charList.Add('C');
                }
                else
                {
                    for (int i = 0; i < ten; i++)
                    {
                        charList.Add('X');
                    }
                }
            }

            int bits = num % 10;
            if (bits != 0)
            {

                if (bits >= 5 && bits < 9)
                {
                    charList.Add('V');

                    for (int i = 0; i < bits - 5; i++)
                    {
                        charList.Add('I');
                    }
                }
                else if (bits == 4)
                {
                    charList.Add('I');
                    charList.Add('V');
                }
                else if (bits == 9)
                {
                    charList.Add('I');
                    charList.Add('X');
                }
                else
                {
                    for (int i = 0; i < bits; i++)
                    {
                        charList.Add('I');
                    }
                }
            }

            return String.Join("", charList.ToArray());
        }
    }
}
