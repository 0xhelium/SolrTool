namespace SolrTool
{
    partial class FrmMain
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
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ComboSolrCore = new System.Windows.Forms.ComboBox();
            this.lblSolrCore = new System.Windows.Forms.Label();
            this.ComboSolrCollection = new System.Windows.Forms.ComboBox();
            this.lblSolrCollection = new System.Windows.Forms.Label();
            this.TextBoxLog = new System.Windows.Forms.TextBox();
            this.SplitCtn = new System.Windows.Forms.SplitContainer();
            this.SplitCtnFiles = new System.Windows.Forms.SplitContainer();
            this.tree = new System.Windows.Forms.TreeView();
            this.TextBoxFileContent = new System.Windows.Forms.RichTextBox();
            this.LinkLblCopy = new System.Windows.Forms.LinkLabel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.BtnExportAllFiles = new System.Windows.Forms.Button();
            this.BtnUpdateCurrentFile = new System.Windows.Forms.Button();
            this.BtnReoload = new System.Windows.Forms.Button();
            this.BtnUploadConfig = new System.Windows.Forms.Button();
            this.BtnExportAllCollections = new System.Windows.Forms.Button();
            this.StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtn)).BeginInit();
            this.SplitCtn.Panel1.SuspendLayout();
            this.SplitCtn.Panel2.SuspendLayout();
            this.SplitCtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnFiles)).BeginInit();
            this.SplitCtnFiles.Panel1.SuspendLayout();
            this.SplitCtnFiles.Panel2.SuspendLayout();
            this.SplitCtnFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 615);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(1162, 22);
            this.StatusStrip.TabIndex = 0;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // StatusStripLabel
            // 
            this.StatusStripLabel.Name = "StatusStripLabel";
            this.StatusStripLabel.Size = new System.Drawing.Size(13, 17);
            this.StatusStripLabel.Text = "-";
            // 
            // ComboSolrCore
            // 
            this.ComboSolrCore.FormattingEnabled = true;
            this.ComboSolrCore.Location = new System.Drawing.Point(84, 12);
            this.ComboSolrCore.Name = "ComboSolrCore";
            this.ComboSolrCore.Size = new System.Drawing.Size(176, 20);
            this.ComboSolrCore.TabIndex = 1;
            // 
            // lblSolrCore
            // 
            this.lblSolrCore.AutoSize = true;
            this.lblSolrCore.Location = new System.Drawing.Point(43, 15);
            this.lblSolrCore.Name = "lblSolrCore";
            this.lblSolrCore.Size = new System.Drawing.Size(35, 12);
            this.lblSolrCore.TabIndex = 2;
            this.lblSolrCore.Text = "CORES";
            // 
            // ComboSolrCollection
            // 
            this.ComboSolrCollection.FormattingEnabled = true;
            this.ComboSolrCollection.Location = new System.Drawing.Point(84, 44);
            this.ComboSolrCollection.Name = "ComboSolrCollection";
            this.ComboSolrCollection.Size = new System.Drawing.Size(176, 20);
            this.ComboSolrCollection.TabIndex = 1;
            this.ComboSolrCollection.Visible = false;
            // 
            // lblSolrCollection
            // 
            this.lblSolrCollection.AutoSize = true;
            this.lblSolrCollection.Location = new System.Drawing.Point(13, 47);
            this.lblSolrCollection.Name = "lblSolrCollection";
            this.lblSolrCollection.Size = new System.Drawing.Size(65, 12);
            this.lblSolrCollection.TabIndex = 2;
            this.lblSolrCollection.Text = "COLLECTION";
            this.lblSolrCollection.Visible = false;
            // 
            // TextBoxLog
            // 
            this.TextBoxLog.BackColor = System.Drawing.Color.Black;
            this.TextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBoxLog.ForeColor = System.Drawing.Color.White;
            this.TextBoxLog.Location = new System.Drawing.Point(0, 0);
            this.TextBoxLog.Multiline = true;
            this.TextBoxLog.Name = "TextBoxLog";
            this.TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxLog.Size = new System.Drawing.Size(896, 165);
            this.TextBoxLog.TabIndex = 3;
            // 
            // SplitCtn
            // 
            this.SplitCtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.SplitCtn.Location = new System.Drawing.Point(266, 0);
            this.SplitCtn.Name = "SplitCtn";
            this.SplitCtn.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitCtn.Panel1
            // 
            this.SplitCtn.Panel1.Controls.Add(this.TextBoxLog);
            // 
            // SplitCtn.Panel2
            // 
            this.SplitCtn.Panel2.Controls.Add(this.SplitCtnFiles);
            this.SplitCtn.Size = new System.Drawing.Size(896, 615);
            this.SplitCtn.SplitterDistance = 165;
            this.SplitCtn.TabIndex = 4;
            // 
            // SplitCtnFiles
            // 
            this.SplitCtnFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitCtnFiles.Location = new System.Drawing.Point(0, 0);
            this.SplitCtnFiles.Name = "SplitCtnFiles";
            // 
            // SplitCtnFiles.Panel1
            // 
            this.SplitCtnFiles.Panel1.Controls.Add(this.tree);
            // 
            // SplitCtnFiles.Panel2
            // 
            this.SplitCtnFiles.Panel2.Controls.Add(this.TextBoxFileContent);
            this.SplitCtnFiles.Panel2.Controls.Add(this.LinkLblCopy);
            this.SplitCtnFiles.Size = new System.Drawing.Size(896, 446);
            this.SplitCtnFiles.SplitterDistance = 242;
            this.SplitCtnFiles.TabIndex = 0;
            // 
            // tree
            // 
            this.tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree.Location = new System.Drawing.Point(0, 0);
            this.tree.Name = "tree";
            this.tree.Size = new System.Drawing.Size(242, 446);
            this.tree.TabIndex = 0;
            // 
            // TextBoxFileContent
            // 
            this.TextBoxFileContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxFileContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBoxFileContent.Location = new System.Drawing.Point(0, 0);
            this.TextBoxFileContent.Name = "TextBoxFileContent";
            this.TextBoxFileContent.Size = new System.Drawing.Size(650, 427);
            this.TextBoxFileContent.TabIndex = 6;
            this.TextBoxFileContent.Text = "";
            // 
            // LinkLblCopy
            // 
            this.LinkLblCopy.AutoSize = true;
            this.LinkLblCopy.Location = new System.Drawing.Point(4, 430);
            this.LinkLblCopy.Name = "LinkLblCopy";
            this.LinkLblCopy.Size = new System.Drawing.Size(29, 12);
            this.LinkLblCopy.TabIndex = 6;
            this.LinkLblCopy.TabStop = true;
            this.LinkLblCopy.Text = "COPY";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BtnExportAllFiles
            // 
            this.BtnExportAllFiles.Location = new System.Drawing.Point(15, 142);
            this.BtnExportAllFiles.Name = "BtnExportAllFiles";
            this.BtnExportAllFiles.Size = new System.Drawing.Size(245, 23);
            this.BtnExportAllFiles.TabIndex = 5;
            this.BtnExportAllFiles.Text = "导出当前配置文件";
            this.BtnExportAllFiles.UseVisualStyleBackColor = true;
            // 
            // BtnUpdateCurrentFile
            // 
            this.BtnUpdateCurrentFile.Location = new System.Drawing.Point(15, 171);
            this.BtnUpdateCurrentFile.Name = "BtnUpdateCurrentFile";
            this.BtnUpdateCurrentFile.Size = new System.Drawing.Size(245, 23);
            this.BtnUpdateCurrentFile.TabIndex = 5;
            this.BtnUpdateCurrentFile.Text = "更新当前文件";
            this.BtnUpdateCurrentFile.UseVisualStyleBackColor = true;
            // 
            // BtnReoload
            // 
            this.BtnReoload.Location = new System.Drawing.Point(197, 70);
            this.BtnReoload.Name = "BtnReoload";
            this.BtnReoload.Size = new System.Drawing.Size(63, 23);
            this.BtnReoload.TabIndex = 5;
            this.BtnReoload.Text = "RELOAD";
            this.BtnReoload.UseVisualStyleBackColor = true;
            // 
            // BtnUploadConfig
            // 
            this.BtnUploadConfig.Location = new System.Drawing.Point(15, 200);
            this.BtnUploadConfig.Name = "BtnUploadConfig";
            this.BtnUploadConfig.Size = new System.Drawing.Size(245, 23);
            this.BtnUploadConfig.TabIndex = 5;
            this.BtnUploadConfig.Text = "新增配置";
            this.BtnUploadConfig.UseVisualStyleBackColor = true;
            // 
            // BtnExportAllCollections
            // 
            this.BtnExportAllCollections.Location = new System.Drawing.Point(15, 113);
            this.BtnExportAllCollections.Name = "BtnExportAllCollections";
            this.BtnExportAllCollections.Size = new System.Drawing.Size(245, 23);
            this.BtnExportAllCollections.TabIndex = 5;
            this.BtnExportAllCollections.Text = "导出全部配置文件";
            this.BtnExportAllCollections.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 637);
            this.Controls.Add(this.BtnUploadConfig);
            this.Controls.Add(this.BtnUpdateCurrentFile);
            this.Controls.Add(this.BtnReoload);
            this.Controls.Add(this.BtnExportAllCollections);
            this.Controls.Add(this.BtnExportAllFiles);
            this.Controls.Add(this.SplitCtn);
            this.Controls.Add(this.lblSolrCollection);
            this.Controls.Add(this.lblSolrCore);
            this.Controls.Add(this.ComboSolrCollection);
            this.Controls.Add(this.ComboSolrCore);
            this.Controls.Add(this.StatusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Main";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.SplitCtn.Panel1.ResumeLayout(false);
            this.SplitCtn.Panel1.PerformLayout();
            this.SplitCtn.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtn)).EndInit();
            this.SplitCtn.ResumeLayout(false);
            this.SplitCtnFiles.Panel1.ResumeLayout(false);
            this.SplitCtnFiles.Panel2.ResumeLayout(false);
            this.SplitCtnFiles.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCtnFiles)).EndInit();
            this.SplitCtnFiles.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripLabel;
        private System.Windows.Forms.ComboBox ComboSolrCore;
        private System.Windows.Forms.Label lblSolrCore;
        private System.Windows.Forms.ComboBox ComboSolrCollection;
        private System.Windows.Forms.Label lblSolrCollection;
        private System.Windows.Forms.TextBox TextBoxLog;
        private System.Windows.Forms.SplitContainer SplitCtn;
        private System.Windows.Forms.SplitContainer SplitCtnFiles;
        private System.Windows.Forms.TreeView tree;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button BtnExportAllFiles;
        private System.Windows.Forms.Button BtnUpdateCurrentFile;
        private System.Windows.Forms.Button BtnReoload;
        private System.Windows.Forms.Button BtnUploadConfig;
        private System.Windows.Forms.LinkLabel LinkLblCopy;
        private System.Windows.Forms.RichTextBox TextBoxFileContent;
        private System.Windows.Forms.Button BtnExportAllCollections;
    }
}

