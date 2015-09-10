using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///You are given two linked lists representing two non-negative numbers. The digits 
///are stored in reverse order and each of their nodes contain a single digit. Add the two numbers and return it as a linked list.
///
///Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
///Output: 7 -> 0 -> 8

namespace My_Algor.LeetCode
{

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Add_Two_Numbers
    {
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            var l3 = new ListNode(0);

            if (l1 == null && l2 == null)
            {
                return null;
            }
            else if (l1 == null)
            {
                l3.val = l2.val;

                ListNode copyl2 = l2.next;
                l3.next = AddTwoNumbers(null, copyl2);
            }
            else if (l2 == null)
            {
                ListNode copyl1 = l1.next;

                if (l1.val >= 10)
                {
                    l3.val = l1.val - 10;
                    if (copyl1 != null)
                    {
                        copyl1.val += 1;
                    }
                    else
                    {
                        copyl1 = new ListNode(1);
                    }
                }
                else
                {
                    l3.val = l1.val;
                }

                l3.next = AddTwoNumbers(copyl1, null);
            }
            else
            {
                int sum = l2.val + l1.val;
                ListNode copyl1 = l1.next;

                if (sum >= 10)
                {
                    sum = sum - 10;
                    if (copyl1 != null)
                    {
                        copyl1.val += 1;
                    }
                    else
                    {
                        copyl1 = new ListNode(1);
                    }

                }

                l3.val = sum;
                l3.next = AddTwoNumbers(copyl1, l2.next);
            }

            return l3;
        }
    }
}
