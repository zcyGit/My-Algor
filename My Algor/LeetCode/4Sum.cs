using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.
    ///•Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ≤ b ≤ c)
    ///•The solution set must not contain duplicate triplets.
    /// </summary>
    public class _4Sum
    {
        public static void Test()
        {
            int[] nums = new int[] { -2, 10, -14, 11, 5, -4, 2, 0, -10, -10, 5, 7, -11, 10, -2, -5, 2, 12, -5, 14, -11, -15, -5, 12, 0, 13, 8, 7, 10, 6, -9, -15, 1, 14, 11, -9, -13, -10, 6, -8, -5, -11, 6, -9, 14, 11, -7, -6, 8, 3, -7, 5, -5, 3, 2, 10, -6, -12, 3, 11, 1, 1, 12, 10, -8, 0, 8, -5, 6, -8, -6, 8, -12, -14, 7, 9, 12, -15, -12, -2, -4, -4, -12, 6, 7, -3, -6, -14, -8, 4, 4, 9, -10, -7, -4, -3, 1, 11, -1, -8, -12, 9, 7, -9, 10, -1, -14, -1, -8, 11, 12, -5, -7 };

            //int[] nums = new int[] { 1, 0, -1, 0, -2, 2 };

            nums = new int[] { -5, 5, 4, -3, 0, 0, 4, -2 };
            var solveLists = FourSum(nums, 4);

            foreach (var solveList in solveLists)
            {
                foreach (var solve in solveList)
                {
                    Console.Write(solve + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 基本思路：先排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<int> solution;
            List<IList<int>> solutionList = new List<IList<int>>();
            List<int> sourceList = new List<int>();
            if (nums == null || nums.Length < 4)
            {
                return solutionList;
            }
            sourceList.AddRange(nums);
            sourceList.Sort();
            int numberLength = sourceList.Count();
            int numberA = 0;
            int numberB = 1;
            int numberC = numberLength - 2;
            int numberD = numberLength - 1;

            int number = 1;

            while (numberD > numberA + 2)
            {
                while (numberA < numberC)
                {
                    var sum = sourceList[numberA] + sourceList[numberB] + sourceList[numberC] + sourceList[numberD];
                    if (sum == target)
                    {
                        solution = new List<int>();
                        solution.AddRange(new int[] { sourceList[numberA], sourceList[numberB], sourceList[numberC], sourceList[numberD] });

                        solutionList.Add(solution);

                        numberB++;
                        numberC--;
                        while (numberB < numberC && sourceList[numberB] == sourceList[numberB - 1])
                            numberB++;
                        //skip same k
                        while (numberC > numberB && sourceList[numberC] == sourceList[numberC + 1])
                            numberC--;

                    }
                    else if (sum > target)
                    {
                        numberC--;
                    }
                    else
                    {
                        numberB++;
                    }
                    if (numberC <= numberB)
                    {
                        numberA++;

                        while (numberA < numberLength - 2 && sourceList[numberA] == sourceList[numberA - 1])
                            numberA++;

                        numberB = numberA + 1;
                        numberC = numberD - 1;

                        if (numberB >= numberC)
                            break;
                    }

                }

                numberA = 0;
                numberB = 1;

                numberC = numberLength - 2 - number;
                numberD = numberLength - 1 - number;

                while (numberD > numberB && sourceList[numberD] == sourceList[numberD + 1])
                {
                    number++;
                    numberC = numberLength - 2 - number;
                    numberD = numberLength - 1 - number;
                }

                number++;

            }

            return solutionList;
        }
    }
}
