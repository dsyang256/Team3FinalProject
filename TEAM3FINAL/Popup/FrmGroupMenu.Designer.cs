namespace TEAM3FINAL
{
    partial class FrmGroupMenu
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRightAdd = new System.Windows.Forms.Button();
            this.btnRightRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancels = new System.Windows.Forms.Button();
            this.dgvGroups = new WindowsFormsApp18.MyDataGridView();
            this.dgvMenus = new WindowsFormsApp18.MyDataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancels);
            this.panel1.Size = new System.Drawing.Size(1035, 56);
            this.panel1.Controls.SetChildIndex(this.btnCancels, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(197, 25);
            this.label1.Text = "그룹별 허용메뉴 관리";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(90, 67);
            this.label2.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(469, 64);
            this.btnOK.Text = "저장";
            this.btnOK.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(533, 64);
            this.btnCancel.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 100);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvGroups);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvMenus);
            this.splitContainer1.Size = new System.Drawing.Size(1025, 456);
            this.splitContainer1.SplitterDistance = 710;
            this.splitContainer1.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.Location = new System.Drawing.Point(6, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
            this.label11.TabIndex = 55;
            this.label11.Text = "권한그룹";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(721, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 55;
            this.label4.Text = "권한등록 메뉴";
            // 
            // btnRightAdd
            // 
            this.btnRightAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnRightAdd.FlatAppearance.BorderSize = 0;
            this.btnRightAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightAdd.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRightAdd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnRightAdd.Image = global::TEAM3FINAL.Properties.Resources.plus_math_30px;
            this.btnRightAdd.Location = new System.Drawing.Point(668, 77);
            this.btnRightAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRightAdd.Name = "btnRightAdd";
            this.btnRightAdd.Size = new System.Drawing.Size(20, 20);
            this.btnRightAdd.TabIndex = 54;
            this.btnRightAdd.UseVisualStyleBackColor = false;
            this.btnRightAdd.Click += new System.EventHandler(this.btnRightAdd_Click);
            // 
            // btnRightRemove
            // 
            this.btnRightRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRightRemove.FlatAppearance.BorderSize = 0;
            this.btnRightRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRightRemove.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRightRemove.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnRightRemove.Image = global::TEAM3FINAL.Properties.Resources.subtract_30px;
            this.btnRightRemove.Location = new System.Drawing.Point(694, 77);
            this.btnRightRemove.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRightRemove.Name = "btnRightRemove";
            this.btnRightRemove.Size = new System.Drawing.Size(20, 20);
            this.btnRightRemove.TabIndex = 54;
            this.btnRightRemove.UseVisualStyleBackColor = false;
            this.btnRightRemove.Click += new System.EventHandler(this.btnRightRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Image = global::TEAM3FINAL.Properties.Resources.Save_16x16;
            this.btnSave.Location = new System.Drawing.Point(967, 61);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 33);
            this.btnSave.TabIndex = 54;
            this.btnSave.Text = "저장";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancels
            // 
            this.btnCancels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancels.BackColor = System.Drawing.Color.Transparent;
            this.btnCancels.FlatAppearance.BorderSize = 0;
            this.btnCancels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancels.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancels.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancels.Image = global::TEAM3FINAL.Properties.Resources.Save_16x16;
            this.btnCancels.Location = new System.Drawing.Point(967, 13);
            this.btnCancels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancels.Name = "btnCancels";
            this.btnCancels.Size = new System.Drawing.Size(63, 33);
            this.btnCancels.TabIndex = 54;
            this.btnCancels.Text = "취소";
            this.btnCancels.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancels.UseVisualStyleBackColor = false;
            this.btnCancels.Click += new System.EventHandler(this.btnCancels_Click);
            // 
            // dgvGroups
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvGroups.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGroups.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGroups.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGroups.EnableHeadersVisualStyles = false;
            this.dgvGroups.Location = new System.Drawing.Point(0, 0);
            this.dgvGroups.Name = "dgvGroups";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroups.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGroups.RowHeadersWidth = 30;
            this.dgvGroups.RowTemplate.Height = 23;
            this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGroups.Size = new System.Drawing.Size(710, 456);
            this.dgvGroups.TabIndex = 0;
            this.dgvGroups.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGroups_CellClick);
            // 
            // dgvMenus
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.dgvMenus.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvMenus.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMenus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvMenus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Menu;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMenus.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMenus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenus.EnableHeadersVisualStyles = false;
            this.dgvMenus.Location = new System.Drawing.Point(0, 0);
            this.dgvMenus.Name = "dgvMenus";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMenus.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMenus.RowHeadersWidth = 30;
            this.dgvMenus.RowTemplate.Height = 23;
            this.dgvMenus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenus.Size = new System.Drawing.Size(311, 456);
            this.dgvMenus.TabIndex = 0;
            // 
            // FrmGroupMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1035, 559);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnRightRemove);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRightAdd);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmGroupMenu";
            this.Load += new System.EventHandler(this.FrmGroupMenu_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.Controls.SetChildIndex(this.btnRightAdd, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnRightRemove, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Button btnRightAdd;
        protected System.Windows.Forms.Button btnRightRemove;
        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.Button btnCancels;
        private WindowsFormsApp18.MyDataGridView dgvGroups;
        private WindowsFormsApp18.MyDataGridView dgvMenus;
    }
}
