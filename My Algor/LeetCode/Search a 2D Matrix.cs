using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// Write an efficient algorithm that searches for a value in an m x n matrix. This matrix has the following properties:
    ///•Integers in each row are sorted from left to right.
    ///•The first integer of each row is greater than the last integer of the previous row.
    ///哈哈这个算法实现的速度，居然在leeCode上超越了100%的人
    /// </summary>
    class Search_a_2D_Matrix
    {
        public static void Test()
        {
            int target = 202;
            int[,] matrix = new int[,]
            { 
            { 1, 3, 5, 7 }, 
            { 10, 11, 16, 20 }, 
            { 23, 30, 34, 50 } 
            };

            //int target = 1;
            //int[,] matrix = new int[,] { { 1 } };

            //int target = 1;
            //int[,] matrix = new int[,] { { 1 } };

            //int target = 0;
            //int[,] matrix = new int[,] { { 1, 1 } };
            Console.WriteLine(SearchMatrix(new int[,] { { 1 }, { 3 } }, 1));

            Console.WriteLine(SearchMatrix(matrix, target));

            Console.WriteLine(SearchMatrix(matrix, target));
        }

        static int row;
        static int col;

        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool SearchMatrix(int[,] matrix, int target)
        {
            row = matrix.GetLength(0);
            col = matrix.GetLength(1);

            int[] begin = new int[] { 1, 1 };
            int[] end = new int[] { row, col };

            int number = row * col / 2;

            int[] middle = new int[] { number / col + 1, number % col + 1 };

            return BinarySearch(matrix, begin, middle, end, target);

        }

        /// <summary>
        /// 递归二分查找
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool BinarySearch(int[,] matrix, int[] begin, int[] middle, int[] end, int target)
        {
            
            if (begin[0] * col + begin[1] > end[0] * col + end[1])
            {
                return false;
            }

            if (matrix[middle[0] - 1, middle[1] - 1] > target)
            {
                //理解成，按距离计算
                int number = ((middle[0] - 1) * col + middle[1] + (begin[0] - 1) * col + begin[1]) / 2;
                //(number - 1) % col + 1 这个很重要(左边取的时候遇到偶数情况如 1 3 5 7 ，中间数选择 3 )
                int[] binaryMiddle = new int[] { (number - 1) / col + 1, (number - 1) % col + 1 };
                if (middle[1] > 1)
                {
                    middle[1]--;
                }
                else
                {
                    middle[0]--;
                    middle[1] = col - 1 + middle[1];
                }

                return BinarySearch(matrix, begin, binaryMiddle, middle, target);
            }
            else if (matrix[middle[0] - 1, middle[1] - 1] < target)
            {
                int number = ((middle[0] - 1) * col + middle[1] + (end[0] - 1) * col + end[1]) / 2;

                //(number ) % col + 1 这个很重要(右边边取的时候遇到偶数情况如 1 3 5 7 ，中间数选择 5 )

                int[] binaryMiddle = new int[] { number / col + 1, number % col + 1 };

                if (middle[1] + 1 > col)
                {
                    middle[0]++;
                    middle[1] = 1;
                }
                else
                    middle[1]++;

                return BinarySearch(matrix, middle, binaryMiddle, end, target);
            }
            else
                return true;



        }




    }
}
