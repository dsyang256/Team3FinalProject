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
using TEAM3FINALVO;

namespace TEAM3FINAL
{

    public partial class FrmMAIN : ProjectBaseForm
    {
        private List<MANAGER_VO> menuList;
        private List<int> checkMenuList=new List<int>();

        public event EventHandler eSearch;
        public event EventHandler eInsert;
        public event EventHandler eUpdate;
        public event EventHandler eDelete;
        public event EventHandler ePrint;
        public event EventHandler eReset;



        public FrmMAIN()
        {
            InitializeComponent();
          //  _log = new LoggingUtility("gudiProject", Level.Debug, 15); //최근 15일만 보관
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //status strip Timer
            timer1.Start();
            timer1.Tick += ((send, args) => lblDateTime.Text = DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분 ss초"));

            //로그인창 호출


            //로그인시 메뉴 불러오기.
            SetMenus();
            stslLoginID.Text = "";

            GetMenus();
        }

        private void GetMenus()
        {
            AuthService service = new AuthService();
            menuList =  service.GetMenus();
        }

        private void ShowMenu()
        {
            menuStrip1.Items.Clear();
            checkMenuList.Clear();

            //var grantMenus = (from item in menuList
            //                  where item.Grant_id == LoginVO.Company_grand
            //                  select item);

            ShowMenuDropDown(menuList);
        }

        private void ShowMenuDropDown(IEnumerable<MANAGER_VO> grantMenus, ToolStripMenuItem tsmiPrent = null)
        {
            foreach (var grantMenu in grantMenus)
            {
                //int menuCode = grantMenu.Menu_code;
                //if (grantMenu.Name_space)
                //{
                //    if (grantMenu.Menu_usable == "Y" && !checkMenuList.Contains(menuCode))
                //    {
                //        ToolStripMenuItem tsmi = new ToolStripMenuItem();
                //        tsmi.Text = grantMenu.Menu_name;

                //        checkMenuList.Add(menuCode);

                //        if (tsmiPrent != null)
                //            tsmiPrent.DropDownItems.Add(tsmi);
                //        else
                //            menuStrip1.Items.Add(tsmi);

                //        var menuChildren = (from item in menuList
                //                            where item.Parent_menu_code == menuCode
                //                            select item);

                //        if (menuChildren.Count() > 0)
                //            ShowMenuDropDown(menuChildren, tsmi);
                //        else
                //            tsmi.Click += (sender, e) => this.MdiChildrenShow(grantMenu.Name_space);
                //    }
                //}
            }
        }

        private void SetMenus()
        {
            //서비스 호출

            //

        }

        #region MDI 탭컨트롤
        /// <summary>
        /// ChildForm 활성화시 발생하는 이벤트. 탭컨트롤을 생성한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// ChildForm 종료시 발생하는 이벤트. 자원회수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((sender as Form).Tag as TabPage).Dispose();
        }

        /// <summary>
        /// 탭컨트롤에서 마우스 클릭시 발생하는 이벤트. 탭컨르롤에 그려진 이미지 클릭시 ChildForm을 종료한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #endregion

        #region 공통버튼 이벤트
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            if (eSearch != null)
            {
                eSearch(this, new EventArgs());
            }
        }

        private void tsbInsert_Click(object sender, EventArgs e)
        {
            if (eInsert != null)
            {
                eInsert(this, new EventArgs());
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (eDelete != null)
            {
                eDelete(this, new EventArgs());
            }
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            if (eUpdate != null)
            {
                eUpdate(this, new EventArgs());
            }
        }


        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (ePrint != null)
            {
                ePrint(this, new EventArgs());
            }
        }
        private void tsbReset_Click(object sender, EventArgs e)
        {
            if (eReset != null)
            {
                eReset(this, new EventArgs());
            }
        }

        #endregion

        private void 로그인ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //FormUtil.OpenOrCreateForm<FrmLogin>(this);
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
            if(frm.DialogResult==DialogResult.OK)
            {
                stslLoginID.Text = $"{LoginInfo.UserInfo.LI_ID}님         ";
            }
        }

        private void 공장관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtil.OpenOrCreateForm<FrmFactoryManage>(this);
        }

        private void 회원가입ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtil.OpenOrCreateForm<FrmSignup>(this);
        }

        private void 품목관리ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormUtil.OpenOrCreateForm<FrmItem>(this);
        }

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabForms.SelectedTab != null && tabForms.SelectedTab.Tag != null)
            {
                (tabForms.SelectedTab.Tag as Form).Select();
            }
        }

        private void 공통코드관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCOMMON frm = new FrmCOMMON();
            frm.Show();
        }

        private void bOM관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtil.OpenOrCreateForm<FrmBOM>(this);
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //자식폼 모두 닫기 -OJH
            foreach (Form form in this.MdiChildren)
            {
                form.Close();
            }
            //로그인 정보 초기화 -OJH
            LoginInfo.UserInfo.InitMember();
        }

        private void 설비관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtil.OpenOrCreateForm<FrmFacilityGroup>(this);
        }
    }
}
