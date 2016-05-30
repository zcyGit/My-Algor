using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Word_Search
    {
        private static string JuHeAllProjectPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase.ToString(), "1.txt");

        public static void Test()
        {
            //var sum = new char[,] { { 'A', 'B', 'C', 'E' }, { 'S', 'F', 'C', 'S' }, { 'A', 'D', 'E', 'E' } };
            //var word = "ABCB";

            var sum = new char[,] { { 'A', 'B'}, {'C', 'D' }};
            var word = "ABCD";

            Console.WriteLine(Exist(sum, word));
        }

        private static int n = 0;
        private static int m = 0;

        public static bool Exist(char[,] board, string word)
        {
            n = board.GetLength(0);
            m = board.GetLength(1);

            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            var listExist = new bool[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (board[i, j] == word[0] && !listExist[i, j])
                    {

                        listExist[i, j] = true;
                        if (word.Length == 1)
                        {
                            return true;
                        }

                        if (SearchBoard(board, word.Substring(1), listExist, i, j))
                        {
                            return true;
                        }
                        listExist[i, j] = false;
                    }
                }
            }

            return false;
        }

        public static bool SearchBoard(char[,] board, string word, bool[,] listExist, int i, int j)
        {
            if (word.Length == 0)
            {
                return true;
            }

            //四个方向
            int[,] direction = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            for (int z = 0; z < 4; z++)
            {
                int x = i + direction[z, 0];
                int y = j + direction[z, 1];

                if (x >= 0 && x < n && y >= 0 && y < m)
                {
                    if (board[x, y] == word[0] && !listExist[x, y])
                    {
                        listExist[x, y] = true;
                        if (word.Length == 1)
                        {
                            return true;
                        }

                        if (SearchBoard(board, word.Substring(1), listExist, x, y))
                        {
                            return true;
                        }
                        listExist[x, y] = false;
                    }
                }
            }

            return false;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        public static void Split()
        {
            var list = new List<byte[]>();

            FileStream fs;
            //获得文件所在路径  
            string filePath = JuHeAllProjectPath;

            //打开文件  
            try
            {
                fs = new FileStream(filePath, FileMode.Open);
            }
            catch (Exception)
            {
                throw;
            }

            //尚未读取的文件内容长度  
            long left = fs.Length;
            //存储读取结果  
            byte[] bytes = new byte[256];
            //每次读取长度  
            int maxLength = bytes.Length;
            //读取位置  
            int start = 0;
            //实际返回结果长度  
            int num = 0;
            //当文件未读取长度大于0时，不断进行读取  
            while (left > 0)
            {
                fs.Position = start;
                num = 0;
                if (left < maxLength)
                    num = fs.Read(bytes, 0, Convert.ToInt32(left));
                else
                    num = fs.Read(bytes, 0, maxLength);
                if (num == 0)
                    break;
                start += num;
                left -= num;
                list.Add(bytes);
            }
            fs.Close();

        }
    }
}
