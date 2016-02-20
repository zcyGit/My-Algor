using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a singly linked list, determine if it is a palindrome.
    /// </summary>
    public class Palindrome_Linked_List
    {

        public static void Test()
        {

            ListNode l1 = new ListNode(1);
            ListNode l2 = new ListNode(2);
            ListNode l3 = new ListNode(10);
            ListNode l4 = new ListNode(2);
            ListNode l5 = new ListNode(1);

            //l4.next = l5;
            //l3.next = l4;
            //l2.next = l3;
            l1.next = l2;

           Console.Write(IsPalindrome(l1));

        }

        /// <summary>
        /// 思路：把中间后半段的链表反转，然后进行比较
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public static bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }

            var begin = head;

            var mid = FindMid(head);
            mid = ReverseList(mid);

            while (mid != null)
            {
                if (begin.val != mid.val)
                {
                    return false;
                }
                begin = begin.next;
                mid = mid.next;
                
            }
            return true;
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
