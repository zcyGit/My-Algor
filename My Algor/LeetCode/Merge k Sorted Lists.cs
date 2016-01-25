using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Merge k sorted linked lists and return it as one sorted list. Analyze and describe its complexity. 
    /// </summary>
    class Merge_k_Sorted_Lists
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static void Test()
        {
            ListNode l1 = new ListNode(2);
            ListNode l2 = new ListNode(3);
            ListNode l3 = new ListNode(4);

            l2.next = l3;
            l1.next = l2;

            ListNode n1 = new ListNode(4);
            ListNode n2 = new ListNode(5);
            ListNode n3 = new ListNode(6);

            n2.next = n3;
            n1.next = n2;

            //ListNode[] lists = new ListNode[] { n1, l1 };

            ListNode[] lists = new ListNode[] { l1, null, n1 };


            var node = MergeKLists1(lists);


        }


        public static ListNode MergeKLists1(ListNode[] lists)
        {
            if (lists == null || lists.Count() == 0)
                return null;
            if (lists.Count() == 1)
            {
                return lists[0];
            }
            ListNode node = new ListNode(-1);
            ListNode head = node;

            node.next = lists[0];
            for (int i = 1; i < lists.Count(); i++)
            {
                if (lists[i] != null)
                {
                    node.next = MergeListNode(node.next, lists[i]);
                }
            }

            return head.next;
        }


        public static ListNode MergeListNode(ListNode first, ListNode secend)
        {
            ListNode MergeListNode = new ListNode(-1);

            ListNode MergeListNodehead = MergeListNode;


            //相邻两组开始归并（每组都已排序）
            while (first != null && secend != null)
            {

                if (first.val > secend.val)
                {
                   MergeListNode.next = secend;
                   secend = secend.next;
                    MergeListNode = MergeListNode.next;
                }
                else
                {
                    MergeListNode.next = first;
                    first = first.next;
                    MergeListNode = MergeListNode.next;
                }
            }
            //把两组中剩余的值加入到列表中
            if (first != null)
            {
                MergeListNode.next = first;
            }

            if (secend != null)
            {
                MergeListNode.next = secend;

            }

            return MergeListNodehead.next;
        }

        #region 转换为数组后，采用归并排序的方法 ( 超时 )
        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Count() == 0)
                return null;
            if (lists.Count() == 1)
            {
                return lists[0];
            }
            List<int> numbers = new List<int>();
            foreach (var list in lists)
            {
                var tempList = list;
                int middle = numbers.Count();
                while (tempList != null)
                {
                    numbers.Add(tempList.val);
                    tempList = tempList.next;
                }
                if (numbers.Count() > 0 && middle != numbers.Count())
                {
                    //两两归并
                    Merge(numbers, 0, middle, numbers.Count());
                }

            }
            if (numbers.Count() > 0)
            {
                ListNode node = new ListNode(numbers[0]);
                ListNode head = node;
                int i = 1;

                while (i < numbers.Count)
                {
                    node.next = new ListNode(numbers[i]);
                    node = node.next;
                    i++;
                }
                return head;
            }
            else
                return null;

        }

        /// <summary>
        /// 归并
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


        #endregion
    }
}
