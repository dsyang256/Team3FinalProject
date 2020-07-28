namespace TEAM3FINAL
{
    partial class FrmBOMPopUp
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
            this.BOM_LAST_MDFY = new System.Windows.Forms.DateTimePicker();
            this.BOM_STARTDATE = new System.Windows.Forms.DateTimePicker();
            this.BOM_ENDDATE = new System.Windows.Forms.DateTimePicker();
            this.ITEM_CODE = new System.Windows.Forms.ComboBox();
            this.BOM_USE_YN = new System.Windows.Forms.ComboBox();
            this.BOM_PLAN_YN = new System.Windows.Forms.ComboBox();
            this.BOM_AUTOREDUCE_YN = new System.Windows.Forms.ComboBox();
            this.BOM_PARENT_CODE = new System.Windows.Forms.ComboBox();
            this.BOM_REMARK = new System.Windows.Forms.TextBox();
            this.BOM_LAST_MDFR = new System.Windows.Forms.TextBox();
            this.BOM_QTY = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.Text = "BOM";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1, 544);
            this.label2.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(294, 520);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(406, 520);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.BOM_LAST_MDFY);
            this.panel2.Controls.Add(this.BOM_STARTDATE);
            this.panel2.Controls.Add(this.BOM_ENDDATE);
            this.panel2.Controls.Add(this.ITEM_CODE);
            this.panel2.Controls.Add(this.BOM_USE_YN);
            this.panel2.Controls.Add(this.BOM_PLAN_YN);
            this.panel2.Controls.Add(this.BOM_AUTOREDUCE_YN);
            this.panel2.Controls.Add(this.BOM_PARENT_CODE);
            this.panel2.Controls.Add(this.BOM_REMARK);
            this.panel2.Controls.Add(this.BOM_LAST_MDFR);
            this.panel2.Controls.Add(this.BOM_QTY);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(5, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(790, 428);
            this.panel2.TabIndex = 128;
            // 
            // BOM_LAST_MDFY
            // 
            this.BOM_LAST_MDFY.Location = new System.Drawing.Point(539, 176);
            this.BOM_LAST_MDFY.Name = "BOM_LAST_MDFY";
            this.BOM_LAST_MDFY.Size = new System.Drawing.Size(193, 23);
            this.BOM_LAST_MDFY.TabIndex = 68;
            // 
            // BOM_STARTDATE
            // 
            this.BOM_STARTDATE.Location = new System.Drawing.Point(539, 79);
            this.BOM_STARTDATE.Name = "BOM_STARTDATE";
            this.BOM_STARTDATE.Size = new System.Drawing.Size(193, 23);
            this.BOM_STARTDATE.TabIndex = 67;
            // 
            // BOM_ENDDATE
            // 
            this.BOM_ENDDATE.Location = new System.Drawing.Point(164, 128);
            this.BOM_ENDDATE.Name = "BOM_ENDDATE";
            this.BOM_ENDDATE.Size = new System.Drawing.Size(193, 23);
            this.BOM_ENDDATE.TabIndex = 66;
            // 
            // ITEM_CODE
            // 
            this.ITEM_CODE.FormattingEnabled = true;
            this.ITEM_CODE.Location = new System.Drawing.Point(539, 30);
            this.ITEM_CODE.Name = "ITEM_CODE";
            this.ITEM_CODE.Size = new System.Drawing.Size(193, 23);
            this.ITEM_CODE.TabIndex = 65;
            // 
            // BOM_USE_YN
            // 
            this.BOM_USE_YN.FormattingEnabled = true;
            this.BOM_USE_YN.Location = new System.Drawing.Point(539, 128);
            this.BOM_USE_YN.Name = "BOM_USE_YN";
            this.BOM_USE_YN.Size = new System.Drawing.Size(193, 23);
            this.BOM_USE_YN.TabIndex = 57;
            // 
            // BOM_PLAN_YN
            // 
            this.BOM_PLAN_YN.FormattingEnabled = true;
            this.BOM_PLAN_YN.Items.AddRange(new object[] {
            "사용",
            "미사용"});
            this.BOM_PLAN_YN.Location = new System.Drawing.Point(539, 226);
            this.BOM_PLAN_YN.Name = "BOM_PLAN_YN";
            this.BOM_PLAN_YN.Size = new System.Drawing.Size(193, 23);
            this.BOM_PLAN_YN.TabIndex = 59;
            // 
            // BOM_AUTOREDUCE_YN
            // 
            this.BOM_AUTOREDUCE_YN.FormattingEnabled = true;
            this.BOM_AUTOREDUCE_YN.Items.AddRange(new object[] {
            "사용",
            "미사용"});
            this.BOM_AUTOREDUCE_YN.Location = new System.Drawing.Point(164, 226);
            this.BOM_AUTOREDUCE_YN.Name = "BOM_AUTOREDUCE_YN";
            this.BOM_AUTOREDUCE_YN.Size = new System.Drawing.Size(193, 23);
            this.BOM_AUTOREDUCE_YN.TabIndex = 62;
            // 
            // BOM_PARENT_CODE
            // 
            this.BOM_PARENT_CODE.FormattingEnabled = true;
            this.BOM_PARENT_CODE.Location = new System.Drawing.Point(164, 29);
            this.BOM_PARENT_CODE.Name = "BOM_PARENT_CODE";
            this.BOM_PARENT_CODE.Size = new System.Drawing.Size(193, 23);
            this.BOM_PARENT_CODE.TabIndex = 63;
            // 
            // BOM_REMARK
            // 
            this.BOM_REMARK.Location = new System.Drawing.Point(164, 275);
            this.BOM_REMARK.Multiline = true;
            this.BOM_REMARK.Name = "BOM_REMARK";
            this.BOM_REMARK.Size = new System.Drawing.Size(568, 117);
            this.BOM_REMARK.TabIndex = 56;
            // 
            // BOM_LAST_MDFR
            // 
            this.BOM_LAST_MDFR.Location = new System.Drawing.Point(164, 176);
            this.BOM_LAST_MDFR.Name = "BOM_LAST_MDFR";
            this.BOM_LAST_MDFR.Size = new System.Drawing.Size(193, 23);
            this.BOM_LAST_MDFR.TabIndex = 55;
            // 
            // BOM_QTY
            // 
            this.BOM_QTY.Location = new System.Drawing.Point(164, 79);
            this.BOM_QTY.Name = "BOM_QTY";
            this.BOM_QTY.Size = new System.Drawing.Size(193, 23);
            this.BOM_QTY.TabIndex = 53;
            this.BOM_QTY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_KeyPress);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(80, 275);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(31, 15);
            this.label27.TabIndex = 38;
            this.label27.Text = "비고";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label23.Location = new System.Drawing.Point(431, 129);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 18);
            this.label23.TabIndex = 51;
            this.label23.Text = "*";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label21.Location = new System.Drawing.Point(431, 178);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(15, 18);
            this.label21.TabIndex = 50;
            this.label21.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(431, 227);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 18);
            this.label19.TabIndex = 49;
            this.label19.Text = "*";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label28.Location = new System.Drawing.Point(56, 273);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(15, 18);
            this.label28.TabIndex = 52;
            this.label28.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label12.Location = new System.Drawing.Point(80, 229);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 27;
            this.label12.Text = "자동차감";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(56, 227);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 18);
            this.label10.TabIndex = 40;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(80, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "수정자";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(56, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 18);
            this.label8.TabIndex = 41;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(80, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 37;
            this.label7.Text = "종료일";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(455, 179);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(43, 15);
            this.label22.TabIndex = 36;
            this.label22.Text = "수정일";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(56, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 18);
            this.label6.TabIndex = 46;
            this.label6.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(455, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(43, 15);
            this.label18.TabIndex = 33;
            this.label18.Text = "시작일";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label24.Location = new System.Drawing.Point(455, 229);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 15);
            this.label24.TabIndex = 32;
            this.label24.Text = "소요계획";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(431, 80);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 18);
            this.label17.TabIndex = 43;
            this.label17.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label20.Location = new System.Drawing.Point(455, 130);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 15);
            this.label20.TabIndex = 31;
            this.label20.Text = "사용유무";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(80, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 30;
            this.label5.Text = "소요량";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(455, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 15);
            this.label16.TabIndex = 29;
            this.label16.Text = "품목";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(56, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 18);
            this.label4.TabIndex = 44;
            this.label4.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(431, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 18);
            this.label15.TabIndex = 45;
            this.label15.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(80, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 15);
            this.label11.TabIndex = 35;
            this.label11.Text = "상위품명";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(56, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 18);
            this.label3.TabIndex = 48;
            this.label3.Text = "*";
            // 
            // FrmBOMPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.panel2);
            this.Name = "FrmBOMPopUp";
            this.Load += new System.EventHandler(this.FrmBOMPopUp_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ITEM_CODE;
        private System.Windows.Forms.ComboBox BOM_USE_YN;
        private System.Windows.Forms.ComboBox BOM_PLAN_YN;
        private System.Windows.Forms.ComboBox BOM_AUTOREDUCE_YN;
        private System.Windows.Forms.ComboBox BOM_PARENT_CODE;
        private System.Windows.Forms.TextBox BOM_REMARK;
        private System.Windows.Forms.TextBox BOM_LAST_MDFR;
        private System.Windows.Forms.TextBox BOM_QTY;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker BOM_LAST_MDFY;
        private System.Windows.Forms.DateTimePicker BOM_STARTDATE;
        private System.Windows.Forms.DateTimePicker BOM_ENDDATE;
    }
}
