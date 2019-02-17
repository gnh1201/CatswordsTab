namespace CatswordsTab
{
    partial class CatswordsTabGodmode
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
            this.labelHashMd5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelHashSha1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelHashMd5
            // 
            this.labelHashMd5.AutoSize = true;
            this.labelHashMd5.Location = new System.Drawing.Point(82, 76);
            this.labelHashMd5.Name = "labelHashMd5";
            this.labelHashMd5.Size = new System.Drawing.Size(30, 12);
            this.labelHashMd5.TabIndex = 1;
            this.labelHashMd5.Text = "MD5";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 73);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(359, 21);
            this.textBox1.TabIndex = 2;
            // 
            // labelHashSha1
            // 
            this.labelHashSha1.AutoSize = true;
            this.labelHashSha1.Location = new System.Drawing.Point(77, 103);
            this.labelHashSha1.Name = "labelHashSha1";
            this.labelHashSha1.Size = new System.Drawing.Size(35, 12);
            this.labelHashSha1.TabIndex = 1;
            this.labelHashSha1.Text = "SHA1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(118, 100);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(359, 21);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hash MD5";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(118, 127);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(359, 21);
            this.textBox3.TabIndex = 2;
            // 
            // CatswordsTabGodmode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 435);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelHashSha1);
            this.Controls.Add(this.labelHashMd5);
            this.Name = "CatswordsTabGodmode";
            this.Text = "CatswordsTabGodmode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelHashMd5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelHashSha1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
    }
}