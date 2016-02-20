using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// There are n bulbs that are initially off. You first turn on all the bulbs. 
    /// Then, you turn off every second bulb. On the third round, 
    /// you toggle every third bulb (turning on if it's off or turning off if it's on). 
    /// For the nth round, you only toggle the last bulb. Find how many bulbs are on after n rounds. 
    /// </summary>
    public class Bulb_Switcher
    {
        public static void Test()
        {
            int n = 3;
            Console.Write(BulbSwitch(n));
        }

        public static int BulbSwitch(int n)
        {
            return (int)Math.Sqrt(n);

        }
    }
}
