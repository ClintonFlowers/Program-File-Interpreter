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
            parseInitialInput();
        }

        public void removeLastLine(RichTextBox rtb)
        {
            rtb.Lines = rtb.Lines.Take(rtb.Lines.Count() - 1).ToArray();
        }

        private void parseInitialInput()
        {
            // Splits "0x" from each and appends to postParse text box
            postParse.Clear();
            foreach (string line in preParse.Lines)
            {
                if (line.Length == 10 && !line.StartsWith("//"))
                {
                    // Line contains an operation or other data. 
                    postParse.AppendText(line.Substring(2) + Environment.NewLine);
                }
                else if (line.StartsWith("// JOB"))
                {
                    // Line is a job. Do special stuff. Probably use a struct to store program/routine/job data. 
                    string[] portions = line.Split(' ');
                    pcb newPCB = new pcb();
                    newPCB.id = Convert.ToInt32(portions[2], 16);
                    newPCB.codeSize = Convert.ToInt32(portions[3], 16);
                    newPCB.priority = Convert.ToInt32(portions[4], 16);
                    Debug.Print(Convert.ToString(newPCB.id,16) + " " + Convert.ToString(newPCB.codeSize,16) + " " + Convert.ToString(newPCB.priority, 16));
                }
                else if (line.StartsWith("// Data"))
                {
                    // Line is a data declaration. Do special stuff. Probably use a struct to store program/routine/job data. 

                }
            }
            removeLastLine(postParse); // Remove extra last line resulting from the final iteration of append, above.

            // Convert each line from hex to binary, parse their meaning, and write to postParse as semi-human-readable instructions
            List<string> textBoxStorage = new List<string>(postParse.Lines.ToList());
            postParse.Clear();
            foreach (string line in textBoxStorage)
            {
                string currentLine = Convert.ToString(Convert.ToInt32(line, 16), 2); // Line: Hex to Binary

                // todo: consider replacing with padLeft?
                while (currentLine.Length < 32)
                {
                    currentLine = "0" + currentLine;
                }

                operations.Add(currentLine); // Add the binary version of the line to the operations list

                // Determine the "instruction format" from first 2 bits and append meaning to surrogate string
                string addme = "";
                switch (currentLine.Substring(0, 2))
                {
                    case "00": postParse.AppendText("A/IF ");
                        addme = currentLine.Substring(8,4) + " ";
                        addme += currentLine.Substring(12, 4) + " ";
                        addme += currentLine.Substring(16, 4) + " ";
                        addme += currentLine.Substring(20, 12) + " ";
                        break;
                    case "01": postParse.AppendText("CBIF ");
                        addme = currentLine.Substring(8, 4) + " ";
                        addme += currentLine.Substring(12, 4) + " ";
                        addme += currentLine.Substring(16, 16) + " ";
                        break;
                    case "10": postParse.AppendText("UNJF "); 
                        addme = currentLine.Substring(8, 24) + " ";
                        break;
                    case "11": postParse.AppendText("I/OF ");
                        addme = currentLine.Substring(8, 4) + " ";
                        addme += currentLine.Substring(12, 4) + " ";
                        addme += currentLine.Substring(16, 16) + " ";
                        break;
                }

                // Determine the operation from opcode bits and append meaning to currentLine
                switch (currentLine.Substring(2, 6))
                {
                    // padRight isn't better than raw padding in this case, but it is a thing
                    case "000000": postParse.AppendText("Read             "); break; 
                    case "000001": postParse.AppendText("Write            "); break;
                    case "000010": postParse.AppendText("Store            "); break;
                    case "000011": postParse.AppendText("Load             "); break;
                    case "000100": postParse.AppendText("Move             "); break;
                    case "000101": postParse.AppendText("Add              "); break;
                    case "000110": postParse.AppendText("Subtract         "); break;
                    case "000111": postParse.AppendText("Multiply         "); break;
                    case "001000": postParse.AppendText("Divide           "); break;
                    case "001001": postParse.AppendText("AND              "); break;
                    case "001010": postParse.AppendText("OR               "); break;
                    case "001011": postParse.AppendText("Move I           "); break;
                    case "001100": postParse.AppendText("Add I            "); break;
                    case "001101": postParse.AppendText("Multiply I       "); break;
                    case "001110": postParse.AppendText("Divide I         "); break;
                    case "001111": postParse.AppendText("Load I           "); break;
                    case "010000": postParse.AppendText("Set Less Than    "); break;
                    case "010001": postParse.AppendText("Set Less Than I  "); break;
                    case "010010": postParse.AppendText("Halt             "); break;
                    case "010011": postParse.AppendText("Next Instruction "); break;
                    case "010100": postParse.AppendText("Jump             "); break;
                    case "010101": postParse.AppendText("BEQ              "); break;
                    case "010110": postParse.AppendText("BNE              "); break;
                    case "010111": postParse.AppendText("BEZ              "); break;
                    case "011000": postParse.AppendText("BNZ              "); break;
                    case "011001": postParse.AppendText("BGZ              "); break;
                    case "011010": postParse.AppendText("BLZ              "); break;

                }
                postParse.AppendText(addme + Environment.NewLine);
            }
            memorySystem.writeToDisk(operations);
        }

        private void arithInstruction()
        {
            throw new NotImplementedException();
        }
    }
}
