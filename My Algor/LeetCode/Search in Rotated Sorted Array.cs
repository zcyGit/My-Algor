using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{


    /// <summary>
    /// Suppose a sorted array is rotated at some pivot unknown to you beforehand.
    ///(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).
    ///You are given a target value to search. If found in the array return its index, otherwise return -1.
    ///You may assume no duplicate exists in the array.

    /// </summary>
    public class Search_in_Rotated_Sorted_Array
    {

        public static void Test()
        {
            var list = new List<int[]>();

            int[] nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
            list.Add(nums);
            nums = new int[] { 1, 3 };
            list.Add(nums);
            nums = new int[] { 3, 5, 1 };
            list.Add(nums);
            nums = new int[] { 5, 1, 3 };
            list.Add(nums);
            nums = new int[] { 4, 5, 6, 7, 8, 1, 2, 3 };
            list.Add(nums);
            nums = new int[] { 5, 1, 2, 3, 4 };
            list.Add(nums);
            nums = new int[] { 9, 1, 2, 3, 4, 5, 6, 7, 8 };
            list.Add(nums);
            nums = new int[] { 8, 9, 2, 3, 4 };
            list.Add(nums);
            nums = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            list.Add(nums);

            Console.WriteLine(Search(nums, 8));

            //Console.WriteLine(Search(nums, 100));
            //Console.WriteLine(Search(nums, -1));

            for (int j = 0; j < list.Count; j++)
            {
                for (int i = 0; i < list[j].Length; i++)
                    Console.Write(Search(list[j], list[j][i]));
                Console.WriteLine();
            }


        }

        private static int Target;

        public static int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            Target = target;
            return BinarySearch(nums, 0, nums.Length - 1);

        }

        public static int BinarySearch(int[] nums, int begin, int end)
        {
            int mid = (begin + end) / 2;

            if (nums[mid] == Target)
            {
                return mid;
            }
            else if (begin >= end)
            {
                return -1;
            }

            if (Target < nums[mid])
            {
                if (nums[begin] > nums[end] && nums[mid] > nums[end] && nums[begin] > Target)
                {
                    return BinarySearch(nums, mid + 1, end);
                }
                else
                {
                    return BinarySearch(nums, begin, mid - 1);
                }
            }
            else
            {
                if (nums[begin] > nums[end] && nums[mid] < nums[begin] && nums[end] < Target)
                {
                    return BinarySearch(nums, begin, mid - 1);
                }
                else
                {
                    return BinarySearch(nums, mid + 1, end);
                }
            }
        }
    }
}
