using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given an array of integers, find two numbers such that they add up to a specific target number.
    ///The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

    ///You may assume that each input would have exactly one solution.
    /// </summary>
    class Two_Sum
    {

        public int[] TwoSum(int[] nums, int target)
        {
            int[] res = new int[2];
            int sum;

            List<int> number = new List<int>();
            number.AddRange(nums);
            int k = 0;
            int l = nums.Length - 1;

            while (k < l)
            {
                if (nums[k] <= target)
                {
                    sum = target - nums[k];

                    int r = number.IndexOf(sum);
                    if (r != -1)
                    {
                        if (r == k)
                        {
                            r = number.IndexOf(sum, 1);
                        }
                        if (r > k)
                        {
                            res[0] = k + 1;
                            res[1] = r + 1;
                        }
                        else
                        {
                            res[0] = r + 1;
                            res[1] = k + 1;
                        }

                        return res;
                    }
                }
                else
                {
                    k++;
                }

                if (nums[l] <= target)
                {
                    sum = target - nums[l];

                    int r = number.IndexOf(sum);
                    if (r != -1)
                    {
                        if (r > l)
                        {
                            res[0] = l + 1;
                            res[1] = r + 1;
                        }
                        else
                        {
                            res[0] = r + 1;
                            res[1] = l + 1;
                        }

                        return res;
                    }
                }
                else
                {
                    l--;
                }
            }
            return res;

        }

        public int[] TwoSum1(int[] nums, int target)
        {
            int[] res = new int[2];
            int[] number = nums;
            int sum;


            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < target)
                {
                    sum = target - nums[i];
                    for (int j = 0; j < number.Length; j++)
                    {
                        if (sum == number[j])
                        {
                            if (i > j)
                            {
                                res[0] = j + 1;
                                res[1] = i + 1;
                            }
                            else
                            {
                                res[0] = i + 1;
                                res[1] = j + 1;
                            }
                            return res;
                        }

                    }
                }
            }

            return res;
        }

        /// <summary>
        /// 比较好的解决方法
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum2(int[] nums, int target)
        {
            ///两个数相加，不一定越来越大，有可能越来越小啊
            int[] res = new int[2];
            int[] number = nums;

            List<int> list = new List<int>();

            list.AddRange(nums);
            list.Sort();

            SortedDictionary<int, int> numberDic = new SortedDictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!numberDic.ContainsKey(nums[i]))
                {
                    numberDic.Add(nums[i], i + 1);
                }
                else if (nums[i] * 2 == target)
                {
                    res[0] = numberDic[nums[i]];
                    res[1] = i + 1;

                    return res;
                }
            }

            int begin = 0;
            int end = list.Count() - 1;

            while (begin < end)
            {
                if (list[begin] + list[end] > target)
                {
                    end--;
                }

                if (list[begin] + list[end] < target)
                {
                    begin++;
                }

                if (list[begin] + list[end] == target)
                {
                    if (numberDic[list[begin]] < numberDic[list[end]])
                    {
                        res[0] = numberDic[list[begin]];
                        res[1] = numberDic[list[end]];
                        return res;


                    }
                    else
                    {
                        res[0] = numberDic[list[end]];
                        res[1] = numberDic[list[begin]];
                        return res;
                    }

                }
            }

            return res;
        }

    }
}
