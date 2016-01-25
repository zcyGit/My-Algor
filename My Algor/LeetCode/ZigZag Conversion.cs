using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// 锯齿形转换
    /// The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility) 
    /// P   A   H   N
    /// A P L S I I G
    /// Y   I   R

    //如果是4的话,图形如下面这样，注意正确理解
    /// P     I
    /// A   L S
    /// Y A   H
    /// p     I
    ///And then read line by line: "PAHNAPLSIIGYIR"

    ///Write the code that will take a string and make this conversion given a number of rows: 
    ///string convert(string text, int nRows);
    ///convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR". 
    /// </summary>
    public class ZigZag_Conversion
    {
        public static void Test()
        {
            string s = "PAYPALISHIRING";
            int numRows = 3;


            Console.Write(Convert(s, numRows));


        }
        public static string Convert(string s, int numRows)
        {
            var convertS = string.Empty;

            if (string.IsNullOrEmpty(s) || numRows <= 1 || numRows >= s.Length)
            {
                return s;
            }
            var chars = s.ToArray();

            var matrixLength = chars.Length - numRows + 1;

            char[,] matrix = new char[numRows, matrixLength];

            int number = 0;
            int col = 0;
            int row = 0;
            var BeginZigZag = 0;
            while (number < chars.Length)
            {
                if (BeginZigZag == 0)
                {
                    matrix[row, col] = chars[number];
                    if (row < numRows - 1)
                    {
                        row++;
                    }
                    else
                    {
                        row = 0;
                        col++;
                        BeginZigZag = numRows - 2;
                    }
                }
                else
                {
                    matrix[BeginZigZag, col] = chars[number];
                    BeginZigZag--;

                    col++;
                }

                number++;
            }

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    if (matrix[i, j] != '\0')
                    {
                        convertS += matrix[i, j];
                    }
                }
            }

            return convertS;
        }
    }
}
