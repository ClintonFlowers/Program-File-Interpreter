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
        private byte[,] disk = new byte[2048, 4]; // Currently WIP


        void stuff()
        {
            pcb cake = new pcb();
            cake.state.pc = 5;
            int icing = cake.state.pc;
        }


        /// <summary>
        /// Converts a 32-character-long string containing binary to 
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
                /*
                disk[i, 0] = test;
                disk[i, 1]= Convert.ToByte(ops[i].Substring(8, 8),2);
                disk[i, 2] = Convert.ToByte(ops[i].Substring(8, 8), 2);
                disk[i, 3] = Convert.ToByte(ops[i].Substring(8, 8), 2);
                */
                byte[] currentRow = new byte[] { disk[i, 0], disk[i, 1], disk[i, 2], disk[i, 3] };
                currentRow = stringToBytes(ops[i].Substring(0, 32));
                disk[i, 0] = currentRow[0];
                disk[i, 1] = currentRow[1];
                disk[i, 2] = currentRow[2];
                disk[i, 3] = currentRow[3];

            }
            //Debug.WriteLine(Convert.ToString(disk[0, 0], 2).PadLeft(8, '0')); // for testing
        }

    }
}
