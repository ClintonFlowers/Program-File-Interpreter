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
            this.loadthebitch = new System.Windows.Forms.Button();
            this.postParse = new System.Windows.Forms.RichTextBox();
            this.fuckclinton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // preParse
            // 
            this.preParse.Dock = System.Windows.Forms.DockStyle.Top;
            this.preParse.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preParse.Location = new System.Drawing.Point(0, 0);
            this.preParse.MaximumSize = new System.Drawing.Size(887, 292);
            this.preParse.Name = "preParse";
            this.preParse.Size = new System.Drawing.Size(887, 292);
            this.preParse.TabIndex = 0;
            this.preParse.Text = resources.GetString("preParse.Text");
            // 
            // loadthebitch
            // 
            this.loadthebitch.Dock = System.Windows.Forms.DockStyle.Top;
            this.loadthebitch.Location = new System.Drawing.Point(0, 292);
            this.loadthebitch.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.loadthebitch.MaximumSize = new System.Drawing.Size(887, 30);
            this.loadthebitch.Name = "loadthebitch";
            this.loadthebitch.Size = new System.Drawing.Size(887, 30);
            this.loadthebitch.TabIndex = 1;
            this.loadthebitch.Text = "Load Text File";
            this.loadthebitch.UseVisualStyleBackColor = true;
            this.loadthebitch.Click += new System.EventHandler(this.loadthebitch_Click);
            // 
            // postParse
            // 
            this.postParse.Dock = System.Windows.Forms.DockStyle.Top;
            this.postParse.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postParse.Location = new System.Drawing.Point(0, 352);
            this.postParse.MinimumSize = new System.Drawing.Size(887, 292);
            this.postParse.Name = "postParse";
            this.postParse.Size = new System.Drawing.Size(887, 292);
            this.postParse.TabIndex = 2;
            this.postParse.Text = "";
            // 
            // fuckclinton
            // 
            this.fuckclinton.Dock = System.Windows.Forms.DockStyle.Top;
            this.fuckclinton.Location = new System.Drawing.Point(0, 322);
            this.fuckclinton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.fuckclinton.MaximumSize = new System.Drawing.Size(887, 30);
            this.fuckclinton.Name = "fuckclinton";
            this.fuckclinton.Size = new System.Drawing.Size(887, 30);
            this.fuckclinton.TabIndex = 3;
            this.fuckclinton.Text = "Process Text";
            this.fuckclinton.UseVisualStyleBackColor = true;
            this.fuckclinton.Click += new System.EventHandler(this.interpretButton_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(887, 644);
            this.Controls.Add(this.postParse);
            this.Controls.Add(this.fuckclinton);
            this.Controls.Add(this.loadthebitch);
            this.Controls.Add(this.preParse);
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "Form1";
            this.Text = "Operating System Interpreter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox preParse;
        private System.Windows.Forms.Button loadthebitch;
        private System.Windows.Forms.RichTextBox postParse;
        private System.Windows.Forms.Button fuckclinton;
    }
}

