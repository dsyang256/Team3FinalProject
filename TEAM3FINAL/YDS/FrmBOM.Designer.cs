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
            this.ITEM_COM_REORDER = new System.Windows.Forms.ComboBox();
            this.ITEM_STND = new System.Windows.Forms.TextBox();
            this.ITEM_NAME = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(1180, 138);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ITEM_COM_REORDER);
            this.panel2.Controls.Add(this.ITEM_STND);
            this.panel2.Controls.Add(this.ITEM_NAME);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Size = new System.Drawing.Size(1174, 113);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(15, 158);
            this.panel3.Size = new System.Drawing.Size(1174, 392);
            // 
            // ITEM_COM_REORDER
            // 
            this.ITEM_COM_REORDER.FormattingEnabled = true;
            this.ITEM_COM_REORDER.Location = new System.Drawing.Point(470, 44);
            this.ITEM_COM_REORDER.Name = "ITEM_COM_REORDER";
            this.ITEM_COM_REORDER.Size = new System.Drawing.Size(193, 23);
            this.ITEM_COM_REORDER.TabIndex = 29;
            this.ITEM_COM_REORDER.SelectedIndexChanged += new System.EventHandler(this.ITEM_COM_REORDER_SelectedIndexChanged);
            // 
            // ITEM_STND
            // 
            this.ITEM_STND.Location = new System.Drawing.Point(855, 46);
            this.ITEM_STND.Name = "ITEM_STND";
            this.ITEM_STND.Size = new System.Drawing.Size(193, 23);
            this.ITEM_STND.TabIndex = 28;
            // 
            // ITEM_NAME
            // 
            this.ITEM_NAME.Location = new System.Drawing.Point(114, 43);
            this.ITEM_NAME.Name = "ITEM_NAME";
            this.ITEM_NAME.Size = new System.Drawing.Size(193, 23);
            this.ITEM_NAME.TabIndex = 27;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(780, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(31, 15);
            this.label19.TabIndex = 26;
            this.label19.Text = "설비";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(413, 45);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(31, 15);
            this.label14.TabIndex = 21;
            this.label14.Text = "공정";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(55, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "품목";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label10.Location = new System.Drawing.Point(757, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(390, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(31, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "*";
            // 
            // FrmBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1204, 562);
            this.Name = "FrmBOM";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ITEM_COM_REORDER;
        private System.Windows.Forms.TextBox ITEM_STND;
        private System.Windows.Forms.TextBox ITEM_NAME;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
    }
}
