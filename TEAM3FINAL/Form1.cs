using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Core;

namespace TEAM3FINAL
{
    public partial class Form1 : ProjectBaseForm
    {
        public Form1()
        {
            InitializeComponent();
          //  _log = new LoggingUtility("gudiProject", Level.Debug, 15); //최근 15일만 보관
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Tick += ((send, args) => lblDateTime.Text = DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분 ss초"));
        }

        private void 예시1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTest frm = new FrmTest();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void 예시2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTest frm = new FrmTest();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void Form1_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
                tabForms.Visible = false;
            else
            {
                if (this.ActiveMdiChild.Tag == null)
                {
                    //TabPage 생성자에 Text를 넘길때 공백을 추가로 넣어서 이미지와 붙지 않게
                    TabPage tp = new TabPage(this.ActiveMdiChild.Text + "    ");
                    tp.Tag = this.ActiveMdiChild;
                    tp.Parent = tabForms;
                    tabForms.SelectedTab = tp;

                    this.ActiveMdiChild.Tag = tp;
                    this.ActiveMdiChild.FormClosed += new FormClosedEventHandler(ActiveMdiChild_FormClosed);
                }

                if (!tabForms.Visible) tabForms.Visible = true;
            }
        }

        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        private void tabForms_MouseDown(object sender, MouseEventArgs e)
        {
            for (var i = 0; i < tabForms.TabPages.Count; i++)
            {
                var tabRect = tabForms.GetTabRect(i);
                
                var closeImage = Properties.Resources.close_grey;
                var imageRect = new Rectangle((tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2, closeImage.Width, closeImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    this.ActiveMdiChild.Close();                    
                    break;
                }
            }
        }
    }
}
