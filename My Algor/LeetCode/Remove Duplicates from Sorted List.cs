using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    ///   Given a sorted linked list, delete all duplicates such that each element appear only once. 
    ///For example,
    ///Given 1->1->2, return 1->2.
    ///Given 1->1->2->3->3, return 1->2->3. 
    /// </summary>
    class Remove_Duplicates_from_Sorted_List
    {

        public static void Test()
        {
            ListNode x = new ListNode(1);
            ListNode x1 = new ListNode(2);
            ListNode x2 = new ListNode(3);
            ListNode x3 = new ListNode(3);

            x2.next = x3;
            x1.next = x2;
            x.next = x1;

            var head = DeleteDuplicates(x);

            while (head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }

            Console.WriteLine();
        }




        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            ListNode Cur = head;
            ListNode Perv = head.next;


            while (Perv != null)
            {

                if (Perv.val == Cur.val)
                {
                    Cur.next = Perv.next;
                    Perv = Perv.next;
                }
                else
                {
                    Cur = Cur.next;
                    Perv = Perv.next;
                }

            }

            return head;


        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }



}
