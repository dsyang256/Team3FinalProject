namespace TEAM3FINAL
{
    partial class FrmSalesMaster
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
            this.cboCom = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.cboOrderGubun = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cboCom2 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.menuPanel1 = new TEAM3FINAL.MenuPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.dgvSales = new WindowsFormsApp18.MyDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1226, 175);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.txtPO);
            this.panel2.Controls.Add(this.txtItem);
            this.panel2.Controls.Add(this.dtpTo);
            this.panel2.Controls.Add(this.dtpFrom);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.cboCom2);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.cboState);
            this.panel2.Controls.Add(this.cboOrderGubun);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cboCom);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Size = new System.Drawing.Size(1220, 150);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 192);
            this.label1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvSales);
            this.panel3.Size = new System.Drawing.Size(1220, 321);
            // 
            // cboCom
            // 
            this.cboCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCom.FormattingEnabled = true;
            this.cboCom.Location = new System.Drawing.Point(530, 59);
            this.cboCom.Name = "cboCom";
            this.cboCom.Size = new System.Drawing.Size(199, 23);
            this.cboCom.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label5.Location = new System.Drawing.Point(436, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "고객사";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(417, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 18);
            this.label4.TabIndex = 35;
            this.label4.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label2.Location = new System.Drawing.Point(431, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "품목";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(412, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 18);
            this.label6.TabIndex = 41;
            this.label6.Text = "*";
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(176, 61);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(199, 23);
            this.cboState.TabIndex = 56;
            // 
            // cboOrderGubun
            // 
            this.cboOrderGubun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrderGubun.FormattingEnabled = true;
            this.cboOrderGubun.Items.AddRange(new object[] {
            "P/O"});
            this.cboOrderGubun.Location = new System.Drawing.Point(176, 104);
            this.cboOrderGubun.Name = "cboOrderGubun";
            this.cboOrderGubun.Size = new System.Drawing.Size(199, 23);
            this.cboOrderGubun.TabIndex = 55;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label14.Location = new System.Drawing.Point(77, 107);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 20);
            this.label14.TabIndex = 51;
            this.label14.Text = "발주구분";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label15.Location = new System.Drawing.Point(58, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 18);
            this.label15.TabIndex = 53;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label16.Location = new System.Drawing.Point(77, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 20);
            this.label16.TabIndex = 52;
            this.label16.Text = "상태";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label17.Location = new System.Drawing.Point(58, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 18);
            this.label17.TabIndex = 54;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label18.Location = new System.Drawing.Point(793, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 20);
            this.label18.TabIndex = 57;
            this.label18.Text = "고객주문번호";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label19.Location = new System.Drawing.Point(774, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 18);
            this.label19.TabIndex = 58;
            this.label19.Text = "*";
            // 
            // cboCom2
            // 
            this.cboCom2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCom2.FormattingEnabled = true;
            this.cboCom2.Location = new System.Drawing.Point(911, 57);
            this.cboCom2.Name = "cboCom2";
            this.cboCom2.Size = new System.Drawing.Size(199, 23);
            this.cboCom2.TabIndex = 62;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label20.Location = new System.Drawing.Point(793, 59);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 20);
            this.label20.TabIndex = 60;
            this.label20.Text = "도착지";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label21.Location = new System.Drawing.Point(774, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(15, 18);
            this.label21.TabIndex = 61;
            this.label21.Text = "*";
            // 
            // menuPanel1
            // 
            this.menuPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPanel1.BackColor = System.Drawing.Color.Transparent;
            this.menuPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.menuPanel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.Location = new System.Drawing.Point(12, 192);
            this.menuPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.menuPanel1.Name = "menuPanel1";
            this.menuPanel1.Size = new System.Drawing.Size(1227, 32);
            this.menuPanel1.TabIndex = 4;
            this.menuPanel1.TitleFont = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.TitleName = "영업마스터";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(1150, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "수요계획생성";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(1051, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 25);
            this.button2.TabIndex = 6;
            this.button2.Text = "영업마스터생성";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(284, 16);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(91, 23);
            this.dtpTo.TabIndex = 72;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(176, 16);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(91, 23);
            this.dtpFrom.TabIndex = 73;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label26.Location = new System.Drawing.Point(266, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(20, 20);
            this.label26.TabIndex = 69;
            this.label26.Text = "~";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label27.Location = new System.Drawing.Point(77, 17);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(84, 20);
            this.label27.TabIndex = 70;
            this.label27.Text = "고객납기일";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label28.Location = new System.Drawing.Point(58, 20);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(15, 18);
            this.label28.TabIndex = 71;
            this.label28.Text = "*";
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(530, 15);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(199, 23);
            this.txtItem.TabIndex = 75;
            // 
            // txtPO
            // 
            this.txtPO.Location = new System.Drawing.Point(911, 15);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(199, 23);
            this.txtPO.TabIndex = 76;
            // 
            // dgvSales
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSales.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSales.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSales.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSales.EnableHeadersVisualStyles = false;
            this.dgvSales.Location = new System.Drawing.Point(0, 0);
            this.dgvSales.Name = "dgvSales";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSales.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSales.RowHeadersWidth = 30;
            this.dgvSales.RowTemplate.Height = 23;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new System.Drawing.Size(1220, 321);
            this.dgvSales.TabIndex = 0;
            // 
            // FrmSalesMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1250, 565);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuPanel1);
            this.Name = "FrmSalesMaster";
            this.Text = "ㅇ";
            this.Load += new System.EventHandler(this.FrmSalesMaster_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.menuPanel1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboCom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.ComboBox cboOrderGubun;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboCom2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private MenuPanel menuPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPO;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private WindowsFormsApp18.MyDataGridView dgvSales;
    }
}
