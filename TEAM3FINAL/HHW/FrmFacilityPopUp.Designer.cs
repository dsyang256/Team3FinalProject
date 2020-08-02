namespace TEAM3FINAL
{
    partial class FrmFacilityPopUp
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
            this.label9 = new System.Windows.Forms.Label();
            this.cboFACUseYN = new System.Windows.Forms.ComboBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtModifier = new System.Windows.Forms.TextBox();
            this.txtFACGCODE = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFACCODE = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtFACNAME = new System.Windows.Forms.TextBox();
            this.cboFACEXHST = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cboFACGOOD = new System.Windows.Forms.ComboBox();
            this.txtModifyDate = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cboFACBAD = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.cboEXTRLYN = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtREMARK = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.panel1.Size = new System.Drawing.Size(1035, 75);
            // 
            // label1
            // 
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Size = new System.Drawing.Size(63, 32);
            this.label1.Text = "설비";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(918, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(400, 765);
            this.btnOK.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(544, 765);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(54, 229);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 54;
            this.label9.Text = "사용유무";
            // 
            // cboFACUseYN
            // 
            this.cboFACUseYN.FormattingEnabled = true;
            this.cboFACUseYN.Items.AddRange(new object[] {
            "사용",
            "미사용"});
            this.cboFACUseYN.Location = new System.Drawing.Point(162, 225);
            this.cboFACUseYN.Margin = new System.Windows.Forms.Padding(4);
            this.cboFACUseYN.Name = "cboFACUseYN";
            this.cboFACUseYN.Size = new System.Drawing.Size(176, 28);
            this.cboFACUseYN.TabIndex = 53;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(162, 345);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(838, 184);
            this.txtNote.TabIndex = 51;
            // 
            // txtModifier
            // 
            this.txtModifier.Location = new System.Drawing.Point(162, 281);
            this.txtModifier.Margin = new System.Windows.Forms.Padding(4);
            this.txtModifier.Name = "txtModifier";
            this.txtModifier.Size = new System.Drawing.Size(176, 27);
            this.txtModifier.TabIndex = 49;
            // 
            // txtFACGCODE
            // 
            this.txtFACGCODE.Location = new System.Drawing.Point(162, 108);
            this.txtFACGCODE.Margin = new System.Windows.Forms.Padding(4);
            this.txtFACGCODE.Name = "txtFACGCODE";
            this.txtFACGCODE.Size = new System.Drawing.Size(176, 27);
            this.txtFACGCODE.TabIndex = 52;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(54, 345);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 20);
            this.label14.TabIndex = 38;
            this.label14.Text = "특이사항";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label13.Location = new System.Drawing.Point(23, 345);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 24);
            this.label13.TabIndex = 42;
            this.label13.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(401, 285);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 39;
            this.label12.Text = "수정시간";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label11.Location = new System.Drawing.Point(370, 283);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 24);
            this.label11.TabIndex = 45;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 288);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 37;
            this.label10.Text = "수정자";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(23, 288);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 24);
            this.label3.TabIndex = 44;
            this.label3.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(401, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 40;
            this.label7.Text = "설비코드";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(370, 109);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 24);
            this.label6.TabIndex = 46;
            this.label6.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(54, 112);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 41;
            this.label5.Text = "설비군코드";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(23, 109);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 24);
            this.label4.TabIndex = 47;
            this.label4.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label15.Location = new System.Drawing.Point(23, 168);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 24);
            this.label15.TabIndex = 47;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(54, 171);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 20);
            this.label16.TabIndex = 41;
            this.label16.Text = "소진창고";
            // 
            // txtFACCODE
            // 
            this.txtFACCODE.Location = new System.Drawing.Point(492, 108);
            this.txtFACCODE.Margin = new System.Windows.Forms.Padding(4);
            this.txtFACCODE.Name = "txtFACCODE";
            this.txtFACCODE.Size = new System.Drawing.Size(176, 27);
            this.txtFACCODE.TabIndex = 52;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(702, 109);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(18, 24);
            this.label17.TabIndex = 46;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label18.Location = new System.Drawing.Point(733, 112);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 20);
            this.label18.TabIndex = 40;
            this.label18.Text = "설비명";
            // 
            // txtFACNAME
            // 
            this.txtFACNAME.Location = new System.Drawing.Point(824, 108);
            this.txtFACNAME.Margin = new System.Windows.Forms.Padding(4);
            this.txtFACNAME.Name = "txtFACNAME";
            this.txtFACNAME.Size = new System.Drawing.Size(176, 27);
            this.txtFACNAME.TabIndex = 52;
            // 
            // cboFACEXHST
            // 
            this.cboFACEXHST.FormattingEnabled = true;
            this.cboFACEXHST.Items.AddRange(new object[] {
            "공장",
            "자재팀창고",
            "생산팀창고",
            "영업팀창고",
            "외주창고"});
            this.cboFACEXHST.Location = new System.Drawing.Point(162, 167);
            this.cboFACEXHST.Margin = new System.Windows.Forms.Padding(4);
            this.cboFACEXHST.Name = "cboFACEXHST";
            this.cboFACEXHST.Size = new System.Drawing.Size(176, 28);
            this.cboFACEXHST.TabIndex = 53;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(23, 229);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 24);
            this.label8.TabIndex = 47;
            this.label8.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label19.Location = new System.Drawing.Point(370, 168);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 24);
            this.label19.TabIndex = 47;
            this.label19.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label20.Location = new System.Drawing.Point(401, 171);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 20);
            this.label20.TabIndex = 41;
            this.label20.Text = "양품창고";
            // 
            // cboFACGOOD
            // 
            this.cboFACGOOD.FormattingEnabled = true;
            this.cboFACGOOD.Items.AddRange(new object[] {
            "공장",
            "자재팀창고",
            "생산팀창고",
            "영업팀창고",
            "외주창고"});
            this.cboFACGOOD.Location = new System.Drawing.Point(492, 167);
            this.cboFACGOOD.Margin = new System.Windows.Forms.Padding(4);
            this.cboFACGOOD.Name = "cboFACGOOD";
            this.cboFACGOOD.Size = new System.Drawing.Size(176, 28);
            this.cboFACGOOD.TabIndex = 53;
            // 
            // txtModifyDate
            // 
            this.txtModifyDate.Location = new System.Drawing.Point(492, 281);
            this.txtModifyDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtModifyDate.Name = "txtModifyDate";
            this.txtModifyDate.Size = new System.Drawing.Size(176, 27);
            this.txtModifyDate.TabIndex = 49;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label23.Location = new System.Drawing.Point(702, 167);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(18, 24);
            this.label23.TabIndex = 44;
            this.label23.Text = "*";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(733, 167);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(69, 20);
            this.label24.TabIndex = 37;
            this.label24.Text = "불량창고";
            // 
            // cboFACBAD
            // 
            this.cboFACBAD.FormattingEnabled = true;
            this.cboFACBAD.Items.AddRange(new object[] {
            "공장",
            "자재팀창고",
            "생산팀창고",
            "영업팀창고",
            "외주창고"});
            this.cboFACBAD.Location = new System.Drawing.Point(824, 163);
            this.cboFACBAD.Margin = new System.Windows.Forms.Padding(4);
            this.cboFACBAD.Name = "cboFACBAD";
            this.cboFACBAD.Size = new System.Drawing.Size(176, 28);
            this.cboFACBAD.TabIndex = 53;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label25.Location = new System.Drawing.Point(370, 229);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(18, 24);
            this.label25.TabIndex = 44;
            this.label25.Text = "*";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(401, 229);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(69, 20);
            this.label26.TabIndex = 37;
            this.label26.Text = "외주여부";
            // 
            // cboEXTRLYN
            // 
            this.cboEXTRLYN.FormattingEnabled = true;
            this.cboEXTRLYN.Items.AddRange(new object[] {
            "사용",
            "미사용"});
            this.cboEXTRLYN.Location = new System.Drawing.Point(492, 223);
            this.cboEXTRLYN.Margin = new System.Windows.Forms.Padding(4);
            this.cboEXTRLYN.Name = "cboEXTRLYN";
            this.cboEXTRLYN.Size = new System.Drawing.Size(176, 28);
            this.cboEXTRLYN.TabIndex = 53;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label27.Location = new System.Drawing.Point(23, 543);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(18, 24);
            this.label27.TabIndex = 42;
            this.label27.Text = "*";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(54, 543);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(39, 20);
            this.label28.TabIndex = 38;
            this.label28.Text = "비고";
            // 
            // txtREMARK
            // 
            this.txtREMARK.Location = new System.Drawing.Point(162, 539);
            this.txtREMARK.Margin = new System.Windows.Forms.Padding(4);
            this.txtREMARK.Multiline = true;
            this.txtREMARK.Name = "txtREMARK";
            this.txtREMARK.Size = new System.Drawing.Size(838, 184);
            this.txtREMARK.TabIndex = 51;
            // 
            // FrmFacilityPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(1035, 840);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboEXTRLYN);
            this.Controls.Add(this.cboFACBAD);
            this.Controls.Add(this.cboFACGOOD);
            this.Controls.Add(this.cboFACEXHST);
            this.Controls.Add(this.cboFACUseYN);
            this.Controls.Add(this.txtREMARK);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.txtModifyDate);
            this.Controls.Add(this.txtModifier);
            this.Controls.Add(this.txtFACNAME);
            this.Controls.Add(this.txtFACCODE);
            this.Controls.Add(this.txtFACGCODE);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(5, 9, 5, 9);
            this.Name = "FrmFacilityPopUp";
            this.Load += new System.EventHandler(this.FrmFacilityPopUp_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label23, 0);
            this.Controls.SetChildIndex(this.label24, 0);
            this.Controls.SetChildIndex(this.label25, 0);
            this.Controls.SetChildIndex(this.label26, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label27, 0);
            this.Controls.SetChildIndex(this.label28, 0);
            this.Controls.SetChildIndex(this.txtFACGCODE, 0);
            this.Controls.SetChildIndex(this.txtFACCODE, 0);
            this.Controls.SetChildIndex(this.txtFACNAME, 0);
            this.Controls.SetChildIndex(this.txtModifier, 0);
            this.Controls.SetChildIndex(this.txtModifyDate, 0);
            this.Controls.SetChildIndex(this.txtNote, 0);
            this.Controls.SetChildIndex(this.txtREMARK, 0);
            this.Controls.SetChildIndex(this.cboFACUseYN, 0);
            this.Controls.SetChildIndex(this.cboFACEXHST, 0);
            this.Controls.SetChildIndex(this.cboFACGOOD, 0);
            this.Controls.SetChildIndex(this.cboFACBAD, 0);
            this.Controls.SetChildIndex(this.cboEXTRLYN, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboFACUseYN;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtModifier;
        private System.Windows.Forms.TextBox txtFACGCODE;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtFACCODE;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtFACNAME;
        private System.Windows.Forms.ComboBox cboFACEXHST;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboFACGOOD;
        private System.Windows.Forms.TextBox txtModifyDate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.ComboBox cboFACBAD;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cboEXTRLYN;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtREMARK;
    }
}
