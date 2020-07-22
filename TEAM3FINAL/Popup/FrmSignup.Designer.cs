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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.cboDept = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(530, 56);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 17);
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.Text = "회원가입";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(714, 75);
            this.label2.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.btnOK.Location = new System.Drawing.Point(177, 405);
            this.btnOK.Size = new System.Drawing.Size(92, 35);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.btnCancel.Location = new System.Drawing.Point(272, 405);
            this.btnCancel.Size = new System.Drawing.Size(92, 35);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(105, 346);
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
            this.label11.Location = new System.Drawing.Point(86, 294);
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
            this.label13.Location = new System.Drawing.Point(105, 242);
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
            this.label14.Location = new System.Drawing.Point(23, 190);
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
            this.label15.Location = new System.Drawing.Point(67, 138);
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
            this.회원ID.Location = new System.Drawing.Point(72, 86);
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
            this.btnIDCheck.Location = new System.Drawing.Point(354, 80);
            this.btnIDCheck.Name = "btnIDCheck";
            this.btnIDCheck.Size = new System.Drawing.Size(108, 37);
            this.btnIDCheck.TabIndex = 41;
            this.btnIDCheck.Text = "중복확인";
            this.btnIDCheck.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.textBox1.Location = new System.Drawing.Point(177, 83);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 32);
            this.textBox1.TabIndex = 42;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.textBox2.Location = new System.Drawing.Point(177, 135);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(162, 32);
            this.textBox2.TabIndex = 42;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.textBox3.Location = new System.Drawing.Point(177, 183);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(162, 32);
            this.textBox3.TabIndex = 42;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.textBox4.Location = new System.Drawing.Point(177, 239);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(162, 32);
            this.textBox4.TabIndex = 42;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.textBox5.Location = new System.Drawing.Point(177, 291);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(285, 32);
            this.textBox5.TabIndex = 42;
            // 
            // cboDept
            // 
            this.cboDept.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.cboDept.FormattingEnabled = true;
            this.cboDept.Location = new System.Drawing.Point(177, 343);
            this.cboDept.Name = "cboDept";
            this.cboDept.Size = new System.Drawing.Size(162, 33);
            this.cboDept.TabIndex = 43;
            // 
            // FrmSignup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(540, 470);
            this.Controls.Add(this.cboDept);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnIDCheck);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.회원ID);
            this.Name = "FrmSignup";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.회원ID, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.btnIDCheck, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.textBox3, 0);
            this.Controls.SetChildIndex(this.textBox4, 0);
            this.Controls.SetChildIndex(this.textBox5, 0);
            this.Controls.SetChildIndex(this.cboDept, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox cboDept;
    }
}
