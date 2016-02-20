using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// 
    /// Given a singly linked list L: L0→L1→…→Ln-1→Ln,
    ///reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→… 
    ///You must do this in-place without altering the nodes' values.
    ///For example,
    ///Given {1,2,3,4}, reorder it to {1,4,2,3}. 
    /// </summary>
    public class Reorder_List
    {

        public static void Test()
        {
            ListNode head = new ListNode(1);

            var tempHead = head;
            for (int i = 2; i < 4; i++)
            {
                ListNode temp = new ListNode(i);
                tempHead.next = temp;
                tempHead = tempHead.next;
            }
            ReorderList(head);
            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        public static void ReorderList(ListNode head)
        {
            if (head == null || head.next == null) return;

            var reMidNode = FindMid(head);
            reMidNode = ReverseList(reMidNode);

            var beginNode = head;
            var tempNode = head;
            while (reMidNode != null)
            {
                tempNode = tempNode.next;

                beginNode.next = reMidNode;

                reMidNode = reMidNode.next;

                beginNode = beginNode.next;

                beginNode.next = tempNode;

                beginNode = beginNode.next;
            }
            beginNode.next = null;

        }


        /// <summary>
        /// 找到中间列表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        protected static ListNode FindMid(ListNode head)
        {
            var beginNode = head;
            var midNode = head;
            while (beginNode != null)
            {
                beginNode = beginNode.next;
                midNode = midNode.next;
                if (beginNode != null)
                {
                    beginNode = beginNode.next;
                }
            }
            return midNode;
        }


        /// <summary>
        /// 反转列表
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        protected static ListNode ReverseList(ListNode node)
        {

            ListNode head = new ListNode(0);
            head.next = node;

            ListNode current, pnext;
            current = head.next;

            while (current.next != null)
            {
                pnext = current.next;
                current.next = pnext.next;
                pnext.next = head.next;
                head.next = pnext;

            }

            return head.next;
        }
    }
}
