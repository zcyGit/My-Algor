using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Delete_Node_in_a_Linked_List
    {
        public static void Test()
        {

            ListNode l1 = new ListNode(1);
            ListNode l2 = new ListNode(2);
            ListNode l3 = new ListNode(3);
            ListNode l4 = new ListNode(4);

            l3.next = l4;
            l2.next = l3;
            l1.next = l2;

            DeleteNode(l1);

            var temp = l1;
            while (temp != null)
            {
                Console.WriteLine(temp.val);
                temp = temp.next;
            }

        }

        /// <summary>
        /// 明白题目的意思就很好做了
        /// </summary>
        /// <param name="node"></param>
        public static void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
    }
}
