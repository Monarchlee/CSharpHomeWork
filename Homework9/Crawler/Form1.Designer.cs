namespace Crawler
{
    partial class CrawlerForm
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
            this.flpStartURL = new System.Windows.Forms.FlowLayoutPanel();
            this.txbStartURL = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.bdsUrl = new System.Windows.Forms.BindingSource(this.components);
            this.dgvDownLoadInfo = new System.Windows.Forms.DataGridView();
            this.urlInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpStartURL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsUrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDownLoadInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // flpStartURL
            // 
            this.flpStartURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpStartURL.Controls.Add(this.txbStartURL);
            this.flpStartURL.Controls.Add(this.btnStart);
            this.flpStartURL.Location = new System.Drawing.Point(12, 12);
            this.flpStartURL.Name = "flpStartURL";
            this.flpStartURL.Size = new System.Drawing.Size(851, 49);
            this.flpStartURL.TabIndex = 0;
            // 
            // txbStartURL
            // 
            this.txbStartURL.Location = new System.Drawing.Point(3, 12);
            this.txbStartURL.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.txbStartURL.Name = "txbStartURL";
            this.txbStartURL.Size = new System.Drawing.Size(420, 25);
            this.txbStartURL.TabIndex = 0;
            this.txbStartURL.Text = "http://www.cnblogs.com/dstang2000/";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(429, 12);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 12, 3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // bdsUrl
            // 
            this.bdsUrl.DataSource = typeof(Crawler.UrlData);
            // 
            // dgvDownLoadInfo
            // 
            this.dgvDownLoadInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDownLoadInfo.AutoGenerateColumns = false;
            this.dgvDownLoadInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDownLoadInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.urlInfoDataGridViewTextBoxColumn});
            this.dgvDownLoadInfo.DataSource = this.bdsUrl;
            this.dgvDownLoadInfo.Location = new System.Drawing.Point(12, 68);
            this.dgvDownLoadInfo.Name = "dgvDownLoadInfo";
            this.dgvDownLoadInfo.RowHeadersWidth = 51;
            this.dgvDownLoadInfo.RowTemplate.Height = 27;
            this.dgvDownLoadInfo.Size = new System.Drawing.Size(851, 382);
            this.dgvDownLoadInfo.TabIndex = 1;
            // 
            // urlInfoDataGridViewTextBoxColumn
            // 
            this.urlInfoDataGridViewTextBoxColumn.DataPropertyName = "UrlInfo";
            this.urlInfoDataGridViewTextBoxColumn.HeaderText = "UrlInfo";
            this.urlInfoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.urlInfoDataGridViewTextBoxColumn.Name = "urlInfoDataGridViewTextBoxColumn";
            this.urlInfoDataGridViewTextBoxColumn.Width = 800;
            // 
            // CrawlerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 462);
            this.Controls.Add(this.dgvDownLoadInfo);
            this.Controls.Add(this.flpStartURL);
            this.Name = "CrawlerForm";
            this.Text = "Crawler";
            this.flpStartURL.ResumeLayout(false);
            this.flpStartURL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsUrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDownLoadInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpStartURL;
        private System.Windows.Forms.TextBox txbStartURL;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.BindingSource bdsUrl;
        private System.Windows.Forms.DataGridView dgvDownLoadInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn urlInfoDataGridViewTextBoxColumn;
    }
}

