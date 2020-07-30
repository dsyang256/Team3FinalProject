namespace TEAM3FINAL
{
    partial class FrmGroupPop
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMDFDate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtRightName = new System.Windows.Forms.TextBox();
            this.txtRightID = new System.Windows.Forms.TextBox();
            this.cboRightgroup = new System.Windows.Forms.ComboBox();
            this.cboRightUseYN = new System.Windows.Forms.ComboBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(590, 56);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.Text = "Group";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(208, 327);
            this.btnOK.Text = "저장";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(319, 327);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtMDFDate);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.txtRightName);
            this.panel2.Controls.Add(this.txtRightID);
            this.panel2.Controls.Add(this.cboRightgroup);
            this.panel2.Controls.Add(this.cboRightUseYN);
            this.panel2.Controls.Add(this.txtRemark);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(5, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 304);
            this.panel2.TabIndex = 129;
            // 
            // txtMDFDate
            // 
            this.txtMDFDate.Location = new System.Drawing.Point(156, 95);
            this.txtMDFDate.Name = "txtMDFDate";
            this.txtMDFDate.ReadOnly = true;
            this.txtMDFDate.Size = new System.Drawing.Size(121, 23);
            this.txtMDFDate.TabIndex = 161;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(36, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 17);
            this.label10.TabIndex = 160;
            this.label10.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(325, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 158;
            this.label6.Text = "사용여부";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(301, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 17);
            this.label9.TabIndex = 159;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(60, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 157;
            this.label8.Text = "그룹명";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(59, 142);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 15);
            this.label23.TabIndex = 155;
            this.label23.Text = "설명";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label25.Location = new System.Drawing.Point(35, 140);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 17);
            this.label25.TabIndex = 156;
            this.label25.Text = "*";
            // 
            // txtRightName
            // 
            this.txtRightName.Location = new System.Drawing.Point(156, 60);
            this.txtRightName.MaxLength = 10;
            this.txtRightName.Name = "txtRightName";
            this.txtRightName.ReadOnly = true;
            this.txtRightName.Size = new System.Drawing.Size(121, 23);
            this.txtRightName.TabIndex = 132;
            // 
            // txtRightID
            // 
            this.txtRightID.Location = new System.Drawing.Point(421, 95);
            this.txtRightID.Name = "txtRightID";
            this.txtRightID.Size = new System.Drawing.Size(121, 23);
            this.txtRightID.TabIndex = 127;
            this.txtRightID.Visible = false;
            // 
            // cboRightgroup
            // 
            this.cboRightgroup.FormattingEnabled = true;
            this.cboRightgroup.Location = new System.Drawing.Point(156, 25);
            this.cboRightgroup.Name = "cboRightgroup";
            this.cboRightgroup.Size = new System.Drawing.Size(121, 23);
            this.cboRightgroup.TabIndex = 130;
            // 
            // cboRightUseYN
            // 
            this.cboRightUseYN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRightUseYN.FormattingEnabled = true;
            this.cboRightUseYN.Items.AddRange(new object[] {
            "사용",
            "미사용"});
            this.cboRightUseYN.Location = new System.Drawing.Point(421, 60);
            this.cboRightUseYN.Name = "cboRightUseYN";
            this.cboRightUseYN.Size = new System.Drawing.Size(121, 23);
            this.cboRightUseYN.TabIndex = 130;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(156, 139);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(386, 109);
            this.txtRemark.TabIndex = 136;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(59, 98);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(43, 15);
            this.label32.TabIndex = 139;
            this.label32.Text = "수정일";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label31.Location = new System.Drawing.Point(35, 96);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 17);
            this.label31.TabIndex = 149;
            this.label31.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label22.Location = new System.Drawing.Point(325, 98);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(57, 15);
            this.label22.TabIndex = 141;
            this.label22.Text = "RIGHT_ID";
            this.label22.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(59, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 15);
            this.label11.TabIndex = 141;
            this.label11.Text = "권한그룹";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(35, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 17);
            this.label3.TabIndex = 153;
            this.label3.Text = "*";
            // 
            // FrmGroupPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(590, 375);
            this.Controls.Add(this.panel2);
            this.Name = "FrmGroupPop";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMDFDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtRightName;
        private System.Windows.Forms.TextBox txtRightID;
        private System.Windows.Forms.ComboBox cboRightgroup;
        private System.Windows.Forms.ComboBox cboRightUseYN;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
    }
}
