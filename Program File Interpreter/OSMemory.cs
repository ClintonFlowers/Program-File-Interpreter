using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_File_Interpreter
{
    class OSMemory
    {
        /* Read and write to registers, RAM, and Disk*/
        /* 
        Memory Summary:
        RAM and Disk are accessed at the 'word' level, with each word being 4 bytes (or 8 hex characters or 32 bits) long
        */

        private word[] ram = new word[1024];
        private word[] disk = new word[2048];

        public OSMemory()
        {
            ram = new word[1024];
            disk = new word[2048];
            for (int i = 0; i < disk.Length; i++)
            {
                disk[i] = new word();
            }
        }

        class word
        {
            public byte[] bytes;
            public word()
            {
                this.bytes = new byte[4];
            }
            public word(byte one, byte two, byte three, byte four)
            {
                this.bytes = new byte[4];
                bytes[1] = one;
                bytes[2] = two;
                bytes[3] = three;
                bytes[4] = four;
            }

            public word(int byteCount)
            {
                this.bytes = new byte[byteCount];
            }
            public string bytesString
            {
                get { return Convert.ToString(bytes[0], 2) + Convert.ToString(bytes[1], 2) + Convert.ToString(bytes[2], 2) + Convert.ToString(bytes[3], 2); }
                set {
                    Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
                }
            }
        }


        void stuff()
        {
            pcb cake = new pcb();
            cake.state.pc = 5;
            int icing = cake.state.pc;
        }


        /// <summary>
        /// Converts a 32-character-long string containing binary to an array of bytes
        /// </summary>
        /// <param name="input">32-character-long string of binary</param>
        /// <returns>4-long array of bytes</returns>
        static byte[] stringToBytes(string input)
        {
            // http://stackoverflow.com/questions/472906/how-to-get-a-consistent-byte-representation-of-strings-in-c-sharp-without-manual
            // byte[] toReturn = new byte[input.Length * sizeof(char)];
            byte[] toReturn = new byte[4];
            Buffer.BlockCopy(input.ToCharArray(), 0, toReturn, 0, toReturn.Length);
            return toReturn;
            
        }

        /// <summary>
        /// Write the list of operations pre-loaded with the program into the disk.
        /// Should only be called once. 
        /// </summary>
        /// <param name="ops"></param>
        public void writeToDisk(List<string> ops) // WIP
        {
            for (int i = 0; i < ops.Count; i++)
            {
                string part = ops[i].Substring(0, 8);
                byte test = Convert.ToByte(part, 2);
                disk[i].bytesString = ops[i];
            }
        }
    }
}
