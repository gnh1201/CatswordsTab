namespace CatswordsTab.Server.Winform
{
    partial class Expert
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
            this.tabPageQuery = new System.Windows.Forms.TabPage();
            this.btnGet = new System.Windows.Forms.Button();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtHashSha256 = new System.Windows.Forms.TextBox();
            this.txtHashHead32 = new System.Windows.Forms.TextBox();
            this.txtHashCrc32 = new System.Windows.Forms.TextBox();
            this.txtHashSha1 = new System.Windows.Forms.TextBox();
            this.txtHashMd5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageAnalytics = new System.Windows.Forms.TabPage();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.txtAnalytics = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tabExpert.SuspendLayout();
            this.tabPageQuery.SuspendLayout();
            this.tabPageAnalytics.SuspendLayout();
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
            this.tabExpert.Controls.Add(this.tabPageQuery);
            this.tabExpert.Controls.Add(this.tabPageAnalytics);
            this.tabExpert.Location = new System.Drawing.Point(12, 131);
            this.tabExpert.Name = "tabExpert";
            this.tabExpert.SelectedIndex = 0;
            this.tabExpert.Size = new System.Drawing.Size(517, 364);
            this.tabExpert.TabIndex = 1;
            // 
            // tabPageQuery
            // 
            this.tabPageQuery.Controls.Add(this.btnGet);
            this.tabPageQuery.Controls.Add(this.txtLanguage);
            this.tabPageQuery.Controls.Add(this.txtExtension);
            this.tabPageQuery.Controls.Add(this.txtHashSha256);
            this.tabPageQuery.Controls.Add(this.txtHashHead32);
            this.tabPageQuery.Controls.Add(this.txtHashCrc32);
            this.tabPageQuery.Controls.Add(this.txtHashSha1);
            this.tabPageQuery.Controls.Add(this.txtHashMd5);
            this.tabPageQuery.Controls.Add(this.label7);
            this.tabPageQuery.Controls.Add(this.label6);
            this.tabPageQuery.Controls.Add(this.label5);
            this.tabPageQuery.Controls.Add(this.label4);
            this.tabPageQuery.Controls.Add(this.label3);
            this.tabPageQuery.Controls.Add(this.label2);
            this.tabPageQuery.Controls.Add(this.label1);
            this.tabPageQuery.Location = new System.Drawing.Point(4, 22);
            this.tabPageQuery.Name = "tabPageQuery";
            this.tabPageQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageQuery.Size = new System.Drawing.Size(509, 338);
            this.tabPageQuery.TabIndex = 0;
            this.tabPageQuery.Text = "Query";
            this.tabPageQuery.UseVisualStyleBackColor = true;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(33, 280);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "Do Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Language";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Extension";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "SHA256";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "HEAD32";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "CRC32";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "SHA1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "MD5";
            // 
            // tabPageAnalytics
            // 
            this.tabPageAnalytics.Controls.Add(this.btnAnalyze);
            this.tabPageAnalytics.Controls.Add(this.txtAnalytics);
            this.tabPageAnalytics.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnalytics.Name = "tabPageAnalytics";
            this.tabPageAnalytics.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnalytics.Size = new System.Drawing.Size(509, 338);
            this.tabPageAnalytics.TabIndex = 7;
            this.tabPageAnalytics.Text = "Analytics";
            this.tabPageAnalytics.UseVisualStyleBackColor = true;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(6, 6);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(497, 33);
            this.btnAnalyze.TabIndex = 1;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // txtAnalytics
            // 
            this.txtAnalytics.Location = new System.Drawing.Point(6, 45);
            this.txtAnalytics.Multiline = true;
            this.txtAnalytics.Name = "txtAnalytics";
            this.txtAnalytics.Size = new System.Drawing.Size(497, 287);
            this.txtAnalytics.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnLogin.Image = global::CatswordsTab.Server.Properties.Resources.iconsdb_white_account_login_32;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.Location = new System.Drawing.Point(398, 59);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(127, 40);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // CatswordsTabExpert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::CatswordsTab.Server.Properties.Resources.iconfinder_shining_mix_wrench_1059388;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(557, 524);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tabExpert);
            this.Controls.Add(this.labelTitle);
            this.Icon = global::CatswordsTab.Server.Properties.Resources.icon_icons_retro_flower_fire_2_24692;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatswordsTabExpert";
            this.Text = "CatswordsTabExpert";
            this.Load += new System.EventHandler(this.CatswordsTabExpert_Load);
            this.tabExpert.ResumeLayout(false);
            this.tabPageQuery.ResumeLayout(false);
            this.tabPageQuery.PerformLayout();
            this.tabPageAnalytics.ResumeLayout(false);
            this.tabPageAnalytics.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabControl tabExpert;
        private System.Windows.Forms.TabPage tabPageQuery;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.TextBox txtHashSha256;
        private System.Windows.Forms.TextBox txtHashHead32;
        private System.Windows.Forms.TextBox txtHashCrc32;
        private System.Windows.Forms.TextBox txtHashSha1;
        private System.Windows.Forms.TextBox txtHashMd5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.TabPage tabPageAnalytics;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.TextBox txtAnalytics;
    }
}