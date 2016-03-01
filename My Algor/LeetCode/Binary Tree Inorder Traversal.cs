using My_Algor.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Binary_Tree_Inorder_Traversal
    {

        public List<int> list = new List<int>();


        public static void Test()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            list = new List<int>() { 1 };

            TreeNode root = new TreeNode(list[0]);

            Binary_Tree.CreatWQBinaryTree(list, root);

            var list1 = new Binary_Tree_Inorder_Traversal().InorderTraversal(root);

        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            list = new List<int>();

            if(root==null)
            {
               return  list;
            }

            MiddleTraverseFor(root);
            return list;
        }

        /// <summary>
        /// 中序遍历-->即按 lChild-->node-->rChild(先“左子节点”，然后“自身节点”，最后“右子节点”)的顺序来递归遍历
        /// </summary>
        /// <param name="root"></param>
        public void MiddleTraverseFor(TreeNode root)
        {
            List<TreeNode> Nodes = new List<TreeNode>();
            Nodes.Add(root);

            var nodeNumber = 0;
            while (nodeNumber >= 0)
            {
                if (Nodes[nodeNumber].left != null)
                {
                    Nodes.Add(Nodes[nodeNumber].left);
                    nodeNumber++;
                }
                else
                {
                    list.Add(Nodes[nodeNumber].val);

                    if (Nodes[nodeNumber].right != null)
                    {
                        Nodes.Add(Nodes[nodeNumber].right);
                        nodeNumber++;
                    }
                    else
                    {
                        while (nodeNumber > 0 && Nodes[nodeNumber - 1].left == null)
                        {
                            Nodes[nodeNumber - 1].right = null;
                            Nodes.RemoveAt(nodeNumber);
                            nodeNumber--;
                        }
                        if (nodeNumber > 0)
                        {
                            Nodes[nodeNumber - 1].left = null;
                        }

                        Nodes.RemoveAt(nodeNumber);
                        nodeNumber--;

                    }

                }
            }
        }
    }
}
