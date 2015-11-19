using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    class The_Skyline_Problem
    {

        public static void Test()
        {

            int[,] buildings = new int[,] { { 2, 9, 10 }, { 3, 7, 15 }, { 5, 12, 12 }, { 15, 20, 10 }, { 19, 24, 8 } };

            //int[,] buildings = new int[,] { { 2, 5, 10 }, { 3, 7, 15 }, { 10, 12, 12 } };
            //     buildings = new int[,] { { 0, 2, 3 }, { 2, 5, 3 } };//2个
            //      buildings = new int[,] { { 1, 2, 1 }, { 1, 2, 2 }, { 1, 2, 3 } };//13,20

            //  buildings = new int[,] { { 2, 4, 7 }, { 2, 4, 5 }, { 2, 4, 6 } }; //[[2,7],[4,0]]

            //buildings = new int[,] { { 3, 10, 20 }, { 3, 9, 19 }, { 3, 8, 18 }, { 3, 7, 17 }, { 3, 6, 16 }, { 3, 5, 15 }, { 3, 4, 14 } }; //[[3,20],[10,0]]


            buildings = new int[,] { { 4, 10, 10 }, { 5, 10, 9 }, { 6, 10, 8 }, { 7, 10, 7 }, { 8, 10, 6 }, { 9, 10, 5 } };// [[4,10],[10,0]]


            //  buildings = new int[,] { { 0, 5, 7 }, { 5, 10, 7 }, { 5, 10, 12 }, { 10, 15, 7 }, { 15, 20, 7 }, { 15, 20, 12 }, { 20, 25, 7 } };//[[0,7],[5,12],[10,7],[15,12],[20,7],[25,0]]


            buildings = new int[,] { { 2, 4, 70 }, { 3, 8, 30 }, { 6, 100, 41 }, { 7, 15, 70 }, { 10, 30, 102 }, { 15, 25, 76 }, { 60, 80, 91 }, { 70, 90, 72 }, { 85, 120, 59 } };//[[2,70],[4,30],[6,41],[7,70],[10,102],[30,41],[60,91],[80,72],[90,59],[120,0]]
            IList<int[]> list = GetSkyline2(buildings);

            foreach (var solveList in list)
            {
                foreach (var solve in solveList)
                {
                    Console.Write(solve);
                }
                Console.WriteLine();
            }



        }

        /// <summary>
        /// 暴力模式（记录每个点）,如果数据大了，性能就不好了
        /// </summary>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public static IList<int[]> GetSkyline(int[,] buildings)
        {
            List<int[]> list = new List<int[]>();
            var hight = new int[10000];

            for (int i = 0; i < buildings.GetLength(0); i++)
            {
                for (int j = buildings[i, 0]; j < buildings[i, 1]; j++)
                {
                    if (hight[j] < buildings[i, 2])
                        hight[j] = buildings[i, 2];
                }
            }

            for (int i = 1; i < 10000; i++)
            {
                if (hight[i] == hight[i - 1])
                {
                    continue;
                }
                list.Add(new int[] { i, hight[i] });
            }

            return list;
        }



        /// <summary>
        /// 利用扫描线算法
        /// </summary>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public static IList<int[]> GetSkyline2(int[,] buildings)
        {
            List<int[]> solutionlist = new List<int[]>();
            List<int[]> LastSolutionlist = new List<int[]>();


            if (buildings == null)
                return solutionlist;
            if (buildings.Length == 0)
            {
                return solutionlist;
            }

            List<AHT> listAHT = new List<AHT>();

            solutionlist.Add(new int[] { buildings[0, 0], buildings[0, 2] });

            AHT aht = new AHT();
            aht.left = buildings[0, 0];
            aht.right = buildings[0, 1];
            aht.hight = buildings[0, 2];
            listAHT.Add(aht);
            var maxRigth = aht.right;


            for (int i = 1; i < buildings.GetLength(0); i++)
            {
                aht = new AHT();
                aht.left = buildings[i, 0];
                aht.right = buildings[i, 1];
                aht.hight = buildings[i, 2];

                if (maxRigth < aht.right)
                {
                    maxRigth = aht.right;
                }

                ShaoMiaoEntrance(listAHT, aht, solutionlist);
            }
            solutionlist.Add(new int[] { maxRigth, 0 });

            for (int i = 0; i < solutionlist.Count; i++)
            {
                if (i != 0 && solutionlist[i][1] == solutionlist[i - 1][1])
                {
                    continue;
                }

                //if (i == solutionlist.Count - 1 && solutionlist[i][0] == solutionlist[i - 1][0])
                //{
                //    LastSolutionlist[LastSolutionlist.Count - 1][1] = 0;
                //}

                if (i != 0 && solutionlist[i][0] == LastSolutionlist[LastSolutionlist.Count - 1][0])
                {
                    if (i == solutionlist.Count - 1)
                    {
                        if (LastSolutionlist[LastSolutionlist.Count - 1][0] == solutionlist[i - 1][0])
                        {
                            LastSolutionlist[LastSolutionlist.Count - 1][1] = 0;
                            continue;
                        }

                    }
                    else if (solutionlist[i][1] > solutionlist[i - 1][1])
                    {
                        LastSolutionlist[LastSolutionlist.Count - 1][1] = solutionlist[i][1];
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                }

                LastSolutionlist.Add(solutionlist[i]);
            }

            return LastSolutionlist;
        }

        public static void ShaoMiaoEntrance(List<AHT> listAHT, AHT cur, List<int[]> solutionlist)
        {
            int hight = cur.hight;
            int left = cur.left;

            int current = 0;

            while (current < listAHT.Count)
            {
                if (listAHT[current].right >= left)
                {
                    if (listAHT[current].right > cur.right)
                    {
                        if (listAHT[current].hight > hight)
                        {
                            hight = listAHT[current].hight;
                            left = listAHT[current].right;
                        }
                    }
                    else
                    {
                        if (listAHT[current].hight > hight)
                        {
                            left = listAHT[current].right;
                        }
                    }
                }

                //产生拐点
                if (listAHT[current].right < cur.left)
                {
                    ShaoMiaoExit(listAHT, cur, solutionlist);
                }

                current++;
            }


            solutionlist.Add(new int[] { left, hight });
            listAHT.Add(cur);

        }

        public static void ShaoMiaoExit(List<AHT> listAHT, AHT cur, List<int[]> solutionlist)
        {
            int hight = 0;

            int right = 0;
            foreach (var aht in listAHT)
            {
                if (aht.right >= right)
                {
                    right = aht.right;

                    if (aht.hight > cur.hight && right > cur.left)
                    {
                        hight = aht.hight;
                    }
                }
            }

            for (int i = listAHT.Count - 1; i >= 0; i--)
            {
                if (listAHT[i].right < cur.left)
                {
                    listAHT.Remove(listAHT[i]);
                }
            }

            solutionlist.Add(new int[] { right, hight });

        }

        public struct AHT
        {
            public int left;
            public int right;
            public int hight;

        }

    }
}
