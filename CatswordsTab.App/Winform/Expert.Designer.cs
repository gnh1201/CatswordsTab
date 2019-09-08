namespace CatswordsTab.App.Winform
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtLocale = new System.Windows.Forms.TextBox();
            this.txtExtension = new System.Windows.Forms.TextBox();
            this.txtHashSha256 = new System.Windows.Forms.TextBox();
            this.txtHashHead32 = new System.Windows.Forms.TextBox();
            this.txtHashCrc32 = new System.Windows.Forms.TextBox();
            this.txtHashSha1 = new System.Windows.Forms.TextBox();
            this.txtHashMd5 = new System.Windows.Forms.TextBox();
            this.labelLocale = new System.Windows.Forms.Label();
            this.labelExtension = new System.Windows.Forms.Label();
            this.labelSha256 = new System.Windows.Forms.Label();
            this.labelHead32 = new System.Windows.Forms.Label();
            this.labelCrc32 = new System.Windows.Forms.Label();
            this.labelSha1 = new System.Windows.Forms.Label();
            this.labelMd5 = new System.Windows.Forms.Label();
            this.labelInfoHash = new System.Windows.Forms.Label();
            this.txtInfoHash = new System.Windows.Forms.TextBox();
            this.btnOpenSolver = new System.Windows.Forms.Button();
            this.btnOpenApplication = new System.Windows.Forms.Button();
            this.btnOpenAssociation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(105, 63);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(91, 37);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Expert";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSubmit.Image = global::CatswordsTab.App.Properties.Resources.iconsdb_white_check_mark_3_32;
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSubmit.Location = new System.Drawing.Point(303, 60);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(109, 43);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.OnClick_btnSubmit);
            // 
            // txtLocale
            // 
            this.txtLocale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocale.Location = new System.Drawing.Point(129, 403);
            this.txtLocale.Name = "txtLocale";
            this.txtLocale.Size = new System.Drawing.Size(284, 23);
            this.txtLocale.TabIndex = 1;
            // 
            // txtExtension
            // 
            this.txtExtension.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtension.Location = new System.Drawing.Point(129, 332);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(284, 23);
            this.txtExtension.TabIndex = 1;
            // 
            // txtHashSha256
            // 
            this.txtHashSha256.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHashSha256.Location = new System.Drawing.Point(129, 296);
            this.txtHashSha256.Name = "txtHashSha256";
            this.txtHashSha256.Size = new System.Drawing.Size(284, 23);
            this.txtHashSha256.TabIndex = 1;
            // 
            // txtHashHead32
            // 
            this.txtHashHead32.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHashHead32.Location = new System.Drawing.Point(129, 260);
            this.txtHashHead32.Name = "txtHashHead32";
            this.txtHashHead32.Size = new System.Drawing.Size(284, 23);
            this.txtHashHead32.TabIndex = 1;
            // 
            // txtHashCrc32
            // 
            this.txtHashCrc32.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHashCrc32.Location = new System.Drawing.Point(129, 224);
            this.txtHashCrc32.Name = "txtHashCrc32";
            this.txtHashCrc32.Size = new System.Drawing.Size(284, 23);
            this.txtHashCrc32.TabIndex = 1;
            // 
            // txtHashSha1
            // 
            this.txtHashSha1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHashSha1.Location = new System.Drawing.Point(129, 190);
            this.txtHashSha1.Name = "txtHashSha1";
            this.txtHashSha1.Size = new System.Drawing.Size(284, 23);
            this.txtHashSha1.TabIndex = 1;
            // 
            // txtHashMd5
            // 
            this.txtHashMd5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHashMd5.Location = new System.Drawing.Point(129, 156);
            this.txtHashMd5.Name = "txtHashMd5";
            this.txtHashMd5.Size = new System.Drawing.Size(284, 23);
            this.txtHashMd5.TabIndex = 1;
            // 
            // labelLocale
            // 
            this.labelLocale.AutoSize = true;
            this.labelLocale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocale.Location = new System.Drawing.Point(30, 407);
            this.labelLocale.Name = "labelLocale";
            this.labelLocale.Size = new System.Drawing.Size(41, 15);
            this.labelLocale.TabIndex = 0;
            this.labelLocale.Text = "Locale";
            // 
            // labelExtension
            // 
            this.labelExtension.AutoSize = true;
            this.labelExtension.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExtension.Location = new System.Drawing.Point(30, 335);
            this.labelExtension.Name = "labelExtension";
            this.labelExtension.Size = new System.Drawing.Size(57, 15);
            this.labelExtension.TabIndex = 0;
            this.labelExtension.Text = "Extension";
            // 
            // labelSha256
            // 
            this.labelSha256.AutoSize = true;
            this.labelSha256.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSha256.Location = new System.Drawing.Point(30, 299);
            this.labelSha256.Name = "labelSha256";
            this.labelSha256.Size = new System.Drawing.Size(48, 15);
            this.labelSha256.TabIndex = 0;
            this.labelSha256.Text = "SHA256";
            // 
            // labelHead32
            // 
            this.labelHead32.AutoSize = true;
            this.labelHead32.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHead32.Location = new System.Drawing.Point(30, 263);
            this.labelHead32.Name = "labelHead32";
            this.labelHead32.Size = new System.Drawing.Size(50, 15);
            this.labelHead32.TabIndex = 0;
            this.labelHead32.Text = "HEAD32";
            // 
            // labelCrc32
            // 
            this.labelCrc32.AutoSize = true;
            this.labelCrc32.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCrc32.Location = new System.Drawing.Point(30, 228);
            this.labelCrc32.Name = "labelCrc32";
            this.labelCrc32.Size = new System.Drawing.Size(42, 15);
            this.labelCrc32.TabIndex = 0;
            this.labelCrc32.Text = "CRC32";
            // 
            // labelSha1
            // 
            this.labelSha1.AutoSize = true;
            this.labelSha1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSha1.Location = new System.Drawing.Point(30, 193);
            this.labelSha1.Name = "labelSha1";
            this.labelSha1.Size = new System.Drawing.Size(36, 15);
            this.labelSha1.TabIndex = 0;
            this.labelSha1.Text = "SHA1";
            // 
            // labelMd5
            // 
            this.labelMd5.AutoSize = true;
            this.labelMd5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMd5.Location = new System.Drawing.Point(30, 159);
            this.labelMd5.Name = "labelMd5";
            this.labelMd5.Size = new System.Drawing.Size(32, 15);
            this.labelMd5.TabIndex = 0;
            this.labelMd5.Text = "MD5";
            // 
            // labelInfoHash
            // 
            this.labelInfoHash.AutoSize = true;
            this.labelInfoHash.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoHash.Location = new System.Drawing.Point(30, 372);
            this.labelInfoHash.Name = "labelInfoHash";
            this.labelInfoHash.Size = new System.Drawing.Size(55, 15);
            this.labelInfoHash.TabIndex = 0;
            this.labelInfoHash.Text = "InfoHash";
            // 
            // txtInfoHash
            // 
            this.txtInfoHash.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInfoHash.Location = new System.Drawing.Point(129, 367);
            this.txtInfoHash.Name = "txtInfoHash";
            this.txtInfoHash.Size = new System.Drawing.Size(284, 23);
            this.txtInfoHash.TabIndex = 1;
            // 
            // btnOpenSolver
            // 
            this.btnOpenSolver.Location = new System.Drawing.Point(129, 449);
            this.btnOpenSolver.Name = "btnOpenSolver";
            this.btnOpenSolver.Size = new System.Drawing.Size(284, 23);
            this.btnOpenSolver.TabIndex = 3;
            this.btnOpenSolver.Text = "Open protection solver...";
            this.btnOpenSolver.UseVisualStyleBackColor = true;
            this.btnOpenSolver.Click += new System.EventHandler(this.OnClick_btnOpenSolver);
            // 
            // btnOpenApplication
            // 
            this.btnOpenApplication.Location = new System.Drawing.Point(129, 478);
            this.btnOpenApplication.Name = "btnOpenApplication";
            this.btnOpenApplication.Size = new System.Drawing.Size(284, 23);
            this.btnOpenApplication.TabIndex = 3;
            this.btnOpenApplication.Text = "View installed software...";
            this.btnOpenApplication.UseVisualStyleBackColor = true;
            this.btnOpenApplication.Click += new System.EventHandler(this.OnClick_btnOpenAppliance);
            // 
            // btnOpenAssociation
            // 
            this.btnOpenAssociation.Location = new System.Drawing.Point(129, 508);
            this.btnOpenAssociation.Name = "btnOpenAssociation";
            this.btnOpenAssociation.Size = new System.Drawing.Size(283, 23);
            this.btnOpenAssociation.TabIndex = 4;
            this.btnOpenAssociation.Text = "View file associations...";
            this.btnOpenAssociation.UseVisualStyleBackColor = true;
            this.btnOpenAssociation.Click += new System.EventHandler(this.OnClick_btnOpenAssociation);
            // 
            // Expert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::CatswordsTab.App.Properties.Resources.iconfinder_shining_mix_wrench_1059388;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(441, 555);
            this.Controls.Add(this.btnOpenAssociation);
            this.Controls.Add(this.btnOpenApplication);
            this.Controls.Add(this.btnOpenSolver);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtInfoHash);
            this.Controls.Add(this.txtLocale);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.txtHashSha256);
            this.Controls.Add(this.labelMd5);
            this.Controls.Add(this.txtHashHead32);
            this.Controls.Add(this.labelSha1);
            this.Controls.Add(this.txtHashCrc32);
            this.Controls.Add(this.labelCrc32);
            this.Controls.Add(this.txtHashSha1);
            this.Controls.Add(this.labelHead32);
            this.Controls.Add(this.txtHashMd5);
            this.Controls.Add(this.labelSha256);
            this.Controls.Add(this.labelInfoHash);
            this.Controls.Add(this.labelLocale);
            this.Controls.Add(this.labelExtension);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Expert";
            this.Text = "CatswordsTabExpert";
            this.Load += new System.EventHandler(this.OnLoad_Expert);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_Expert);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox txtLocale;
        private System.Windows.Forms.TextBox txtExtension;
        private System.Windows.Forms.TextBox txtHashSha256;
        private System.Windows.Forms.TextBox txtHashHead32;
        private System.Windows.Forms.TextBox txtHashCrc32;
        private System.Windows.Forms.TextBox txtHashSha1;
        private System.Windows.Forms.TextBox txtHashMd5;
        private System.Windows.Forms.Label labelLocale;
        private System.Windows.Forms.Label labelExtension;
        private System.Windows.Forms.Label labelSha256;
        private System.Windows.Forms.Label labelHead32;
        private System.Windows.Forms.Label labelCrc32;
        private System.Windows.Forms.Label labelSha1;
        private System.Windows.Forms.Label labelMd5;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label labelInfoHash;
        private System.Windows.Forms.TextBox txtInfoHash;
        private System.Windows.Forms.Button btnOpenSolver;
        private System.Windows.Forms.Button btnOpenApplication;
        private System.Windows.Forms.Button btnOpenAssociation;
    }
}