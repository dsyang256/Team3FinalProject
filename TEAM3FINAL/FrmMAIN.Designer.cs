namespace TEAM3FINAL
{
    partial class FrmMAIN
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMAIN));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSearch = new System.Windows.Forms.ToolStripButton();
            this.tsbInsert = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblDateTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabForms = new TEAM3FINAL.ucTabControl();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.test용입니다ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그인ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.회원가입ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.자원관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.공장관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.품목관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.품목관리ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bOM관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.공통코드관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSearch,
            this.tsbInsert,
            this.tsbDelete,
            this.tsbUpdate,
            this.tsbPrint,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 48);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 39);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSearch
            // 
            this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
            this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSearch.Name = "tsbSearch";
            this.tsbSearch.Size = new System.Drawing.Size(36, 36);
            this.tsbSearch.Text = "toolStripButton1";
            this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
            // 
            // tsbInsert
            // 
            this.tsbInsert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInsert.Image = ((System.Drawing.Image)(resources.GetObject("tsbInsert.Image")));
            this.tsbInsert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsert.Name = "tsbInsert";
            this.tsbInsert.Size = new System.Drawing.Size(36, 36);
            this.tsbInsert.Text = "toolStripButton2";
            this.tsbInsert.Click += new System.EventHandler(this.tsbInsert_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(36, 36);
            this.tsbDelete.Text = "toolStripButton3";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdate.Image")));
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(36, 36);
            this.tsbUpdate.Text = "toolStripButton4";
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(36, 36);
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(115, 36);
            this.toolStripLabel1.Text = "현재 활성된 폼 이름";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblDateTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 540);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblDateTime
            // 
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(33, 17);
            this.lblDateTime.Text = "Time";
            // 
            // tabForms
            // 
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabForms.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabForms.Location = new System.Drawing.Point(0, 87);
            this.tabForms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(800, 28);
            this.tabForms.TabIndex = 9;
            this.tabForms.Visible = false;
            this.tabForms.SelectedIndexChanged += new System.EventHandler(this.tabForms_SelectedIndexChanged);
            this.tabForms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabForms_MouseDown);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test용입니다ToolStripMenuItem,
            this.로그인ToolStripMenuItem,
            this.자원관리ToolStripMenuItem,
            this.품목관리ToolStripMenuItem,
            this.공통코드관리ToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 24);
            this.menuStrip2.TabIndex = 11;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // test용입니다ToolStripMenuItem
            // 
            this.test용입니다ToolStripMenuItem.Name = "test용입니다ToolStripMenuItem";
            this.test용입니다ToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.test용입니다ToolStripMenuItem.Text = "Test용입니다.";
            // 
            // 로그인ToolStripMenuItem
            // 
            this.로그인ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.로그인ToolStripMenuItem1,
            this.회원가입ToolStripMenuItem});
            this.로그인ToolStripMenuItem.Name = "로그인ToolStripMenuItem";
            this.로그인ToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.로그인ToolStripMenuItem.Text = "로그인";
            // 
            // 로그인ToolStripMenuItem1
            // 
            this.로그인ToolStripMenuItem1.Name = "로그인ToolStripMenuItem1";
            this.로그인ToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.로그인ToolStripMenuItem1.Text = "로그인";
            this.로그인ToolStripMenuItem1.Click += new System.EventHandler(this.로그인ToolStripMenuItem1_Click);
            // 
            // 회원가입ToolStripMenuItem
            // 
            this.회원가입ToolStripMenuItem.Name = "회원가입ToolStripMenuItem";
            this.회원가입ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.회원가입ToolStripMenuItem.Text = "회원가입";
            this.회원가입ToolStripMenuItem.Click += new System.EventHandler(this.회원가입ToolStripMenuItem_Click);
            // 
            // 자원관리ToolStripMenuItem
            // 
            this.자원관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.공장관리ToolStripMenuItem});
            this.자원관리ToolStripMenuItem.Name = "자원관리ToolStripMenuItem";
            this.자원관리ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.자원관리ToolStripMenuItem.Text = "자원관리";
            // 
            // 공장관리ToolStripMenuItem
            // 
            this.공장관리ToolStripMenuItem.Name = "공장관리ToolStripMenuItem";
            this.공장관리ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.공장관리ToolStripMenuItem.Text = "공장관리";
            this.공장관리ToolStripMenuItem.Click += new System.EventHandler(this.공장관리ToolStripMenuItem_Click);
            // 
            // 품목관리ToolStripMenuItem
            // 
            this.품목관리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.품목관리ToolStripMenuItem1,
            this.bOM관리ToolStripMenuItem});
            this.품목관리ToolStripMenuItem.Name = "품목관리ToolStripMenuItem";
            this.품목관리ToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.품목관리ToolStripMenuItem.Text = "품목관리";
            // 
            // 품목관리ToolStripMenuItem1
            // 
            this.품목관리ToolStripMenuItem1.Name = "품목관리ToolStripMenuItem1";
            this.품목관리ToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.품목관리ToolStripMenuItem1.Text = "품목관리";
            this.품목관리ToolStripMenuItem1.Click += new System.EventHandler(this.품목관리ToolStripMenuItem1_Click);
            // 
            // bOM관리ToolStripMenuItem
            // 
            this.bOM관리ToolStripMenuItem.Name = "bOM관리ToolStripMenuItem";
            this.bOM관리ToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.bOM관리ToolStripMenuItem.Text = "BOM관리";
            // 
            // 공통코드관리ToolStripMenuItem
            // 
            this.공통코드관리ToolStripMenuItem.Name = "공통코드관리ToolStripMenuItem";
            this.공통코드관리ToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.공통코드관리ToolStripMenuItem.Text = "공통코드관리";
            this.공통코드관리ToolStripMenuItem.Click += new System.EventHandler(this.공통코드관리ToolStripMenuItem_Click);
            // 
            // FrmMAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip2;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FrmMAIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MdiChildActivate += new System.EventHandler(this.Form1_MdiChildActivate);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSearch;
        private System.Windows.Forms.ToolStripButton tsbInsert;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblDateTime;
        private System.Windows.Forms.Timer timer1;
        private ucTabControl tabForms;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem test용입니다ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 자원관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 품목관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 공장관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 회원가입ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 품목관리ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bOM관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 공통코드관리ToolStripMenuItem;
    }
}

