using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.Sort
{
    /// <summary>
    /// http://developer.51cto.com/art/201403/430986.htm
    /// </summary>
    class QuickSort
    {

        public static void QuickSortTest()
        {
            
            List<int> list = new List<int>() { 13, 10, 2, 4, 5, 9, 6, 1, 54, 4, 0 };
            int left = 0;
            int rigth = list.Count - 1;
            QuickSortAlog(list, left, rigth);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        ///自己写一个快速排序
        public static void QuickSortAlog(List<int> list, int left, int right)
        {

            if (left > right)
            {
                return;
            }
            var middle = list[left];
            var leftNumber = left;
            var rightNumber = right;


            for (; right > left; )
            {
                if (list[right] < middle)
                {
                    for (; left < right; )
                    {
                        if (list[left] > middle)
                        {
                            int temp = list[left];
                            list[left] = list[right];
                            list[right] = temp;
                            break;
                        }
                        else
                            left++;
                    }
                }
                else
                    --right;
            }

            if (left == right)
            {
                list[leftNumber] = list[left];
                list[left] = middle;
            }

            QuickSortAlog(list, leftNumber, rightNumber - 1);
            QuickSortAlog(list, leftNumber + 1, rightNumber);


        }
    }
}
