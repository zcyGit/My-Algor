using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given an array of n integers where n > 1, nums, return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].
    ///Solve it without division and in O(n).

    //For example, given [1,2,3,4], return [24,12,8,6]. 

    /// </summary>
    public class Product_of_Array_Except_Self
    {
        public static void Test()
        {
            int[] nums = new int[] { 1, 2, 3, 4,1 };

            var list = ProductExceptSelf(nums);
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }

        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] temp = new int[nums.Length];
            temp[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                temp[i] = nums[i - 1] * temp[i - 1];
            }
            int right = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                temp[i] = temp[i] * right;
                right = nums[i] * right;
            }

            return temp;
        }

    }
}
