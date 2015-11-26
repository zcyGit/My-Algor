using My_Algor.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given an array where elements are sorted in ascending order, convert it to a height balanced BST.
    /// 平衡二叉搜索树
    /// </summary>
    public class Convert_Sorted_Array_to_Binary_Search_Tree
    {
        public static void Test()
        {
            int[] nums = new int[] { 0};

            var TreeNode = SortedArrayToBST(nums);


        }

        public static TreeNode SortedArrayToBST(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return null;
            }
            int begin = 0;
            int end = nums.Length - 1;
            TreeNode node = null;


            var result = SortedArrayToBST(nums, begin, end, node);

            return result;

        }


        public static TreeNode SortedArrayToBST(int[] nums, int begin, int end, TreeNode node)
        {
            int middle = begin + (end - begin) / 2;

            if (begin == end)
            {
                return new TreeNode(nums[middle]);
            }
            else if (begin > end)
            {
                return null;
            }
            else
            {
                node = new TreeNode(nums[middle]);
            }

            node.left = SortedArrayToBST(nums, begin, middle - 1, node);

            node.right = SortedArrayToBST(nums, middle + 1, end, node);

            return node;
        }

    }
}
