using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Program_File_Interpreter
{
    public partial class InterpeterForm : Form
    {

        public List<string> operations = new List<string>();

        public InterpeterForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadFileButton_click(object sender, EventArgs e)
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
                    removeLastLine(preParse); //removes last line
                }
            }
        }

        private void interpretButton_click(object sender, EventArgs e)
        {
            parseInitialInput();
            //translateToBinary();
        }



        public void removeLastLine(RichTextBox rtb)
        {
            rtb.Lines = rtb.Lines.Take(rtb.Lines.Count() - 1).ToArray();
        }

        private void parseInitialInput()
        {
            foreach (string line in preParse.Lines)
            {
                if (line.Length == 10 && !line.StartsWith("//"))
                {
                    postParse.AppendText(line.Substring(2) + Environment.NewLine);
                }
            }
            removeLastLine(postParse); //removes last line

            List<string> textBoxStorage = new List<string>(postParse.Lines.ToList());
            postParse.Clear();
            foreach (string line in textBoxStorage)
            {
                string currentLine = Convert.ToString(Convert.ToInt32(line, 16), 2);

                while (currentLine.Length < 32)
                {
                    currentLine = "0" + currentLine;
                }

                operations.Add(currentLine);

                for (int i = 4; i < 35; i = i + 5)
                {
                    //currentLine = currentLine.Insert(i, " ");
                }

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

                switch (currentLine.Substring(2, 6))
                {
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
                //postParse.AppendText(currentLine + " ");
                //postParse.AppendText(Environment.NewLine);
                //postParse.AppendText(currentLine + Environment.NewLine);
            }
        }

        private void arithInstruction()
        {
            throw new NotImplementedException();
        }
    }
}
