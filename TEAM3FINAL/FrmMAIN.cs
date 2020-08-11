using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net.Core;
using TEAM3FINALVO;

namespace TEAM3FINAL
{

    public partial class FrmMAIN : ProjectBaseForm
    {
        private List<Menu_VO> menuList;
        private List<ManagerRight_VO> rightList;
        private List<int> checkMenuList = new List<int>();

        public event EventHandler eSearch;
        public event EventHandler eInsert;
        public event EventHandler eUpdate;
        public event EventHandler eDelete;
        public event EventHandler ePrint;
        public event EventHandler eReset;
       
        public delegate void BarCodeReadComplete(object sender, ReadEventArgs e);
        public event BarCodeReadComplete Readed;

        SerialPort _port;

        public SerialPort Port
        {
            get
            {
                if (_port == null)
                {
                    _port = new SerialPort();
                    _port.DataReceived += Port_DataReceived;
                }

                return _port;
            }
        }

        private StringBuilder _strings;
        public String Strings
        {
            set
            {
                if (_strings == null)
                    _strings = new StringBuilder(1024);

                _strings.AppendLine(value);

                if (Readed != null)
                {
                    ReadEventArgs args = new ReadEventArgs();
                    args.ReadMsg = _strings.ToString();
                    Readed(this, args);
                }
            }
        }

        private bool _isopen;
        public bool IsOpen
        {
            get { return _isopen; }
            set { _isopen = value; }
        }

        public void ClearStrings()
        {
            _strings.Clear();
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);

            string msg = Port.ReadExisting();
            this.Invoke(new EventHandler(delegate
            {
                Strings = msg;
            }));
        }

        private void SerialPortConnecting()
        {
            if (!Port.IsOpen) //연결
            {
                int a = 0;
                foreach(var item in SerialPort.GetPortNames())
                {
                    if(item == Properties.Settings.Default.PortName)
                    {
                        Port.PortName = Properties.Settings.Default.PortName;
                        a++;
                    }
                }
                if(a == 0)
                {
                    return;
                }
                Port.PortName = Properties.Settings.Default.PortName;
                Port.BaudRate = Convert.ToInt32(Properties.Settings.Default.BaudRate);
                Port.DataBits = Convert.ToInt32(Properties.Settings.Default.DataSize);

                Parity par = Parity.None;
                if (Properties.Settings.Default.Parity == "even")
                    par = Parity.Even;
                else if (Properties.Settings.Default.Parity == "odd")
                    par = Parity.Odd;
                Port.Parity = par;

                Handshake hands = Handshake.None;
                Port.Handshake = hands;

                try
                {
                    Port.Open();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else
            {
                Port.Close();
            }
            IsOpen = _port.IsOpen;
        }
        public FrmMAIN()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.PortName.Length > 0)
                SerialPortConnecting();
            //status strip Timer
            timer1.Start();
            timer1.Tick += ((send, args) => lblDateTime.Text = DateTime.Now.ToString("yyyy년 MM월 dd일 HH시 mm분 ss초"));
            stslLoginID.Text = "";
            LoadLogin();


        }

        private void LoadLogin()
        {
            this.Hide();

            //로그인창 호출
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {

                this.Show();
                stslLoginID.Text = $"{LoginInfo.UserInfo.LI_NAME}({LoginInfo.UserInfo.LI_ID})님         ";
                //로그인시 메뉴 불러오기.
                GetMenus();
                GetRights();
                ShowMenu();
            }
        }

        private void GetMenus()
        {
            AuthService service = new AuthService();
            menuList = service.GetMenus(LoginInfo.UserInfo.LI_ID);
        }
        private void GetRights()
        {
            if(rightList!=null)
            rightList.Clear();
            AuthService service = new AuthService();
            rightList = service.GetRights(LoginInfo.UserInfo.LI_ID);
        }

        private void ShowMenu()
        {
            //초기화
            menuStrip1.Items.Clear();
            checkMenuList.Clear();

            //메뉴생성
            ShowMenuDropDown(menuList);
        }

        private void ShowMenuDropDown(IEnumerable<Menu_VO> grantMenus, ToolStripMenuItem tsmiPrent = null)
        {
            foreach (var grantMenu in grantMenus)
            {
                int menuCode = grantMenu.MENU_ID;


                if (!checkMenuList.Contains(menuCode))
                {
                    ToolStripMenuItem tsmi = new ToolStripMenuItem();
                    tsmi.Text = grantMenu.MENU_NAME;

                    checkMenuList.Add(menuCode);

                    if (tsmiPrent != null)
                        tsmiPrent.DropDownItems.Add(tsmi);
                    else
                        menuStrip1.Items.Add(tsmi);

                    var menuChildren = (from item in menuList
                                        where item.MENU_PARENT == menuCode
                                        select item);

                    if (menuChildren.Count() > 0)
                        ShowMenuDropDown(menuChildren, tsmi);
                    else
                    {
                        if (grantMenu.MENU_NAME == "공통코드관리")
                        {
                            tsmi.Click += (sender, e) => ShowDialog(grantMenu.MENU_PROGRAM);
                        }
                        else
                        {
                            tsmi.Click += (sender, e) => this.MdiChildrenShow(grantMenu.MENU_PROGRAM);

                        }
                    }
                }

            }
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

                //공통버튼 권한 적용
                SetBtnRight();
            }
        }

        private void SetBtnRight()
        {
            //공통버튼 메뉴 권한 적용
            if (rightList.Count > 0)
            {
                foreach (var menu in rightList)
                {

                    if (this.ActiveMdiChild.Name == menu.MENU_PROGRAM)
                    {
                        tsbInsert.Enabled = false;//C
                        tsbSearch.Enabled = false;//R
                        tsbUpdate.Enabled = false;//U
                        tsbDelete.Enabled = false;//D
                        tsbPrint.Enabled = false;//P
                        tsbReset.Enabled = false;//R

                        if (menu.ManagerR_CRUD.Contains("C"))
                            tsbInsert.Enabled = true;
                        if (menu.ManagerR_CRUD.Contains("R"))
                            tsbSearch.Enabled = true;
                        if (menu.ManagerR_CRUD.Contains("U"))
                            tsbUpdate.Enabled = true;
                        if (menu.ManagerR_CRUD.Contains("D"))
                            tsbDelete.Enabled = true;
                        if (menu.ManagerR_CRUD.Contains("P"))
                            tsbPrint.Enabled = true;
                        if (menu.ManagerR_CRUD.Contains("R"))
                            tsbReset.Enabled = true;

                    }
                }
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

        private void ShowDialog(string formName)
        {
            Type type = Type.GetType("TEAM3FINAL." + formName);
            Form f = (Form)Activator.CreateInstance(type);
            f.ShowDialog();
        }

        private void tabForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabForms.SelectedTab != null && tabForms.SelectedTab.Tag != null)
            {
                (tabForms.SelectedTab.Tag as Form).Select();
            }
        }

        /// <summary>
        /// 로그아웃시 발생하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbLogout_Click(object sender, EventArgs e)
        {
            //자식폼 모두 닫기 -OJH
            if (Application.OpenForms.Count > 0) // 만약 폼이 1개 이상 열려있으면
            {
                foreach (Form form in this.MdiChildren)
                {
                    form.Close();
                }
            }
            //로그인 정보 초기화 -OJH
            LoginInfo.UserInfo.InitMember();
            //로그인호출
            LoadLogin();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Port.IsOpen)
                Port.Close();

            FrmPortSetting frm = new FrmPortSetting();
            frm.ShowDialog();

            if (Properties.Settings.Default.PortName.Length > 0)
            {
                SerialPortConnecting();
            }
        }
    }
    public class ReadEventArgs : EventArgs
    {
        private string msg;

        public string ReadMsg
        {
            get { return msg; }
            set { msg = value; }
        }

    }
}
