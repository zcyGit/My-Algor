using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My_Algor.Hash
{
    /// <summary>
    /// 魔兽文件打包器里的传奇哈希表
    /// 暴雪的程序员如何实现哈希表 
    /// 参考网站
    /// http://kb.cnblogs.com/page/189480/
    /// http://www.nowamagic.net/academy/detail/3008091
    /// </summary>
    public class Hash
    {
        private const long MaxHashTableLegth = 1024;
        //建立一个大小为1024的哈希索引表
        private uint[] cryptTable = new uint[MaxHashTableLegth];
        private ulong nTableLength = MaxHashTableLegth;
        private HASHTABLE[] m_HashIndexTable;

        public struct HASHTABLE
        {

            public long nHashA;
            public long nHashB;
            public bool bExists;
        }

        public Hash()
        {
            m_HashIndexTable = new HASHTABLE[nTableLength];

            for (ulong i = 0; i < nTableLength; i++)
            {
                m_HashIndexTable[i].nHashA = -1;
                m_HashIndexTable[i].nHashB = -1;
                m_HashIndexTable[i].bExists = false;

            }

        }

        public unsafe void Test()
        {
            string fileName = "zcy";
            ulong hashcode = 0;

            fixed (char* p = fileName)
            {
                hashcode = HashString2(p);
            }
            prepareCryptTable();


            Console.WriteLine(hashcode);

        }



        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        unsafe long ContainsKey(string str)
        {
            const int HASH_OFFSET = 0, HASH_A = 1, HASH_B = 2;

            fixed (char* p = str)
            {
                //1. 计算出字符串的三个哈希值（一个用来确定位置，另外两个用来校验)  
                ulong nHash = HashString(p, HASH_OFFSET);
                ulong nHashA = HashString(p, HASH_A);
                ulong nHashB = HashString(p, HASH_B);

                ulong nHashStart = nHash % nTableLength;
                ulong nHashPos = nHashStart;

                while (m_HashIndexTable[nHashPos].bExists)
                {
                    if (m_HashIndexTable[nHashPos].nHashA == (long)nHashA && m_HashIndexTable[nHashPos].nHashB == (long)nHashB)
                    {
                        return (long)nHashPos;
                    }
                    nHashPos = (nHashPos + 1) % nTableLength;
                    if (nHashPos == nHashStart)
                    {
                        return -1;
                    }
                }

            }
            return -1;
        }

        /// <summary>
        /// 插入hash表
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        unsafe bool HashTable(string str)
        {
            const int HASH_OFFSET = 0, HASH_A = 1, HASH_B = 2;

            fixed (char* p = str)
            {
                //1. 计算出字符串的三个哈希值（一个用来确定位置，另外两个用来校验)  
                ulong nHash = HashString(p, HASH_OFFSET);
                ulong nHashA = HashString(p, HASH_A);
                ulong nHashB = HashString(p, HASH_B);

                ulong nHashStart = nHash % nTableLength;
                ulong nHashPos = nHashStart;

                while (m_HashIndexTable[nHashPos].bExists)
                {
                    nHashPos = (nHashPos + 1) % nTableLength;
                    if (nHashPos == nHashStart)
                    {
                        return false;
                    }
                }

                m_HashIndexTable[nHashPos].nHashA = (long)nHashA;
                m_HashIndexTable[nHashPos].nHashB = (long)nHashB;
                m_HashIndexTable[nHashPos].bExists = true;

            }
            return true;
        }



        /// <summary>
        /// 乎所有的流行的hash map都采用了DJB hash function，俗称“Times33”算法。Perl、Berkeley DB 、Apache、MFC、STL 等等。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        unsafe ulong HashStringTime33(char* str)
        {
            ulong nHash = 0;
            while (*str != 0x00)
                nHash = (nHash << 5) + nHash + *str++;
            return nHash;
        }



        //以下的函数生成一个长度为0x500（合10进制数：1024）的预处理cryptTable[0x500]  
        public void prepareCryptTable()
        {
            uint seed = 0x00100001, index1 = 0, index2 = 0, i;
            for (index1 = 0; index1 < 256; index1++)
            {
                for (index2 = index1, i = 0; i < 4; i++, index2 += 256)
                {
                    uint temp1, temp2;
                    seed = (seed * 125 + 3) % 0x2AAAAB;
                    temp1 = (seed & 0xFFFF) << 0x10;
                    seed = (seed * 125 + 3) % 0x2AAAAB;
                    temp2 = (seed & 0xFFFF);
                    cryptTable[index2] = (temp1 | temp2);
                }
            }
        }

        ///MPQ格式，使用了一种非常复杂的散列算法（如下所示），产生完全不可预测的哈希值，
        ///这个算法十分有效，这就是所谓的单向散列算法。通过单向散列算法几乎不可能通过哈希值来唯一的确定输入值。
        ///使用这种算法，文件名 "arr\units.dat" 的哈希值是0xF4E6C69D，"unit\neutral\acritter.grp" 的哈希值是 0xA26067F3。MPQ格式
        ///
        //以下函数计算lpszFileName 字符串的hash值，其中dwHashType 为hash的类型，  
        //在下面GetHashTablePos函数里面调用本函数，其可以取的值为0、1、2；该函数  
        //返回lpszFileName 字符串的hash值；  
        unsafe ulong HashString(char* str, int dwHashType)
        {
            ///一个字符串在内存中是这样 zcy0/ 然后 char* str指向第一个字符地址 z 
            ulong seed1 = 0x7FED7FED;
            ulong seed2 = 0xEEEEEEEE;
            uint ch;
            while (*str != 0x00)//一直到末尾
            {
                ch = (uint)*str++;//加的时候指向 c
                seed1 = cryptTable[(dwHashType << 8) + ch] ^ (seed1 + seed2);
                seed2 = ch + seed1 + seed2 + (seed2 << 5) + 3;
            }

            return seed1;
        }


        /// <summary>
        /// 代码中的函数演示了一种非常简单的散列算法。这个函数在遍历字符串过程中，将哈希值左移一位，然后加上字符值；
        /// 通过这个算法，字符串"arr\units.dat" 的哈希值是0x5A858026，字符串"unit\neutral\acritter.grp" 的哈希值是0x694CD020；
        /// 现在，众所周知的，这是一个基本没有什么实用价值的简单算法，因为它会在较低的数据范围内产生相对可预测的输出，
        /// 从而可能会产生大量冲突（不同的字符串产生相同的哈希值）。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dwHashType"></param>
        /// <returns></returns>
        unsafe ulong HashString2(char* str)
        {
            ulong ulHash = 0xf1e2d3c4;
            while (*str != 0x00)
            {
                ulHash <<= 1;
                ulHash += *str++;
            }

            return ulHash;
        }

        #region .net 自己的实现方式
        //        public override int GetHashCode()
        //        {

        //#if FEATURE_RANDOMIZED_STRING_HASHING
        //            if(HashHelpers.s_UseRandomizedStringHashing)
        //            {
        //                return InternalMarvin32HashString(this, this.Length, 0);
        //            }
        //#endif // FEATURE_RANDOMIZED_STRING_HASHING

        //            unsafe
        //            {
        //                fixed (char* src = this)
        //                {
        //                    Contract.Assert(src[this.Length] == '\0', "src[this.Length] == '\\0'");
        //                    Contract.Assert(((int)src) % 4 == 0, "Managed string should start at 4 bytes boundary");

        //#if WIN32
        //                    int hash1 = (5381<<16) + 5381;
        //#else
        //                    int hash1 = 5381;
        //#endif
        //                    int hash2 = hash1;

        //#if WIN32
        //                    // 32 bit machines.
        //                    int* pint = (int *)src;
        //                    int len = this.Length;
        //                    while (len > 2)
        //                    {
        //                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ pint[0];
        //                        hash2 = ((hash2 << 5) + hash2 + (hash2 >> 27)) ^ pint[1];
        //                        pint += 2;
        //                        len  -= 4;
        //                    }

        //                    if (len > 0)
        //                    {
        //                        hash1 = ((hash1 << 5) + hash1 + (hash1 >> 27)) ^ pint[0];
        //                    }
        //#else
        //                    int c;
        //                    char* s = src;
        //                    while ((c = s[0]) != 0)
        //                    {
        //                        hash1 = ((hash1 << 5) + hash1) ^ c;
        //                        c = s[1];
        //                        if (c == 0)
        //                            break;
        //                        hash2 = ((hash2 << 5) + hash2) ^ c;
        //                        s += 2;
        //                    }
        //#endif
        //#if DEBUG
        //                    // We want to ensure we can change our hash function daily.
        //                    // This is perfectly fine as long as you don't persist the
        //                    // value from GetHashCode to disk or count on String A 
        //                    // hashing before string B.  Those are bugs in your code.
        //                    hash1 ^= ThisAssembly.DailyBuildNumber;
        //#endif
        //                    return hash1 + (hash2 * 1566083941);
        //                }
        //            }
        //        }
        #endregion


    }



}
