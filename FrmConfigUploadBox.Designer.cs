namespace SolrTool
{
    partial class FrmConfigUploadBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxConfName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBoxFolder = new System.Windows.Forms.TextBox();
            this.LinkLblSelectFolder = new System.Windows.Forms.LinkLabel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "配置名";
            // 
            // TextBoxConfName
            // 
            this.TextBoxConfName.Location = new System.Drawing.Point(111, 10);
            this.TextBoxConfName.Name = "TextBoxConfName";
            this.TextBoxConfName.Size = new System.Drawing.Size(266, 21);
            this.TextBoxConfName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "配置文件路径";
            // 
            // TextBoxFolder
            // 
            this.TextBoxFolder.Location = new System.Drawing.Point(111, 37);
            this.TextBoxFolder.Name = "TextBoxFolder";
            this.TextBoxFolder.Size = new System.Drawing.Size(266, 21);
            this.TextBoxFolder.TabIndex = 1;
            // 
            // LinkLblSelectFolder
            // 
            this.LinkLblSelectFolder.AutoSize = true;
            this.LinkLblSelectFolder.BackColor = System.Drawing.Color.Transparent;
            this.LinkLblSelectFolder.Location = new System.Drawing.Point(332, 40);
            this.LinkLblSelectFolder.Name = "LinkLblSelectFolder";
            this.LinkLblSelectFolder.Size = new System.Drawing.Size(23, 12);
            this.LinkLblSelectFolder.TabIndex = 2;
            this.LinkLblSelectFolder.TabStop = true;
            this.LinkLblSelectFolder.Text = "...";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("宋体", 14F);
            this.BtnCancel.Location = new System.Drawing.Point(275, 81);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(102, 37);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Font = new System.Drawing.Font("宋体", 14F);
            this.BtnOk.Location = new System.Drawing.Point(167, 81);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(102, 37);
            this.BtnOk.TabIndex = 3;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            // 
            // FrmConfigUploadBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 140);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LinkLblSelectFolder);
            this.Controls.Add(this.TextBoxFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxConfName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfigUploadBox";
            this.Text = "FrmConfigUploadBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxConfName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBoxFolder;
        private System.Windows.Forms.LinkLabel LinkLblSelectFolder;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
    }
}