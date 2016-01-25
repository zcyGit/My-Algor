using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements. 
    /// For example, given nums = [0, 1, 0, 3, 12], after calling your function, nums should be [1, 3, 12, 0, 0]. 
    /// </summary>
    public class Move_Zeroes
    {
        public static void Test()
        {

            int[] nums = new int[] { 0, 1, 0, 3, 2 };

            MoveZeroes(nums);

            for (int i = 0; i < nums.Count(); i++)
            {
                Console.Write(nums[i] + " ");
            }


        }

        public static void MoveZeroes(int[] nums)
        {
            int temp;
            int next;
            int length = nums.Count();
            for (int i = 0; i < length; i++)
            {
                next = i + 1;
                while (next < length)
                {
                    if (nums[i] == 0)
                    {
                        if (nums[next] != 0)
                        {
                            temp = nums[next];
                            nums[i] = temp;
                            nums[next] = 0;
                            break;
                        }
                        next++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

    }


}
