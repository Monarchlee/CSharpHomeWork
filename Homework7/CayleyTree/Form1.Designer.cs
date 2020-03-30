namespace CayleyTree
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.lblDepth = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtLeng = new System.Windows.Forms.TextBox();
            this.lblLeng = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtRightLeng = new System.Windows.Forms.TextBox();
            this.lblRightLength = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtLeftLeng = new System.Windows.Forms.TextBox();
            this.lblLeftLength = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.trbRightAngle = new System.Windows.Forms.TrackBar();
            this.lblRightAngle = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trbLeftAngle = new System.Windows.Forms.TrackBar();
            this.lblLeftAngle = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cmbPenColor = new System.Windows.Forms.ComboBox();
            this.lblPenColor = new System.Windows.Forms.Label();
            this.txtRangeDepth = new System.Windows.Forms.Label();
            this.txtRangeLeng = new System.Windows.Forms.Label();
            this.txtRightLengRange = new System.Windows.Forms.Label();
            this.txtLeftLengRange = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbRightAngle)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLeftAngle)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.AutoScroll = true;
            this.pnlCanvas.Location = new System.Drawing.Point(3, 12);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(479, 426);
            this.pnlCanvas.TabIndex = 0;
            this.pnlCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCanvas_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDepth);
            this.panel2.Controls.Add(this.lblDepth);
            this.panel2.Location = new System.Drawing.Point(586, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(153, 32);
            this.panel2.TabIndex = 1;
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(93, 4);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(57, 25);
            this.txtDepth.TabIndex = 0;
            this.txtDepth.TextChanged += new System.EventHandler(this.txtDepth_Changed);
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblDepth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDepth.Location = new System.Drawing.Point(35, 7);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(47, 15);
            this.lblDepth.TabIndex = 1;
            this.lblDepth.Text = "Depth";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtLeng);
            this.panel3.Controls.Add(this.lblLeng);
            this.panel3.Location = new System.Drawing.Point(586, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(153, 32);
            this.panel3.TabIndex = 2;
            // 
            // txtLeng
            // 
            this.txtLeng.Location = new System.Drawing.Point(93, 4);
            this.txtLeng.Name = "txtLeng";
            this.txtLeng.Size = new System.Drawing.Size(57, 25);
            this.txtLeng.TabIndex = 0;
            this.txtLeng.TextChanged += new System.EventHandler(this.txtLeng_Changed);
            // 
            // lblLeng
            // 
            this.lblLeng.AutoSize = true;
            this.lblLeng.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblLeng.Location = new System.Drawing.Point(43, 7);
            this.lblLeng.Name = "lblLeng";
            this.lblLeng.Size = new System.Drawing.Size(39, 15);
            this.lblLeng.TabIndex = 1;
            this.lblLeng.Text = "Leng";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtRightLeng);
            this.panel4.Controls.Add(this.lblRightLength);
            this.panel4.Location = new System.Drawing.Point(533, 85);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(206, 32);
            this.panel4.TabIndex = 2;
            // 
            // txtRightLeng
            // 
            this.txtRightLeng.Location = new System.Drawing.Point(146, 3);
            this.txtRightLeng.Name = "txtRightLeng";
            this.txtRightLeng.Size = new System.Drawing.Size(57, 25);
            this.txtRightLeng.TabIndex = 0;
            this.txtRightLeng.TextChanged += new System.EventHandler(this.txtRightLeng_Changed);
            // 
            // lblRightLength
            // 
            this.lblRightLength.AutoSize = true;
            this.lblRightLength.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblRightLength.Location = new System.Drawing.Point(32, 6);
            this.lblRightLength.Name = "lblRightLength";
            this.lblRightLength.Size = new System.Drawing.Size(103, 15);
            this.lblRightLength.TabIndex = 1;
            this.lblRightLength.Text = "Right Length";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtLeftLeng);
            this.panel5.Controls.Add(this.lblLeftLength);
            this.panel5.Location = new System.Drawing.Point(533, 123);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(206, 32);
            this.panel5.TabIndex = 2;
            // 
            // txtLeftLeng
            // 
            this.txtLeftLeng.Location = new System.Drawing.Point(146, 3);
            this.txtLeftLeng.Name = "txtLeftLeng";
            this.txtLeftLeng.Size = new System.Drawing.Size(57, 25);
            this.txtLeftLeng.TabIndex = 0;
            this.txtLeftLeng.TextChanged += new System.EventHandler(this.txtLeftLeng_Changed);
            // 
            // lblLeftLength
            // 
            this.lblLeftLength.AutoSize = true;
            this.lblLeftLength.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblLeftLength.Location = new System.Drawing.Point(40, 7);
            this.lblLeftLength.Name = "lblLeftLength";
            this.lblLeftLength.Size = new System.Drawing.Size(95, 15);
            this.lblLeftLength.TabIndex = 1;
            this.lblLeftLength.Text = "Left Length";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.trbRightAngle);
            this.panel6.Controls.Add(this.lblRightAngle);
            this.panel6.Location = new System.Drawing.Point(508, 195);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(231, 60);
            this.panel6.TabIndex = 2;
            // 
            // trbRightAngle
            // 
            this.trbRightAngle.Location = new System.Drawing.Point(132, 3);
            this.trbRightAngle.Maximum = 120;
            this.trbRightAngle.Name = "trbRightAngle";
            this.trbRightAngle.Size = new System.Drawing.Size(96, 56);
            this.trbRightAngle.TabIndex = 2;
            // 
            // lblRightAngle
            // 
            this.lblRightAngle.AutoSize = true;
            this.lblRightAngle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblRightAngle.Location = new System.Drawing.Point(31, 21);
            this.lblRightAngle.Name = "lblRightAngle";
            this.lblRightAngle.Size = new System.Drawing.Size(95, 15);
            this.lblRightAngle.TabIndex = 1;
            this.lblRightAngle.Text = "Right Angle";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnStart.Location = new System.Drawing.Point(593, 341);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.trbLeftAngle);
            this.panel1.Controls.Add(this.lblLeftAngle);
            this.panel1.Location = new System.Drawing.Point(508, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 60);
            this.panel1.TabIndex = 3;
            // 
            // trbLeftAngle
            // 
            this.trbLeftAngle.Location = new System.Drawing.Point(132, 3);
            this.trbLeftAngle.Maximum = 120;
            this.trbLeftAngle.Name = "trbLeftAngle";
            this.trbLeftAngle.Size = new System.Drawing.Size(96, 56);
            this.trbLeftAngle.TabIndex = 3;
            // 
            // lblLeftAngle
            // 
            this.lblLeftAngle.AutoSize = true;
            this.lblLeftAngle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblLeftAngle.Location = new System.Drawing.Point(39, 20);
            this.lblLeftAngle.Name = "lblLeftAngle";
            this.lblLeftAngle.Size = new System.Drawing.Size(87, 15);
            this.lblLeftAngle.TabIndex = 1;
            this.lblLeftAngle.Text = "Left Angle";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.cmbPenColor);
            this.panel7.Controls.Add(this.lblPenColor);
            this.panel7.Location = new System.Drawing.Point(533, 157);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(206, 32);
            this.panel7.TabIndex = 3;
            // 
            // cmbPenColor
            // 
            this.cmbPenColor.DisplayMember = "Pen";
            this.cmbPenColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPenColor.FormattingEnabled = true;
            this.cmbPenColor.Items.AddRange(new object[] {
            "Black",
            "White",
            "Red",
            "Silver",
            "Gray"});
            this.cmbPenColor.Location = new System.Drawing.Point(146, 4);
            this.cmbPenColor.Name = "cmbPenColor";
            this.cmbPenColor.Size = new System.Drawing.Size(60, 23);
            this.cmbPenColor.TabIndex = 2;
            // 
            // lblPenColor
            // 
            this.lblPenColor.AutoSize = true;
            this.lblPenColor.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblPenColor.Location = new System.Drawing.Point(56, 7);
            this.lblPenColor.Name = "lblPenColor";
            this.lblPenColor.Size = new System.Drawing.Size(79, 15);
            this.lblPenColor.TabIndex = 1;
            this.lblPenColor.Text = "Pen Color";
            // 
            // txtRangeDepth
            // 
            this.txtRangeDepth.AutoSize = true;
            this.txtRangeDepth.BackColor = System.Drawing.SystemColors.Info;
            this.txtRangeDepth.Location = new System.Drawing.Point(746, 19);
            this.txtRangeDepth.Name = "txtRangeDepth";
            this.txtRangeDepth.Size = new System.Drawing.Size(30, 15);
            this.txtRangeDepth.TabIndex = 4;
            this.txtRangeDepth.Text = "∈N";
            // 
            // txtRangeLeng
            // 
            this.txtRangeLeng.AutoSize = true;
            this.txtRangeLeng.BackColor = System.Drawing.SystemColors.Info;
            this.txtRangeLeng.Location = new System.Drawing.Point(753, 57);
            this.txtRangeLeng.Name = "txtRangeLeng";
            this.txtRangeLeng.Size = new System.Drawing.Size(23, 15);
            this.txtRangeLeng.TabIndex = 5;
            this.txtRangeLeng.Text = ">0";
            // 
            // txtRightLengRange
            // 
            this.txtRightLengRange.AutoSize = true;
            this.txtRightLengRange.BackColor = System.Drawing.SystemColors.Info;
            this.txtRightLengRange.Location = new System.Drawing.Point(753, 91);
            this.txtRightLengRange.Name = "txtRightLengRange";
            this.txtRightLengRange.Size = new System.Drawing.Size(23, 15);
            this.txtRightLengRange.TabIndex = 6;
            this.txtRightLengRange.Text = ">0";
            // 
            // txtLeftLengRange
            // 
            this.txtLeftLengRange.AutoSize = true;
            this.txtLeftLengRange.BackColor = System.Drawing.SystemColors.Info;
            this.txtLeftLengRange.Location = new System.Drawing.Point(753, 130);
            this.txtLeftLengRange.Name = "txtLeftLengRange";
            this.txtLeftLengRange.Size = new System.Drawing.Size(23, 15);
            this.txtLeftLengRange.TabIndex = 7;
            this.txtLeftLengRange.Text = ">0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLeftLengRange);
            this.Controls.Add(this.txtRightLengRange);
            this.Controls.Add(this.txtRangeLeng);
            this.Controls.Add(this.txtRangeDepth);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlCanvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbRightAngle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbLeftAngle)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDepth;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtLeng;
        private System.Windows.Forms.Label lblLeng;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtRightLeng;
        private System.Windows.Forms.Label lblRightLength;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtLeftLeng;
        private System.Windows.Forms.Label lblLeftLength;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblRightAngle;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLeftAngle;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lblPenColor;
        private System.Windows.Forms.ComboBox cmbPenColor;
        private System.Windows.Forms.TrackBar trbRightAngle;
        private System.Windows.Forms.TrackBar trbLeftAngle;
        private System.Windows.Forms.Label txtRangeDepth;
        private System.Windows.Forms.Label txtRangeLeng;
        private System.Windows.Forms.Label txtRightLengRange;
        private System.Windows.Forms.Label txtLeftLengRange;
    }
}

