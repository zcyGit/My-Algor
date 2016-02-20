using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a list of non negative integers, arrange them such that they form the largest number.
    /// For example, given [3, 30, 34, 5, 9], the largest formed number is 9534330.
    /// Note: The result may be very large, so you need to return a string instead of an integer.
    /// </summary>
    public class Largest_Number
    {
        public static void Test()
        {
            //int[] nums = new int[] { 3, 3, 30, 34, 341, 2 };
            int[] nums = new int[] { 0,0 };

            Console.Write(LargestNumber(nums));
        }

        /// <summary>
        /// http://blog.csdn.net/ljiabin/article/details/42676433
        /// 思路： 可以换一下思路，要想比较两个数在最终结果中的先后位置，何不直接比较一下不同组合的结果大小？
        ///举个例子：要比较3和34的先后位置，可以比较334和343的大小，而343比334大，所以34应当在前。
        ///这样，有了比较两个数的方法，就可以对整个数组进行排序。然后再把排好序的数拼接在一起就好了。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static string LargestNumber(int[] nums)
        {
            string largestNumber = string.Empty;

            if (nums.Length == 1)
            {
                return nums[0].ToString();
            }

            List<string> list = new List<string>();

            for (int i = 0; i < nums.Length; i++)
            {
                list.Add(nums[i].ToString());
            }
            list.Sort(compareNumber);

            if (list[0] == "0")
            {
                return "0";
            }

            foreach (var s in list)
            {
                largestNumber += s;
            }


            return largestNumber;
        }

        /// <summary>
        /// 比较器
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private static int compareNumber(string x, string y)
        {
            if (string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y))
            {
                return 0;
            }

            long xInt = Convert.ToInt64(x + y);
            long yInt = Convert.ToInt64(y + x);

            if (xInt > yInt)
            {
                return -1;
            }
            else if (xInt < yInt)
            {
                return 1;
            }
            else
                return 0;

        }

    }
}
