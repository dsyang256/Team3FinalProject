namespace TEAM3FINAL
{
    partial class FrmSalesWorkList
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
            this.cboWOITEM = new System.Windows.Forms.ComboBox();
            this.cboSearchDate = new System.Windows.Forms.ComboBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cboCom2 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1151, 117);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboWOITEM);
            this.panel2.Controls.Add(this.cboSearchDate);
            this.panel2.Controls.Add(this.txtItem);
            this.panel2.Controls.Add(this.dtpTo);
            this.panel2.Controls.Add(this.dtpFrom);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.cboCom2);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.cboState);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Size = new System.Drawing.Size(1145, 95);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 574);
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.Text = "작업지시현황";
            this.label1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(15, 137);
            this.panel3.Size = new System.Drawing.Size(1145, 416);
            // 
            // cboWOITEM
            // 
            this.cboWOITEM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWOITEM.FormattingEnabled = true;
            this.cboWOITEM.Items.AddRange(new object[] {
            "WO",
            "품목"});
            this.cboWOITEM.Location = new System.Drawing.Point(443, 17);
            this.cboWOITEM.Name = "cboWOITEM";
            this.cboWOITEM.Size = new System.Drawing.Size(82, 23);
            this.cboWOITEM.TabIndex = 115;
            // 
            // cboSearchDate
            // 
            this.cboSearchDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchDate.FormattingEnabled = true;
            this.cboSearchDate.Items.AddRange(new object[] {
            "투입시간",
            "생산실적일"});
            this.cboSearchDate.Location = new System.Drawing.Point(79, 17);
            this.cboSearchDate.Name = "cboSearchDate";
            this.cboSearchDate.Size = new System.Drawing.Size(82, 23);
            this.cboSearchDate.TabIndex = 114;
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(535, 17);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(199, 23);
            this.txtItem.TabIndex = 113;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(289, 17);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(91, 23);
            this.dtpTo.TabIndex = 111;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(181, 17);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(91, 23);
            this.dtpFrom.TabIndex = 112;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label26.Location = new System.Drawing.Point(271, 18);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(20, 20);
            this.label26.TabIndex = 109;
            this.label26.Text = "~";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label28.Location = new System.Drawing.Point(58, 22);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(15, 18);
            this.label28.TabIndex = 110;
            this.label28.Text = "*";
            // 
            // cboCom2
            // 
            this.cboCom2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCom2.FormattingEnabled = true;
            this.cboCom2.Location = new System.Drawing.Point(843, 18);
            this.cboCom2.Name = "cboCom2";
            this.cboCom2.Size = new System.Drawing.Size(199, 23);
            this.cboCom2.TabIndex = 108;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label20.Location = new System.Drawing.Point(795, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 20);
            this.label20.TabIndex = 106;
            this.label20.Text = "창고";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label21.Location = new System.Drawing.Point(774, 22);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(15, 18);
            this.label21.TabIndex = 107;
            this.label21.Text = "*";
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "작업생성",
            "작업지시",
            "작업취소",
            "작업완료"});
            this.cboState.Location = new System.Drawing.Point(181, 54);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(199, 23);
            this.cboState.TabIndex = 105;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label16.Location = new System.Drawing.Point(75, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 20);
            this.label16.TabIndex = 103;
            this.label16.Text = "상태";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label17.Location = new System.Drawing.Point(56, 59);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 18);
            this.label17.TabIndex = 104;
            this.label17.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(422, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 18);
            this.label6.TabIndex = 102;
            this.label6.Text = "*";
            // 
            // FrmSalesWorkList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1175, 565);
            this.Name = "FrmSalesWorkList";
            this.Text = "작업지시현황";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboWOITEM;
        private System.Windows.Forms.ComboBox cboSearchDate;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboCom2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
    }
}
