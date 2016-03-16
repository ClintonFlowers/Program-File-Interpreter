using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_File_Interpreter
{
    class cpu
    {
        /// <summary>
        /// Instruction set struct
        /// </summary>
        struct iSet
        {
            /// <summary>
            /// Type I/O - Reads content of I/P buffer into a accumulatorr
            /// </summary>
            public const int RD = 0x00;
            /// <summary>
            /// Type I/O - Writes the content of accumulator into O/P buffer
            /// </summary>
            public const int WR = 0x01;

            /// <summary>
            /// Type I - Stores content of a reg. into an address
            /// </summary>
            public const int ST = 0x02;
            /// <summary>
            /// Type I - Loads the content of an address into a reg.
            /// </summary>
            public const int LW = 0x03;

            /// <summary>
            /// Type R - Transfers the content of one register into another
            /// </summary>
            public const int MOV = 0x04;
            /// <summary>
            /// Type R - Adds content of two S-regs into D-reg
            /// </summary>
            public const int ADD = 0x05;
            /// <summary>
            /// Type R - Subtracts content of two S-regs into D-reg
            /// </summary>
            public const int SUB = 0x06;
            /// <summary>
            /// Type R - Multiplies content of two S-regs into D-reg
            /// </summary>
            public const int MUL = 0x07;
            /// <summary>
            /// Type R - Divides content of two S-regs into D-reg
            /// </summary>
            public const int DIV = 0x08;
            /// <summary>
            /// Type R - Logical AND of two S-regs into D-reg
            /// </summary>
            public const int AND = 0x09;
            /// <summary>
            /// Type R - Logical OR of two S-regs into D-reg
            /// </summary>
            public const int OR = 0x0A;

            /// <summary>
            /// Type I - Transfers address/data directly into a register
            /// </summary>
            public const int MOVI = 0x0B;
            /// <summary>
            /// Type I - Adds a data directly to the content of a register
            /// </summary>
            public const int ADDI = 0x0C;
            /// <summary>
            /// Type I - Multiplies a data directly to the content of a register
            /// </summary>
            public const int MULI = 0x0D;
            /// <summary>
            /// Type I - Divides a data directly to the content of a register
            /// </summary>
            public const int DIVI = 0x0E;
            /// <summary>
            /// Type I - Loads a data/address directly to the content of a register
            /// </summary>
            public const int LDI = 0x0F;

            /// <summary>
            /// Type R - Sets the D-reg to 1 if  first S-reg is less than second B-reg, and 0 otherwise
            /// </summary>
            public const int SLT = 0x10;
            /// <summary>
            ///  Type I - Sets the D-reg to 1 if  first S-reg is less than a data, and 0 otherwise
            /// </summary>
            public const int SLTI = 0x11;
            /// <summary>
            /// Type J - Logical end of program
            /// </summary>
            public const int HLT = 0x12;
            /// <summary>
            /// No Type - Does nothing and moves to next instruction
            /// </summary>
            public const int NOP = 0x13;
            /// <summary>
            /// Type J - Jumps to a specified location
            /// </summary>
            public const int JMP = 0x14;

            /// <summary>
            /// Type I - Branches to an address when content of B-reg = D-reg
            /// </summary>
            public const int BEQ = 0x15;
            /// <summary>
            /// Type I - Branches to an address when content of B-reg <> D-reg
            /// </summary>
            public const int BNE = 0x16;
            /// <summary>
            /// Type I - Branches to an address when content of B-reg = 0
            /// </summary>
            public const int BEZ = 0x17;
            /// <summary>
            /// Type I - Branches to an address when content of B-reg <> 0
            /// </summary>
            public const int BNZ = 0x18;
            /// <summary>
            /// Type I - Branches to an address when content of B-reg > 0
            /// </summary>
            public const int BGZ = 0x19;
            /// <summary>
            /// Type I - Branches to an address when content of B-reg < 0
            /// </summary>
            public const int BLZ = 0x1A;
        }

        public static void execute(pcb job)
        {
            string operation = ""; // Get operation from pcb's current/next line
            int opcode = Convert.ToInt16(operation.Substring(2, 6), 2);

            switch (opcode){
                case iSet.RD: // read
                    break;
            }
        }
    }
}