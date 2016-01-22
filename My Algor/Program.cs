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
            //执行次数
            int iteration = 1;

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
            //Roman_to_Integer.Test();
            //CodeTimer.Time("Test", iteration, () => { _3Sum.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Same_Tree.Test(); });
            //CodeTimer.Time("Test", iteration, () => { ZigZag_Conversion.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Largest_Number.Test(); });
            //CodeTimer.Time("Test", iteration, () => { CandyAlgor.Test(); });        
            //CodeTimer.Time("Test", iteration, () => { Contains_Duplicate.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Longest_Consecutive_Sequence.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Single_Number.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Palindrome_Partitioning.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Repeated_DNA_Sequences.Test(); }); 
            //CodeTimer.Time("Test", iteration, () => { Sort_List.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Majority_Element.Test(); }); 
            //CodeTimer.Time("Test", iteration, () => { Ugly_Number.Test(); }); 
            //CodeTimer.Time("Test", iteration, () => { Integer_to_Roman.Test(); }); 
            //new Program().abc();
            //CodeTimer.Time("Test", iteration, () => { Product_of_Array_Except_Self.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Valid_Palindrome.Test(); }); 
            //CodeTimer.Time("Test", iteration, () => { The_Skyline_Problem.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Summary_Ranges.Test(); }); 
            //CodeTimer.Time("Test", iteration, () => { House_Robber.Test(); }); 
            //CodeTimer.Time("Test", iteration, () => { House_RobberII.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Remove_Duplicates_from_Sorted_ListII.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Maximum_Gap.Test(); }); 
            //CodeTimer.Time("Test", iteration, () => { _4Sum.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Symmetric_Tree.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Palindrome_Number.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Palindrome_Linked_List.Test(); }); 
            //CodeTimer.Time("Test", iteration, () => { Convert_Sorted_Array_to_Binary_Search_Tree.Test(); }); 
            //CodeTimer.Time("Test", iteration, () => { Longest_Palindromic_Substring.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Excel_Sheet_Column_Title.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Gas_Station.Test(); });            
            //CodeTimer.Time("Test", iteration, () => { Ugly_NumberII.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Valid_Parentheses.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Sliding_Window_Maximum.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Largest_Rectangle_in_Histogram.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Excel_Sheet_Column_Number.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Reverse_Linked_List.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Reverse_Linked_List_II.Test(); });

            //CodeTimer.Time("Test", iteration, () => { Single_Number_III.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Find_the_Duplicate_Number.Test(); });Power_of_Three
            //CodeTimer.Time("Test", iteration, () => { Power_of_Three.Test(); });

            //CodeTimer.Time("Test", iteration, () => { Unique_Binary_Search_Trees.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Delete_Node_in_a_Linked_List.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Burst_Balloons.Test(); });
            //CodeTimer.Time("Test", iteration, () => { Reverse_Integer.Test(); });    
            //CodeTimer.Time("Test", iteration, () => { Super_Ugly_Number.Test(); }); 
            CodeTimer.Time("Test", iteration, () => { Invert_Binary_Tree.Test(); }); 

            Console.ReadLine();
        }


        public async Task<bool> abc()
        {
            for (int i = 0; i < 5; i++)
            {
                prithf(i);
                Console.Write(i);

            }
            return true;

        }

        public async Task<int> prithf(int j)
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(i);
            }
            return 1;
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
