using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right.
    /// You can only see the k numbers in the window. Each time the sliding window moves right by one position.
    /// </summary>
    class Sliding_Window_Maximum
    {
        public static void Test()
        {
            int[] nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };

            nums = new int[] { 1, 3, 1, 2, 0, 5 };//[3,3,2,5]

            var list = MaxSlidingWindow(nums, 3);

            foreach (var num in list)
            {
                Console.WriteLine(num);
            }


        }

        //Given nums = [1,3,-1,-3,5,3,4,2], and k = 1.
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
            {
                return nums;
            }

            if (k == 1)
            {
                return nums;
            }

            int[] result = new int[nums.Length - k + 1];

            List<int> windows = new List<int>();
            List<int> windowsPlace = new List<int>();

            windows.Add(nums[0]);
            windowsPlace.Add(0);

            for (int i = 1; i < nums.Length; i++)
            {
                var number = windows.Count;
                for (int j = number - 1; j >= 0; j--)
                {
                    if (windows[j] < nums[i])
                    {
                        windows.RemoveAt(j);
                        windowsPlace.RemoveAt(j);
                    }
                    if (j == number - 1)
                    {
                        windows.Add(nums[i]);
                        windowsPlace.Add(i);
                    }
                }

                if (i >= k - 1)
                {
                    if (windowsPlace[0] > i - k)
                    {
                        result[i - k + 1] = windows[0];
                    }
                    if (windowsPlace[0] <= i - k + 1)
                    {
                        windows.RemoveAt(0);
                        windowsPlace.RemoveAt(0);
                    }
                }
            }

            return result;

        }


    }
}
