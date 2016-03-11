using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_File_Interpreter
{
    class cpu
    {
        public static void execute(string operation)
        {
            string opcodestr = operation.Substring(2, 6);
            int opcode = Convert.ToInt16(opcodestr,2);
            switch (opcode){
                case 0x0: // read
                    break;
            }
        }
    }
}