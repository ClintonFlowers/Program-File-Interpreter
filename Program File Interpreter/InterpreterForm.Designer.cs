namespace Program_File_Interpreter
{
    partial class InterpreterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterpreterForm));
            this.preParse = new System.Windows.Forms.RichTextBox();
            this.loadTextFile = new System.Windows.Forms.Button();
            this.postParse = new System.Windows.Forms.RichTextBox();
            this.interpretButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // preParse
            // 
            this.preParse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preParse.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preParse.Location = new System.Drawing.Point(0, 0);
            this.preParse.Name = "preParse";
            this.preParse.Size = new System.Drawing.Size(760, 237);
            this.preParse.TabIndex = 0;
            this.preParse.Text = resources.GetString("preParse.Text");
            // 
            // loadTextFile
            // 
            this.loadTextFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loadTextFile.Location = new System.Drawing.Point(0, 237);
            this.loadTextFile.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.loadTextFile.Name = "loadTextFile";
            this.loadTextFile.Size = new System.Drawing.Size(760, 30);
            this.loadTextFile.TabIndex = 1;
            this.loadTextFile.Text = "Load Text File";
            this.loadTextFile.UseVisualStyleBackColor = true;
            this.loadTextFile.Click += new System.EventHandler(this.loadTextFile_Click);
            // 
            // postParse
            // 
            this.postParse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postParse.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postParse.Location = new System.Drawing.Point(0, 0);
            this.postParse.Name = "postParse";
            this.postParse.Size = new System.Drawing.Size(760, 236);
            this.postParse.TabIndex = 2;
            this.postParse.Text = "";
            // 
            // interpretButton
            // 
            this.interpretButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.interpretButton.Location = new System.Drawing.Point(0, 267);
            this.interpretButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.interpretButton.Name = "interpretButton";
            this.interpretButton.Size = new System.Drawing.Size(760, 30);
            this.interpretButton.TabIndex = 3;
            this.interpretButton.Text = "Process Text";
            this.interpretButton.UseVisualStyleBackColor = true;
            this.interpretButton.Click += new System.EventHandler(this.interpretButton_click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.preParse);
            this.splitContainer1.Panel1.Controls.Add(this.loadTextFile);
            this.splitContainer1.Panel1.Controls.Add(this.interpretButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.postParse);
            this.splitContainer1.Size = new System.Drawing.Size(760, 537);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 4;
            // 
            // InterpreterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(0, 56);
            this.Name = "InterpreterForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Operating System Interpreter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
               

        private System.Windows.Forms.RichTextBox preParse;
        private System.Windows.Forms.Button loadTextFile;
        private System.Windows.Forms.RichTextBox postParse;
        private System.Windows.Forms.Button interpretButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

