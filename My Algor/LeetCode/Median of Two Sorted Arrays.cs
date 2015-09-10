using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace My_Algor.LeetCode
{
    /// <summary>
    /// There are two sorted arrays nums1 and nums2 of size m and n respectively. 
    /// Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).
    /// 求两个数组的中位数
    /// </summary>
    class Median_of_Two_Sorted_Arrays
    {

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            List<int> list = new List<int>();
            list.AddRange(nums1);
            list.AddRange(nums2);
            list.Sort();

            if (list.Count > 0)
            {
                if(list.Count % 2 == 1)
                {
                   return list[list.Count / 2] ;
                }
                else
                {
                  return  (list[list.Count / 2-1] + list[list.Count / 2] ) / 2.0;
                }
            }

            return 0;
        }



    }
}
