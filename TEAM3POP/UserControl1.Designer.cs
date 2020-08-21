namespace TEAM3POP
{
    partial class UserControl1
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.task_code = new System.Windows.Forms.Label();
            this.btnTaskStop = new System.Windows.Forms.Button();
            this.dgv = new WindowsFormsApp18.MyDataGridView();
            this.itemname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.hostPort = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hostIP = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnTaskStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BADQTY = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.residualqty = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.GOODQTY = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.qty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.taskID = new System.Windows.Forms.Label();
            this.timSocket_Connect = new System.Windows.Forms.Timer(this.components);
            this.timSocket_Check = new System.Windows.Forms.Timer(this.components);
            this.timSocket_Ka = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.task_code);
            this.panel1.Controls.Add(this.btnTaskStop);
            this.panel1.Controls.Add(this.dgv);
            this.panel1.Controls.Add(this.itemname);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.btnTaskStart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.BADQTY);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.residualqty);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.GOODQTY);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.qty);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.taskID);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1899, 200);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1641, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 78);
            this.button1.TabIndex = 32;
            this.button1.Text = "초기화";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(1260, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(63, 54);
            this.panel3.TabIndex = 8;
            // 
            // task_code
            // 
            this.task_code.AutoSize = true;
            this.task_code.Location = new System.Drawing.Point(1077, 58);
            this.task_code.Name = "task_code";
            this.task_code.Size = new System.Drawing.Size(38, 12);
            this.task_code.TabIndex = 31;
            this.task_code.Text = "label5";
            this.task_code.Visible = false;
            // 
            // btnTaskStop
            // 
            this.btnTaskStop.Enabled = false;
            this.btnTaskStop.Location = new System.Drawing.Point(1485, 19);
            this.btnTaskStop.Name = "btnTaskStop";
            this.btnTaskStop.Size = new System.Drawing.Size(150, 78);
            this.btnTaskStop.TabIndex = 22;
            this.btnTaskStop.Text = "설비중단";
            this.btnTaskStop.UseVisualStyleBackColor = true;
            this.btnTaskStop.Click += new System.EventHandler(this.btnTaskStop_Click);
            // 
            // dgv
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Location = new System.Drawing.Point(658, 106);
            this.dgv.Name = "dgv";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.RowHeadersWidth = 20;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(442, 81);
            this.dgv.TabIndex = 30;
            // 
            // itemname
            // 
            this.itemname.Enabled = false;
            this.itemname.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.itemname.Location = new System.Drawing.Point(740, 61);
            this.itemname.Name = "itemname";
            this.itemname.Size = new System.Drawing.Size(262, 39);
            this.itemname.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(555, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 27);
            this.label4.TabIndex = 27;
            this.label4.Text = "작업품목";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hostPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.hostIP);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(28, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 124);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "서버정보";
            // 
            // hostPort
            // 
            this.hostPort.AutoSize = true;
            this.hostPort.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.hostPort.Location = new System.Drawing.Point(120, 35);
            this.hostPort.Name = "hostPort";
            this.hostPort.Size = new System.Drawing.Size(66, 27);
            this.hostPort.TabIndex = 6;
            this.hostPort.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(36, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(27, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port";
            // 
            // hostIP
            // 
            this.hostIP.AutoSize = true;
            this.hostIP.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.hostIP.Location = new System.Drawing.Point(97, 81);
            this.hostIP.Name = "hostIP";
            this.hostIP.Size = new System.Drawing.Size(38, 27);
            this.hostIP.TabIndex = 5;
            this.hostIP.Text = "IP";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(69, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 27);
            this.label10.TabIndex = 16;
            this.label10.Text = ":";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(97, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 27);
            this.label11.TabIndex = 17;
            this.label11.Text = ":";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1641, 103);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(150, 78);
            this.button6.TabIndex = 25;
            this.button6.Text = "로그보기";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(1485, 103);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(150, 78);
            this.btnStop.TabIndex = 24;
            this.btnStop.Text = "작업종료";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1329, 103);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 78);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "작업시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnTaskStart
            // 
            this.btnTaskStart.Location = new System.Drawing.Point(1329, 19);
            this.btnTaskStart.Name = "btnTaskStart";
            this.btnTaskStart.Size = new System.Drawing.Size(150, 78);
            this.btnTaskStart.TabIndex = 21;
            this.btnTaskStart.Text = "설비가동";
            this.btnTaskStart.UseVisualStyleBackColor = true;
            this.btnTaskStart.Click += new System.EventHandler(this.btnTaskStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(555, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 27);
            this.label1.TabIndex = 19;
            this.label1.Text = "작업지시";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(740, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(262, 35);
            this.comboBox1.TabIndex = 18;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BADQTY
            // 
            this.BADQTY.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BADQTY.Location = new System.Drawing.Point(430, 148);
            this.BADQTY.Name = "BADQTY";
            this.BADQTY.ReadOnly = true;
            this.BADQTY.Size = new System.Drawing.Size(100, 39);
            this.BADQTY.TabIndex = 15;
            this.BADQTY.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(356, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 27);
            this.label9.TabIndex = 14;
            this.label9.Text = "불량";
            // 
            // residualqty
            // 
            this.residualqty.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.residualqty.Location = new System.Drawing.Point(430, 58);
            this.residualqty.Name = "residualqty";
            this.residualqty.ReadOnly = true;
            this.residualqty.Size = new System.Drawing.Size(100, 39);
            this.residualqty.TabIndex = 13;
            this.residualqty.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label8.Location = new System.Drawing.Point(356, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 27);
            this.label8.TabIndex = 12;
            this.label8.Text = "잔여";
            // 
            // GOODQTY
            // 
            this.GOODQTY.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.GOODQTY.Location = new System.Drawing.Point(430, 103);
            this.GOODQTY.Name = "GOODQTY";
            this.GOODQTY.ReadOnly = true;
            this.GOODQTY.Size = new System.Drawing.Size(100, 39);
            this.GOODQTY.TabIndex = 11;
            this.GOODQTY.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(356, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 27);
            this.label7.TabIndex = 10;
            this.label7.Text = "양품";
            // 
            // qty
            // 
            this.qty.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.qty.Location = new System.Drawing.Point(430, 13);
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Size = new System.Drawing.Size(100, 39);
            this.qty.TabIndex = 9;
            this.qty.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(356, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 27);
            this.label6.TabIndex = 8;
            this.label6.Text = "지시";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(1260, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(63, 54);
            this.panel2.TabIndex = 7;
            // 
            // taskID
            // 
            this.taskID.AutoSize = true;
            this.taskID.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.taskID.Location = new System.Drawing.Point(23, 16);
            this.taskID.Name = "taskID";
            this.taskID.Size = new System.Drawing.Size(96, 27);
            this.taskID.TabIndex = 2;
            this.taskID.Text = "설비명";
            // 
            // timSocket_Connect
            // 
            this.timSocket_Connect.Tick += new System.EventHandler(this.timSocket_Connect_Tick);
            // 
            // timSocket_Check
            // 
            this.timSocket_Check.Tick += new System.EventHandler(this.timSocket_Check_Tick);
            // 
            // timSocket_Ka
            // 
            this.timSocket_Ka.Tick += new System.EventHandler(this.timSocket_Ka_Tick);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1800, 215);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BADQTY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox residualqty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox GOODQTY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox qty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label hostIP;
        public System.Windows.Forms.Label taskID;
        public System.Windows.Forms.Label hostPort;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnTaskStop;
        private System.Windows.Forms.Button btnTaskStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox itemname;
        public System.Windows.Forms.Label label4;
        private WindowsFormsApp18.MyDataGridView dgv;
        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timSocket_Connect;
        private System.Windows.Forms.Timer timSocket_Check;
        private System.Windows.Forms.Timer timSocket_Ka;
        private System.Windows.Forms.Label task_code;
        public System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
    }
  
}
