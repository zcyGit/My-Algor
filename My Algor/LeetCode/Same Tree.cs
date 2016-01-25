using My_Algor.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given two binary trees, write a function to check if they are equal or not. 
    ///Two binary trees are considered equal if they are structurally identical and the nodes have the same value. 
    /// </summary>
    public class Same_Tree
    {
        public static void Test()
        {
            List<int> listp = new List<int>() { 1};

            TreeNode p = new TreeNode(listp[0]);
            Binary_Tree.CreatWQBinaryTree(listp, p);

            List<int> listq = new List<int>() { 1};

            TreeNode q = new TreeNode(listq[0]);
            Binary_Tree.CreatWQBinaryTree(listq, q);

            Console.Write(IsSameTree(p, q));


        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }
            else if ((p == null && q != null) || (p != null && q == null))
            {
                return false;
            }

            TreeNode Nodep = p;
            TreeNode Nodeq = q;

            List<TreeNode> PNodes = new List<TreeNode>();
            List<TreeNode> QNodes = new List<TreeNode>();

            PNodes.Add(p);
            QNodes.Add(q);

            int nodeNumber = 0;
            while (PNodes.Count > 0)
            {
                if (Nodep.val != Nodeq.val)
                {
                    return false;
                }

                if (Nodep.left != null)
                {
                    if (Nodeq.left == null || Nodeq.left.val != Nodep.left.val)
                    {
                        return false;
                    }

                    PNodes.Add(Nodep.left);
                    QNodes.Add(Nodeq.left);
                }
                else if (Nodeq.left != null)
                {
                    return false;
                }

                if (Nodep.right != null)
                {
                    if (Nodeq.right == null || Nodeq.right.val != Nodep.right.val)
                    {
                        return false;
                    }

                    PNodes.Add(Nodep.right);
                    QNodes.Add(Nodeq.right);

                }
                else if (Nodeq.right != null)
                {
                    return false;
                }

                nodeNumber++;
                if (nodeNumber >= PNodes.Count)
                {
                    break;
                }
                Nodep = PNodes[nodeNumber];
                Nodeq = QNodes[nodeNumber];

            }

            return true;

        }
    }
}
