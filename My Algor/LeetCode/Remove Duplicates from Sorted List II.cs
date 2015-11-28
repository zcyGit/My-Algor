using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a sorted linked list, delete all nodes that have duplicate numbers, leaving only distinct numbers from the original list. 
    /// For example,
    /// Given 1->2->3->3->4->4->5, return 1->2->5.
    /// Given 1->1->1->2->3, return 2->3. 
    /// </summary>
    class Remove_Duplicates_from_Sorted_ListII
    {

        public static void Test()
        {
            ListNode x = new ListNode(1);
            ListNode x1 = new ListNode(1);
            ListNode x2 = new ListNode(2);
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

        }


        public static ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }
            ListNode temp = new ListNode(int.MinValue);
            temp.next = head;

            ListNode Cur = temp;
            ListNode Next = temp.next;
            ListNode Pre = temp;

            while (Next != null)
            {
                if (Next.val == Cur.val)
                {
                    Next = Next.next;

                    while (Next != null && Next.val == Cur.val)
                    {
                        Next = Next.next;
                    }

                    Pre.next = Next;
                    Cur = Pre.next;
                    if (Next == null)
                    {
                        return temp.next;
                    }
                    Next = Next.next;
                }
                else
                {
                    Pre = Cur;
                    Cur = Cur.next;
                    Next = Next.next;
                }
            }

            return temp.next;
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }



}
