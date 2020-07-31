namespace TEAM3FINAL
{
    partial class FrmSalesMasterUpLoad
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
            this.panel1.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Visible = false;
            // 
            // label1
            // 
            this.label1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(15, 13);
            this.panel3.Size = new System.Drawing.Size(770, 537);
            // 
            // FrmSalesMasterUpLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Name = "FrmSalesMasterUpLoad";
            this.Text = "영업마스터 업로드";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
