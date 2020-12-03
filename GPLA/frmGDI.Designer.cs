namespace GPLA
{
    partial class frmGDI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_ActionCmd = new System.Windows.Forms.TextBox();
            this.btn_run = new System.Windows.Forms.Button();
            this.rtxt_code = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel_output = new System.Windows.Forms.Panel();
            this.pbOutput = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.sAVEToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lOADToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel_output.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel3);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.panel_output);
            this.panel1.Controls.Add(this.txt_ActionCmd);
            this.panel1.Controls.Add(this.btn_run);
            this.panel1.Controls.Add(this.rtxt_code);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1554, 842);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txt_ActionCmd
            // 
            this.txt_ActionCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ActionCmd.Location = new System.Drawing.Point(150, 604);
            this.txt_ActionCmd.Margin = new System.Windows.Forms.Padding(6);
            this.txt_ActionCmd.Name = "txt_ActionCmd";
            this.txt_ActionCmd.Size = new System.Drawing.Size(509, 56);
            this.txt_ActionCmd.TabIndex = 14;
            this.txt_ActionCmd.TextChanged += new System.EventHandler(this.txt_ActionCmd_TextChanged);
            // 
            // btn_run
            // 
            this.btn_run.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_run.Location = new System.Drawing.Point(286, 720);
            this.btn_run.Margin = new System.Windows.Forms.Padding(6);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(230, 54);
            this.btn_run.TabIndex = 10;
            this.btn_run.Text = "EXECUTE";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.Btn_run_Click);
            // 
            // rtxt_code
            // 
            this.rtxt_code.Location = new System.Drawing.Point(150, 134);
            this.rtxt_code.Margin = new System.Windows.Forms.Padding(6);
            this.rtxt_code.Name = "rtxt_code";
            this.rtxt_code.Size = new System.Drawing.Size(509, 349);
            this.rtxt_code.TabIndex = 1;
            this.rtxt_code.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sAVEToolStripMenuItem1,
            this.lOADToolStripMenuItem1,
            this.hELPToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1554, 42);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel_output
            // 
            this.panel_output.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_output.Controls.Add(this.pbOutput);
            this.panel_output.Location = new System.Drawing.Point(810, 128);
            this.panel_output.Margin = new System.Windows.Forms.Padding(4);
            this.panel_output.Name = "panel_output";
            this.panel_output.Size = new System.Drawing.Size(568, 646);
            this.panel_output.TabIndex = 7;
            this.panel_output.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_output_Paint);
            // 
            // pbOutput
            // 
            this.pbOutput.ErrorImage = null;
            this.pbOutput.Location = new System.Drawing.Point(6, 6);
            this.pbOutput.Margin = new System.Windows.Forms.Padding(6);
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(10, 10);
            this.pbOutput.TabIndex = 7;
            this.pbOutput.TabStop = false;
            this.pbOutput.Click += new System.EventHandler(this.pbOutput_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(805, 76);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(150, 42);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Output :";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(143, 561);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(184, 37);
            this.linkLabel2.TabIndex = 17;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Command :";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.LinkColor = System.Drawing.Color.Black;
            this.linkLabel3.Location = new System.Drawing.Point(143, 91);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(164, 37);
            this.linkLabel3.TabIndex = 18;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "TextArea :";
            // 
            // sAVEToolStripMenuItem1
            // 
            this.sAVEToolStripMenuItem1.Name = "sAVEToolStripMenuItem1";
            this.sAVEToolStripMenuItem1.Size = new System.Drawing.Size(88, 38);
            this.sAVEToolStripMenuItem1.Text = "SAVE";
            this.sAVEToolStripMenuItem1.Click += new System.EventHandler(this.sAVEToolStripMenuItem1_Click);
            // 
            // lOADToolStripMenuItem1
            // 
            this.lOADToolStripMenuItem1.Name = "lOADToolStripMenuItem1";
            this.lOADToolStripMenuItem1.Size = new System.Drawing.Size(94, 38);
            this.lOADToolStripMenuItem1.Text = "LOAD";
            this.lOADToolStripMenuItem1.Click += new System.EventHandler(this.lOADToolStripMenuItem1_Click);
            // 
            // hELPToolStripMenuItem1
            // 
            this.hELPToolStripMenuItem1.Name = "hELPToolStripMenuItem1";
            this.hELPToolStripMenuItem1.Size = new System.Drawing.Size(88, 38);
            this.hELPToolStripMenuItem1.Text = "HELP";
            this.hELPToolStripMenuItem1.Click += new System.EventHandler(this.hELPToolStripMenuItem1_Click);
            // 
            // frmGDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1554, 842);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGDI";
            this.Text = "Graphical Programming Language Application";
            this.Load += new System.EventHandler(this.FrmGPLA_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_output.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.RichTextBox rtxt_code;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txt_ActionCmd;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel_output;
        private System.Windows.Forms.PictureBox pbOutput;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStripMenuItem sAVEToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lOADToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem1;
    }
}

