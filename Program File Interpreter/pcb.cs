using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_File_Interpreter
{
    class pcb
    {
        public int id;
        public int cpuid;
        public int programCounter;
        public state state = new state();
        public int codeSize; // Second number from JOB line. # of words constituting instructions of the job. 
        public registers registers = new registers();
        public sched sched = new sched();
        public memories memories = new memories();
        public progeny progeny = new progeny();
        public int parent; // pointer to parent child, null if not spawned
        public resources resources = new resources();
        public int status; // running, ready, blocked, new
        public int statusInfo; // pointer to (ready-list of active processes) OR (resource-list on blocked processes)
        public int priority; // extracted from the last value of the JOB line

    }
    class state
    {
        public int pc;
        public int[] registers = new int[16];
        public int inputBufferSize;
        public int outputBufferSize;
        public int tempBufferSize;
        // permissions, buffers, caches, active pages/blocks
    }

    class registers
    {
        // Create new registers
        public OSMemory.word[] regs = new OSMemory.word[16];
        // Instantiate new/default registers
        public registers()
        {
            for(int i = 0; i < regs.Length; i++)
            {
                regs[i] = new OSMemory.word(4); // 4 bytes = 32 bits
            }
            regs[0].bytes = new byte[] { 0, 0, 0, 0 }; // Accumulator
            regs[0].bytes = new byte[] { 0, 0, 0, 0 }; // Zero register
        }
        // accumulators, index, general
    }
    class sched
    {
        int priority;
        // burst-time, priority, queue-type, time-slice, remain-time
    }
    class accounts
    {
        public double cpuTime;
        // cpu-time, time-limit, time-delays, start/end times, io-times
    }
    class memories
    {
        // todo: proper memory management with pages and arrays and pointers
        public int operationsStart;
        public int operationsEnd;
        public int dataStart;
        public int dataEnd;
        // page-table-base, pages, page-size, base-registers, logical/physical map, limit-reg
    }
    class progeny
    {
        // child-processIDs, child-code-pointers
    }
    class resources
    {
        // file-pointers, io-devices, unitclass, unit #, open-file-tables
    }
}
