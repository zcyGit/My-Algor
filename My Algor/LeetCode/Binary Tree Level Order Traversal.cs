using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_Algor.Tree;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).
    /// </summary>
    class Binary_Tree_Level_Order_Traversal
    {
        public static void Test()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            TreeNode root = new TreeNode(list[0]);

            Binary_Tree.CreatWQBinaryTree(list, root);

            LevelOrder(root);

        }


        public static IList<IList<int>> LevelOrder(TreeNode root)
        {

            List<IList<int>> treeList = new List<IList<int>>();
            List<TreeNode> Nodes = new List<TreeNode>();

            if (root == null)
            {
                return treeList;
            }

            //用来保存节点的深度
            List<int> NodeDepth = new List<int>();

            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();

            TreeNode Node = root;
            bool left = false;
            bool rigth = false;

            NodeDepth.Add(0);
            Nodes.Add(root);
            treeList.Add(new List<int>() { root.val });

            int nodeNumber = 0;
            while (Nodes.Count > 0)
            {

                if (Node.left != null)
                {
                    left = false;
                    Nodes.Add(Node.left);
                    //当前深度等于
                    NodeDepth.Add(NodeDepth[nodeNumber] + 1);

                    if (dic.ContainsKey(NodeDepth[nodeNumber] + 1))
                    {
                        dic[NodeDepth[nodeNumber] + 1].Add(Node.left.val);
                    }
                    else
                    {
                        List<int> sameDepthNodeList = new List<int>();
                        sameDepthNodeList.Add(Node.left.val);
                        dic.Add(NodeDepth[nodeNumber] + 1, sameDepthNodeList);
                    }
                }
                else
                    left = true;

                if (Node.right != null)
                {
                    rigth = false;
                    Nodes.Add(Node.right);
                    NodeDepth.Add(NodeDepth[nodeNumber] + 1);

                    if (dic.ContainsKey(NodeDepth[nodeNumber] + 1))
                    {
                        dic[NodeDepth[nodeNumber] + 1].Add(Node.right.val);
                    }
                    else
                    {
                        List<int> sameDepthNodeList = new List<int>();
                        sameDepthNodeList.Add(Node.right.val);
                        dic.Add(NodeDepth[nodeNumber] + 1, sameDepthNodeList);
                    }

                }
                else
                    rigth = true;

                nodeNumber++;

                if (rigth && left && nodeNumber > Nodes.Count() - 1)
                {
                    break;
                }

                Node = Nodes[nodeNumber];
            }

            foreach (var sameDepthNodeList in dic.Values)
            {
                treeList.Add(sameDepthNodeList);
            }

            return treeList;

        }
    }
}
