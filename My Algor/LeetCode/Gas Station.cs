using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// There are N gas stations along a circular route, where the amount of gas at station i is gas[i]. 
    /// You have a car with an unlimited gas tank and it costs cost[i] of gas to travel from station i to its next station (i+1). You begin the journey with an empty tank at one of the gas stations. 
    /// Return the starting gas station's index if you can travel around the circuit once, otherwise return -1. 

    /// </summary>
    public class Gas_Station
    {
        public static void Test()
        {
            int[] gas = new int[] { 5 };
            int[] cost = new int[] { 4 };

            Console.Write(CanCompleteCircuit(gas, cost));



        }

        /// <summary>
        /// 更优的解法 http://www.cnblogs.com/felixfang/p/3814463.html 
        /// 当前只是枚举所有可能性
        /// </summary>
        /// <param name="gas"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            if (gas.Length == 0 || cost.Length==0)
            {
                return -1;
            }

            int gasTotle = 0;
            int costTotle = 0;
            int stationBegin = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                gasTotle = gas[i];
                costTotle = cost[i];
                stationBegin = i;
                while (gasTotle >= costTotle)
                {
                    stationBegin++;
                    if (stationBegin == gas.Length)
                    {
                        stationBegin = 0;
                    }
                    if (stationBegin == i)
                    {
                        return i + 1;
                    }

                    gasTotle += gas[stationBegin];
                    costTotle += cost[stationBegin];
                }
            }
            return -1;
        }
    }
}
