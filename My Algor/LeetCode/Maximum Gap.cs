using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given an unsorted array, find the maximum difference between the successive elements in its sorted form.

    ///Try to solve it in linear time/space.

    ///Return 0 if the array contains less than 2 elements.

    ///You may assume all elements in the array are non-negative integers and fit in the 32-bit signed integer range.

    /// </summary>
    public class Maximum_Gap
    {
        public static void Test()
        {
            //2901
            int[] nums = new int[] { 15252, 16764, 27963, 7817, 26155, 20757, 3478, 22602, 20404, 6739, 16790, 10588, 16521, 6644, 20880, 15632, 27078, 25463, 20124, 15728, 30042, 16604, 17223, 4388, 23646, 32683, 23688, 12439, 30630, 3895, 7926, 22101, 32406, 21540, 31799, 3768, 26679, 21799, 23740 };

            nums = new int[] { 100, 3, 2, 1 };
            Console.WriteLine(new Maximum_Gap().MaximumGap(nums));
        }


        /// <summary>
        /// 关键在于如何确定桶的长度和每个桶的容量
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumGap(int[] nums)
        {
            int result = 0;
            int tempA = 0;
            if (nums == null || nums.Length < 2)
            {
                return result;
            }

            int max = nums[0];
            int min = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i];
                }

                if (min > nums[i])
                {
                    min = nums[i];
                }
            }

            if (max == min)
                return result;

            // gap必然要大于dis=(max-min)/(n-1)
            int gap = (max - min) / (nums.Length - 1);
            if (gap == 0)
            {
                gap = 1;
            }
            //关键点
            int bucketNumber = (max - min) / gap + 1;


            int[,] bucket = new int[bucketNumber, 2];

            for (int i = 0; i < nums.Length; i++)
            {
                int value = (nums[i] - min) / gap;

                if (bucket[value, 0] == 0)
                {
                    bucket[value, 0] = nums[i];
                }
                else if (nums[i] < bucket[value, 0])
                {
                    if (bucket[value, 1] == 0)
                    {
                        bucket[value, 1] = bucket[value, 0];
                    }
                    bucket[value, 0] = nums[i];
                }
                else if (nums[i] > bucket[value, 1])
                {
                    bucket[value, 1] = nums[i];
                }

            }
            tempA = min;
            for (int i = 0; i < bucketNumber; i++)
            {
                if (bucket[i, 0] != 0 )
                {
                    if (bucket[i, 0] - tempA > result)
                    {
                        result = bucket[i, 0] - tempA;
                    }

                    tempA = bucket[i, 1] == 0 ? bucket[i, 0] : bucket[i, 1];
                }
            }

            return result;
        }
    }
}
