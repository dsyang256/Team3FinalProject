﻿namespace TEAM3FINAL
{
    partial class FrmWorkRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuPanel1 = new TEAM3FINAL.MenuPanel();
            this.dgvWorkRecordList = new WindowsFormsApp18.MyDataGridView();
            this.btnWorkCancel = new System.Windows.Forms.Button();
            this.btnMOVE = new System.Windows.Forms.Button();
            this.cboDATEtype = new System.Windows.Forms.ComboBox();
            this.dtpFROM = new System.Windows.Forms.DateTimePicker();
            this.dtpTO = new System.Windows.Forms.DateTimePicker();
            this.cboSTATE = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvMOVEList = new WindowsFormsApp18.MyDataGridView();
            this.menuPanel2 = new TEAM3FINAL.MenuPanel();
            this.btnFinalWork = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkRecordList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMOVEList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Size = new System.Drawing.Size(1232, 82);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboSTATE);
            this.panel2.Controls.Add(this.dtpTO);
            this.panel2.Controls.Add(this.dtpFROM);
            this.panel2.Controls.Add(this.cboDATEtype);
            this.panel2.Location = new System.Drawing.Point(3, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Size = new System.Drawing.Size(1224, 62);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 205);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.Text = "작업실적등록";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvWorkRecordList);
            this.panel3.Location = new System.Drawing.Point(12, 134);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(1229, 250);
            this.panel3.Controls.SetChildIndex(this.panel4, 0);
            this.panel3.Controls.SetChildIndex(this.dgvWorkRecordList, 0);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 442);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(1764, 27);
            // 
            // menuPanel1
            // 
            this.menuPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPanel1.BackColor = System.Drawing.Color.Transparent;
            this.menuPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.menuPanel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.Location = new System.Drawing.Point(12, 98);
            this.menuPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.menuPanel1.Name = "menuPanel1";
            this.menuPanel1.Size = new System.Drawing.Size(1226, 32);
            this.menuPanel1.TabIndex = 7;
            this.menuPanel1.TitleFont = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.TitleName = "작업실적등록";
            // 
            // dgvWorkRecordList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvWorkRecordList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkRecordList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkRecordList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorkRecordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkRecordList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWorkRecordList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkRecordList.EnableHeadersVisualStyles = false;
            this.dgvWorkRecordList.Location = new System.Drawing.Point(0, 0);
            this.dgvWorkRecordList.Name = "dgvWorkRecordList";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkRecordList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvWorkRecordList.RowHeadersWidth = 30;
            this.dgvWorkRecordList.RowTemplate.Height = 23;
            this.dgvWorkRecordList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorkRecordList.Size = new System.Drawing.Size(1229, 250);
            this.dgvWorkRecordList.TabIndex = 8;
            // 
            // btnWorkCancel
            // 
            this.btnWorkCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkCancel.AutoSize = true;
            this.btnWorkCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnWorkCancel.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWorkCancel.Location = new System.Drawing.Point(1044, 102);
            this.btnWorkCancel.Name = "btnWorkCancel";
            this.btnWorkCancel.Size = new System.Drawing.Size(94, 25);
            this.btnWorkCancel.TabIndex = 9;
            this.btnWorkCancel.Text = "작업취소/중단";
            this.btnWorkCancel.UseVisualStyleBackColor = false;
            this.btnWorkCancel.Click += new System.EventHandler(this.btnWorkCancel_Click);
            // 
            // btnMOVE
            // 
            this.btnMOVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMOVE.AutoSize = true;
            this.btnMOVE.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMOVE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMOVE.Location = new System.Drawing.Point(1144, 102);
            this.btnMOVE.Name = "btnMOVE";
            this.btnMOVE.Size = new System.Drawing.Size(89, 25);
            this.btnMOVE.TabIndex = 9;
            this.btnMOVE.Text = "실적등록";
            this.btnMOVE.UseVisualStyleBackColor = false;
            this.btnMOVE.Click += new System.EventHandler(this.btnMOVE_Click);
            // 
            // cboDATEtype
            // 
            this.cboDATEtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDATEtype.FormattingEnabled = true;
            this.cboDATEtype.Items.AddRange(new object[] {
            "날짜제외",
            "지시일",
            "투입일",
            "생산일"});
            this.cboDATEtype.Location = new System.Drawing.Point(58, 22);
            this.cboDATEtype.Margin = new System.Windows.Forms.Padding(2);
            this.cboDATEtype.Name = "cboDATEtype";
            this.cboDATEtype.Size = new System.Drawing.Size(85, 23);
            this.cboDATEtype.TabIndex = 0;
            this.cboDATEtype.SelectedIndexChanged += new System.EventHandler(this.cboDATE_SelectedIndexChanged);
            // 
            // dtpFROM
            // 
            this.dtpFROM.CustomFormat = "";
            this.dtpFROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFROM.Location = new System.Drawing.Point(168, 22);
            this.dtpFROM.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFROM.Name = "dtpFROM";
            this.dtpFROM.ShowCheckBox = true;
            this.dtpFROM.Size = new System.Drawing.Size(125, 23);
            this.dtpFROM.TabIndex = 1;
            this.dtpFROM.ValueChanged += new System.EventHandler(this.dtpFROM_ValueChanged);
            // 
            // dtpTO
            // 
            this.dtpTO.CustomFormat = "";
            this.dtpTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTO.Location = new System.Drawing.Point(304, 22);
            this.dtpTO.Margin = new System.Windows.Forms.Padding(2);
            this.dtpTO.Name = "dtpTO";
            this.dtpTO.ShowCheckBox = true;
            this.dtpTO.Size = new System.Drawing.Size(125, 23);
            this.dtpTO.TabIndex = 1;
            this.dtpTO.ValueChanged += new System.EventHandler(this.dtpTO_ValueChanged);
            // 
            // cboSTATE
            // 
            this.cboSTATE.FormattingEnabled = true;
            this.cboSTATE.Location = new System.Drawing.Point(552, 21);
            this.cboSTATE.Margin = new System.Windows.Forms.Padding(2);
            this.cboSTATE.Name = "cboSTATE";
            this.cboSTATE.Size = new System.Drawing.Size(145, 23);
            this.cboSTATE.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label11.Location = new System.Drawing.Point(485, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 20);
            this.label11.TabIndex = 30;
            this.label11.Text = "상태";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(457, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "*";
            // 
            // dgvMOVEList
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvMOVEList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMOVEList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMOVEList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMOVEList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMOVEList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMOVEList.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMOVEList.EnableHeadersVisualStyles = false;
            this.dgvMOVEList.Location = new System.Drawing.Point(12, 424);
            this.dgvMOVEList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMOVEList.Name = "dgvMOVEList";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMOVEList.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMOVEList.RowHeadersWidth = 30;
            this.dgvMOVEList.RowTemplate.Height = 23;
            this.dgvMOVEList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMOVEList.Size = new System.Drawing.Size(1229, 131);
            this.dgvMOVEList.TabIndex = 10;
            // 
            // menuPanel2
            // 
            this.menuPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPanel2.BackColor = System.Drawing.Color.Transparent;
            this.menuPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.menuPanel2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel2.Location = new System.Drawing.Point(12, 388);
            this.menuPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.menuPanel2.Name = "menuPanel2";
            this.menuPanel2.Size = new System.Drawing.Size(1226, 32);
            this.menuPanel2.TabIndex = 11;
            this.menuPanel2.TitleFont = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel2.TitleName = "공정이동";
            // 
            // btnFinalWork
            // 
            this.btnFinalWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalWork.AutoSize = true;
            this.btnFinalWork.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFinalWork.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFinalWork.Location = new System.Drawing.Point(1139, 391);
            this.btnFinalWork.Name = "btnFinalWork";
            this.btnFinalWork.Size = new System.Drawing.Size(94, 25);
            this.btnFinalWork.TabIndex = 9;
            this.btnFinalWork.Text = "이동처리";
            this.btnFinalWork.UseVisualStyleBackColor = false;
            this.btnFinalWork.Click += new System.EventHandler(this.btnFinalWork_Click);
            // 
            // FrmWorkRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1250, 565);
            this.Controls.Add(this.btnFinalWork);
            this.Controls.Add(this.menuPanel2);
            this.Controls.Add(this.dgvMOVEList);
            this.Controls.Add(this.btnMOVE);
            this.Controls.Add(this.btnWorkCancel);
            this.Controls.Add(this.menuPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "FrmWorkRecord";
            this.Text = "작업실적등록";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWorkRecord_FormClosing);
            this.Load += new System.EventHandler(this.FrmWorkRecord_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.menuPanel1, 0);
            this.Controls.SetChildIndex(this.btnWorkCancel, 0);
            this.Controls.SetChildIndex(this.btnMOVE, 0);
            this.Controls.SetChildIndex(this.dgvMOVEList, 0);
            this.Controls.SetChildIndex(this.menuPanel2, 0);
            this.Controls.SetChildIndex(this.btnFinalWork, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkRecordList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMOVEList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuPanel menuPanel1;
        private WindowsFormsApp18.MyDataGridView dgvWorkRecordList;
        private System.Windows.Forms.Button btnWorkCancel;
        private System.Windows.Forms.Button btnMOVE;
        private System.Windows.Forms.ComboBox cboSTATE;
        private System.Windows.Forms.DateTimePicker dtpTO;
        private System.Windows.Forms.DateTimePicker dtpFROM;
        private System.Windows.Forms.ComboBox cboDATEtype;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private WindowsFormsApp18.MyDataGridView dgvMOVEList;
        private MenuPanel menuPanel2;
        private System.Windows.Forms.Button btnFinalWork;
    }
}
