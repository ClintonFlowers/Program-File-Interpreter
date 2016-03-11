using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_File_Interpreter
{
    class Memory
    {
        public List<BitVector32> operations = new List<BitVector32>();
        public BitVector32[] disk = new BitVector32[2048];
        byte[,] byteDisk = new byte[2048, 4]; // Currently WIP


        public static string bitVectorString(BitVector32 bv)
        {
            return bv.ToString().Substring(12, 32);
        }
    }
}
