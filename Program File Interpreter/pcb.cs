using System;
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
        public state state;
        public int codeSize; // Second number from JOB line. # of words constituting instructions of the job. 
        public registers registers;
        public sched sched;
        public memories memories;
        public progeny progeny;
        public int parent; // pointer to parent child, null if not spawned
        public resources resources;
        public int status; // running, ready, blocked, new
        public int statusInfo; // pointer to (ready-list of active processes) OR (resource-list on blocked processes)
        public int priority; // extracted from the last value of the JOB line

    }
    class state
    {
        public int pc;
        public int[] registers;
        // permissions, buffers, caches, active pages/blocks
    }

    class registers
    {
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
