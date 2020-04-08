namespace OrderSystemSurface
{
    partial class AddUpdateForm
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
            this.lblID = new System.Windows.Forms.Label();
            this.txbID = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txbCustomerName = new System.Windows.Forms.TextBox();
            this.lblCustomerLevel = new System.Windows.Forms.Label();
            this.cmbLevel = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdata = new System.Windows.Forms.Button();
            this.lblCmName = new System.Windows.Forms.Label();
            this.txbCmName = new System.Windows.Forms.TextBox();
            this.lblCmPrice = new System.Windows.Forms.Label();
            this.txbCmPrice = new System.Windows.Forms.TextBox();
            this.lblCmQuantity = new System.Windows.Forms.Label();
            this.txbCmQuantity = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.lblID);
            this.flowLayoutPanel1.Controls.Add(this.txbID);
            this.flowLayoutPanel1.Controls.Add(this.lblCustomerName);
            this.flowLayoutPanel1.Controls.Add(this.txbCustomerName);
            this.flowLayoutPanel1.Controls.Add(this.lblCustomerLevel);
            this.flowLayoutPanel1.Controls.Add(this.cmbLevel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(660, 32);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 7);
            this.lblID.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(31, 15);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // txbID
            // 
            this.txbID.Location = new System.Drawing.Point(40, 3);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(100, 25);
            this.txbID.TabIndex = 1;
            this.txbID.TextChanged += new System.EventHandler(this.txbID_TextChanged);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(146, 7);
            this.lblCustomerName.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(111, 15);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "CustomerName:";
            // 
            // txbCustomerName
            // 
            this.txbCustomerName.Location = new System.Drawing.Point(263, 3);
            this.txbCustomerName.Name = "txbCustomerName";
            this.txbCustomerName.Size = new System.Drawing.Size(100, 25);
            this.txbCustomerName.TabIndex = 3;
            // 
            // lblCustomerLevel
            // 
            this.lblCustomerLevel.AutoSize = true;
            this.lblCustomerLevel.Location = new System.Drawing.Point(369, 7);
            this.lblCustomerLevel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.lblCustomerLevel.Name = "lblCustomerLevel";
            this.lblCustomerLevel.Size = new System.Drawing.Size(119, 15);
            this.lblCustomerLevel.TabIndex = 4;
            this.lblCustomerLevel.Text = "CustomerLevel:";
            // 
            // cmbLevel
            // 
            this.cmbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLevel.FormattingEnabled = true;
            this.cmbLevel.Items.AddRange(new object[] {
            "Bronze",
            "Silver",
            "Gold",
            "Diamond"});
            this.cmbLevel.Location = new System.Drawing.Point(494, 3);
            this.cmbLevel.Name = "cmbLevel";
            this.cmbLevel.Size = new System.Drawing.Size(121, 23);
            this.cmbLevel.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(597, 133);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Create";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(12, 133);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdata
            // 
            this.btnUpdata.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdata.Location = new System.Drawing.Point(516, 133);
            this.btnUpdata.Name = "btnUpdata";
            this.btnUpdata.Size = new System.Drawing.Size(75, 23);
            this.btnUpdata.TabIndex = 8;
            this.btnUpdata.Text = "Updata";
            this.btnUpdata.UseVisualStyleBackColor = true;
            this.btnUpdata.Click += new System.EventHandler(this.btnUpdata_Click);
            // 
            // lblCmName
            // 
            this.lblCmName.AutoSize = true;
            this.lblCmName.Location = new System.Drawing.Point(20, 56);
            this.lblCmName.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.lblCmName.Name = "lblCmName";
            this.lblCmName.Size = new System.Drawing.Size(127, 15);
            this.lblCmName.TabIndex = 7;
            this.lblCmName.Text = "Commodity Name:";
            // 
            // txbCmName
            // 
            this.txbCmName.Location = new System.Drawing.Point(161, 52);
            this.txbCmName.Name = "txbCmName";
            this.txbCmName.Size = new System.Drawing.Size(100, 25);
            this.txbCmName.TabIndex = 8;
            // 
            // lblCmPrice
            // 
            this.lblCmPrice.AutoSize = true;
            this.lblCmPrice.Location = new System.Drawing.Point(12, 104);
            this.lblCmPrice.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.lblCmPrice.Name = "lblCmPrice";
            this.lblCmPrice.Size = new System.Drawing.Size(135, 15);
            this.lblCmPrice.TabIndex = 9;
            this.lblCmPrice.Text = "Commodity Price:";
            // 
            // txbCmPrice
            // 
            this.txbCmPrice.Location = new System.Drawing.Point(161, 101);
            this.txbCmPrice.Name = "txbCmPrice";
            this.txbCmPrice.Size = new System.Drawing.Size(100, 25);
            this.txbCmPrice.TabIndex = 10;
            this.txbCmPrice.TextChanged += new System.EventHandler(this.txbCmPrice_TextChanged);
            // 
            // lblCmQuantity
            // 
            this.lblCmQuantity.AutoSize = true;
            this.lblCmQuantity.Location = new System.Drawing.Point(272, 56);
            this.lblCmQuantity.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.lblCmQuantity.Name = "lblCmQuantity";
            this.lblCmQuantity.Size = new System.Drawing.Size(159, 15);
            this.lblCmQuantity.TabIndex = 11;
            this.lblCmQuantity.Text = "Commodity Quantity:";
            // 
            // txbCmQuantity
            // 
            this.txbCmQuantity.Location = new System.Drawing.Point(437, 52);
            this.txbCmQuantity.Name = "txbCmQuantity";
            this.txbCmQuantity.Size = new System.Drawing.Size(100, 25);
            this.txbCmQuantity.TabIndex = 12;
            this.txbCmQuantity.TextChanged += new System.EventHandler(this.txbCmQuantity_TextChanged);
            // 
            // AddUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 168);
            this.Controls.Add(this.txbCmQuantity);
            this.Controls.Add(this.lblCmQuantity);
            this.Controls.Add(this.btnUpdata);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblCmName);
            this.Controls.Add(this.txbCmName);
            this.Controls.Add(this.txbCmPrice);
            this.Controls.Add(this.lblCmPrice);
            this.Name = "AddUpdateForm";
            this.Text = "添加/修改订单";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txbCustomerName;
        private System.Windows.Forms.Label lblCustomerLevel;
        private System.Windows.Forms.ComboBox cmbLevel;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdata;
        private System.Windows.Forms.Label lblCmName;
        private System.Windows.Forms.TextBox txbCmName;
        private System.Windows.Forms.Label lblCmPrice;
        private System.Windows.Forms.TextBox txbCmPrice;
        private System.Windows.Forms.Label lblCmQuantity;
        private System.Windows.Forms.TextBox txbCmQuantity;
    }
}