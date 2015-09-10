using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_Algor.LeetCode;
using My_Algor.Sort;
namespace My_Algor
{
    class Program
    {
        static void Main(string[] args)
        {

            QuickSort.QuickSortTest();
            Console.ReadLine();
        }




        static void Median_of_Two_Sorted_ArraysMain()
        {
            int[] dis = new int[] { 2,3,4};
            int[] dis2 = new int[] { 1};

            var res = Median_of_Two_Sorted_Arrays.FindMedianSortedArrays(dis, dis2);

            Console.WriteLine(res);

        }

        static void Plus_OneMain()
        {
            int[] dis = new int[] { 9 };
            var res = Plus_One.PlusOne(dis);

            Console.WriteLine();

        }

        static void Add_Two_NumbersMain()
        {
            ListNode l1 = new ListNode(9);
            ListNode l2 = new ListNode(9);
            ListNode l3 = new ListNode(3);

            //l2.next = l3;
            l1.next = l2;

            ListNode m1 = new ListNode(9);
            ListNode m2 = new ListNode(6);
            ListNode m3 = new ListNode(4);

            //m2.next = m3;
            //m1.next = m2;

            int[] numbers = { -1, -2, -3, -4, -5 };

            var nodes = Add_Two_Numbers.AddTwoNumbers(l1, m1);

            Console.WriteLine(nodes.ToString());

        }
    }
}
