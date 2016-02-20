using My_Algor.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Binary_Tree_Preorder_Traversal
    {
        public static void Test()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TreeNode root = new TreeNode(list[0]);

            Binary_Tree.CreatWQBinaryTree(list, root);

            var listRes = PreorderTraversal(root);

            foreach (var number in listRes)
            {
                Console.Write(number + " ");
            }
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


        public static void PerTraverse(TreeNode root)
        {
            if (root != null)
            {
                Console.Write("{0} ", root.val);

                PerTraverse(root.left);
                PerTraverse(root.right);
            }
            else
            {
                return;
            }
        }
    }
}
