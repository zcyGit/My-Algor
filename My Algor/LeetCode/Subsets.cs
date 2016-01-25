using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a set of distinct integers, nums, return all possible subsets. 
    /// 排列组合
    /// Note:
    ///•Elements in a subset must be in non-descending order.
    ///•The solution set must not contain duplicate subsets.
    /// </summary>
    class SubsetsClass
    {
        public static void Test()
        {
            int[] nums = new int[] { 1, 2, 3 };
            var list = Subsets(nums);
            List<int> subsetList = new List<int>();


            //List<IList<int>> subsetsList = new List<IList<int>>();
            //subsetsList.Add(subsetList);
            //Console.Write(subsetList[0]);

            foreach (var solveList in list)
            {
                if (solveList != null)
                {
                    foreach (var solve in solveList)
                    {
                        Console.Write(solve);
                    }
                    Console.WriteLine();

                }
                else
                    Console.WriteLine(" ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 可以发现S=[1, 2] 的解就是 把S = [1]的所有解末尾添上2，然后再并上S = [1]里面的原有解  (规律)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static IList<IList<int>> Subsets(int[] nums)
        {
            return GetSubByNumber(nums, nums.Length);
        }


        /// <summary>
        /// 获取数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static List<IList<int>> GetSubByNumber(int[] nums, int length)
        {
            List<int> subsetList;
            List<IList<int>> subsetsList = new List<IList<int>>();

            if (length == 0)
            {
                subsetsList.Add(new List<int>());
                return subsetsList;
            }

            var tempSubsetsList = GetSubByNumber(nums, length - 1);

            foreach (List<int> tempSetList in tempSubsetsList)
            {
                subsetList = new List<int>();
                if (tempSetList != null)
                {
                    subsetList = tempSetList.Where((i) => { return true; }).ToList();
                }
                subsetList.Add(nums[length - 1]);
                subsetList.Sort();
                subsetsList.Add(subsetList);
            }
            subsetsList.AddRange(tempSubsetsList);
            return subsetsList;
        }

    }
}
