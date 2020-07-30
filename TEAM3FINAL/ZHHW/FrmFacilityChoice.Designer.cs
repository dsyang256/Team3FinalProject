namespace TEAM3FINAL
{
    partial class FrmFacilityChoice
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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(285, 56);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(78, 16);
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.Text = "수정창 선택";
            // 
            // label2
            // 
            this.label2.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(30, 125);
            this.btnOK.Size = new System.Drawing.Size(97, 68);
            this.btnOK.Text = "설비군";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(166, 125);
            this.btnCancel.Size = new System.Drawing.Size(93, 68);
            this.btnCancel.Text = "설비";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmFacilityChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(285, 235);
            this.Name = "FrmFacilityChoice";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
