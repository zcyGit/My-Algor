using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{

    /// <summary>
    /// Given n balloons, indexed from 0 to n-1. Each balloon is painted with a number on it represented by array nums. 
    /// You are asked to burst all the balloons. If the you burst balloon i you will get nums[left] * nums[i] * nums[right] coins. 
    /// Here left and right are adjacent indices of i. After the burst, the left and right then becomes adjacent(相邻). 

    ///Find the maximum coins you can collect by bursting the balloons wisely. 

    ///Note: 
    /// (1) You may imagine nums[-1] = nums[n] = 1. They are not real therefore you can not burst them.
    /// (2) 0 ≤ n ≤ 500, 0 ≤ nums[i] ≤ 100 
    ///   Example: 

    ///Given [3, 1, 5, 8] 

    ///Return 167 
    ///    nums = [3,1,5,8] --> [3,5,8] -->   [3,8]   -->  [8]  --> []
    ///   coins =  3*1*5      +  3*5*8    +  1*3*8      + 1*8*1   = 167

    /// </summary>
    public class Burst_Balloons
    {

        public static void Test()
        {
            int[] nums = new int[] { 3, 1, 5, 8 };

            Console.Write(MaxCoins(nums));

        }


        /// <summary>
        /// 基本思路：背包问题的延伸
        /// 
        /// 从小数组往全数组推
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MaxCoins(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0];
            }

            int n = nums.Length;
            int[] tempNums = new int[n + 2];
            for (int i = 0; i < n; i++) tempNums[i + 1] = nums[i];
            tempNums[0] = tempNums[n + 1] = 1;
            int[,] solve = new int[nums.Length + 2, nums.Length + 2];

            for (int i = 1; i <= nums.Length; i++)
            {
                for (int j = 1; j <= nums.Length - i + 1; j++)
                {
                    int k = j + i - 1;

                    for (int x = j; x <= k; x++)
                    {
                        solve[j, k] = Math.Max(solve[j, k], solve[j, x - 1] + tempNums[j - 1] * tempNums[x] * tempNums[k + 1] + solve[x + 1, k]);
                    }
                }
            }
            return solve[1, nums.Length];
        }

        /// <summary>
        /// 基本思路：背包问题的延伸
        /// 
        /// 从后往前推（超时）
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int MaxCoins1(int[] nums)
        {
            int MaxSum = 0;
            int[] sum = new int[nums.Length];
            int left = 1;
            int right = 1;
            var key = string.Join("", nums);

            if (nums.Length == 1)
            {
                return nums[0];
            }

            if (solve.ContainsKey(key))
            {
                return solve[key];
            }

            for (int i = 0; i < nums.Length - 1; i++)
            {

                if (i != 0)
                {
                    left = nums[i - 1];
                }
                else
                {
                    left = 1;
                }
                if (i != nums.Length - 1)
                {
                    right = nums[i + 1];
                }
                else
                {
                    right = 1;
                }
                var tempNums = new int[nums.Length - 1];
                int tempNum = 0;
                for (int j = 0; j < nums.Length; j++)
                {
                    if (j != i)
                    {
                        tempNums[tempNum] = nums[j];
                        tempNum++;
                    }
                }
                sum[i] = nums[i] * left * right + MaxCoins(tempNums);
            }

            for (int i = 0; i < sum.Length - 1; i++)
            {

                if (MaxSum < sum[i])
                {
                    MaxSum = sum[i];
                }
            }
            if (!solve.ContainsKey(key))
            {
                solve.Add(key, MaxSum);
            }

            return MaxSum;
        }


        private static Dictionary<string, int> solve = new Dictionary<string, int>();


    }
}
