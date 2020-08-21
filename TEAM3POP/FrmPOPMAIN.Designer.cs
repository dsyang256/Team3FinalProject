namespace TEAM3POP
{
    partial class FrmPOPMAIN
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FCLTS_NAME = new System.Windows.Forms.TextBox();
            this.ITEM_CODE = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PLAN_ID = new System.Windows.Forms.TextBox();
            this.WO_Code = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.WO_PLAN_QTY = new System.Windows.Forms.TextBox();
            this.WO_QTY_OUT = new System.Windows.Forms.TextBox();
            this.WO_QTY_ALL = new System.Windows.Forms.TextBox();
            this.WO_QTY_PROD = new System.Windows.Forms.TextBox();
            this.WO_QTY_BAD = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.asdfa = new System.Windows.Forms.TabPage();
            this.dgv1 = new WindowsFormsApp18.MyDataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.asdfa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 317);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색조건";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(337, 65);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(142, 36);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 41);
            this.button1.TabIndex = 8;
            this.button1.Text = "검색";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(157, 224);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(193, 38);
            this.comboBox2.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(157, 145);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(193, 38);
            this.comboBox1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 30);
            this.label4.TabIndex = 4;
            this.label4.Text = "-";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(155, 65);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(142, 36);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "작  업  장";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "공      정";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "작업 일자";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FCLTS_NAME);
            this.groupBox2.Controls.Add(this.ITEM_CODE);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.PLAN_ID);
            this.groupBox2.Controls.Add(this.WO_Code);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.groupBox2.Location = new System.Drawing.Point(657, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(628, 317);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "세부정보";
            // 
            // FCLTS_NAME
            // 
            this.FCLTS_NAME.Location = new System.Drawing.Point(436, 195);
            this.FCLTS_NAME.Name = "FCLTS_NAME";
            this.FCLTS_NAME.ReadOnly = true;
            this.FCLTS_NAME.Size = new System.Drawing.Size(172, 36);
            this.FCLTS_NAME.TabIndex = 20;
            // 
            // ITEM_CODE
            // 
            this.ITEM_CODE.Location = new System.Drawing.Point(436, 120);
            this.ITEM_CODE.Name = "ITEM_CODE";
            this.ITEM_CODE.ReadOnly = true;
            this.ITEM_CODE.Size = new System.Drawing.Size(172, 36);
            this.ITEM_CODE.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(329, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 30);
            this.label9.TabIndex = 17;
            this.label9.Text = "설비명";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(329, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 30);
            this.label10.TabIndex = 16;
            this.label10.Text = "품목코드";
            // 
            // PLAN_ID
            // 
            this.PLAN_ID.Location = new System.Drawing.Point(139, 195);
            this.PLAN_ID.Name = "PLAN_ID";
            this.PLAN_ID.ReadOnly = true;
            this.PLAN_ID.Size = new System.Drawing.Size(172, 36);
            this.PLAN_ID.TabIndex = 14;
            // 
            // WO_Code
            // 
            this.WO_Code.Location = new System.Drawing.Point(139, 120);
            this.WO_Code.Name = "WO_Code";
            this.WO_Code.ReadOnly = true;
            this.WO_Code.Size = new System.Drawing.Size(172, 36);
            this.WO_Code.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 30);
            this.label6.TabIndex = 11;
            this.label6.Text = "계획번호";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 30);
            this.label7.TabIndex = 10;
            this.label7.Text = "지시번호";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.label11.Location = new System.Drawing.Point(1304, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 30);
            this.label11.TabIndex = 24;
            this.label11.Text = "생산전량";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.label12.Location = new System.Drawing.Point(1304, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 30);
            this.label12.TabIndex = 23;
            this.label12.Text = "실적합계";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.label13.Location = new System.Drawing.Point(1304, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 30);
            this.label13.TabIndex = 22;
            this.label13.Text = "지시수량";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.label15.Location = new System.Drawing.Point(1304, 260);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 30);
            this.label15.TabIndex = 26;
            this.label15.Text = "불량수량";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.label16.Location = new System.Drawing.Point(1304, 207);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 30);
            this.label16.TabIndex = 25;
            this.label16.Text = "양품수량";
            // 
            // WO_PLAN_QTY
            // 
            this.WO_PLAN_QTY.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.WO_PLAN_QTY.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.WO_PLAN_QTY.Location = new System.Drawing.Point(1477, 45);
            this.WO_PLAN_QTY.Name = "WO_PLAN_QTY";
            this.WO_PLAN_QTY.ReadOnly = true;
            this.WO_PLAN_QTY.Size = new System.Drawing.Size(219, 36);
            this.WO_PLAN_QTY.TabIndex = 22;
            this.WO_PLAN_QTY.Text = "0";
            this.WO_PLAN_QTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // WO_QTY_OUT
            // 
            this.WO_QTY_OUT.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.WO_QTY_OUT.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.WO_QTY_OUT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.WO_QTY_OUT.Location = new System.Drawing.Point(1477, 98);
            this.WO_QTY_OUT.Name = "WO_QTY_OUT";
            this.WO_QTY_OUT.ReadOnly = true;
            this.WO_QTY_OUT.Size = new System.Drawing.Size(219, 36);
            this.WO_QTY_OUT.TabIndex = 27;
            this.WO_QTY_OUT.Text = "0";
            this.WO_QTY_OUT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // WO_QTY_ALL
            // 
            this.WO_QTY_ALL.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.WO_QTY_ALL.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.WO_QTY_ALL.ForeColor = System.Drawing.Color.Yellow;
            this.WO_QTY_ALL.Location = new System.Drawing.Point(1477, 157);
            this.WO_QTY_ALL.Name = "WO_QTY_ALL";
            this.WO_QTY_ALL.ReadOnly = true;
            this.WO_QTY_ALL.Size = new System.Drawing.Size(219, 36);
            this.WO_QTY_ALL.TabIndex = 28;
            this.WO_QTY_ALL.Text = "0";
            this.WO_QTY_ALL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // WO_QTY_PROD
            // 
            this.WO_QTY_PROD.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.WO_QTY_PROD.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.WO_QTY_PROD.ForeColor = System.Drawing.Color.Lime;
            this.WO_QTY_PROD.Location = new System.Drawing.Point(1477, 204);
            this.WO_QTY_PROD.Name = "WO_QTY_PROD";
            this.WO_QTY_PROD.ReadOnly = true;
            this.WO_QTY_PROD.Size = new System.Drawing.Size(219, 36);
            this.WO_QTY_PROD.TabIndex = 29;
            this.WO_QTY_PROD.Text = "0";
            this.WO_QTY_PROD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // WO_QTY_BAD
            // 
            this.WO_QTY_BAD.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.WO_QTY_BAD.Font = new System.Drawing.Font("맑은 고딕", 16F);
            this.WO_QTY_BAD.ForeColor = System.Drawing.Color.Red;
            this.WO_QTY_BAD.Location = new System.Drawing.Point(1477, 257);
            this.WO_QTY_BAD.Name = "WO_QTY_BAD";
            this.WO_QTY_BAD.ReadOnly = true;
            this.WO_QTY_BAD.Size = new System.Drawing.Size(219, 36);
            this.WO_QTY_BAD.TabIndex = 30;
            this.WO_QTY_BAD.Text = "0";
            this.WO_QTY_BAD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 39);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1932, 469);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "투입 현황";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 39);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1932, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "불량현황";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // asdfa
            // 
            this.asdfa.Controls.Add(this.dgv1);
            this.asdfa.Location = new System.Drawing.Point(4, 39);
            this.asdfa.Name = "asdfa";
            this.asdfa.Padding = new System.Windows.Forms.Padding(3);
            this.asdfa.Size = new System.Drawing.Size(1932, 469);
            this.asdfa.TabIndex = 0;
            this.asdfa.Text = "생산현황";
            this.asdfa.UseVisualStyleBackColor = true;
            // 
            // dgv1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.ColumnHeadersHeight = 100;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.Location = new System.Drawing.Point(3, 3);
            this.dgv1.Name = "dgv1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv1.RowHeadersWidth = 100;
            this.dgv1.RowTemplate.Height = 100;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(1926, 463);
            this.dgv1.TabIndex = 0;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.asdfa);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.Location = new System.Drawing.Point(0, 335);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1940, 512);
            this.tabControl1.TabIndex = 31;
            // 
            // FrmPOPMAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1940, 847);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.WO_QTY_BAD);
            this.Controls.Add(this.WO_QTY_PROD);
            this.Controls.Add(this.WO_QTY_ALL);
            this.Controls.Add(this.WO_QTY_OUT);
            this.Controls.Add(this.WO_PLAN_QTY);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPOPMAIN";
            this.Load += new System.EventHandler(this.FrmPOPMAIN_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.asdfa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.TextBox FCLTS_NAME;
        private System.Windows.Forms.TextBox ITEM_CODE;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PLAN_ID;
        private System.Windows.Forms.TextBox WO_Code;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox WO_PLAN_QTY;
        private System.Windows.Forms.TextBox WO_QTY_OUT;
        private System.Windows.Forms.TextBox WO_QTY_ALL;
        private System.Windows.Forms.TextBox WO_QTY_PROD;
        private System.Windows.Forms.TextBox WO_QTY_BAD;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage asdfa;
        private WindowsFormsApp18.MyDataGridView dgv1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}
