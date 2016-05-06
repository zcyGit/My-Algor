using My_Algor.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Lowest_Common_Ancestor_of_a_Binary_Search_Tree
    {

        public static void Test()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TreeNode root = new TreeNode(0);
            Binary_Tree.CreatWQBinaryTree(list, root);


        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return root;
            }
            if (root.val > p.val && root.val > q.val)
            {
                return LowestCommonAncestor(root.left, p, q);
            }
            else if (root.val < p.val && root.val< q.val)
            {
                return LowestCommonAncestor(root.right, p, q);
            }
            return root;
        }

    }
}
