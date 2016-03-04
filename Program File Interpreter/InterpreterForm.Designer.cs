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
            this.SuspendLayout();
            // 
            // preParse
            // 
            this.preParse.Dock = System.Windows.Forms.DockStyle.Top;
            this.preParse.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preParse.Location = new System.Drawing.Point(0, 0);
            this.preParse.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.preParse.MaximumSize = new System.Drawing.Size(1770, 558);
            this.preParse.Name = "preParse";
            this.preParse.Size = new System.Drawing.Size(1754, 558);
            this.preParse.TabIndex = 0;
            this.preParse.Text = resources.GetString("preParse.Text");
            // 
            // loadTextFile
            // 
            this.loadTextFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadTextFile.Location = new System.Drawing.Point(0, 558);
            this.loadTextFile.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.loadTextFile.MaximumSize = new System.Drawing.Size(1774, 58);
            this.loadTextFile.Name = "loadTextFile";
            this.loadTextFile.Size = new System.Drawing.Size(1754, 58);
            this.loadTextFile.TabIndex = 1;
            this.loadTextFile.Text = "Load Text File";
            this.loadTextFile.UseVisualStyleBackColor = true;
            this.loadTextFile.Click += new System.EventHandler(this.loadTextFile_Click);
            // 
            // postParse
            // 
            this.postParse.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postParse.Location = new System.Drawing.Point(0, 677);
            this.postParse.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.postParse.MinimumSize = new System.Drawing.Size(1770, 558);
            this.postParse.Name = "postParse";
            this.postParse.Size = new System.Drawing.Size(1770, 558);
            this.postParse.TabIndex = 2;
            this.postParse.Text = "";
            // 
            // interpretButton
            // 
            this.interpretButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.interpretButton.Location = new System.Drawing.Point(0, 616);
            this.interpretButton.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.interpretButton.MaximumSize = new System.Drawing.Size(1774, 58);
            this.interpretButton.Name = "interpretButton";
            this.interpretButton.Size = new System.Drawing.Size(1754, 58);
            this.interpretButton.TabIndex = 3;
            this.interpretButton.Text = "Process Text";
            this.interpretButton.UseVisualStyleBackColor = true;
            this.interpretButton.Click += new System.EventHandler(this.interpretButton_click);
            // 
            // InterpreterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1754, 1177);
            this.Controls.Add(this.postParse);
            this.Controls.Add(this.interpretButton);
            this.Controls.Add(this.loadTextFile);
            this.Controls.Add(this.preParse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1780, 1248);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(74, 71);
            this.Name = "InterpreterForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Operating System Interpreter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
               

        private System.Windows.Forms.RichTextBox preParse;
        private System.Windows.Forms.Button loadTextFile;
        private System.Windows.Forms.RichTextBox postParse;
        private System.Windows.Forms.Button interpretButton;


        
    }
}

