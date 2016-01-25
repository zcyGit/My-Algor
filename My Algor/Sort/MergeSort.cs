using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.Sort
{
    /// <summary>
    /// 归并排序
    /// 归并操作的工作原理如下：
    ///第一步：申请空间，使其大小为两个已经排序序列之和，该空间用来存放合并后的序列
    ///第二步：设定两个指针，最初位置分别为两个已经排序序列的起始位置
    ///第三步：比较两个指针所指向的元素，选择相对小的元素放入到合并空间，并移动指针到下一位置
    ///重复步骤3直到某一指针超出序列尾
    ///将另一序列剩下的所有元素直接复制到合并序列尾归并排序是建立在归并操作上的一种有效的排序算法,该算法是采用分治法（Divide and Conquer）的一个非常典型的应用。
    ///将已有序的子序列合并，得到完全有序的序列；即先使每个子序列有序，再使子序列段间有序。若将两个有序表合并成一个有序表，称为二路归并。
    ///归并过程为：比较a[i]和a[j]的大小，若a[i]≤a[j]，则将第一个有序表中的元素a[i]复制到r[k]中，并令i和k分别加上1；
    ///否则将第二个有序表中的元素a[j]复制到r[k]中，并令j和k分别加上1，如此循环下去，直到其中一个有序表取完，然
    ///后再将另一个有序表中剩余的元素复制到r中从下标k到下标t的单元。归并排序的算法我们通常用递归实现，先把待排序区间[s,t]以中点二分，
    ///接着把左边子区间排序，再把右边子区间排序，最后把左区间和右区间用一次归并操作合并成有序的区间[s,t]。
    /// </summary>
    class MergeSort
    {

        public static void Test()
        {
            List<int> list = new List<int>() { 6, 1, 4, 0, 8 };
            MergeSortAlogr(list);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        /// <summary>
        /// 归并排序
        /// </summary>
        /// （1）“分解”——将序列每次折半划分。
        /// <param name="list"></param>
        public static void MergeSortAlogr(List<int> list)
        {
            for (int groupNumber = 1; groupNumber < list.Count; groupNumber = groupNumber * 2)
            {
                MergeSortPass(list, groupNumber, list.Count());
            }
        }

        /// <summary>
        /// 合并”——将划分后的序列段两两合并后排序。
        /// </summary>
        public static void MergeSortPass(List<int> list, int groupNumber, int length)
        {
            //奇数和偶然分组不一样
            // 2 * (i + 1) - 1 < length 代表可两两分为多少组
            int i;
            for (i = 0; i + 2 * groupNumber < length; i = groupNumber * 2 + i)
            {
                Merge(list, i, i + groupNumber, i + groupNumber * 2);
            }
            if (i + groupNumber < length)//如果剩余的不满一个组的话，本轮就轮空，不进行归并。
            {
                Merge(list, i, i + groupNumber, length);
            }

        }


        /// <summary>
        /// 相邻两组归并
        /// </summary>
        public static void Merge(List<int> list, int low, int middle, int hight)
        {
            int lowCopy = low;
            int middelCopy = middle;
            List<int> MergeList = new List<int>();
            //相邻两组开始归并（每组都已排序）
            while (lowCopy < middle && middelCopy < hight)
            {
                if (list[lowCopy] > list[middelCopy])
                {
                    MergeList.Add(list[middelCopy]);
                    middelCopy++;
                }
                else
                {
                    MergeList.Add(list[lowCopy]);
                    lowCopy++;
                }
            }
            //把两组中剩余的值加入到列表中
            while (lowCopy < middle)
            {
                MergeList.Add(list[lowCopy]);
                lowCopy++;
            }

            while (middelCopy < hight)
            {
                MergeList.Add(list[middelCopy]);
                middelCopy++;
            }

            //把归并后的值赋值给原数组
            for (int k = 0, i = low; i < hight; i++, k++)
            {
                list[i] = MergeList[k];
            }

        }



    }
}
