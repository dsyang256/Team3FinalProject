namespace TEAM3FINAL
{
    partial class FrmSignup
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
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.회원ID = new System.Windows.Forms.Label();
            this.btnIDCheck = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtPwdCheck = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEML = new System.Windows.Forms.TextBox();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.pnlContents = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.pnlContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(554, 56);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 17);
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.Text = "회원가입";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1057, 441);
            this.label2.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.btnOK.Location = new System.Drawing.Point(184, 400);
            this.btnOK.Size = new System.Drawing.Size(92, 35);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.btnCancel.Location = new System.Drawing.Point(279, 400);
            this.btnCancel.Size = new System.Drawing.Size(92, 35);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(119, 283);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 25);
            this.label10.TabIndex = 36;
            this.label10.Text = "부서";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(100, 231);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 25);
            this.label11.TabIndex = 35;
            this.label11.Text = "이메일";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(119, 179);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 25);
            this.label13.TabIndex = 38;
            this.label13.Text = "이름";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(37, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 25);
            this.label14.TabIndex = 39;
            this.label14.Text = "비밀번호 확인";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(81, 75);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 25);
            this.label15.TabIndex = 40;
            this.label15.Text = "비밀번호";
            // 
            // 회원ID
            // 
            this.회원ID.AutoSize = true;
            this.회원ID.BackColor = System.Drawing.Color.Transparent;
            this.회원ID.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.회원ID.Location = new System.Drawing.Point(86, 23);
            this.회원ID.Name = "회원ID";
            this.회원ID.Size = new System.Drawing.Size(88, 25);
            this.회원ID.TabIndex = 34;
            this.회원ID.Text = "관리자ID";
            // 
            // btnIDCheck
            // 
            this.btnIDCheck.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnIDCheck.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.btnIDCheck.ForeColor = System.Drawing.SystemColors.Window;
            this.btnIDCheck.Location = new System.Drawing.Point(368, 17);
            this.btnIDCheck.Name = "btnIDCheck";
            this.btnIDCheck.Size = new System.Drawing.Size(108, 37);
            this.btnIDCheck.TabIndex = 41;
            this.btnIDCheck.Text = "중복확인";
            this.btnIDCheck.UseVisualStyleBackColor = false;
            this.btnIDCheck.Click += new System.EventHandler(this.btnStdCheck_Click);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.txtID.Location = new System.Drawing.Point(191, 20);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(162, 32);
            this.txtID.TabIndex = 42;
            this.txtID.Tag = "ID";
            this.txtID.TextChanged += new System.EventHandler(this.txtID_TextChanged);
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.txtPwd.Location = new System.Drawing.Point(191, 72);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(162, 32);
            this.txtPwd.TabIndex = 42;
            this.txtPwd.Tag = "비밀번호";
            // 
            // txtPwdCheck
            // 
            this.txtPwdCheck.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.txtPwdCheck.Location = new System.Drawing.Point(191, 120);
            this.txtPwdCheck.Name = "txtPwdCheck";
            this.txtPwdCheck.PasswordChar = '*';
            this.txtPwdCheck.Size = new System.Drawing.Size(162, 32);
            this.txtPwdCheck.TabIndex = 42;
            this.txtPwdCheck.Tag = "비밀번호확인";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.txtName.Location = new System.Drawing.Point(191, 176);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 32);
            this.txtName.TabIndex = 42;
            this.txtName.Tag = "이름";
            // 
            // txtEML
            // 
            this.txtEML.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.txtEML.Location = new System.Drawing.Point(191, 228);
            this.txtEML.Name = "txtEML";
            this.txtEML.Size = new System.Drawing.Size(285, 32);
            this.txtEML.TabIndex = 42;
            this.txtEML.Tag = "이메일";
            // 
            // cboDept
            // 
            this.cboDept.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(191, 280);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(162, 33);
            this.cboDept.TabIndex = 43;
            // 
            // pnlContents
            // 
            this.pnlContents.Controls.Add(this.회원ID);
            this.pnlContents.Controls.Add(this.label15);
            this.pnlContents.Controls.Add(this.label14);
            this.pnlContents.Controls.Add(this.label13);
            this.pnlContents.Controls.Add(this.label11);
            this.pnlContents.Controls.Add(this.cboDept);
            this.pnlContents.Controls.Add(this.label10);
            this.pnlContents.Controls.Add(this.txtEML);
            this.pnlContents.Controls.Add(this.btnIDCheck);
            this.pnlContents.Controls.Add(this.txtName);
            this.pnlContents.Controls.Add(this.txtID);
            this.pnlContents.Controls.Add(this.txtPwdCheck);
            this.pnlContents.Controls.Add(this.txtPwd);
            this.pnlContents.Location = new System.Drawing.Point(5, 68);
            this.pnlContents.Name = "pnlContents";
            this.pnlContents.Size = new System.Drawing.Size(543, 325);
            this.pnlContents.TabIndex = 44;
            // 
            // FrmSignup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(554, 442);
            this.Controls.Add(this.pnlContents);
            this.Name = "FrmSignup";
            this.Load += new System.EventHandler(this.FrmSignup_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.pnlContents, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlContents.ResumeLayout(false);
            this.pnlContents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label 회원ID;
        private System.Windows.Forms.Button btnIDCheck;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtPwdCheck;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEML;
        private System.Windows.Forms.ComboBox cboDept;
        private System.Windows.Forms.Panel pnlContents;
    }
}
