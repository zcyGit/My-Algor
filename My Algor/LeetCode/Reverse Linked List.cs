using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Reverse_Linked_List
    {
        /// <summary>
        /// 反转一个链表
        /// </summary>
        public static void Test()
        {
            ListNode l1 = new ListNode(2);
            ListNode l2 = new ListNode(3);
            ListNode l3 = new ListNode(4);

            l2.next = l3;
            l1.next = l2;

            var node = ReverseList(l1);


        }

        public static ListNode ReverseList(ListNode head)
        {
            if(head==null)
            {
                return null;
            }

            ListNode tempHead = new ListNode(0);
            tempHead.next = head;

            ListNode current, pnext;
            current = tempHead.next;

            while (current.next != null)
            {
                pnext = current.next;
                current.next = pnext.next;
                pnext.next = tempHead.next;
                tempHead.next = pnext;
            }

            return tempHead.next;
        }
    }
}
