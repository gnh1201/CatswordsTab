namespace CatswordsTab.App
{
    partial class Main
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnWriter = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.txtTerminal = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnWriter
            // 
            this.btnWriter.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnWriter.FlatAppearance.BorderSize = 0;
            this.btnWriter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWriter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWriter.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnWriter.Image = global::CatswordsTab.App.Properties.Resources.icondb_white_edit_32;
            this.btnWriter.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWriter.Location = new System.Drawing.Point(254, 49);
            this.btnWriter.Name = "btnWriter";
            this.btnWriter.Size = new System.Drawing.Size(127, 40);
            this.btnWriter.TabIndex = 1;
            this.btnWriter.Text = "btnWriter";
            this.btnWriter.UseVisualStyleBackColor = false;
            this.btnWriter.Click += new System.EventHandler(this.OnClick_btnWriter);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(44, 52);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(126, 37);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "labelTitle";
            this.labelTitle.DoubleClick += new System.EventHandler(this.OnDblClick_labelTitle);
            // 
            // txtTerminal
            // 
            this.txtTerminal.BackColor = System.Drawing.SystemColors.Window;
            this.txtTerminal.Enabled = false;
            this.txtTerminal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTerminal.Location = new System.Drawing.Point(15, 122);
            this.txtTerminal.Multiline = true;
            this.txtTerminal.Name = "txtTerminal";
            this.txtTerminal.ReadOnly = true;
            this.txtTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTerminal.Size = new System.Drawing.Size(366, 335);
            this.txtTerminal.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(245, 460);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(136, 12);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://catswords.com";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::CatswordsTab.App.Properties.Resources.iconfinder_simpline_45_2305617;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(395, 488);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtTerminal);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnWriter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "CatswordsTabMain";
            this.Load += new System.EventHandler(this.OnLoad_Main);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_Main);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnWriter;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox txtTerminal;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
