#define DEBUG2
// Debug 1 adds job cards to the disk by batch, debug 2 doesn't add them to the disk, debug 3 adds them line-by-line

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Program_File_Interpreter
{
    public partial class InterpreterForm : Form
    {
        /*
        Todos:
        Improve UI, show each step of the input interpreting process--don't overwrite the same text box like currently. 
        Separate jobs; create struct to store process control block/PCB.
        Implement basic memory management/MMU and various classes
        */
        // https://msdn.microsoft.com/en-us/library/ayybcxe5.aspx
        // https://msdn.microsoft.com/en-us/library/z5z9kes2.aspx
        // https://msdn.microsoft.com/en-us/library/ms131069.aspx
        // https://msdn.microsoft.com/en-us/library/system.collections.specialized.bitvector32(v=vs.110).aspx

        public List<string> operations = new List<string>();
        private OSMemory memorySystem = new OSMemory();
        List<pcb> jobs = new List<pcb>();
        List<pcb> data = new List<pcb>();

        public InterpreterForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadTextFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text Files (.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.Stream fileStream = openFileDialog1.OpenFile();

                using (System.IO.StreamReader reader = new System.IO.StreamReader(fileStream))
                {
                    while (!reader.EndOfStream) { 
                        preParse.AppendText(reader.ReadLine() + Environment.NewLine);
                    }
                    removeLastLine(preParse); // Remove extra last line resulting from the final iteration of append, above.
                }
            }
        }

        private void interpretButton_click(object sender, EventArgs e)
        {
            loader();
        }

        public void removeLastLine(RichTextBox rtb)
        {
            rtb.Lines = rtb.Lines.Take(rtb.Lines.Count() - 1).ToArray();
        }

        private void loader()
        {
            List<string> lineList = new List<string>();
            int diskPosition = 0;
            int ramPosition = 0;
            List<OSMemory.word> block;
            pcb newPCB = new pcb();
            block = new List<OSMemory.word>();
            // Splits "0x" from each and appends to postParse text box
            //for(int i = 0; i < 70; i++)
            foreach (string line in preParse.Lines)
            {
                //string line = preParse.Lines[i];
                
                if (line.StartsWith("// JOB"))
                {
                    // Line is a job. Do special stuff -- add it to a Process Control Block object. 
                    string[] portions = line.Split(' ');
                    newPCB = new pcb();
                    newPCB.id = Convert.ToInt32(portions[2], 16);
                    newPCB.codeSize = Convert.ToInt32(portions[3], 16);
                    newPCB.priority = Convert.ToInt32(portions[4], 16);
                    jobs.Add(newPCB);

#if DEBUG3
                    string thisJob = "";
                    thisJob = "100111001".PadRight(15, '0')
                        + Convert.ToString(newPCB.id, 2).PadLeft(4, '0')
                        + Convert.ToString(newPCB.codeSize, 2).PadLeft(8, '0') 
                        + Convert.ToString(newPCB.priority, 2).PadLeft(4, '0');
                    thisJob.PadLeft(32, '0');
                    lineList.Add(Convert.ToString(Convert.ToInt32(thisJob, 2), 16));
#endif
                }
                else if (line.StartsWith("// Data"))
                {
                    // Line is a data declaration. Do special stuff. Probably use disk to store data. 
                    string[] dataPortions = line.Split(' ');
                    newPCB.state.inputBufferSize = Convert.ToInt32(dataPortions[2], 16);
                    newPCB.state.outputBufferSize = Convert.ToInt32(dataPortions[3], 16);
                    newPCB.state.tempBufferSize = Convert.ToInt32(dataPortions[4], 16);
                    data.Add(newPCB);

#if DEBUG3
                    string thisData = "";
                    thisData = "1100110011".PadRight(15, '0')
                        + Convert.ToString(newPCB.state.inputBufferSize, 2).PadLeft(8, '0')
                        + Convert.ToString(newPCB.state.outputBufferSize, 2).PadLeft(4, '0')
                        + Convert.ToString(newPCB.state.tempBufferSize, 2).PadLeft(4, '0');
                    thisData.PadLeft(32, '0');
                    lineList.Add(Convert.ToString(Convert.ToInt32(thisData, 2), 16));
#endif
                }
                else if (line.StartsWith("// END"))
                {
#if DEBUG1
                    OSMemory.word jobWord = new OSMemory.word();
                    string thisJob = "";
                    thisJob = "100111001".PadRight(16, '0');
                    thisJob += Convert.ToString(newPCB.id, 2).PadLeft(4, '0');
                    thisJob += Convert.ToString(newPCB.codeSize, 2).PadLeft(8, '0');
                    thisJob += Convert.ToString(newPCB.priority, 2).PadLeft(4, '0');
                    thisJob.PadLeft(32, '0');
                    jobWord.asString = thisJob;
                    memorySystem.write(jobWord, diskPosition, memorySystem.disk);
                    memorySystem.bulkWrite(block.GetRange(0, newPCB.codeSize), diskPosition + 1, memorySystem.disk);
                    diskPosition += newPCB.codeSize + 1;

                    OSMemory.word dataWord = new OSMemory.word();
                    string thisData = "";
                    thisData = "1100110011".PadRight(16, '0')
                        + Convert.ToString(newPCB.state.inputBufferSize, 2).PadLeft(8, '0')
                        + Convert.ToString(newPCB.state.outputBufferSize, 2).PadLeft(4, '0')
                        + Convert.ToString(newPCB.state.tempBufferSize, 2).PadLeft(4, '0');
                    thisData.PadLeft(32, '0');
                    dataWord.asString = thisData;
                    memorySystem.write(dataWord, diskPosition, memorySystem.disk);
                    memorySystem.bulkWrite(block.GetRange(newPCB.codeSize, block.Count - newPCB.codeSize), diskPosition + 1, memorySystem.disk);
                    diskPosition = diskPosition + 1 + newPCB.state.inputBufferSize + newPCB.state.outputBufferSize + newPCB.state.tempBufferSize;
                    block = new List<OSMemory.word>();
#endif
                }
                else if (line.Length == 10 && !line.StartsWith("//"))
                {
                    // Line contains an operation or other data. 
                    lineList.Add(line.Substring(2));
#if DEBUG1
                    OSMemory.word thisLine = new OSMemory.word();
                    thisLine.asInt = Convert.ToInt32(line.Substring(2), 16);
                    block.Add(thisLine);
#endif
                }

            }

            // Convert each line from hex to binary, parse their meaning, and write to postParse as semi-human-readable instructions
            List<string> lineList2 = new List<string>(lineList.ToArray());
            List<string> lineList3 = new List<string>();
            postParse.Clear();
            operations.Clear();
            for (int i = 0; i < lineList2.Count; i++)
            {
                int lineInt = Convert.ToInt32(lineList2[i], 16); // Line: Hex to Binary/Int
                string currentLine = Convert.ToString(lineInt, 2); // Line: Binary/Int to Binary String

                // todo: consider replacing with padLeft?
                while (currentLine.Length < 32)
                {
                    currentLine = "0" + currentLine;
                }

                operations.Add(currentLine); // Add the binary version of the line to the operations list

                // Determine the "instruction format" from first 2 bits and append meaning to surrogate string
                StringBuilder addme = new StringBuilder();
                switch (currentLine.Substring(0, 2))
                {
                    case "00": addme.Append("A/IF ");
                        break;
                    case "01": addme.Append("CBIF ");
                        break;
                    case "10": addme.Append("UNJF "); 
                        break;
                    case "11": addme.Append("I/OF ");
                        break;
                }

                // Determine the operation from opcode bits and append meaning to current line (addme)
                switch (currentLine.Substring(2, 6))
                {
                    // padRight isn't better than raw padding in this case, but it is a thing
                    case "000000": addme.Append("Read             "); break; 
                    case "000001": addme.Append("Write            "); break;
                    case "000010": addme.Append("Store            "); break;
                    case "000011": addme.Append("Load             "); break;
                    case "000100": addme.Append("Move             "); break;
                    case "000101": addme.Append("Add              "); break;
                    case "000110": addme.Append("Subtract         "); break;
                    case "000111": addme.Append("Multiply         "); break;
                    case "001000": addme.Append("Divide           "); break;
                    case "001001": addme.Append("AND              "); break;
                    case "001010": addme.Append("OR               "); break;
                    case "001011": addme.Append("Move I           "); break;
                    case "001100": addme.Append("Add I            "); break;
                    case "001101": addme.Append("Multiply I       "); break;
                    case "001110": addme.Append("Divide I         "); break;
                    case "001111": addme.Append("Load I           "); break;
                    case "010000": addme.Append("Set Less Than    "); break;
                    case "010001": addme.Append("Set Less Than I  "); break;
                    case "010010": addme.Append("Halt             "); break;
                    case "010011": addme.Append("Next Instruction "); break;
                    case "010100": addme.Append("Jump             "); break;
                    case "010101": addme.Append("BEQ              "); break;
                    case "010110": addme.Append("BNE              "); break;
                    case "010111": addme.Append("BEZ              "); break;
                    case "011000": addme.Append("BNZ              "); break;
                    case "011001": addme.Append("BGZ              "); break;
                    case "011010": addme.Append("BLZ              "); break;
                }

                // Depending on the instruction format, append the relevant bits for the operations (e.g., s- and d-reg)
                switch (currentLine.Substring(0, 2))
                {
                    case "00":
                        addme.Append(currentLine.Substring(8, 4) + " ");
                        addme.Append(currentLine.Substring(12, 4) + " ");
                        addme.Append(currentLine.Substring(16, 4) + " ");
                        addme.Append(currentLine.Substring(20, 12));
                        break;
                    case "01":
                        addme.Append(currentLine.Substring(8, 4) + " ");
                        addme.Append(currentLine.Substring(12, 4) + " ");
                        addme.Append(currentLine.Substring(16, 16));
                        break;
                    case "10":
                        addme.Append(currentLine.Substring(8, 24));
                        break;
                    case "11":
                        addme.Append(currentLine.Substring(8, 4) + " ");
                        addme.Append(currentLine.Substring(12, 4) + " ");
                        addme.Append(currentLine.Substring(16, 16));
                        break;
                }
                lineList3.Add(addme.ToString());
            }
            postParse.Lines = lineList3.ToArray();
#if (DEBUG2 || DEBUG3)
            memorySystem.writeToDisk(operations);
#endif
            List<string> binaryStringList = new List<string>();
            for(int i = 0; i < memorySystem.disk.Length; i++)
            {
                binaryStringList.Add(memorySystem.disk[i].asString);
            }
            richTextboxBinary.Lines = binaryStringList.ToArray();
        }

        private void arithInstruction()
        {
            throw new NotImplementedException();
        }
    }
}
