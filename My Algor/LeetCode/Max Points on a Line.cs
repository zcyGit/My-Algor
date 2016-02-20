using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    public class Point
    {
        public int x;
        public int y;
        public Point() { x = 0; y = 0; }
        public Point(int a, int b) { x = a; y = b; }
    }

    public class Max_Points_on_a_Line
    {

        public static void Test()
        {

            Point Point1 = new Point(0, 0);
            Point Point2 = new Point(1, 1);
            Point Point3 = new Point(1, -1);

            //Point Point3 = new Point(4, 5);
            //Point Point4 = new Point(5, 6);

            Point[] point = new Point[] { Point1, Point2, Point3 };
            Console.Write(MaxPoints(point));
        }

        public static int MaxPoints(Point[] points)
        {
            if (points.Length < 3)
            {
                return points.Length;
            }

            int MaxPoints = 0;

            Dictionary<double, int> shopK = new Dictionary<double, int>();
            for (int i = 0; i < points.Length; i++)
            {
                int samePointNumber = 1;
                int sameXpointNumber = 0;
                shopK.Clear();

                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (points[i].x == points[j].x && points[i].y == points[j].y)
                    {
                        samePointNumber += 1;
                    }
                    else if (points[i].x == points[j].x)
                    {
                        sameXpointNumber += 1;
                    }
                    else
                    {
                        double k = (double)(points[i].y - points[j].y) / (points[i].x - points[j].x);
                        if (shopK.ContainsKey(k))
                        {
                            shopK[k]++;
                        }
                        else
                            shopK.Add(k, 1);
                    }
                }
                int shopKMax = 0;

                shopKMax = sameXpointNumber;

                if (shopK.Count > 0)
                {
                    foreach (var value in shopK.Values)
                    {
                        if (value > shopKMax)
                        {
                            shopKMax = value;
                        }
                    }
                    MaxPoints = Math.Max(MaxPoints, shopKMax + samePointNumber);
                }
                else
                {
                    MaxPoints = shopKMax + samePointNumber;
                }
            }

            return MaxPoints;
        }
    }
}
