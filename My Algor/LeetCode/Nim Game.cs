﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// You are playing the following Nim Game with your friend: There is a heap of stones on the table, each time one of you take turns to remove 1 to 3 stones. The one who removes the last stone will be the winner. You will take the first turn to remove the stones. 
    ///Both of you are very clever and have optimal strategies for the game. Write a function to determine whether you can win the game given the number of stones in the heap. 
    ///For example, if there are 4 stones in the heap, then you will never win the game: no matter 1, 2, or 3 stones you remove, the last stone will always be removed by your friend. 
    /// </summary>
    public class Nim_Game
    {
        public static void Test()
        {

        }

        /// <summary>
        /// 只要我留下4颗，我就能赢，也就是形成一个4的倍数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool CanWinNim(int n)
        {
            if ((n - 1) % 4 == 0)
            {
                return true;
            }
            if ((n - 2) % 4 == 0)
            {
                return true;
            }
            if ((n - 3) % 4 == 0)
            {
                return true;
            }
            return false;
        }

    }
}
