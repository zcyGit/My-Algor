using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    class First_Missing_Positive
    {

        public static void Test()
        {
            int[] nums = new int[] { 1, 2, 0 };
            Console.Write(FirstMissingPositive(nums));
        }

        public static int FirstMissingPositive(int[] nums)
        {
            HashSet<int> hash = new HashSet<int>();

            if (nums.Length == 0)
            {
                return 1;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                hash.Add(nums[i]);
            }
            int j = 1;
            for (; j <= nums.Length; j++)
            {
                if (!hash.Contains(j))
                {
                    return j;
                }
            }
            return j;
        }

    }
}
