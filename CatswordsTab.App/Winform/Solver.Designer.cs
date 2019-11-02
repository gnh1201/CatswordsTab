namespace CatswordsTab.App.Winform
{
    partial class Solver
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
            this.btnSolve = new System.Windows.Forms.Button();
            this.txtManifestFilename = new System.Windows.Forms.TextBox();
            this.labelManifest = new System.Windows.Forms.Label();
            this.btnOpenManifest = new System.Windows.Forms.Button();
            this.labelExport = new System.Windows.Forms.Label();
            this.txtExportFilename = new System.Windows.Forms.TextBox();
            this.btnOpenExport = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(73, 72);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(90, 37);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Solver";
            // 
            // btnSolve
            // 
            this.btnSolve.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSolve.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSolve.FlatAppearance.BorderSize = 0;
            this.btnSolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolve.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnSolve.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSolve.Image = global::CatswordsTab.App.Properties.Resources.iconsdb_white_check_mark_3_32;
            this.btnSolve.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSolve.Location = new System.Drawing.Point(310, 66);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(109, 43);
            this.btnSolve.TabIndex = 15;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = false;
            this.btnSolve.Click += new System.EventHandler(this.OnClick_BtnSolve);
            // 
            // txtManifestFilename
            // 
            this.txtManifestFilename.Location = new System.Drawing.Point(108, 148);
            this.txtManifestFilename.Name = "txtManifestFilename";
            this.txtManifestFilename.Size = new System.Drawing.Size(230, 20);
            this.txtManifestFilename.TabIndex = 16;
            this.txtManifestFilename.Click += new System.EventHandler(this.OnClick_txtManifestFilename);
            // 
            // labelManifest
            // 
            this.labelManifest.AutoSize = true;
            this.labelManifest.Location = new System.Drawing.Point(25, 151);
            this.labelManifest.Name = "labelManifest";
            this.labelManifest.Size = new System.Drawing.Size(63, 13);
            this.labelManifest.TabIndex = 17;
            this.labelManifest.Text = "Manifest file";
            // 
            // btnOpenManifest
            // 
            this.btnOpenManifest.Location = new System.Drawing.Point(344, 147);
            this.btnOpenManifest.Name = "btnOpenManifest";
            this.btnOpenManifest.Size = new System.Drawing.Size(75, 23);
            this.btnOpenManifest.TabIndex = 18;
            this.btnOpenManifest.Text = "Choose...";
            this.btnOpenManifest.UseVisualStyleBackColor = true;
            this.btnOpenManifest.Click += new System.EventHandler(this.OnClick_btnOpenManifest);
            // 
            // labelExport
            // 
            this.labelExport.AutoSize = true;
            this.labelExport.Location = new System.Drawing.Point(25, 184);
            this.labelExport.Name = "labelExport";
            this.labelExport.Size = new System.Drawing.Size(49, 13);
            this.labelExport.TabIndex = 19;
            this.labelExport.Text = "Export to";
            // 
            // txtExportFilename
            // 
            this.txtExportFilename.Location = new System.Drawing.Point(108, 181);
            this.txtExportFilename.Name = "txtExportFilename";
            this.txtExportFilename.Size = new System.Drawing.Size(230, 20);
            this.txtExportFilename.TabIndex = 16;
            this.txtExportFilename.Click += new System.EventHandler(this.OnClick_txtExportFilename);
            // 
            // btnOpenExport
            // 
            this.btnOpenExport.Location = new System.Drawing.Point(344, 179);
            this.btnOpenExport.Name = "btnOpenExport";
            this.btnOpenExport.Size = new System.Drawing.Size(75, 23);
            this.btnOpenExport.TabIndex = 18;
            this.btnOpenExport.Text = "Choose...";
            this.btnOpenExport.UseVisualStyleBackColor = true;
            this.btnOpenExport.Click += new System.EventHandler(this.OnClick_btnOpenExport);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(25, 220);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(161, 13);
            this.linkLabel1.TabIndex = 20;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Download manifest file (Solver)...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnClick_LinkLabel1);
            // 
            // Solver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::CatswordsTab.App.Properties.Resources.iconfinder_simpline_24_2305594;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(449, 254);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.labelExport);
            this.Controls.Add(this.btnOpenExport);
            this.Controls.Add(this.btnOpenManifest);
            this.Controls.Add(this.labelManifest);
            this.Controls.Add(this.txtExportFilename);
            this.Controls.Add(this.txtManifestFilename);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Solver";
            this.Text = "CatswordsTabSolver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.TextBox txtManifestFilename;
        private System.Windows.Forms.Label labelManifest;
        private System.Windows.Forms.Button btnOpenManifest;
        private System.Windows.Forms.Label labelExport;
        private System.Windows.Forms.TextBox txtExportFilename;
        private System.Windows.Forms.Button btnOpenExport;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}