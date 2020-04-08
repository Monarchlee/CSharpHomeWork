namespace OrderSystemSurface
{
    partial class DeleteForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDelID = new System.Windows.Forms.Label();
            this.txbID = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnDelAll = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.lblDelID);
            this.flowLayoutPanel1.Controls.Add(this.txbID);
            this.flowLayoutPanel1.Controls.Add(this.btnDel);
            this.flowLayoutPanel1.Controls.Add(this.btnDelAll);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(399, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblDelID
            // 
            this.lblDelID.AutoSize = true;
            this.lblDelID.Location = new System.Drawing.Point(3, 7);
            this.lblDelID.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.lblDelID.Name = "lblDelID";
            this.lblDelID.Size = new System.Drawing.Size(31, 15);
            this.lblDelID.TabIndex = 0;
            this.lblDelID.Text = "ID:";
            // 
            // txbID
            // 
            this.txbID.Location = new System.Drawing.Point(40, 3);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(100, 25);
            this.txbID.TabIndex = 1;
            this.txbID.TextChanged += new System.EventHandler(this.txbID_TextChanged);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(146, 3);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnDelAll
            // 
            this.btnDelAll.Location = new System.Drawing.Point(227, 3);
            this.btnDelAll.Name = "btnDelAll";
            this.btnDelAll.Size = new System.Drawing.Size(153, 23);
            this.btnDelAll.TabIndex = 3;
            this.btnDelAll.Text = "Delete All Orders";
            this.btnDelAll.UseVisualStyleBackColor = true;
            this.btnDelAll.Click += new System.EventHandler(this.btnDelAll_Click);
            // 
            // DeleteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 61);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DeleteForm";
            this.Text = "删除订单";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblDelID;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnDelAll;
    }
}