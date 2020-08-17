namespace TEAM3FINAL
{
    partial class FrmReceivingSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.WRHS = new System.Windows.Forms.ComboBox();
            this.ITEM_MANAGE_LEVEL = new System.Windows.Forms.ComboBox();
            this.ITEM_TYP = new System.Windows.Forms.ComboBox();
            this.QTY = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sday = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.menuPanel1 = new TEAM3FINAL.MenuPanel();
            this.dgv1 = new WindowsFormsApp18.MyDataGridView();
            this.ITEMENAME = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1285, 200);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ITEMENAME);
            this.panel2.Controls.Add(this.sday);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.WRHS);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.ITEM_MANAGE_LEVEL);
            this.panel2.Controls.Add(this.ITEM_TYP);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.QTY);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Size = new System.Drawing.Size(1279, 180);
            // 
            // label1
            // 
            this.label1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv1);
            this.panel3.Location = new System.Drawing.Point(15, 249);
            this.panel3.Size = new System.Drawing.Size(1279, 423);
            // 
            // WRHS
            // 
            this.WRHS.FormattingEnabled = true;
            this.WRHS.Location = new System.Drawing.Point(164, 79);
            this.WRHS.Name = "WRHS";
            this.WRHS.Size = new System.Drawing.Size(193, 23);
            this.WRHS.TabIndex = 25;
            // 
            // ITEM_MANAGE_LEVEL
            // 
            this.ITEM_MANAGE_LEVEL.FormattingEnabled = true;
            this.ITEM_MANAGE_LEVEL.Location = new System.Drawing.Point(905, 77);
            this.ITEM_MANAGE_LEVEL.Name = "ITEM_MANAGE_LEVEL";
            this.ITEM_MANAGE_LEVEL.Size = new System.Drawing.Size(193, 23);
            this.ITEM_MANAGE_LEVEL.TabIndex = 27;
            // 
            // ITEM_TYP
            // 
            this.ITEM_TYP.FormattingEnabled = true;
            this.ITEM_TYP.Location = new System.Drawing.Point(905, 27);
            this.ITEM_TYP.Name = "ITEM_TYP";
            this.ITEM_TYP.Size = new System.Drawing.Size(193, 23);
            this.ITEM_TYP.TabIndex = 20;
            // 
            // QTY
            // 
            this.QTY.Location = new System.Drawing.Point(531, 77);
            this.QTY.Name = "QTY";
            this.QTY.Size = new System.Drawing.Size(193, 23);
            this.QTY.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(828, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 15);
            this.label18.TabIndex = 43;
            this.label18.Text = "관리등급";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(829, 32);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 15);
            this.label19.TabIndex = 42;
            this.label19.Text = "품목유형";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(462, 79);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 15);
            this.label15.TabIndex = 39;
            this.label15.Text = "재고량";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(461, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 15);
            this.label14.TabIndex = 23;
            this.label14.Text = "품목";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(104, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 15);
            this.label12.TabIndex = 38;
            this.label12.Text = "창고";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label8.Location = new System.Drawing.Point(805, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 17);
            this.label8.TabIndex = 37;
            this.label8.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(805, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 17);
            this.label10.TabIndex = 35;
            this.label10.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(438, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 34;
            this.label5.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(438, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 17);
            this.label7.TabIndex = 31;
            this.label7.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(79, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 28;
            this.label4.Text = "*";
            // 
            // sday
            // 
            this.sday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.sday.Location = new System.Drawing.Point(164, 25);
            this.sday.Name = "sday";
            this.sday.Size = new System.Drawing.Size(193, 23);
            this.sday.TabIndex = 170;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(103, 29);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 15);
            this.label20.TabIndex = 166;
            this.label20.Text = "입고출일";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label21.Location = new System.Drawing.Point(79, 26);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 17);
            this.label21.TabIndex = 167;
            this.label21.Text = "*";
            // 
            // menuPanel1
            // 
            this.menuPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPanel1.BackColor = System.Drawing.Color.Transparent;
            this.menuPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.menuPanel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.Location = new System.Drawing.Point(12, 214);
            this.menuPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.menuPanel1.Name = "menuPanel1";
            this.menuPanel1.Size = new System.Drawing.Size(1282, 32);
            this.menuPanel1.TabIndex = 4;
            this.menuPanel1.TitleFont = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.TitleName = "자재재고현황";
            // 
            // dgv1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1.EnableHeadersVisualStyles = false;
            this.dgv1.Location = new System.Drawing.Point(0, 0);
            this.dgv1.Name = "dgv1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv1.RowHeadersWidth = 30;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(1279, 423);
            this.dgv1.TabIndex = 0;
            // 
            // ITEMENAME
            // 
            this.ITEMENAME.Location = new System.Drawing.Point(531, 25);
            this.ITEMENAME.Name = "ITEMENAME";
            this.ITEMENAME.Size = new System.Drawing.Size(193, 23);
            this.ITEMENAME.TabIndex = 171;
            // 
            // FrmReceivingSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 684);
            this.Controls.Add(this.menuPanel1);
            this.Name = "FrmReceivingSearch";
            this.Text = "자재재고현황";
            this.Load += new System.EventHandler(this.FrmReceivingSearch_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.menuPanel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox WRHS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ITEM_MANAGE_LEVEL;
        private System.Windows.Forms.ComboBox ITEM_TYP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox QTY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker sday;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private MenuPanel menuPanel1;
        private WindowsFormsApp18.MyDataGridView dgv1;
        private System.Windows.Forms.TextBox ITEMENAME;
    }
}