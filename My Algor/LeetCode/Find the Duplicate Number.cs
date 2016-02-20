using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), prove 
    /// that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one. 
    /// Note:
    /// 1.You must not modify the array (assume the array is read only).
    /// 2.You must use only constant, O(1) extra space.
    /// 3.Your runtime complexity should be less than O(n2).
    /// 4.There is only one duplicate number in the array, but it could be repeated more than once.
    /// </summary>
    public class Find_the_Duplicate_Number
    {

        public static void Test()
        {
            int[] nums = new int[] { 1, 2, 6, 3, 5, 1, 4 };

            Console.Write(Cycle_detection.cycleDetection(nums));
        }
        /// <summary>
        /// 思路：不能循环，不能排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindDuplicate(int[] nums)
        {
            int num = 0;

            for (int jump = 1; jump < nums.Length; jump++)
            {
                for (int i = 0; i < nums.Length - jump; i++)
                {
                    if (nums[i] == nums[i + jump])
                    {
                        return nums[i];
                    }
                }
            }
            return num;
        }
    }
}
