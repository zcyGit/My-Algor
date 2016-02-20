using My_Algor.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
    /// </summary>
    public class Symmetric_Tree
    {
        /// <summary>
        /// https://leetcode.com/discuss/54627/c%23-accepted-issymmetrictree-recursive-and-non-recursive
        /// </summary>
        public static void Test()
        {

            List<int> list = new List<int>() { 1,2,2,3,4,4,3,6,5,7,8,8,7,5,5 };

            TreeNode root = new TreeNode(list[0]);
            Binary_Tree.CreatWQBinaryTree(list, root);

            Console.Write(IsSymmetric2(root));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsSymmetric(TreeNode root)
        {
            var result = false;

            if (root == null)
                return true;

            var nodeListA = PreorderTraversal(root.left);
            var nodeListB = PreorderTraversalReverse(root.right);


            if (nodeListA.Count == nodeListB.Count)
            {
                for (int i = 0; i < nodeListA.Count; i++)
                {
                    if (nodeListA[i] != nodeListB[i])
                    {
                        return false;
                    }
                }
                result = true;
            }

            return result;
        }


        public static bool IsSymmetric2(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            if (root.right == null && root.left == null)
            {
                return true;
            }
            else if (root.right == null || root.left == null)
            {
                return false;
            }

            List<TreeNode> NodesLeft = new List<TreeNode>();
            List<TreeNode> NodesRight = new List<TreeNode>();

            NodesLeft.Add(root.left);
            NodesRight.Add(root.right);

            int nodeNumber = 0;
            while (nodeNumber >= 0)
            {
                if (NodesLeft[nodeNumber].val != NodesRight[nodeNumber].val)
                {
                    return false;
                }

                //进行左节点
                if (NodesLeft[nodeNumber].left != null)
                {
                    NodesLeft.Add(NodesLeft[nodeNumber].left);
                }

                if (NodesRight[nodeNumber].right != null)
                {
                    NodesRight.Add(NodesRight[nodeNumber].right);
                }
                if (NodesRight.Count != NodesLeft.Count)
                {
                    return false;
                }

                //进行右节点
                if (NodesLeft[nodeNumber].right != null)
                {
                    NodesLeft.Add(NodesLeft[nodeNumber].right);
                }
                if (NodesRight[nodeNumber].left != null)
                {
                    NodesRight.Add(NodesRight[nodeNumber].left);
                }
                if (NodesRight.Count != NodesLeft.Count)
                {
                    return false;
                }

                if (nodeNumber == NodesRight.Count-1)
                {
                    break;
                }

                nodeNumber++;

            }

            return true;

        }



        public static IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            List<int> preorder = new List<int>();
            List<TreeNode> Nodes = new List<TreeNode>();

            Nodes.Add(root);

            int nodeNumber = 0;
            while (nodeNumber >= 0)
            {
                //这里判断根节点是否已经保存了
                if (nodeNumber == Nodes.Count() - 1)
                {
                    preorder.Add(Nodes[nodeNumber].val);
                }
                else
                {
                    nodeNumber = nodeNumber - 1;
                }
                //进行左节点
                if (Nodes[nodeNumber].left != null)
                {
                    Nodes.Add(Nodes[nodeNumber].left);
                    nodeNumber++;

                    continue;
                }
                //进行右节点
                if (Nodes[nodeNumber].right != null)
                {
                    Nodes.Add(Nodes[nodeNumber].right);
                    nodeNumber++;

                    continue;
                }
                //左右都跑完后，上一个节点设为空
                else
                {
                    if (nodeNumber == 0)
                    {
                        break;
                    }
                    if (Nodes[nodeNumber - 1].left == null)
                    {
                        Nodes[nodeNumber - 1].right = null;
                    }
                    else
                    {
                        Nodes[nodeNumber - 1].left = null;
                    }
                }
                Nodes.RemoveAt(nodeNumber);

            }

            return preorder;
        }


        public static IList<int> PreorderTraversalReverse(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>();
            }

            List<int> preorder = new List<int>();
            List<TreeNode> Nodes = new List<TreeNode>();
            Nodes.Add(root);

            int nodeNumber = 0;
            while (nodeNumber >= 0)
            {
                //这里判断根节点是否已经保存了
                if (nodeNumber == Nodes.Count() - 1)
                {
                    preorder.Add(Nodes[nodeNumber].val);
                }
                else
                {
                    nodeNumber = nodeNumber - 1;
                }
                //进行右节点
                if (Nodes[nodeNumber].right != null)
                {
                    Nodes.Add(Nodes[nodeNumber].right);
                    nodeNumber++;

                    continue;
                }
                //进行左节点
                if (Nodes[nodeNumber].left != null)
                {
                    Nodes.Add(Nodes[nodeNumber].left);
                    nodeNumber++;

                    continue;
                }
                //左右都跑完后，上一个节点设为空
                else
                {
                    if (nodeNumber == 0)
                    {
                        break;
                    }
                    if (Nodes[nodeNumber - 1].right == null)
                    {
                        Nodes[nodeNumber - 1].left = null;
                    }
                    else
                    {
                        Nodes[nodeNumber - 1].right = null;
                    }
                }
                Nodes.RemoveAt(nodeNumber);

            }

            return preorder;
        }

    }
}
