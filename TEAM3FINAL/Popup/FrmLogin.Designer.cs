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
            this.btnSignup = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Size = new System.Drawing.Size(400, 56);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 17);
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.Text = "로그인";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 66);
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 200;
            this.label2.Text = "ID";
            this.label2.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Image = global::TEAM3FINAL.Properties.Resources.import_24px;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(100, 275);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnOK.Size = new System.Drawing.Size(200, 52);
            this.btnOK.Text = "로그인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(254, 338);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btnCancel.Size = new System.Drawing.Size(46, 29);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "종료";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ptxtPswd
            // 
            this.ptxtPswd.BackColor = System.Drawing.SystemColors.Control;
            this.ptxtPswd.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Italic);
            this.ptxtPswd.ForeColor = System.Drawing.Color.Gray;
            this.ptxtPswd.Location = new System.Drawing.Point(75, 194);
            this.ptxtPswd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ptxtPswd.Name = "ptxtPswd";
            this.ptxtPswd.PlaceHolderText = "PASSWORD";
            this.ptxtPswd.Size = new System.Drawing.Size(250, 39);
            this.ptxtPswd.TabIndex = 1;
            this.ptxtPswd.Text = "PASSWORD";
            this.ptxtPswd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ptxtPswd.TextChanged += new System.EventHandler(this.ptxtPswd_TextChanged);
            this.ptxtPswd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ptxtPswd_KeyDown);
            this.ptxtPswd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ptxtID_KeyPress);
            this.ptxtPswd.Leave += new System.EventHandler(this.ptxtPswd_Leave);
            // 
            // ptxtID
            // 
            this.ptxtID.BackColor = System.Drawing.SystemColors.Control;
            this.ptxtID.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Italic);
            this.ptxtID.ForeColor = System.Drawing.Color.Gray;
            this.ptxtID.Location = new System.Drawing.Point(75, 126);
            this.ptxtID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ptxtID.Name = "ptxtID";
            this.ptxtID.PlaceHolderText = "ID";
            this.ptxtID.Size = new System.Drawing.Size(250, 39);
            this.ptxtID.TabIndex = 0;
            this.ptxtID.Text = "ID";
            this.ptxtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ptxtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ptxtID_KeyDown);
            this.ptxtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ptxtID_KeyPress);
            // 
            // btnSignup
            // 
            this.btnSignup.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSignup.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSignup.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSignup.Location = new System.Drawing.Point(176, 338);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(72, 29);
            this.btnSignup.TabIndex = 3;
            this.btnSignup.Text = "회원가입";
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Location = new System.Drawing.Point(75, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 5);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Location = new System.Drawing.Point(75, 231);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 5);
            this.panel3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(71, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 20);
            this.label3.TabIndex = 201;
            this.label3.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(71, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 201;
            this.label4.Text = "Password";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(400, 428);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSignup);
            this.Controls.Add(this.ptxtPswd);
            this.Controls.Add(this.ptxtID);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FrmLogin";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.Controls.SetChildIndex(this.ptxtID, 0);
            this.Controls.SetChildIndex(this.ptxtPswd, 0);
            this.Controls.SetChildIndex(this.btnSignup, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectPC.PlaceHolderTextBox ptxtPswd;
        private ProjectPC.PlaceHolderTextBox ptxtID;
        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
