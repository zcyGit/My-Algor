using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class _3Sum_Closest
    {

        public static void Test()
        {
            //int[] nums = new int[] { -2, 10, -14, 11, 5, -4, 2, 0, -10, -10, 5, 7, -11, 10, -2, -5, 2, 12, -5, 14, -11, -15, -5, 12, 0, 13, 8, 7, 10, 6, -9, -15, 1, 14, 11, -9, -13, -10, 6, -8, -5, -11, 6, -9, 14, 11, -7, -6, 8, 3, -7, 5, -5, 3, 2, 10, -6, -12, 3, 11, 1, 1, 12, 10, -8, 0, 8, -5, 6, -8, -6, 8, -12, -14, 7, 9, 12, -15, -12, -2, -4, -4, -12, 6, 7, -3, -6, -14, -8, 4, 4, 9, -10, -7, -4, -3, 1, 11, -1, -8, -12, 9, 7, -9, 10, -1, -14, -1, -8, 11, 12, -5, -7 };

            //int[] nums = new int[] { 1, 2, 4, 8, 16, 32, 64, 128 };


            //var solveLists = ThreeSumClosest(nums, 82);

            //int[] nums = new int[] { 1, 1, -1, -1, 3 };
            //var solveLists = ThreeSumClosest(nums, -1);

            int[] nums = new int[] { 13, 2, 0, -14, -20, 19, 8, -5, -13, -3, 20, 15, 20, 5, 13, 14, -17, -7, 12, -6, 0, 20, -19, -1, -15, -2, 8, -2, -9, 13, 0, -3, -18, -9, -9, -19, 17, -14, -19, -4, -16, 2, 0, 9, 5, -7, -4, 20, 18, 9, 0, 12, -1, 10, -17, -11, 16, -13, -14, -3, 0, 2, -18, 2, 8, 20, -15, 3, -13, -12, -2, -19, 11, 11, -10, 1, 1, -10, -2, 12, 0, 17, -19, -7, 8, -19, -17, 5, -5, -10, 8, 0, -12, 4, 19, 2, 0, 12, 14, -9, 15, 7, 0, -16, -5, 16, -12, 0, 2, -16, 14, 18, 12, 13, 5, 0, 5, 6 };
            var solveLists = ThreeSumClosest(nums, -59);

            Console.Write(solveLists);


        }


        public static int ThreeSumClosest(int[] nums, int target)
        {
            List<int> sourceList = new List<int>();

            //获取负数的列表并排序
            sourceList.AddRange(nums);
            sourceList.Sort();

            int numberLength = sourceList.Count();
            int numberA = 0;
            int numberB = 1;
            int numberC = numberLength - 1;
            int result = int.MaxValue;
            int resultSum =0;

            while (numberA < numberC)
            {
                var sum = sourceList[numberA] + sourceList[numberB] + sourceList[numberC];

                if (sum == target)
                {
                    return target;
                }

                var temp = Math.Abs(sum - target);
                if (Math.Abs(sum - target) < result)
                {
                    result = Math.Abs(sum - target);
                    resultSum = sum;
                }

                if (sum > target)
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

                    while (numberA < numberLength - 1 && sourceList[numberA] == sourceList[numberA - 1])
                        numberA++;

                    numberB = numberA + 1;
                    numberC = numberLength - 1;

                    if (numberB >= numberC)
                        break;
                }

            }

            return resultSum;
        }
    }
}
