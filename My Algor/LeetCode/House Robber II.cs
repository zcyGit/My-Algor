using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// After robbing those houses on that street, the thief has found himself a new place for his thievery so 
    /// that he will not get too much attention. This time, all houses at this place are arranged in a circle.
    /// That means the first house is the neighbor of the last one. Meanwhile, the security system for these 
    /// houses remain the same as for those in the previous street. 
    /// </summary>
    public class House_RobberII
    {
        public static void Test()
        {

            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 20 };
            nums = new int[] { 10, 174, 214, 16, 218, 48, 153, 131, 128, 17, 157, 142, 88, 43, 37, 157, 43, 221, 191, 68, 206, 23, 225, 82, 54, 118, 111, 46, 80, 49, 245, 63, 25, 194, 72, 80, 143, 55, 209, 18, 55, 122, 65, 66, 177, 101, 63, 201, 172, 130, 103, 225, 142, 46, 86, 185, 62, 138, 212, 192, 125, 77, 223, 188, 99, 228, 90, 25, 193, 211, 84, 239, 119, 234, 85, 83, 123, 120, 131, 203, 219, 10, 82, 35, 120, 180, 249, 106, 37, 169, 225, 54, 103, 55, 166, 12400 };

         //   nums = new int[] { 1, 2, 0};
            var max = Rob(nums);

            Console.Write(max);

        }


        public static int Rob(int[] nums)
        {
            int maxMoney = 0;
            int tempMoney = 0;
            if (nums == null || nums.Length == 0)
            {
                return maxMoney;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            int[] maxMoneys = new int[nums.Length];

            maxMoneys[0] = nums[0];
            maxMoneys[1] = nums[0] > nums[1] ? nums[0] : nums[1];

            for (int i = 2; i < nums.Length; i++)
            {
                tempMoney = maxMoneys[i - 2] + nums[i];
                maxMoneys[i] = tempMoney > maxMoneys[i - 1] ? tempMoney : maxMoneys[i - 1];

                if (i == nums.Length - 1 && tempMoney > maxMoneys[i - 1] )
                {
                    maxMoneys[i] = maxMoneys[i - 1];
                }
                else if (i == nums.Length - 1)
                {
                    return maxMoneys[nums.Length - 1];
                }
            }

            int[] maxMoneysCopy = new int[nums.Length];

            maxMoneysCopy[nums.Length - 1] = nums[nums.Length - 1];
            maxMoneysCopy[nums.Length - 2] = nums[nums.Length - 1] > nums[nums.Length - 2] ? nums[nums.Length - 1] : nums[nums.Length - 2];
            for (int i = nums.Length - 3; i >= 0; i--)
            {
                tempMoney = maxMoneysCopy[i + 2] + nums[i];
                maxMoneysCopy[i] = tempMoney > maxMoneysCopy[i + 1] ? tempMoney : maxMoneysCopy[i + 1];

                if (i == 0&& tempMoney > maxMoneysCopy[i + 1])
                {
                    maxMoneysCopy[i] = maxMoneysCopy[i + 1];
                }
                else if (i == 0)
                {
                    return maxMoneysCopy[0];
                }
            }

            return maxMoneysCopy[0] >= maxMoneys[nums.Length - 1] ? maxMoneysCopy[0] : maxMoneys[nums.Length - 1];
        }

    }
}
