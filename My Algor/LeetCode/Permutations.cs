using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Permutations
    {
        public static void Test()
        {
            var nums = new int[] { 1, 2, 3,4,5,6,7,8,9,10 };

            var list = Permute(nums);


            //foreach (var temp in list)
            //{
            //    foreach (var num in temp)
            //    {
            //        Console.Write(num + " ");
            //    }
            //    Console.Write("\n");
            //}

        }

        public static IList<IList<int>> Permute(int[] nums)
        {
            var listList = new List<IList<int>>();

            var length = nums.Length;

            if (length == 0)
            {
                return listList;
            }
            if (length == 1)
            {
                listList.Add(nums);
                return listList;
            }

            foreach (var num in nums)
            {
                var tempNums = BuildNum(nums, num);
                var templistList = Permute(tempNums);
                foreach (var temp in templistList)
                {
                    var list = temp.ToList();
                    list.Add(num);
                    listList.Add(list);
                }
            }

            return listList;
        }


        public static int[] BuildNum(int[] nums, int removeNumber)
        {
            var newNum = new int[nums.Length - 1];
            var number = 0;
            foreach (var num in nums)
            {
                if (num != removeNumber)
                {
                    newNum[number] = num;
                    number++;
                }
            }

            return newNum;
        }



    }
}
