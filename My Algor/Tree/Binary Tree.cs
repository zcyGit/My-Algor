using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.Tree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    /// <summary>
    /// 二叉树相关操作
    /// </summary>
    class Binary_Tree
    {
        /// <summary>
        /// 创建一颗完全二叉树
        /// </summary>
        /// <param name="list"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public static TreeNode CreatWQBinaryTree(List<int> list, TreeNode root)
        {

            //代表节点个数，根节点为1
            int i = 1;
            TreeNode Node = root;

            //当前父节点编号
            int nodeNumber = 1;
            //父节点编号集合
            List<TreeNode> nodes = new List<TreeNode>();
            //添加根节点
            nodes.Add(root);

            //思路，根据完全二叉树的性质，我们可以一个父节点一个父节点的顺序插入左右节点
            while (i < list.Count)
            {
                //添加左节点
                Node.left = new TreeNode(list[i]);
                nodes.Add(Node.left);
                i++;
                //添加右节点
                if (i < list.Count)
                {
                    Node.right = new TreeNode(list[i]);
                    nodes.Add(Node.right);
                    i++;
                }
                else
                    break;

                //前往下一个父节点
                nodeNumber++;
                Node = nodes[nodeNumber - 1];
            }

            return root;
        }


        /// <summary>
        ///层序遍历
        /// </summary>
        /// <param name="root"></param>
        public static void LayerTraverse(TreeNode root)
        {
            TreeNode Node = root;
            List<TreeNode> Nodes = new List<TreeNode>();
            Nodes.Add(root);
            int nodeNumber = 0;
            while (Nodes.Count > 0)
            {

                if (Node.left != null)
                {
                    Nodes.Add(Node.left);
                }
                else
                    break;
                if (Node.right != null)
                {
                    Nodes.Add(Node.right);
                }
                else
                    break;

                nodeNumber++;
                Node = Nodes[nodeNumber];
            }

            foreach (var node in Nodes)
            {
                Console.WriteLine(node.val);
            }
        }


        ///前序遍历，就是先访问根节点------左子树------右子树，如下图所示
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
        /// <summary>
        /// 中序遍历-->即按 lChild-->node-->rChild(先“左子节点”，然后“自身节点”，最后“右子节点”)的顺序来递归遍历
        /// </summary>
        /// <param name="root"></param>
        public static void MiddleTraverse(TreeNode root)
        {
            if (root != null)
            {
                PerTraverse(root.left);

                Console.Write("{0} ", root.val);

                PerTraverse(root.right);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 后序遍历-->即按 lChild-->rChild-->node(先“左子节点”，然后“右子节点”，最后“自身节点”)的顺序来递归遍历
        /// </summary>
        /// <param name="root"></param>
        public static void LastTraverse(TreeNode root)
        {
            if (root != null)
            {

                PerTraverse(root.left);
                PerTraverse(root.right);
                Console.Write("{0} ", root.val);

            }
            else
            {
                return;
            }
        }
    }
}
