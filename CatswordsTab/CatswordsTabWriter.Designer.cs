﻿namespace CatswordsTab
{
    partial class CatswordsTabWriter
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
            this.labelMessage = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.cbPrivacy = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Location = new System.Drawing.Point(77, 43);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(56, 12);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "labelTitle";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(26, 137);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(85, 12);
            this.labelMessage.TabIndex = 8;
            this.labelMessage.Text = "labelMessage";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(28, 155);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(358, 97);
            this.txtMessage.TabIndex = 9;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSend.Image = global::CatswordsTab.Properties.Resources.IconCheck32;
            this.btnSend.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSend.Location = new System.Drawing.Point(259, 43);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(127, 40);
            this.btnSend.TabIndex = 14;
            this.btnSend.Text = "btnSend";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cbPrivacy
            // 
            this.cbPrivacy.AutoSize = true;
            this.cbPrivacy.Location = new System.Drawing.Point(28, 272);
            this.cbPrivacy.Name = "cbPrivacy";
            this.cbPrivacy.Size = new System.Drawing.Size(80, 16);
            this.cbPrivacy.TabIndex = 17;
            this.cbPrivacy.Text = "cbPrivacy";
            this.cbPrivacy.UseVisualStyleBackColor = true;
            // 
            // CatswordsTabWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::CatswordsTab.Properties.Resources.iconPencli128;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(420, 316);
            this.Controls.Add(this.cbPrivacy);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelTitle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatswordsTabWriter";
            this.Text = "CatswordTabWriter";
            this.Load += new System.EventHandler(this.CatswordsTabWriter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckBox cbPrivacy;
    }
}