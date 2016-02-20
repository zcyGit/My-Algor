using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Sort_List
    {
        /// <summary>
        /// 时间复杂度要求要nlogn ，空间要求不开辟新的内存空间，
        /// 选择用归并排序来做
        /// </summary>
        public static void Test()
        {

            ListNode l1 = new ListNode(2);
            ListNode l2 = new ListNode(3);
            ListNode l3 = new ListNode(1);
            ListNode l4 = new ListNode(4);

            l2.next = l3;
            l1.next = l2;

            var list = new Sort_List().SortList(l1);


        }

        public ListNode MergeListNode(ListNode first, ListNode secend)
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

        private ListNode mergeSort(ListNode head, ListNode tail)
        {
            if (head.next == tail)
            { //single node
                head.next = null;
                return head;
            }

            ListNode itr = head, mid = head;
            while (itr != tail)
            {
                itr = itr.next;

                if (itr != tail)
                {
                    itr = itr.next;
                }

                mid = mid.next;
            }

            ListNode l1 = mergeSort(head, mid);

            ListNode l2 = mergeSort(mid, tail);

            return MergeListNode(l1, l2);
        }

        public ListNode SortList(ListNode head)
        {
            if (head == null) //trap
                return null;

            return mergeSort(head, null);
        }


    }
}
