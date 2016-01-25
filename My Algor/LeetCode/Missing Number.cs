using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Missing_Number
    {
        public static void Test()
        {

            int[] nums = new int[] { 0, 1, 3 ,2};

            Console.Write(MissingNumber(nums));

        }

        public static int MissingNumber(int[] nums)
        {
            int sum = (0 + nums.Length)*(nums.Length + 1) / 2  ;

            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum - nums[i];
            }

            return sum;
        }
    }
}
