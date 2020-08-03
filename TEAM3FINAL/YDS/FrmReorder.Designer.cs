namespace TEAM3FINAL
{
    partial class FrmReorder
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
            this.ITEM_TYP = new System.Windows.Forms.ComboBox();
            this.USE_YN = new System.Windows.Forms.ComboBox();
            this.PLAN_ID = new System.Windows.Forms.ComboBox();
            this.COM_CODE = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ITEM_STND = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.REORDER_TYP = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.MANAGER = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.FACILITY_TYPE = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvReorder = new WindowsFormsApp18.MyDataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReorder)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1260, 200);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ITEM_TYP);
            this.panel2.Controls.Add(this.USE_YN);
            this.panel2.Controls.Add(this.PLAN_ID);
            this.panel2.Controls.Add(this.COM_CODE);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.ITEM_STND);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label26);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.REORDER_TYP);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.MANAGER);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.comboBox5);
            this.panel2.Controls.Add(this.comboBox6);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.FACILITY_TYPE);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Size = new System.Drawing.Size(1254, 180);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvReorder);
            this.panel3.Size = new System.Drawing.Size(1254, 318);
            // 
            // ITEM_TYP
            // 
            this.ITEM_TYP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ITEM_TYP.FormattingEnabled = true;
            this.ITEM_TYP.Location = new System.Drawing.Point(566, 62);
            this.ITEM_TYP.Name = "ITEM_TYP";
            this.ITEM_TYP.Size = new System.Drawing.Size(199, 23);
            this.ITEM_TYP.TabIndex = 149;
            // 
            // USE_YN
            // 
            this.USE_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.USE_YN.FormattingEnabled = true;
            this.USE_YN.Location = new System.Drawing.Point(566, 90);
            this.USE_YN.Name = "USE_YN";
            this.USE_YN.Size = new System.Drawing.Size(199, 23);
            this.USE_YN.TabIndex = 148;
            // 
            // PLAN_ID
            // 
            this.PLAN_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PLAN_ID.FormattingEnabled = true;
            this.PLAN_ID.Location = new System.Drawing.Point(189, 30);
            this.PLAN_ID.Name = "PLAN_ID";
            this.PLAN_ID.Size = new System.Drawing.Size(199, 23);
            this.PLAN_ID.TabIndex = 147;
            // 
            // COM_CODE
            // 
            this.COM_CODE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COM_CODE.FormattingEnabled = true;
            this.COM_CODE.Location = new System.Drawing.Point(189, 61);
            this.COM_CODE.Name = "COM_CODE";
            this.COM_CODE.Size = new System.Drawing.Size(199, 23);
            this.COM_CODE.TabIndex = 146;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label3.Location = new System.Drawing.Point(68, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 144;
            this.label3.Text = "업체코드";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(49, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 18);
            this.label7.TabIndex = 145;
            this.label7.Text = "*";
            // 
            // ITEM_STND
            // 
            this.ITEM_STND.Location = new System.Drawing.Point(947, 31);
            this.ITEM_STND.Name = "ITEM_STND";
            this.ITEM_STND.Size = new System.Drawing.Size(199, 23);
            this.ITEM_STND.TabIndex = 143;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(674, 34);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(91, 23);
            this.dateTimePicker2.TabIndex = 141;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(566, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(91, 23);
            this.dateTimePicker1.TabIndex = 142;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label26.Location = new System.Drawing.Point(656, 35);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(20, 20);
            this.label26.TabIndex = 138;
            this.label26.Text = "~";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label27.Location = new System.Drawing.Point(68, 33);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 20);
            this.label27.TabIndex = 139;
            this.label27.Text = "Plan ID";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label28.Location = new System.Drawing.Point(49, 36);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(15, 18);
            this.label28.TabIndex = 140;
            this.label28.Text = "*";
            // 
            // REORDER_TYP
            // 
            this.REORDER_TYP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.REORDER_TYP.FormattingEnabled = true;
            this.REORDER_TYP.Location = new System.Drawing.Point(947, 96);
            this.REORDER_TYP.Name = "REORDER_TYP";
            this.REORDER_TYP.Size = new System.Drawing.Size(199, 23);
            this.REORDER_TYP.TabIndex = 137;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label22.Location = new System.Drawing.Point(829, 95);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 20);
            this.label22.TabIndex = 135;
            this.label22.Text = "발주방식";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label23.Location = new System.Drawing.Point(810, 98);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 18);
            this.label23.TabIndex = 136;
            this.label23.Text = "*";
            // 
            // MANAGER
            // 
            this.MANAGER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MANAGER.FormattingEnabled = true;
            this.MANAGER.Location = new System.Drawing.Point(947, 65);
            this.MANAGER.Name = "MANAGER";
            this.MANAGER.Size = new System.Drawing.Size(199, 23);
            this.MANAGER.TabIndex = 134;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label20.Location = new System.Drawing.Point(829, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(54, 20);
            this.label20.TabIndex = 132;
            this.label20.Text = "담당자";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label21.Location = new System.Drawing.Point(810, 67);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(15, 18);
            this.label21.TabIndex = 133;
            this.label21.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label18.Location = new System.Drawing.Point(829, 35);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 20);
            this.label18.TabIndex = 130;
            this.label18.Text = "자재/규격";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label19.Location = new System.Drawing.Point(810, 38);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(15, 18);
            this.label19.TabIndex = 131;
            this.label19.Text = "*";
            // 
            // comboBox5
            // 
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(189, 121);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(199, 23);
            this.comboBox5.TabIndex = 129;
            // 
            // comboBox6
            // 
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(566, 121);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(199, 23);
            this.comboBox6.TabIndex = 128;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label14.Location = new System.Drawing.Point(449, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 20);
            this.label14.TabIndex = 124;
            this.label14.Text = " Shortage 구간";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label15.Location = new System.Drawing.Point(430, 125);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 18);
            this.label15.TabIndex = 126;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label16.Location = new System.Drawing.Point(68, 122);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 20);
            this.label16.TabIndex = 125;
            this.label16.Text = "Shortage Only ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label17.Location = new System.Drawing.Point(49, 125);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 18);
            this.label17.TabIndex = 127;
            this.label17.Text = "*";
            // 
            // FACILITY_TYPE
            // 
            this.FACILITY_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FACILITY_TYPE.FormattingEnabled = true;
            this.FACILITY_TYPE.Location = new System.Drawing.Point(189, 92);
            this.FACILITY_TYPE.Name = "FACILITY_TYPE";
            this.FACILITY_TYPE.Size = new System.Drawing.Size(199, 23);
            this.FACILITY_TYPE.TabIndex = 123;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label9.Location = new System.Drawing.Point(449, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 20);
            this.label9.TabIndex = 119;
            this.label9.Text = "계획구분";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(430, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 18);
            this.label10.TabIndex = 121;
            this.label10.Text = "*";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label12.Location = new System.Drawing.Point(68, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 20);
            this.label12.TabIndex = 120;
            this.label12.Text = "창고";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label13.Location = new System.Drawing.Point(49, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 18);
            this.label13.TabIndex = 122;
            this.label13.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label2.Location = new System.Drawing.Point(449, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 117;
            this.label2.Text = "품목형태";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(430, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 18);
            this.label6.TabIndex = 118;
            this.label6.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label5.Location = new System.Drawing.Point(449, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 115;
            this.label5.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(430, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 18);
            this.label4.TabIndex = 116;
            this.label4.Text = "*";
            // 
            // dgvReorder
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvReorder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReorder.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReorder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReorder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReorder.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReorder.EnableHeadersVisualStyles = false;
            this.dgvReorder.Location = new System.Drawing.Point(0, 0);
            this.dgvReorder.Name = "dgvReorder";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReorder.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReorder.RowHeadersWidth = 30;
            this.dgvReorder.RowTemplate.Height = 23;
            this.dgvReorder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReorder.Size = new System.Drawing.Size(1254, 318);
            this.dgvReorder.TabIndex = 0;
            // 
            // FrmReorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1284, 562);
            this.Name = "FrmReorder";
            this.Text = "정규발주";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReorder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ITEM_TYP;
        private System.Windows.Forms.ComboBox USE_YN;
        private System.Windows.Forms.ComboBox PLAN_ID;
        private System.Windows.Forms.ComboBox COM_CODE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ITEM_STND;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox REORDER_TYP;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox MANAGER;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox FACILITY_TYPE;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private WindowsFormsApp18.MyDataGridView dgvReorder;
    }
}
