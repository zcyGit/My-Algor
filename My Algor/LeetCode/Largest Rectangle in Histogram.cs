using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram. 
    /// </summary>
    public class Largest_Rectangle_in_Histogram
    {

        public static void Test()
        {

            int[] height = new int[] { 2, 1, 5, 6, 2, 3 };

            height = new int[] { 2, 3, 4, 5, 6, 7, 1 };
            height = new int[] { 3, 2, 3 };


            Console.Write(LargestRectangleArea(height));

        }


        /// <summary>
        /// 解题思路参考（http://www.zgxue.com/167/1674536.html）
        /// 这个解法真的很漂亮！！
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public static int LargestRectangleArea(int[] height)
        {
            int maxArea = 0;

            if (height == null || height.Length == 0)
            {
                return maxArea;
            }

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i <= height.Length; i++)
            {
                if (i != height.Length && (stack.Count == 0 || height[stack.Peek()] <= height[i]))
                {
                    stack.Push(i);
                }
                else
                {
                    if (stack.Count != 0)
                    {
                        int width = stack.Peek();
                        stack.Pop();

                        int temp = height[width] * (stack.Count == 0 ? i : i - stack.Peek() - 1);

                        if (temp > maxArea)
                        {
                            maxArea = temp;
                        }
                        i--;
                    }
                }
            }

            return maxArea;

        }
    }
}
