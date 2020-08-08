namespace TEAM3FINAL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuPanel1 = new TEAM3FINAL.MenuPanel();
            this.dgvWorkRecordList = new WindowsFormsApp18.MyDataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cboDATEtype = new System.Windows.Forms.ComboBox();
            this.dtpFROM = new System.Windows.Forms.DateTimePicker();
            this.dtpTO = new System.Windows.Forms.DateTimePicker();
            this.cboSTATE = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkRecordList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Size = new System.Drawing.Size(1057, 138);
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
            this.panel2.Location = new System.Drawing.Point(10, 18);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Size = new System.Drawing.Size(1031, 102);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 273);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Size = new System.Drawing.Size(99, 20);
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
            this.panel3.Location = new System.Drawing.Point(15, 200);
            this.panel3.Size = new System.Drawing.Size(1053, 537);
            this.panel3.Controls.SetChildIndex(this.panel4, 0);
            this.panel3.Controls.SetChildIndex(this.dgvWorkRecordList, 0);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 792);
            this.panel4.Margin = new System.Windows.Forms.Padding(3);
            // 
            // menuPanel1
            // 
            this.menuPanel1.BackColor = System.Drawing.Color.Transparent;
            this.menuPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.menuPanel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.Location = new System.Drawing.Point(12, 153);
            this.menuPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.menuPanel1.Name = "menuPanel1";
            this.menuPanel1.Size = new System.Drawing.Size(1057, 44);
            this.menuPanel1.TabIndex = 7;
            this.menuPanel1.TitleFont = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.TitleName = "작업실적등록";
            // 
            // dgvWorkRecordList
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvWorkRecordList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvWorkRecordList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkRecordList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvWorkRecordList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkRecordList.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvWorkRecordList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkRecordList.EnableHeadersVisualStyles = false;
            this.dgvWorkRecordList.Location = new System.Drawing.Point(0, 0);
            this.dgvWorkRecordList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvWorkRecordList.Name = "dgvWorkRecordList";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkRecordList.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvWorkRecordList.RowHeadersWidth = 30;
            this.dgvWorkRecordList.RowTemplate.Height = 23;
            this.dgvWorkRecordList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWorkRecordList.Size = new System.Drawing.Size(1053, 537);
            this.dgvWorkRecordList.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(700, 158);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 33);
            this.button1.TabIndex = 9;
            this.button1.Text = "작업취소/중단";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(824, 158);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 33);
            this.button2.TabIndex = 9;
            this.button2.Text = "실적등록";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.AutoSize = true;
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(946, 158);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(114, 33);
            this.button3.TabIndex = 9;
            this.button3.Text = "바코드출력";
            this.button3.UseVisualStyleBackColor = false;
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
            this.cboDATEtype.Location = new System.Drawing.Point(73, 36);
            this.cboDATEtype.Name = "cboDATEtype";
            this.cboDATEtype.Size = new System.Drawing.Size(108, 28);
            this.cboDATEtype.TabIndex = 0;
            this.cboDATEtype.SelectedIndexChanged += new System.EventHandler(this.cboDATE_SelectedIndexChanged);
            // 
            // dtpFROM
            // 
            this.dtpFROM.CustomFormat = "";
            this.dtpFROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFROM.Location = new System.Drawing.Point(213, 37);
            this.dtpFROM.Name = "dtpFROM";
            this.dtpFROM.ShowCheckBox = true;
            this.dtpFROM.Size = new System.Drawing.Size(132, 27);
            this.dtpFROM.TabIndex = 1;
            this.dtpFROM.ValueChanged += new System.EventHandler(this.dtpFROM_ValueChanged);
            // 
            // dtpTO
            // 
            this.dtpTO.CustomFormat = "";
            this.dtpTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTO.Location = new System.Drawing.Point(389, 37);
            this.dtpTO.Name = "dtpTO";
            this.dtpTO.ShowCheckBox = true;
            this.dtpTO.Size = new System.Drawing.Size(132, 27);
            this.dtpTO.TabIndex = 1;
            this.dtpTO.ValueChanged += new System.EventHandler(this.dtpTO_ValueChanged);
            // 
            // cboSTATE
            // 
            this.cboSTATE.FormattingEnabled = true;
            this.cboSTATE.Location = new System.Drawing.Point(717, 36);
            this.cboSTATE.Name = "cboSTATE";
            this.cboSTATE.Size = new System.Drawing.Size(185, 28);
            this.cboSTATE.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(653, 39);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.label3.Location = new System.Drawing.Point(622, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 24);
            this.label3.TabIndex = 31;
            this.label3.Text = "*";
            // 
            // FrmWorkRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1080, 749);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmWorkRecord";
            this.Text = "작업실적";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWorkRecord_FormClosing);
            this.Load += new System.EventHandler(this.FrmWorkRecord_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.menuPanel1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkRecordList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuPanel menuPanel1;
        private WindowsFormsApp18.MyDataGridView dgvWorkRecordList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cboSTATE;
        private System.Windows.Forms.DateTimePicker dtpTO;
        private System.Windows.Forms.DateTimePicker dtpFROM;
        private System.Windows.Forms.ComboBox cboDATEtype;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
    }
}
