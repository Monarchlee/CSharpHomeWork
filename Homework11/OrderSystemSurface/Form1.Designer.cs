namespace OrderSystemSurface
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsrOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsrAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsrDel = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlOrderInfo = new System.Windows.Forms.Panel();
            this.splOrderInfo = new System.Windows.Forms.SplitContainer();
            this.dgvOrderInfo = new System.Windows.Forms.DataGridView();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IfSoved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvItemInfo = new System.Windows.Forms.DataGridView();
            this.OrderId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommodityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsItem = new System.Windows.Forms.BindingSource(this.components);
            this.flpQueryInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txbID = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txbCustomer = new System.Windows.Forms.TextBox();
            this.lblCommodity = new System.Windows.Forms.Label();
            this.txbCommodity = new System.Windows.Forms.TextBox();
            this.btnQueryStart = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpErrorInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.lblErrorText = new System.Windows.Forms.Label();
            this.lblErrorInfo = new System.Windows.Forms.Label();
            this.ofdImprot = new System.Windows.Forms.OpenFileDialog();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.orderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdsOrder = new System.Windows.Forms.BindingSource(this.components);
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsrImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsrExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsrIO = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.pnlOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splOrderInfo)).BeginInit();
            this.splOrderInfo.Panel1.SuspendLayout();
            this.splOrderInfo.Panel2.SuspendLayout();
            this.splOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsItem)).BeginInit();
            this.flpQueryInfo.SuspendLayout();
            this.flpErrorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsrOrder,
            this.tsrIO});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1110, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsrOrder
            // 
            this.tsrOrder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsrAdd,
            this.tsrDel});
            this.tsrOrder.Name = "tsrOrder";
            this.tsrOrder.Size = new System.Drawing.Size(53, 26);
            this.tsrOrder.Text = "订单";
            // 
            // tsrAdd
            // 
            this.tsrAdd.Name = "tsrAdd";
            this.tsrAdd.Size = new System.Drawing.Size(224, 26);
            this.tsrAdd.Text = "添加/修改订单";
            this.tsrAdd.Click += new System.EventHandler(this.tsrAdd_Click);
            // 
            // tsrDel
            // 
            this.tsrDel.Name = "tsrDel";
            this.tsrDel.Size = new System.Drawing.Size(224, 26);
            this.tsrDel.Text = "删除订单";
            this.tsrDel.Click += new System.EventHandler(this.tsrDel_Click);
            // 
            // pnlOrderInfo
            // 
            this.pnlOrderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOrderInfo.AutoScroll = true;
            this.pnlOrderInfo.Controls.Add(this.splOrderInfo);
            this.pnlOrderInfo.Location = new System.Drawing.Point(12, 66);
            this.pnlOrderInfo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlOrderInfo.Name = "pnlOrderInfo";
            this.pnlOrderInfo.Padding = new System.Windows.Forms.Padding(2);
            this.pnlOrderInfo.Size = new System.Drawing.Size(1086, 380);
            this.pnlOrderInfo.TabIndex = 1;
            // 
            // splOrderInfo
            // 
            this.splOrderInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splOrderInfo.Location = new System.Drawing.Point(2, 2);
            this.splOrderInfo.Name = "splOrderInfo";
            // 
            // splOrderInfo.Panel1
            // 
            this.splOrderInfo.Panel1.Controls.Add(this.dgvOrderInfo);
            // 
            // splOrderInfo.Panel2
            // 
            this.splOrderInfo.Panel2.Controls.Add(this.dgvItemInfo);
            this.splOrderInfo.Size = new System.Drawing.Size(1082, 376);
            this.splOrderInfo.SplitterDistance = 630;
            this.splOrderInfo.TabIndex = 0;
            // 
            // dgvOrderInfo
            // 
            this.dgvOrderInfo.AutoGenerateColumns = false;
            this.dgvOrderInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIdDataGridViewTextBoxColumn,
            this.Customer,
            this.Sum,
            this.Date,
            this.IfSoved});
            this.dgvOrderInfo.DataSource = this.bdsOrder;
            this.dgvOrderInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrderInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvOrderInfo.Name = "dgvOrderInfo";
            this.dgvOrderInfo.RowHeadersWidth = 51;
            this.dgvOrderInfo.RowTemplate.Height = 27;
            this.dgvOrderInfo.Size = new System.Drawing.Size(630, 376);
            this.dgvOrderInfo.TabIndex = 0;
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "CustomerName";
            this.Customer.HeaderText = "CustomerName";
            this.Customer.MinimumWidth = 6;
            this.Customer.Name = "Customer";
            this.Customer.Width = 125;
            // 
            // Sum
            // 
            this.Sum.DataPropertyName = "Sum";
            this.Sum.HeaderText = "Sum";
            this.Sum.MinimumWidth = 6;
            this.Sum.Name = "Sum";
            this.Sum.ReadOnly = true;
            this.Sum.Width = 125;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.Width = 125;
            // 
            // IfSoved
            // 
            this.IfSoved.DataPropertyName = "IfSolved";
            this.IfSoved.HeaderText = "IfSoved";
            this.IfSoved.MinimumWidth = 6;
            this.IfSoved.Name = "IfSoved";
            this.IfSoved.ReadOnly = true;
            this.IfSoved.Width = 125;
            // 
            // dgvItemInfo
            // 
            this.dgvItemInfo.AutoGenerateColumns = false;
            this.dgvItemInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrderId,
            this.OrderItemId,
            this.CommodityName,
            this.quantityDataGridViewTextBoxColumn});
            this.dgvItemInfo.DataSource = this.bdsItem;
            this.dgvItemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItemInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvItemInfo.Name = "dgvItemInfo";
            this.dgvItemInfo.RowHeadersWidth = 51;
            this.dgvItemInfo.RowTemplate.Height = 27;
            this.dgvItemInfo.Size = new System.Drawing.Size(448, 376);
            this.dgvItemInfo.TabIndex = 0;
            // 
            // OrderId
            // 
            this.OrderId.DataPropertyName = "OrderId";
            this.OrderId.HeaderText = "OrderId";
            this.OrderId.MinimumWidth = 6;
            this.OrderId.Name = "OrderId";
            this.OrderId.Width = 125;
            // 
            // OrderItemId
            // 
            this.OrderItemId.DataPropertyName = "OrderItemId";
            this.OrderItemId.HeaderText = "OrderItemId";
            this.OrderItemId.MinimumWidth = 6;
            this.OrderItemId.Name = "OrderItemId";
            this.OrderItemId.Width = 125;
            // 
            // CommodityName
            // 
            this.CommodityName.DataPropertyName = "CommodityName";
            this.CommodityName.HeaderText = "CommodityName";
            this.CommodityName.MinimumWidth = 6;
            this.CommodityName.Name = "CommodityName";
            this.CommodityName.Width = 125;
            // 
            // bdsItem
            // 
            this.bdsItem.DataMember = "OrderItems";
            this.bdsItem.DataSource = this.bdsOrder;
            // 
            // flpQueryInfo
            // 
            this.flpQueryInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpQueryInfo.Controls.Add(this.label1);
            this.flpQueryInfo.Controls.Add(this.txbID);
            this.flpQueryInfo.Controls.Add(this.lblCustomer);
            this.flpQueryInfo.Controls.Add(this.txbCustomer);
            this.flpQueryInfo.Controls.Add(this.lblCommodity);
            this.flpQueryInfo.Controls.Add(this.txbCommodity);
            this.flpQueryInfo.Controls.Add(this.btnQueryStart);
            this.flpQueryInfo.Location = new System.Drawing.Point(13, 32);
            this.flpQueryInfo.Name = "flpQueryInfo";
            this.flpQueryInfo.Size = new System.Drawing.Size(1085, 29);
            this.flpQueryInfo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // txbID
            // 
            this.txbID.Location = new System.Drawing.Point(40, 3);
            this.txbID.Name = "txbID";
            this.txbID.Size = new System.Drawing.Size(100, 25);
            this.txbID.TabIndex = 1;
            this.txbID.TextChanged += new System.EventHandler(this.txbID_TextChanged);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(146, 7);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(79, 15);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Customer:";
            // 
            // txbCustomer
            // 
            this.txbCustomer.Location = new System.Drawing.Point(231, 3);
            this.txbCustomer.Name = "txbCustomer";
            this.txbCustomer.Size = new System.Drawing.Size(100, 25);
            this.txbCustomer.TabIndex = 3;
            // 
            // lblCommodity
            // 
            this.lblCommodity.AutoSize = true;
            this.lblCommodity.Location = new System.Drawing.Point(337, 7);
            this.lblCommodity.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.lblCommodity.Name = "lblCommodity";
            this.lblCommodity.Size = new System.Drawing.Size(87, 15);
            this.lblCommodity.TabIndex = 4;
            this.lblCommodity.Text = "Commodity:";
            // 
            // txbCommodity
            // 
            this.txbCommodity.Location = new System.Drawing.Point(430, 3);
            this.txbCommodity.Name = "txbCommodity";
            this.txbCommodity.Size = new System.Drawing.Size(100, 25);
            this.txbCommodity.TabIndex = 5;
            // 
            // btnQueryStart
            // 
            this.btnQueryStart.Location = new System.Drawing.Point(536, 3);
            this.btnQueryStart.Name = "btnQueryStart";
            this.btnQueryStart.Size = new System.Drawing.Size(100, 25);
            this.btnQueryStart.TabIndex = 6;
            this.btnQueryStart.Text = "StartQuery";
            this.btnQueryStart.UseVisualStyleBackColor = true;
            this.btnQueryStart.Click += new System.EventHandler(this.btnQueryStart_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Customer";
            this.dataGridViewTextBoxColumn1.HeaderText = "Customer";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Customer";
            this.dataGridViewTextBoxColumn2.HeaderText = "Customer";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // flpErrorInfo
            // 
            this.flpErrorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpErrorInfo.Controls.Add(this.lblErrorText);
            this.flpErrorInfo.Controls.Add(this.lblErrorInfo);
            this.flpErrorInfo.Location = new System.Drawing.Point(12, 450);
            this.flpErrorInfo.Name = "flpErrorInfo";
            this.flpErrorInfo.Size = new System.Drawing.Size(1086, 30);
            this.flpErrorInfo.TabIndex = 3;
            // 
            // lblErrorText
            // 
            this.lblErrorText.AutoSize = true;
            this.lblErrorText.Location = new System.Drawing.Point(3, 7);
            this.lblErrorText.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.lblErrorText.Name = "lblErrorText";
            this.lblErrorText.Size = new System.Drawing.Size(87, 15);
            this.lblErrorText.TabIndex = 0;
            this.lblErrorText.Text = "ErrorInfo:";
            // 
            // lblErrorInfo
            // 
            this.lblErrorInfo.AutoSize = true;
            this.lblErrorInfo.Location = new System.Drawing.Point(96, 7);
            this.lblErrorInfo.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.lblErrorInfo.Name = "lblErrorInfo";
            this.lblErrorInfo.Size = new System.Drawing.Size(0, 15);
            this.lblErrorInfo.TabIndex = 1;
            // 
            // ofdImprot
            // 
            this.ofdImprot.FileName = "targetFile";
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            this.orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.HeaderText = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            this.orderIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // bdsOrder
            // 
            this.bdsOrder.DataSource = typeof(OrderSystemNew.Order);
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 125;
            // 
            // tsrImport
            // 
            this.tsrImport.Name = "tsrImport";
            this.tsrImport.Size = new System.Drawing.Size(224, 26);
            this.tsrImport.Text = "导入订单";
            this.tsrImport.Click += new System.EventHandler(this.tsrImport_Click);
            // 
            // tsrExport
            // 
            this.tsrExport.Name = "tsrExport";
            this.tsrExport.Size = new System.Drawing.Size(224, 26);
            this.tsrExport.Text = "导出订单";
            this.tsrExport.Click += new System.EventHandler(this.tsrExport_Click);
            // 
            // tsrIO
            // 
            this.tsrIO.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsrImport,
            this.tsrExport});
            this.tsrIO.Name = "tsrIO";
            this.tsrIO.Size = new System.Drawing.Size(89, 26);
            this.tsrIO.Text = "导入/导出";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 489);
            this.Controls.Add(this.flpErrorInfo);
            this.Controls.Add(this.flpQueryInfo);
            this.Controls.Add(this.pnlOrderInfo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "订单管理系统";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlOrderInfo.ResumeLayout(false);
            this.splOrderInfo.Panel1.ResumeLayout(false);
            this.splOrderInfo.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splOrderInfo)).EndInit();
            this.splOrderInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsItem)).EndInit();
            this.flpQueryInfo.ResumeLayout(false);
            this.flpQueryInfo.PerformLayout();
            this.flpErrorInfo.ResumeLayout(false);
            this.flpErrorInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsrOrder;
        private System.Windows.Forms.ToolStripMenuItem tsrAdd;
        private System.Windows.Forms.ToolStripMenuItem tsrDel;
        private System.Windows.Forms.Panel pnlOrderInfo;
        private System.Windows.Forms.FlowLayoutPanel flpQueryInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbID;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.TextBox txbCustomer;
        private System.Windows.Forms.Label lblCommodity;
        private System.Windows.Forms.TextBox txbCommodity;
        private System.Windows.Forms.Button btnQueryStart;
        private System.Windows.Forms.SplitContainer splOrderInfo;
        private System.Windows.Forms.DataGridView dgvOrderInfo;
        private System.Windows.Forms.DataGridView dgvItemInfo;
        private System.Windows.Forms.BindingSource bdsOrder;
        private System.Windows.Forms.BindingSource bdsItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.FlowLayoutPanel flpErrorInfo;
        private System.Windows.Forms.Label lblErrorText;
        private System.Windows.Forms.Label lblErrorInfo;
        private System.Windows.Forms.OpenFileDialog ofdImprot;
        private System.Windows.Forms.SaveFileDialog sfdExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommodityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IfSoved;
        private System.Windows.Forms.ToolStripMenuItem tsrIO;
        private System.Windows.Forms.ToolStripMenuItem tsrImport;
        private System.Windows.Forms.ToolStripMenuItem tsrExport;
    }
}

