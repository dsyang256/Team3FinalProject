namespace TEAM3FINAL
{
    partial class FrmItem
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ITEM_NAME = new System.Windows.Forms.TextBox();
            this.ITEM_STND = new System.Windows.Forms.TextBox();
            this.ITEM_COM_REORDER = new System.Windows.Forms.ComboBox();
            this.ITEM_WRHS_OUT = new System.Windows.Forms.ComboBox();
            this.ITEM_USE_YN = new System.Windows.Forms.ComboBox();
            this.ITEM_TYP = new System.Windows.Forms.ComboBox();
            this.ITEM_WRHS_IN = new System.Windows.Forms.ComboBox();
            this.ITEM_MANAGER = new System.Windows.Forms.ComboBox();
            this.ITEM_COM_DLVR = new System.Windows.Forms.ComboBox();
            this.dgvitem = new WindowsFormsApp18.MyDataGridView();
            this.menuPanel1 = new TEAM3FINAL.MenuPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1132, 200);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ITEM_COM_DLVR);
            this.panel2.Controls.Add(this.ITEM_MANAGER);
            this.panel2.Controls.Add(this.ITEM_WRHS_IN);
            this.panel2.Controls.Add(this.ITEM_TYP);
            this.panel2.Controls.Add(this.ITEM_USE_YN);
            this.panel2.Controls.Add(this.ITEM_WRHS_OUT);
            this.panel2.Controls.Add(this.ITEM_COM_REORDER);
            this.panel2.Controls.Add(this.ITEM_STND);
            this.panel2.Controls.Add(this.ITEM_NAME);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Size = new System.Drawing.Size(1126, 180);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.Text = "품목정보";
            this.label1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvitem);
            this.panel3.Location = new System.Drawing.Point(15, 252);
            this.panel3.Size = new System.Drawing.Size(1126, 298);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(44, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(44, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(44, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(403, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(403, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(403, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 18);
            this.label7.TabIndex = 7;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(770, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 18);
            this.label8.TabIndex = 12;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label9.Location = new System.Drawing.Point(770, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 18);
            this.label9.TabIndex = 11;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(770, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 18);
            this.label10.TabIndex = 10;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "품명";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(68, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 13;
            this.label12.Text = "납품업체";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(68, 136);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 15);
            this.label13.TabIndex = 14;
            this.label13.Text = "담당자";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(426, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "규격";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(426, 82);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 15);
            this.label15.TabIndex = 13;
            this.label15.Text = "입고창고";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(426, 134);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 15);
            this.label16.TabIndex = 14;
            this.label16.Text = "품목유형";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(793, 138);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 15);
            this.label17.TabIndex = 17;
            this.label17.Text = "사용유무";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(793, 86);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 15);
            this.label18.TabIndex = 16;
            this.label18.Text = "출고창고";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(793, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 15);
            this.label19.TabIndex = 15;
            this.label19.Text = "업체";
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.Location = new System.Drawing.Point(127, 29);
            this.ITEM_NAME.Name = "ITEM_NAME";
            this.ITEM_NAME.Size = new System.Drawing.Size(193, 23);
            this.ITEM_NAME.TabIndex = 0;
            // 
            // ITEM_STND
            // 
            this.ITEM_STND.Location = new System.Drawing.Point(496, 29);
            this.ITEM_STND.Name = "ITEM_STND";
            this.ITEM_STND.Size = new System.Drawing.Size(193, 23);
            this.ITEM_STND.TabIndex = 1;
            // 
            // ITEM_COM_REORDER
            // 
            this.ITEM_COM_REORDER.FormattingEnabled = true;
            this.ITEM_COM_REORDER.Location = new System.Drawing.Point(870, 31);
            this.ITEM_COM_REORDER.Name = "ITEM_COM_REORDER";
            this.ITEM_COM_REORDER.Size = new System.Drawing.Size(193, 23);
            this.ITEM_COM_REORDER.TabIndex = 2;
            // 
            // ITEM_WRHS_OUT
            // 
            this.ITEM_WRHS_OUT.FormattingEnabled = true;
            this.ITEM_WRHS_OUT.Location = new System.Drawing.Point(870, 81);
            this.ITEM_WRHS_OUT.Name = "ITEM_WRHS_OUT";
            this.ITEM_WRHS_OUT.Size = new System.Drawing.Size(193, 23);
            this.ITEM_WRHS_OUT.TabIndex = 5;
            // 
            // ITEM_USE_YN
            // 
            this.ITEM_USE_YN.FormattingEnabled = true;
            this.ITEM_USE_YN.Location = new System.Drawing.Point(870, 133);
            this.ITEM_USE_YN.Name = "ITEM_USE_YN";
            this.ITEM_USE_YN.Size = new System.Drawing.Size(193, 23);
            this.ITEM_USE_YN.TabIndex = 8;
            // 
            // ITEM_TYP
            // 
            this.ITEM_TYP.FormattingEnabled = true;
            this.ITEM_TYP.Location = new System.Drawing.Point(496, 131);
            this.ITEM_TYP.Name = "ITEM_TYP";
            this.ITEM_TYP.Size = new System.Drawing.Size(193, 23);
            this.ITEM_TYP.TabIndex = 7;
            // 
            // ITEM_WRHS_IN
            // 
            this.ITEM_WRHS_IN.FormattingEnabled = true;
            this.ITEM_WRHS_IN.Location = new System.Drawing.Point(496, 81);
            this.ITEM_WRHS_IN.Name = "ITEM_WRHS_IN";
            this.ITEM_WRHS_IN.Size = new System.Drawing.Size(193, 23);
            this.ITEM_WRHS_IN.TabIndex = 4;
            // 
            // ITEM_MANAGER
            // 
            this.ITEM_MANAGER.FormattingEnabled = true;
            this.ITEM_MANAGER.Location = new System.Drawing.Point(127, 131);
            this.ITEM_MANAGER.Name = "ITEM_MANAGER";
            this.ITEM_MANAGER.Size = new System.Drawing.Size(193, 23);
            this.ITEM_MANAGER.TabIndex = 6;
            // 
            // ITEM_COM_DLVR
            // 
            this.ITEM_COM_DLVR.FormattingEnabled = true;
            this.ITEM_COM_DLVR.Location = new System.Drawing.Point(129, 81);
            this.ITEM_COM_DLVR.Name = "ITEM_COM_DLVR";
            this.ITEM_COM_DLVR.Size = new System.Drawing.Size(193, 23);
            this.ITEM_COM_DLVR.TabIndex = 3;
            // 
            // dgvitem
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvitem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvitem.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvitem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvitem.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvitem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvitem.EnableHeadersVisualStyles = false;
            this.dgvitem.Location = new System.Drawing.Point(0, 0);
            this.dgvitem.Name = "dgvitem";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvitem.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvitem.RowHeadersWidth = 30;
            this.dgvitem.RowTemplate.Height = 23;
            this.dgvitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvitem.Size = new System.Drawing.Size(1126, 298);
            this.dgvitem.TabIndex = 0;
            this.dgvitem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvitem_CellContentClick);
            // 
            // menuPanel1
            // 
            this.menuPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPanel1.BackColor = System.Drawing.Color.Transparent;
            this.menuPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.menuPanel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.Location = new System.Drawing.Point(12, 217);
            this.menuPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.menuPanel1.Name = "menuPanel1";
            this.menuPanel1.Size = new System.Drawing.Size(1129, 32);
            this.menuPanel1.TabIndex = 1;
            this.menuPanel1.TitleFont = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.TitleName = "품목정보";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(1052, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 25);
            this.button1.TabIndex = 6;
            this.button1.Text = "바코드출력";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1156, 574);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuPanel1);
            this.Name = "FrmItem";
            this.Text = "품목";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmItem_FormClosing);
            this.Load += new System.EventHandler(this.FrmItem_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.menuPanel1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ITEM_COM_DLVR;
        private System.Windows.Forms.ComboBox ITEM_MANAGER;
        private System.Windows.Forms.ComboBox ITEM_WRHS_IN;
        private System.Windows.Forms.ComboBox ITEM_TYP;
        private System.Windows.Forms.ComboBox ITEM_USE_YN;
        private System.Windows.Forms.ComboBox ITEM_WRHS_OUT;
        private System.Windows.Forms.ComboBox ITEM_COM_REORDER;
        private System.Windows.Forms.TextBox ITEM_STND;
        private System.Windows.Forms.TextBox ITEM_NAME;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private WindowsFormsApp18.MyDataGridView dgvitem;
        private MenuPanel menuPanel1;
        private System.Windows.Forms.Button button1;
    }
}
