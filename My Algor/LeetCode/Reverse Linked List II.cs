using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Reverse_Linked_List_II
    {
        /// <summary>
        /// 反转一个链表
        /// </summary>
        public static void Test()
        {
            ListNode l1 = new ListNode(2);
            ListNode l2 = new ListNode(3);
            ListNode l3 = new ListNode(4);
            ListNode l4 = new ListNode(5);

            l3.next = l4;
            l2.next = l3;
            l1.next = l2;

            var node = ReverseList(l1, 2, 3);

            while (node != null)
            {
                Console.WriteLine(node.val);
                node = node.next;

            }


        }

        public static ListNode ReverseList(ListNode head, int m, int n)
        {
            if (head == null || m == n)
            {
                return head;
            }

            ListNode tempHead = new ListNode(0);
            tempHead.next = head;
            var mNode = tempHead;
            ListNode current, pnext;
            int i = 1;           

            while (i < m)
            {
                mNode = mNode.next;
                i++;
            }

            current = mNode.next;        

            while (current.next != null && i < n)
            {
                pnext = current.next;
                current.next = pnext.next;
                pnext.next = mNode.next;
                mNode.next = pnext;
                i++;
            }

            return tempHead.next;
        }

    }
}
