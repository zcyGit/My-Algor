using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{

    /// <summary>
    /// 参考论坛 https://leetcode.com/discuss/20139/java-hashtable-double-linked-list-with-touch-of-pseudo-nodes
    /// 里java的实现方法，重新写一个c#的
    /// </summary>
    public class LRUCache
    {

        private int Capacity;
        private int count;

        #region 双向链表 + 字典

        private Dictionary<int, DLinkedNode> cache = new Dictionary<int, DLinkedNode>();
        private DLinkedNode head, tail;

        class DLinkedNode
        {
            public int key;
            public int value;
            public DLinkedNode pre;
            public DLinkedNode post;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="node"></param>
        private void addNode(DLinkedNode node)
        {
            node.pre = head;
            node.post = head.post;

            head.post.pre = node;
            head.post = node;
        }

        /// <summary>
        /// 移除一个节点
        /// </summary>
        /// <param name="node"></param>
        private void removeNode(DLinkedNode node)
        {
            DLinkedNode pre = node.pre;
            DLinkedNode post = node.post;

            pre.post = post;
            post.pre = pre;
        }

        /// <summary>
        /// 移动节点
        /// </summary>
        /// <param name="node"></param>
        private void moveToHead(DLinkedNode node)
        {
            this.removeNode(node);
            this.addNode(node);
        }

        /// <summary>
        /// 移除最后一个
        /// </summary>
        /// <returns></returns>
        private DLinkedNode popTail()
        {
            DLinkedNode res = tail.pre;
            this.removeNode(res);
            return res;
        }


        public LRUCache(int capacity)
        {
            Capacity = capacity;
            count = 0;

            head = new DLinkedNode();
            head.pre = null;

            tail = new DLinkedNode();
            tail.post = null;

            head.post = tail;
            tail.pre = head;
        }

        public int Get(int key)
        {
            DLinkedNode node = null;

            if (cache.ContainsKey(key))
            {
                node = cache[key];
            }

            if (node == null)
            {
                return -1;
            }

            this.moveToHead(node);
            return node.value;
        }


        public void Set(int key, int value)
        {

            DLinkedNode node = null;

            if (cache.ContainsKey(key))
            {
                node = cache[key];
            }

            if (node == null)
            {
                DLinkedNode newNode = new DLinkedNode();
                newNode.key = key;
                newNode.value = value;

                this.cache.Add(key, newNode);
                this.addNode(newNode);

                ++count;

                if (count > Capacity)
                {
                    DLinkedNode tail = this.popTail();
                    this.cache.Remove(tail.key);
                    --count;
                }
            }
            else
            {
                node.value = value;
                this.moveToHead(node);
            }

        }

        #endregion


        #region 用list代替双链表 超时

        //private static List<int> listNode = new List<int>();
        //private Dictionary<int, Node> cache = new Dictionary<int, Node>();

        //public class Node
        //{
        //    public int key;
        //    public int value;
        //}

        //public LRUCache(int capacity)
        //{
        //    Capacity = capacity;
        //    listNode = new List<int>();
        //}

        //public int Get(int key)
        //{
        //    Node node = new Node();

        //    if (cache.ContainsKey(key))
        //    {
        //        node = cache[key];
        //        listNode.Remove(key);
        //        listNode.Insert(0, key);
        //        return node.value;
        //    }
        //    else
        //    {
        //        return -1;
        //    }
        //}

        //public void Set(int key, int value)
        //{

        //    if (cache.ContainsKey(key))
        //    {
        //        var node = cache[key];
        //        listNode.Remove(key);
        //        node.value = value;
        //        cache[key] = node;
        //        listNode.Insert(0, key);

        //    }
        //    else
        //    {
        //        if (listNode.Count == Capacity)
        //        {
        //            var reNode = listNode.Last();
        //            cache.Remove(key);
        //            listNode.RemoveAt(Capacity - 1);
        //        }

        //        Node node = new Node();
        //        node.key = key;
        //        node.value = value;
        //        listNode.Insert(0, key);

        //        cache.Add(key, node);
        //    }
        //}

        #endregion


    }
}
