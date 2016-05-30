using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Container_With_Most_Water
    {
        public static void Test()
        {
            var height = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine(MaxArea(height));

        }

        public static int MaxArea(int[] height)
        {
            var res = 0;

            var l = 0;
            var r = height.Length - 1;

            while (l < r)
            {
                res = Math.Max(res, Math.Min(height[l], height[r]) * (r - l));

                if (height[l] < height[r])
                {
                    var temp = l;
                    if (temp < r && height[l] >= height[temp])
                    {
                        temp++;
                    }
                    l = temp;
                }
                else
                {
                    var temp = r;
                    if (l < temp && height[r] >= height[temp])
                    {
                        temp--;
                    }
                    r = temp;
                }
            }

            return res;
        }
    }
}
 