using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a binary tree, find its maximum depth.
    ///The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
    /// </summary>
    class Maximum_Depth_of_Binary_Tree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }


        public static void Test()
        {
            List<int> list = new List<int>() { 13};

            TreeNode root = new TreeNode(1);

            CreatBinaryTree(list, root);

            MaxDepth(root);
            Console.Write(maxDepth);

        }

        /// <summary>
        /// 创建一颗二叉树
        /// </summary>
        /// <param name="list"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static TreeNode CreatBinaryTree(List<int> list, TreeNode root)
        {

            if (list.Count > 0)
            {
                root.left = new TreeNode(list[0]);
                list.RemoveAt(0);
            }
            else
            {
                return root;
            }

            if (list.Count > 0)
            {
                root.right = new TreeNode(list[0]);
                list.RemoveAt(0);
            }
            else
            {
                return root;
            }

            CreatBinaryTree(list, root.left);

            return root;
        }


        private static int maxDepth = 0;

        public static int MaxDepth(TreeNode root)
        {

            PerTraverse(root, 0);
            return 0;

        }


        ///前序遍历，就是先访问根节点------左子树------右子树，如下图所示
        public static void PerTraverse(TreeNode root, int depth)
        {
            if (root != null)
            {
                depth += 1;
            }
            else
            {
                if (depth > maxDepth)
                {
                    maxDepth = depth;
                }
                return;
            }

            PerTraverse(root.left, depth);
            PerTraverse(root.right, depth);

        }

    }
}
