using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Remove_Nth_Node_From_End_of_List
    {
        /// <summary>
        /// </summary>
        public static void Test()
        {
            ListNode l1 = new ListNode(2);
            ListNode l2 = new ListNode(3);
            ListNode l3 = new ListNode(4);

            l2.next = l3;
            l1.next = l2;

            var node = RemoveNthFromEnd(l1, 4);

            while (node != null)
            {
                Console.WriteLine(node.val);
                node = node.next;
            }



        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null)
            {
                return null;
            }

            if (n == 0)
            {
                return head;
            }

            ListNode tempHead = new ListNode(0);
            tempHead.next = head;

            ListNode current;
            current = tempHead.next;
            int totel = 0;


            while (current != null)
            {
                current = current.next;
                totel++;
            }

            int number = totel - n;
            current = tempHead;

            while (current != null)
            {
                if (number == 0)
                {
                    if (current.next != null)
                    {
                        current.next = current.next.next;
                    }
                }
                current = current.next;
                number--;


            }

            return tempHead.next;
        }
    }
}
