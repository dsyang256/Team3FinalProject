namespace TEAM3FINAL
{
    partial class FrmLogin
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptxtPswd = new ProjectPC.PlaceHolderTextBox();
            this.ptxtID = new ProjectPC.PlaceHolderTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(390, 45);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.Text = "로그인";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 53);
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.Text = "ID";
            this.label2.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOK.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnOK.ForeColor = System.Drawing.SystemColors.Window;
            this.btnOK.Location = new System.Drawing.Point(100, 220);
            this.btnOK.Size = new System.Drawing.Size(200, 42);
            this.btnOK.Text = "로그인";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCancel.Font = new System.Drawing.Font("굴림", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCancel.Location = new System.Drawing.Point(240, 270);
            this.btnCancel.Size = new System.Drawing.Size(60, 23);
            this.btnCancel.Text = "종료";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ptxtPswd
            // 
            this.ptxtPswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic);
            this.ptxtPswd.ForeColor = System.Drawing.Color.Gray;
            this.ptxtPswd.Location = new System.Drawing.Point(75, 155);
            this.ptxtPswd.Name = "ptxtPswd";
            this.ptxtPswd.PlaceHolderText = "PASSWORD";
            this.ptxtPswd.Size = new System.Drawing.Size(250, 35);
            this.ptxtPswd.TabIndex = 4;
            this.ptxtPswd.Text = "PASSWORD";
            this.ptxtPswd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ptxtPswd.TextChanged += new System.EventHandler(this.ptxtPswd_TextChanged);
            this.ptxtPswd.Leave += new System.EventHandler(this.ptxtPswd_Leave);
            // 
            // ptxtID
            // 
            this.ptxtID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Italic);
            this.ptxtID.ForeColor = System.Drawing.Color.Gray;
            this.ptxtID.Location = new System.Drawing.Point(75, 105);
            this.ptxtID.Name = "ptxtID";
            this.ptxtID.PlaceHolderText = "ID";
            this.ptxtID.Size = new System.Drawing.Size(250, 35);
            this.ptxtID.TabIndex = 3;
            this.ptxtID.Text = "ID";
            this.ptxtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(400, 342);
            this.Controls.Add(this.ptxtPswd);
            this.Controls.Add(this.ptxtID);
            this.Name = "FrmLogin";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLogin_KeyDown);
            this.Controls.SetChildIndex(this.ptxtID, 0);
            this.Controls.SetChildIndex(this.ptxtPswd, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectPC.PlaceHolderTextBox ptxtPswd;
        private ProjectPC.PlaceHolderTextBox ptxtID;
    }
}
