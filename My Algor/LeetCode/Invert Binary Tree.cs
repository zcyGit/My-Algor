using My_Algor.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Invert_Binary_Tree
    {

        public static void Test()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TreeNode root = new TreeNode(list[0]);

            Binary_Tree.CreatWQBinaryTree(list, root);

            var node = InvertTree(root);

        }


        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null))
                return root;

            List<TreeNode> nodeList = new List<TreeNode>();
            nodeList.Add(root);

            for (int i = 0; i < nodeList.Count; )
            {
                if (nodeList[i] == null || (nodeList[i].left == null && nodeList[i].right == null))
                {
                    i++;
                    continue;
                }

                TreeNode tempNode = nodeList[i].right;
                nodeList[i].right = nodeList[i].left;
                nodeList[i].left = tempNode;

                nodeList.Add(nodeList[i].right);
                nodeList.Add(nodeList[i].left);
                i++;
            }

            return root;
        }
    }
}
