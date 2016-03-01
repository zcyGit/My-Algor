using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Swap_Nodes_in_Pairs
    {

        public static void Test()
        {
            ListNode l1 = new ListNode(1);
            ListNode l2 = new ListNode(2);
            ListNode l3 = new ListNode(3);
            ListNode l4 = new ListNode(4);
            ListNode l5 = new ListNode(5);

            l4.next = l5;
            l3.next = l4;
            l2.next = l3;
            l1.next = l2;

            var node = new Swap_Nodes_in_Pairs().SwapPairs(l1);

            while (node != null)
            {
                Console.WriteLine(node.val);
                node = node.next;
            }

        }

        public ListNode SwapPairs(ListNode head)
        {
            ListNode tempHead = new ListNode(-1);
            tempHead.next = head;
            var node = tempHead;
            ListNode current, pnext;

            current = node.next;

            while (current != null)
            {
                pnext = current.next;

                if (pnext != null)
                {
                    //交换
                    current.next = pnext.next;
                    pnext.next = node.next;
                    node.next = pnext;
                    //重置
                    node = current;
                    current = node.next;

                }
                else
                {
                    break;
                }
            }

            return tempHead.next;
        }
    }
}
