using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor
{
    public class Cycle_detection
    {



        /// <summary>
        ///http://blog.csdn.net/javasus/article/details/50015687
        ///
        /// 算法描述
        ///如果有限状态机、迭代函数或者链表存在环，那么一定存在一个起点可以到达某个环的某处(这个起点也可以在某个环上)。
        ///初始状态下，假设已知某个起点节点为节点S。现设两个指针t和h，将它们均指向S。
        ///接着，同时让t和h往前推进，但是二者的速度不同：t每前进1步，h前进2步。只要二者都可以前进而且没有相遇，就如此保持二者的推进。当h无法前进，即到达某个没有后继的节点时，就可以确定从S出发不会遇到环。反之当t与h再次相遇时，就可以确定从S出发一定会进入某个环，设其为环C。

        ///如果确定了存在某个环，就可以求此环的起点与长度。 
        ///
        /// 
        /// 用来解决 Find_the_Duplicate_Number 问题
        /// 
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int cycleDetection(int[] nums)
        {
            int t = 0;
            int h = 0;
            //找到环了
            do
            {
                t = nums[t];
                h = nums[nums[h]];
            } while (t != h);
            //t 返回0，保存
            int find = 0;
            while (find != t)
            {
                t = nums[t];
                find = nums[find];
            }
            return find;
        }
    }
}
