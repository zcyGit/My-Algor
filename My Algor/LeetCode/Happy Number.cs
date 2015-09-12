using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
namespace My_Algor.LeetCode
{
    class Happy_Number
    {

        public static void Test()
        {

            int number = 7;
            Console.WriteLine(IsHappy(number));
        }



        public static bool IsHappy(int number)
        {
            int ends = number;

            while (ends != 1)
            {

                var numberArray = ends.ToString().ToArray();
                ends = 0;
                foreach (var num in numberArray)
                {
                    var numInt = Convert.ToInt32(num) - 48;
                    ends += numInt * numInt;
                }
                if (ends == 1)
                {
                    return true;
                }
                if (ends <= 9)
                {
                    return false;
                }

            }

            return true;
        }


    }
}
