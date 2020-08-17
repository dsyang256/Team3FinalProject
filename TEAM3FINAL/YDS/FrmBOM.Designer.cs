namespace TEAM3FINAL
{
    partial class FrmBOM
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
            this.ITEM_NAEM = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.day = new System.Windows.Forms.DateTimePicker();
            this.BOM_USE_YN = new System.Windows.Forms.ComboBox();
            this.dgvBOM = new WindowsFormsApp18.MyDataGridView();
            this.menuPanel1 = new TEAM3FINAL.MenuPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1180, 138);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.day);
            this.panel2.Controls.Add(this.BOM_USE_YN);
            this.panel2.Controls.Add(this.ITEM_NAEM);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Size = new System.Drawing.Size(1174, 113);
            // 
            // label1
            // 
            this.label1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvBOM);
            this.panel3.Location = new System.Drawing.Point(15, 190);
            this.panel3.Size = new System.Drawing.Size(1174, 360);
            // 
            // ITEM_NAEM
            // 
            this.ITEM_NAEM.Location = new System.Drawing.Point(513, 41);
            this.ITEM_NAEM.Name = "ITEM_NAEM";
            this.ITEM_NAEM.Size = new System.Drawing.Size(193, 23);
            this.ITEM_NAEM.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(811, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 15);
            this.label19.TabIndex = 26;
            this.label19.Text = "사용유무";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(443, 43);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 15);
            this.label14.TabIndex = 21;
            this.label14.Text = "품목";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(86, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "기준일자";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(787, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 18);
            this.label10.TabIndex = 25;
            this.label10.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(420, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 18);
            this.label7.TabIndex = 24;
            this.label7.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(61, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "*";
            // 
            // day
            // 
            this.day.Location = new System.Drawing.Point(144, 41);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(193, 23);
            this.day.TabIndex = 0;
            // 
            // BOM_USE_YN
            // 
            this.BOM_USE_YN.FormattingEnabled = true;
            this.BOM_USE_YN.Location = new System.Drawing.Point(887, 43);
            this.BOM_USE_YN.Name = "BOM_USE_YN";
            this.BOM_USE_YN.Size = new System.Drawing.Size(193, 23);
            this.BOM_USE_YN.TabIndex = 2;
            // 
            // dgvBOM
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBOM.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBOM.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBOM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBOM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBOM.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBOM.EnableHeadersVisualStyles = false;
            this.dgvBOM.Location = new System.Drawing.Point(0, 0);
            this.dgvBOM.Name = "dgvBOM";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBOM.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBOM.RowHeadersWidth = 30;
            this.dgvBOM.RowTemplate.Height = 23;
            this.dgvBOM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBOM.Size = new System.Drawing.Size(1174, 360);
            this.dgvBOM.TabIndex = 0;
            // 
            // menuPanel1
            // 
            this.menuPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuPanel1.BackColor = System.Drawing.Color.Transparent;
            this.menuPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.menuPanel1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.Location = new System.Drawing.Point(12, 155);
            this.menuPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.menuPanel1.Name = "menuPanel1";
            this.menuPanel1.Size = new System.Drawing.Size(1180, 32);
            this.menuPanel1.TabIndex = 4;
            this.menuPanel1.TitleFont = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.TitleName = "BOM";
            // 
            // FrmBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1204, 562);
            this.Controls.Add(this.menuPanel1);
            this.Name = "FrmBOM";
            this.Text = "BOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBOM_FormClosing);
            this.Load += new System.EventHandler(this.FrmBOM_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.menuPanel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBOM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ITEM_NAEM;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker day;
        private System.Windows.Forms.ComboBox BOM_USE_YN;
        private WindowsFormsApp18.MyDataGridView dgvBOM;
        private MenuPanel menuPanel1;
    }
}
