using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{



    /// <summary>
    /// The gray code is a binary numeral system where two successive values differ in only one bit.

    //Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code. A gray code sequence must begin with 0.

    //For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:
    //00 - 0
    //01 - 1
    //11 - 3
    ///10 - 2
    public class Gray_Code
    {
        public static void Test()
        {
            int n = 3;
            var list = new Gray_Code().GrayCode(n);

            foreach (var number in list)
            {
                Console.WriteLine(number);
            }

        }

        #region
        /// <summary>
        /// 格雷码
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> GrayCode(int n)
        {
            List<int> list = new List<int>();
            int nSize = 1 << n;
            for (int i = 0; i < nSize; ++i)
            {
                list.Add((i >> 1) ^ i);
            }
            return list;
        }

        #endregion

        #region 题意理解错误
        /// </summary>
        /// <param name="n"></param>
        /// 格雷码
        /// <returns></returns>
        public IList<int> GrayCode1(int n)
        {
            List<int> list = new List<int>();
            List<int> tempList = new List<int>();

            int number = 1;
            int temp = 0;
            int tempNumber = 0;

            list.Add(0);
            if (n == 0)
            {
                return list;
            }

            while (true)
            {
                tempNumber = 0;
                while (tempNumber < tempList.Count)
                {
                    temp = list.Last() ^ tempList[tempNumber];

                    if (((temp) & (temp - 1)) == 0)
                    {
                        list.Add(tempList[tempNumber]);
                        if (n == tempList[tempNumber])
                        {
                            return list;
                        }
                        tempList.RemoveAt(tempNumber);
                    }
                    else
                        tempNumber++;
                }


                temp = list.Last() ^ number;  
                if (((temp) & (temp - 1)) == 0)
                {
                    list.Add(number);
                    if (n == number)
                    {
                        break;
                    }
                }
                else
                {
                    tempList.Add(number);
                }

                number++;
            }

            return list;

        }


        #endregion
    }
}
