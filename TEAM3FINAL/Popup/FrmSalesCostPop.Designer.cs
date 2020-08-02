namespace TEAM3FINAL
{
    partial class FrmSalesCostPop
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
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.cboItem = new System.Windows.Forms.ComboBox();
            this.txtExPrice = new System.Windows.Forms.TextBox();
            this.txtMDFDate = new System.Windows.Forms.TextBox();
            this.txtNowPrice = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.cboUseYN = new System.Windows.Forms.ComboBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
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
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.Text = "영업단가";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(31, 481);
            this.label2.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(215, 403);
            this.btnOK.Text = "저장";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(332, 403);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtEndDate);
            this.panel2.Controls.Add(this.cboItem);
            this.panel2.Controls.Add(this.txtExPrice);
            this.panel2.Controls.Add(this.txtMDFDate);
            this.panel2.Controls.Add(this.txtNowPrice);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label25);
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.dtpStartDate);
            this.panel2.Controls.Add(this.cboCompany);
            this.panel2.Controls.Add(this.cboUseYN);
            this.panel2.Controls.Add(this.txtRemark);
            this.panel2.Controls.Add(this.label32);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label31);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(5, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 374);
            this.panel2.TabIndex = 130;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtEndDate.Location = new System.Drawing.Point(419, 97);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.ReadOnly = true;
            this.txtEndDate.Size = new System.Drawing.Size(121, 23);
            this.txtEndDate.TabIndex = 5;
            this.txtEndDate.Text = "2099-12-31";
            // 
            // cboItem
            // 
            this.cboItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItem.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboItem.FormattingEnabled = true;
            this.cboItem.Location = new System.Drawing.Point(419, 22);
            this.cboItem.Name = "cboItem";
            this.cboItem.Size = new System.Drawing.Size(121, 23);
            this.cboItem.TabIndex = 1;
            // 
            // txtExPrice
            // 
            this.txtExPrice.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtExPrice.Location = new System.Drawing.Point(419, 60);
            this.txtExPrice.Name = "txtExPrice";
            this.txtExPrice.Size = new System.Drawing.Size(121, 23);
            this.txtExPrice.TabIndex = 3;
            this.txtExPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSTARTTIME_KeyPress);
            // 
            // txtMDFDate
            // 
            this.txtMDFDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMDFDate.Location = new System.Drawing.Point(154, 174);
            this.txtMDFDate.Name = "txtMDFDate";
            this.txtMDFDate.ReadOnly = true;
            this.txtMDFDate.Size = new System.Drawing.Size(121, 23);
            this.txtMDFDate.TabIndex = 7;
            // 
            // txtNowPrice
            // 
            this.txtNowPrice.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtNowPrice.Location = new System.Drawing.Point(154, 63);
            this.txtNowPrice.Name = "txtNowPrice";
            this.txtNowPrice.Size = new System.Drawing.Size(121, 23);
            this.txtNowPrice.TabIndex = 2;
            this.txtNowPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSTARTTIME_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(299, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 15);
            this.label10.TabIndex = 160;
            this.label10.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(58, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 158;
            this.label6.Text = "사용여부";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(34, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 15);
            this.label9.TabIndex = 159;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(323, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 157;
            this.label8.Text = "품목";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.Location = new System.Drawing.Point(57, 221);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 15);
            this.label23.TabIndex = 155;
            this.label23.Text = "비고";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label25.Location = new System.Drawing.Point(33, 219);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(12, 15);
            this.label25.TabIndex = 156;
            this.label25.Text = "*";
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCode.Location = new System.Drawing.Point(419, 134);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(121, 23);
            this.txtCode.TabIndex = 127;
            this.txtCode.Visible = false;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpStartDate.Location = new System.Drawing.Point(154, 100);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(121, 23);
            this.dtpStartDate.TabIndex = 4;
            // 
            // cboCompany
            // 
            this.cboCompany.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(154, 22);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(121, 23);
            this.cboCompany.TabIndex = 0;
            // 
            // cboUseYN
            // 
            this.cboUseYN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUseYN.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboUseYN.FormattingEnabled = true;
            this.cboUseYN.Items.AddRange(new object[] {
            "사용",
            "미사용"});
            this.cboUseYN.Location = new System.Drawing.Point(154, 137);
            this.cboUseYN.Name = "cboUseYN";
            this.cboUseYN.Size = new System.Drawing.Size(121, 23);
            this.cboUseYN.TabIndex = 6;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemark.Location = new System.Drawing.Point(154, 218);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(386, 109);
            this.txtRemark.TabIndex = 8;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label32.Location = new System.Drawing.Point(57, 177);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(43, 15);
            this.label32.TabIndex = 139;
            this.label32.Text = "수정일";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(57, 105);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 15);
            this.label19.TabIndex = 140;
            this.label19.Text = "시작일";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(323, 103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 15);
            this.label17.TabIndex = 140;
            this.label17.Text = "종료일";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(33, 103);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(12, 15);
            this.label18.TabIndex = 148;
            this.label18.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(323, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 15);
            this.label15.TabIndex = 140;
            this.label15.Text = "이전단가";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(299, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(12, 15);
            this.label16.TabIndex = 148;
            this.label16.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label13.Location = new System.Drawing.Point(57, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 15);
            this.label13.TabIndex = 140;
            this.label13.Text = "현재단가";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(299, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(12, 15);
            this.label14.TabIndex = 148;
            this.label14.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(33, 67);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 15);
            this.label12.TabIndex = 148;
            this.label12.Text = "*";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label31.Location = new System.Drawing.Point(33, 175);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(12, 15);
            this.label31.TabIndex = 149;
            this.label31.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label22.Location = new System.Drawing.Point(323, 137);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 15);
            this.label22.TabIndex = 141;
            this.label22.Text = "영업단가코드";
            this.label22.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(57, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 141;
            this.label11.Text = "업체";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(33, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 15);
            this.label3.TabIndex = 153;
            this.label3.Text = "*";
            // 
            // FrmSalesCostPop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(590, 446);
            this.Controls.Add(this.panel2);
            this.Name = "FrmSalesCostPop";
            this.Load += new System.EventHandler(this.FrmSalesCostPop_Load);
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
        private System.Windows.Forms.TextBox txtEndDate;
        private System.Windows.Forms.ComboBox cboItem;
        private System.Windows.Forms.TextBox txtExPrice;
        private System.Windows.Forms.TextBox txtMDFDate;
        private System.Windows.Forms.TextBox txtNowPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.ComboBox cboUseYN;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
    }
}
