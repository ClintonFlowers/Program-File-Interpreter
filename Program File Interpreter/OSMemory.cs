﻿using System;
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

        public word[] ram = new word[1024];
        public word[] disk = new word[2048];
        public List<pcb> jobs = new List<pcb>();
        

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
        /// General class for storage of words, stored internally as a big-endian array of bytes, defaulting to 4 bytes/32 bits per word. 
        /// </summary>
        public class word
        {
            public byte[] bytes;

            /// <summary>
            /// Theoretically allows array-like access to each bit of the word (as a bool) using an Indexer
            /// </summary>
            /// <param name="i"></param>
            /// <returns></returns>
            public bool this[int i]
            {
                get
                {
                    return new BitArray(bytes)[i];
                }
                set
                {
                    BitArray tempBArray = new BitArray(bytes);
                    tempBArray[i] = value;
                }
            }
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
            /// Constructor allowing length of the word to be used, in bytes.
            /// </summary>
            /// <param name="byteCount"></param>
            public word(int byteCount)
            {
                this.bytes = new byte[byteCount];
            }

            /// <summary>
            /// Write to and read from the word's byte[] as a string (currently 32 binary characters)
            /// </summary>
            public string asString
            {
                get
                {
                    StringBuilder builder = new StringBuilder();
                    for(int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(Convert.ToString(bytes[i], 2).PadLeft(8, '0'));
                    }
                    return builder.ToString();
                }
                set
                {
                    // todo: handle exceptions such as a string that's too long?
                    for(int i = 0; i < bytes.Length; i++)
                    {
                        bytes[i] = Convert.ToByte(value.Substring(i * 8, 8), 2);
                    }
                }
            }

            /// <summary>
            /// Write to and read from the word's byte[] as a (signed?) int32
            /// </summary>
            public int asInt
            {
                get
                {
                    return BitConverter.ToInt32(bytes, 0);
                }
                set
                {
                    // todo: confirm endianness
                    bytes[0] = BitConverter.GetBytes(value)[3];
                    bytes[1] = BitConverter.GetBytes(value)[2];
                    bytes[2] = BitConverter.GetBytes(value)[1];
                    bytes[3] = BitConverter.GetBytes(value)[0];
                }
            }

            //public void insertAt()
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
                //string part = ops[i].Substring(0, 8);
                //byte test = Convert.ToByte(part, 2);
                disk[i].asInt = Convert.ToInt32(ops[i], 2); // for testing purposes
            }
        }

        /// <summary>
        /// Writes the contents of a list of words, starting at addressStart, to local OSMemory.disk or OSMemory.ram
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="package"></param>
        /// <param name="addressStart"></param>
        public void bulkWrite(List<word> package, Int32 addressStart, word[] storage)
        {
            for(int i = 0; i < package.Count; i++)
            {
                storage[i + addressStart] = package[i];
            }
        }

        /// <summary>
        /// Writes a word to an address of either OSMemory.disk or OSMemory.ram
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="inputWord"></param>
        /// <param name="address"></param>
        public void write(word inputWord, Int32 address, word[] storage)
        {
            disk[address] = inputWord;
        }
    }
}
