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

        private byte[,] ram = new byte[1024, 4];
        //private byte[,] disk = new byte[2048, 4]; // Currently WIP
        private word[] disk = new word[2048];

        public OSMemory()
        {
            ram = new byte[1024, 4];
            disk = new word[2048];
            for(int i = 0; i < disk.Length; i++)
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
            
            //public byte byte1
            //{
            //    get { return bytes[0]; }
            //    set { bytes[0] = value; }
            //}
            //public byte byte2
            //{
            //    get { return bytes[1]; }
            //    set { bytes[1] = value; }
            //}
            //public byte byte3
            //{
            //    get { return bytes[2]; }
            //    set { bytes[2] = value; }
            //}
            //public byte byte4
            //{
            //    get { return bytes[3]; }
            //    set { bytes[3] = value; }
            //}
            public string bytesString
            {
                get { return Convert.ToString(bytes[0], 2) + Convert.ToString(bytes[1], 2) + Convert.ToString(bytes[2], 2) + Convert.ToString(bytes[3], 2); }
                set {
                    Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
                    //bytes[0] = Convert.ToByte(value.Substring(0, 8), 2);
                    //bytes[1] = Convert.ToByte(value.Substring(8, 8), 2);
                    //bytes[2] = Convert.ToByte(value.Substring(16, 8), 2);
                    //bytes[3] = Convert.ToByte(value.Substring(24, 8), 2);
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
                //Console.Write(disk[i].bytesString + Environment.NewLine);
                /*
                disk[i, 0] = test;
                disk[i, 1]= Convert.ToByte(ops[i].Substring(8, 8),2);
                disk[i, 2] = Convert.ToByte(ops[i].Substring(8, 8), 2);
                disk[i, 3] = Convert.ToByte(ops[i].Substring(8, 8), 2);
                */
                //byte[] currentRow = new byte[] { disk[i, 0], disk[i, 1], disk[i, 2], disk[i, 3] };
                //currentRow = stringToBytes(ops[i].Substring(0, 32));
                //disk[i, 0] = currentRow[0];
                //disk[i, 1] = currentRow[1];
                //disk[i, 2] = currentRow[2];
                //disk[i, 3] = currentRow[3];
            }
        }
    }
}
