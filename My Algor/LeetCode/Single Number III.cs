using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{

    /// <summary>
    /// Given an array of integers, every element appears twice except for one. Find that single one.
    ///Note:
    ///Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory? 
    ///Subscribe to see which companies asked this question
    public class Single_Number_III
    {

        public static void Test()
        {
            int[] nums = new int[] { 1, 2, 1, 3, 3, 9, 9, 4 };
            var numbers = SingleNumberIII(nums);
            Console.WriteLine(numbers[0] + " " + numbers[1]);
        }

        /// <summary>
        /// 设题目中这两个只出现1次的数字分别为A和B，如果能将A，B分开到二个数组中，那显然符合“异或”解法的关键点了。因此这个题目的关键点就是将A，
        /// B分开到二个数组中。由于A，B肯定是不相等的，因此在二进制上必定有一位是不同的。根据这一位是0还是1可以将A，B分开到A组和B组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SingleNumberIII(int[] nums)
        {
            int[] signleNumber = new int[2];
            if (nums == null || nums.Length <= 2)
            {
                return nums;
            }
            int result = 0;
            int flag = 0;
            int resultA = 0;
            int resultB = 0;
            //求出两个异或的值
            for (int i = 0; i < nums.Length; i++)
            {
                result = result ^ nums[i];
            }

            for (; flag < sizeof(int) * 8; )
            {
                if (((result >> flag) & 1) == 1)
                {
                    break;
                }
                flag++;
            }

            //根据flag分组
            for (int i = 0; i < nums.Length; i++)
            {
                if (((nums[i] >> flag) & 1) == 1)
                {
                    resultA = resultA ^ nums[i];
                }
                else
                {
                    resultB = resultB ^ nums[i];
                }
            }

            signleNumber[0] = resultA;
            signleNumber[1] = resultB;

            return signleNumber;
        }




    }
}
