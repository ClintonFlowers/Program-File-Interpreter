using System;
using System.Collections;
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

        /// <summary>
        /// General class for storage of words, stored internally as an array of bytes, defaulting to 4 bytes/32 bits per word. 
        /// </summary>
        public class word
        {
            public byte[] bytes;
            /// <summary>
            /// Default constructor of 4 bytes/32 bits. 
            /// </summary>
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

            /// <summary>
            /// Length of the word to be used, in bytes.
            /// </summary>
            /// <param name="byteCount"></param>
            public word(int byteCount)
            {
                this.bytes = new byte[byteCount];
            }
            public string bytesString
            {
                get
                {
                    StringBuilder builder = new StringBuilder();
                    for(int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(Convert.ToString(bytes[i], 2).PadLeft(8,'0'));
                    }
                    return builder.ToString();
                }
                set
                {
                    // todo: handle exceptions such as a string that's too long
                    Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
                }
            }

            public BitArray wordBitArray
            {
                get
                {
                    return new BitArray(bytes);
                }
                set
                {
                    value.CopyTo(bytes, 0);
                }
            }
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
