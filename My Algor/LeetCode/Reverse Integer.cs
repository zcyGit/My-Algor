using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Reverse_Integer
    {

        public static void Test()
        {
            int n = -321;

            Console.Write(Reverse(n));

        }

        /// <summary>
        /// 主要处理溢出，一种是采用long来判断int32的边界值，不通用（万一传进来为long呢）
        /// 
        /// 可以采用规律来判断
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int Reverse(int x)
        {
            int dupx = x;
            int num = 0;

            while (dupx != 0)
            {
                int tempNum = num * 10 + dupx % 10;
                if (tempNum / 10 != num)
                    return 0;
                num = tempNum;
                dupx = dupx / 10;
            }

            return num;
        }

    }
}
