using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Summary_Ranges
    {
        /// <summary>
        /// Given a sorted integer array without duplicates, return the summary of its ranges.
        /// For example, given [0,1,2,4,5,7], return ["0->2","4->5","7"]. 
        /// </summary>
        public static void Test()
        {
            int[] nums = new int[] { 0 };

            var list = SummaryRanges(nums);

            foreach (var str in list)
            {
                Console.Write(str + " ");
            }

        }


        public static IList<string> SummaryRanges(int[] nums)
        {
            List<string> solveList = new List<string>();

            if (nums == null || nums.Length == 0)
            {
                return solveList;
            }


            int begin = nums[0];
            int end = nums[0];

            int i = 1;

            while (i <= nums.Length)
            {
                if (i == nums.Length)
                {
                    if (begin == end)
                    {
                        solveList.Add(begin.ToString());
                    }
                    else
                    {
                        solveList.Add(begin.ToString() + "->" + end.ToString());
                    }
                    break;
                }

                if (end + 1 == nums[i])
                {
                    end = nums[i];
                }
                else
                {
                    if (begin == end)
                    {
                        solveList.Add(begin.ToString());
                    }
                    else
                    {
                        solveList.Add(begin.ToString() + "->" + end.ToString());
                    }

                    begin = nums[i];
                    end = nums[i];

                }
                i++;
            }


            return solveList;
        }


    }
}
