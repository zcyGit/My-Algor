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
            //Plus_OneMain();
            //QuickSort.QuickSortTest();
            //Longest_Substring_Without_Repeating_Characters.Test();
            //Remove_Duplicates_from_Sorted_List.Test();
            //Happy_Number.Test();
            //N_Queens.Test();
            //N_QueensII.Test();
            //MergeSort.Test();
            //Maximum_Depth_of_Binary_Tree.Test();
            //Search_a_2D_Matrix.Test();
            //new My_Algor.Hash.Hash().Test();
            //Power_of_Two.Test();
            //Merge_k_Sorted_Lists.Test();
            //Move_Zeroes.Test();
            //Number_of_1_Bits.Test();
            //Binary_Tree_Preorder_Traversal.Test();
            //Valid_Anagram.Test();
            //Valid_Number.Test();
            Valid_Sudoku.Test();
            Console.ReadLine();
        }




        static void Median_of_Two_Sorted_ArraysMain()
        {
            int[] dis = new int[] { 2, 3, 4 };
            int[] dis2 = new int[] { 1 };

            var res = Median_of_Two_Sorted_Arrays.FindMedianSortedArrays(dis, dis2);

            Console.WriteLine(res);

        }

        static void Plus_OneMain()
        {
            int[] dis = new int[] { 8 };
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
