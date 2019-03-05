namespace CatswordsTab.Shell
{
    partial class FormExpert
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.tabExpert = new System.Windows.Forms.TabControl();
            this.tpQuery = new System.Windows.Forms.TabPage();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtHashSha256 = new System.Windows.Forms.TextBox();
            this.txtHashHead32 = new System.Windows.Forms.TextBox();
            this.txtHashCrc32 = new System.Windows.Forms.TextBox();
            this.txtHashSha1 = new System.Windows.Forms.TextBox();
            this.txtHashMd5 = new System.Windows.Forms.TextBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.labelExtension = new System.Windows.Forms.Label();
            this.labelSha256 = new System.Windows.Forms.Label();
            this.labelHead32 = new System.Windows.Forms.Label();
            this.labelCrc32 = new System.Windows.Forms.Label();
            this.labelSha1 = new System.Windows.Forms.Label();
            this.labelMd5 = new System.Windows.Forms.Label();
            this.tpReport = new System.Windows.Forms.TabPage();
            this.txtReport = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tabExpert.SuspendLayout();
            this.tpQuery.SuspendLayout();
            this.tpReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Location = new System.Drawing.Point(100, 44);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(56, 12);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "labelTitle";
            // 
            // tabExpert
            // 
            this.tabExpert.Controls.Add(this.tpQuery);
            this.tabExpert.Controls.Add(this.tpReport);
            this.tabExpert.Location = new System.Drawing.Point(12, 131);
            this.tabExpert.Name = "tabExpert";
            this.tabExpert.SelectedIndex = 0;
            this.tabExpert.Size = new System.Drawing.Size(517, 364);
            this.tabExpert.TabIndex = 1;
            // 
            // tpQuery
            // 
            this.tpQuery.Controls.Add(this.btnQuery);
            this.tpQuery.Controls.Add(this.txtLanguage);
            this.tpQuery.Controls.Add(this.txtExtension);
            this.tpQuery.Controls.Add(this.txtHashSha256);
            this.tpQuery.Controls.Add(this.txtHashHead32);
            this.tpQuery.Controls.Add(this.txtHashCrc32);
            this.tpQuery.Controls.Add(this.txtHashSha1);
            this.tpQuery.Controls.Add(this.txtHashMd5);
            this.tpQuery.Controls.Add(this.labelLanguage);
            this.tpQuery.Controls.Add(this.labelExtension);
            this.tpQuery.Controls.Add(this.labelSha256);
            this.tpQuery.Controls.Add(this.labelHead32);
            this.tpQuery.Controls.Add(this.labelCrc32);
            this.tpQuery.Controls.Add(this.labelSha1);
            this.tpQuery.Controls.Add(this.labelMd5);
            this.tpQuery.Location = new System.Drawing.Point(4, 22);
            this.tpQuery.Name = "tpQuery";
            this.tpQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tpQuery.Size = new System.Drawing.Size(509, 338);
            this.tpQuery.TabIndex = 0;
            this.tpQuery.Text = "tpQuery";
            this.tpQuery.UseVisualStyleBackColor = true;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(33, 280);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(107, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "btnQuery";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // txtLanguage
            // 
            this.txtLanguage.Location = new System.Drawing.Point(146, 225);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.Size = new System.Drawing.Size(331, 21);
            this.txtLanguage.TabIndex = 1;
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(146, 193);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(331, 21);
            this.txtExtension.TabIndex = 1;
            // 
            // txtHashSha256
            // 
            this.txtHashSha256.Location = new System.Drawing.Point(146, 160);
            this.txtHashSha256.Name = "txtHashSha256";
            this.txtHashSha256.Size = new System.Drawing.Size(331, 21);
            this.txtHashSha256.TabIndex = 1;
            // 
            // txtHashHead32
            // 
            this.txtHashHead32.Location = new System.Drawing.Point(146, 127);
            this.txtHashHead32.Name = "txtHashHead32";
            this.txtHashHead32.Size = new System.Drawing.Size(331, 21);
            this.txtHashHead32.TabIndex = 1;
            // 
            // txtHashCrc32
            // 
            this.txtHashCrc32.Location = new System.Drawing.Point(146, 94);
            this.txtHashCrc32.Name = "txtHashCrc32";
            this.txtHashCrc32.Size = new System.Drawing.Size(331, 21);
            this.txtHashCrc32.TabIndex = 1;
            // 
            // txtHashSha1
            // 
            this.txtHashSha1.Location = new System.Drawing.Point(146, 62);
            this.txtHashSha1.Name = "txtHashSha1";
            this.txtHashSha1.Size = new System.Drawing.Size(331, 21);
            this.txtHashSha1.TabIndex = 1;
            // 
            // txtHashMd5
            // 
            this.txtHashMd5.Location = new System.Drawing.Point(146, 31);
            this.txtHashMd5.Name = "txtHashMd5";
            this.txtHashMd5.Size = new System.Drawing.Size(331, 21);
            this.txtHashMd5.TabIndex = 1;
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(31, 229);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(88, 12);
            this.labelLanguage.TabIndex = 0;
            this.labelLanguage.Text = "labelLanguage";
            // 
            // labelExtension
            // 
            this.labelExtension.AutoSize = true;
            this.labelExtension.Location = new System.Drawing.Point(31, 196);
            this.labelExtension.Name = "labelExtension";
            this.labelExtension.Size = new System.Drawing.Size(88, 12);
            this.labelExtension.TabIndex = 0;
            this.labelExtension.Text = "labelExtension";
            // 
            // labelSha256
            // 
            this.labelSha256.AutoSize = true;
            this.labelSha256.Location = new System.Drawing.Point(31, 163);
            this.labelSha256.Name = "labelSha256";
            this.labelSha256.Size = new System.Drawing.Size(72, 12);
            this.labelSha256.TabIndex = 0;
            this.labelSha256.Text = "labelSha256";
            // 
            // labelHead32
            // 
            this.labelHead32.AutoSize = true;
            this.labelHead32.Location = new System.Drawing.Point(31, 130);
            this.labelHead32.Name = "labelHead32";
            this.labelHead32.Size = new System.Drawing.Size(73, 12);
            this.labelHead32.TabIndex = 0;
            this.labelHead32.Text = "labelHead32";
            // 
            // labelCrc32
            // 
            this.labelCrc32.AutoSize = true;
            this.labelCrc32.Location = new System.Drawing.Point(31, 97);
            this.labelCrc32.Name = "labelCrc32";
            this.labelCrc32.Size = new System.Drawing.Size(64, 12);
            this.labelCrc32.TabIndex = 0;
            this.labelCrc32.Text = "labelCrc32";
            // 
            // labelSha1
            // 
            this.labelSha1.AutoSize = true;
            this.labelSha1.Location = new System.Drawing.Point(31, 65);
            this.labelSha1.Name = "labelSha1";
            this.labelSha1.Size = new System.Drawing.Size(60, 12);
            this.labelSha1.TabIndex = 0;
            this.labelSha1.Text = "labelSha1";
            // 
            // labelMd5
            // 
            this.labelMd5.AutoSize = true;
            this.labelMd5.Location = new System.Drawing.Point(31, 34);
            this.labelMd5.Name = "labelMd5";
            this.labelMd5.Size = new System.Drawing.Size(56, 12);
            this.labelMd5.TabIndex = 0;
            this.labelMd5.Text = "labelMd5";
            // 
            // tpReport
            // 
            this.tpReport.Controls.Add(this.txtReport);
            this.tpReport.Location = new System.Drawing.Point(4, 22);
            this.tpReport.Name = "tpReport";
            this.tpReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpReport.Size = new System.Drawing.Size(509, 338);
            this.tpReport.TabIndex = 7;
            this.tpReport.Text = "tpReport";
            this.tpReport.UseVisualStyleBackColor = true;
            // 
            // txtReport
            // 
            this.txtReport.Location = new System.Drawing.Point(6, 6);
            this.txtReport.Multiline = true;
            this.txtReport.Name = "txtReport";
            this.txtReport.Size = new System.Drawing.Size(497, 326);
            this.txtReport.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnLogin.Image = global::CatswordsTab.Shell.Properties.Resources.iconsdb_white_account_login_32;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.Location = new System.Drawing.Point(398, 59);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(127, 40);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ShellExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::CatswordsTab.Shell.Properties.Resources.iconfinder_shining_mix_wrench_1059388;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(557, 524);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tabExpert);
            this.Controls.Add(this.labelTitle);
            this.Icon = global::CatswordsTab.Shell.Properties.Resources.icon_icons_retro_flower_fire_2_24692;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShellExpert";
            this.Text = "CatswordsTabExpert";
            this.Load += new System.EventHandler(this.CatswordsTabExpert_Load);
            this.tabExpert.ResumeLayout(false);
            this.tpQuery.ResumeLayout(false);
            this.tpQuery.PerformLayout();
            this.tpReport.ResumeLayout(false);
            this.tpReport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabControl tabExpert;
        private System.Windows.Forms.TabPage tpQuery;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.TextBox txtHashSha256;
        private System.Windows.Forms.TextBox txtHashHead32;
        private System.Windows.Forms.TextBox txtHashCrc32;
        private System.Windows.Forms.TextBox txtHashSha1;
        private System.Windows.Forms.TextBox txtHashMd5;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.Label labelExtension;
        private System.Windows.Forms.Label labelSha256;
        private System.Windows.Forms.Label labelHead32;
        private System.Windows.Forms.Label labelCrc32;
        private System.Windows.Forms.Label labelSha1;
        private System.Windows.Forms.Label labelMd5;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TabPage tpReport;
        private System.Windows.Forms.TextBox txtReport;
    }
}