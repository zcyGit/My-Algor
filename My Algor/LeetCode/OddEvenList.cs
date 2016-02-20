using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Odd_Even_List
    {

        public static void Test()
        {
            ListNode head = new ListNode(1);

            var tempHead = head;
            for (int i = 2; i < 9; i++)
            {
                ListNode temp = new ListNode(i);
                tempHead.next = temp;
                tempHead = tempHead.next;
            }


            var list = OddEvenList(head);
            while (list != null)
            {
                Console.WriteLine(list.val);
                list = list.next;
            }
        }

        public static ListNode OddEvenList(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null) return head;

            var odd = head;
            var oddHead = odd;
            var even = head.next;
            var evenHead = even;

            while (even != null && even.next != null)
            {
                //奇数的下一个连接偶数的下一个
                odd.next = even.next;
                odd = odd.next;

                even.next = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return oddHead;  

        }
    }
}
  