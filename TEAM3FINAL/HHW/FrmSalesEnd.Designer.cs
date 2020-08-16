namespace TEAM3FINAL
{
    partial class FrmSalesEnd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnMOVE = new System.Windows.Forms.Button();
            this.menuPanel1 = new TEAM3FINAL.MenuPanel();
            this.dgvSalesEnd = new WindowsFormsApp18.MyDataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1365, 178);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Location = new System.Drawing.Point(14, 17);
            this.panel2.Size = new System.Drawing.Size(1335, 145);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.dgvSalesEnd);
            this.panel3.Location = new System.Drawing.Point(15, 235);
            this.panel3.Size = new System.Drawing.Size(1363, 384);
            this.panel3.Controls.SetChildIndex(this.panel4, 0);
            this.panel3.Controls.SetChildIndex(this.dgvSalesEnd, 0);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 639);
            this.panel4.Size = new System.Drawing.Size(2051, 36);
            // 
            // btnMOVE
            // 
            this.btnMOVE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMOVE.AutoSize = true;
            this.btnMOVE.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMOVE.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMOVE.Location = new System.Drawing.Point(1262, 195);
            this.btnMOVE.Margin = new System.Windows.Forms.Padding(4);
            this.btnMOVE.Name = "btnMOVE";
            this.btnMOVE.Size = new System.Drawing.Size(114, 33);
            this.btnMOVE.TabIndex = 12;
            this.btnMOVE.Text = "마감처리";
            this.btnMOVE.UseVisualStyleBackColor = false;
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
            this.menuPanel1.Size = new System.Drawing.Size(1366, 39);
            this.menuPanel1.TabIndex = 11;
            this.menuPanel1.TitleFont = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.menuPanel1.TitleName = "고객주문";
            // 
            // dgvSalesEnd
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.dgvSalesEnd.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSalesEnd.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesEnd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSalesEnd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalesEnd.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSalesEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesEnd.EnableHeadersVisualStyles = false;
            this.dgvSalesEnd.Location = new System.Drawing.Point(0, 0);
            this.dgvSalesEnd.Name = "dgvSalesEnd";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalesEnd.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSalesEnd.RowHeadersWidth = 30;
            this.dgvSalesEnd.RowTemplate.Height = 23;
            this.dgvSalesEnd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesEnd.Size = new System.Drawing.Size(1363, 384);
            this.dgvSalesEnd.TabIndex = 8;
            // 
            // FrmSalesEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1389, 753);
            this.Controls.Add(this.btnMOVE);
            this.Controls.Add(this.menuPanel1);
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Name = "FrmSalesEnd";
            this.Text = "매출마감";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSalesEnd_FormClosing);
            this.Load += new System.EventHandler(this.FrmSalesEnd_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.menuPanel1, 0);
            this.Controls.SetChildIndex(this.btnMOVE, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMOVE;
        private MenuPanel menuPanel1;
        private WindowsFormsApp18.MyDataGridView dgvSalesEnd;
    }
}
