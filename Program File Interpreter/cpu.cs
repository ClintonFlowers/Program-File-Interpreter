using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_File_Interpreter
{
    class cpu
    {
        public static void execute(pcb job)
        {
            string operation = ""; // Get operation from pcb's current/next line
            int opcode = Convert.ToInt16(operation.Substring(2, 6), 2);

            switch (opcode){
                case 0x0: // read
                    break;
            }
        }
    }
}