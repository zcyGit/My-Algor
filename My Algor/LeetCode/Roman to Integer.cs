using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    //Given a roman numeral, convert it to an integer.
    //Input is guaranteed to be within the range from 1 to 3999.
    //http://baike.baidu.com/link?url=kVelZOJfjSXY8kUk2AhG9LtbNIlen6hS57sh1UXeKBhDysBCo1iAq1AVXIX65VZm_y_QMpPM0iomoBJ_VdWdIK

    public class Roman_to_Integer
    {
        public static void Test()
        {
            string[] ss = new string[] { "MCMLXXVI", "CMLII" };

            foreach (var s in ss)
            {
                Console.WriteLine(s + ":" + RomanToInt(s) + " ");

            }
        }

        //1. 基本数字 Ⅰ、X 、C 中的任何一个、自身连用构成数目、或者放在大数的右边连用构成数目、都不能超过三个；放在大数的左边只能用一个；
        //2. 不能把基本数字 V 、L 、D 中的任何一个作为小数放在大数的左边采用相减的方法构成数目；放在大数的右边采用相加的方式构成数目、只能使用一个；
        //3. V 和 X 左边的小数字只能用 Ⅰ；
        //4.L 和 C 左边的小数字只能用X；
        //5. D 和 M 左边的小数字只能用 C。
        public static int RomanToInt(string s)
        {
            Dictionary<char, int> romanToInt = new Dictionary<char, int>();
            romanToInt.Add('I', 1);
            romanToInt.Add('V', 5);
            romanToInt.Add('X', 10);
            romanToInt.Add('L', 50);
            romanToInt.Add('C', 100);
            romanToInt.Add('D', 500);
            romanToInt.Add('M', 1000);

            s = s.Trim();
            if (s == null || string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            int TheInteger = 0;
            var chars = s.ToArray();

            for (int number = 0; number < chars.Count(); number++)
            {
                if (number > 0)
                {
                    if (romanToInt[chars[number]] > romanToInt[chars[number - 1]])
                    {
                        TheInteger -= romanToInt[chars[number - 1]];
                        TheInteger += romanToInt[chars[number]] - romanToInt[chars[number - 1]];
                        continue;
                    }
                }
                TheInteger += romanToInt[chars[number]];
            }


            return TheInteger;
        }
    }
}
