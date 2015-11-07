using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.LeetCode
{
    /// <summary>
    /// All DNA is composed of a series of nucleotides abbreviated as A, C, G, and T, for example: "ACGAATTCCG". When studying DNA, it is sometimes useful to identify repeated sequences within the DNA.

    ///Write a function to find all the 10-letter-long sequences (substrings) that occur more than once in a DNA molecule.
    ///For example,
    ///Given s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT"
    ///Return:
    ///["AAAAACCCCC", "CCCCCAAAAA"].

    /// </summary>
    public class Repeated_DNA_Sequences
    {
        public static void Test()
        {
            string s = "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT";
            //s = "AAAAAAAAAAAA";

            var list = FindRepeatedDnaSequences(s);

            foreach (var s1 in list)
            {
                Console.WriteLine(s1);
            }
        }

        public static int length = 10;
        public static IList<string> FindRepeatedDnaSequences(string s)
        {
            List<string> list = new List<string>();

            Dictionary<string, int> dicList = new Dictionary<string, int>();

            if (s.Length <= length)
            {
                return list;
            }
            dicList.Add(s.Substring(0, length), 1);
            for (int i = 1; i <= s.Length - length; i++)
            {
                var tempS = s.Substring(i, length);
                if (dicList.ContainsKey(tempS))
                {
                    dicList[tempS] += 1;
                }
                else
                {
                    dicList.Add(tempS, 1);
                }
            }

            foreach (var dic in dicList)
            {
                if (dic.Value > 1)
                {
                    list.Add(dic.Key);
                }
            }

            return list;
        }
    }
}
