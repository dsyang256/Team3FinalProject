using log4net.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEAM3FINAL;
using TEAM3FINALDAC;


namespace TEAM3POP
{
    public partial class frmATLTask : Form 
    {
        public bool bExit = false;

        string PGM_ID;
        string hostIP;
        int hostPort;
        int timer_CONNECT = 100;
        int timer_READ = 100;
        int timer_KA = 100;
        int timer_CHECK = 100;

        SqlConnection conn = null;
        ThreadATLTask m_ThreadATLTask = null;

        bool LogVisible = false;

        int KEEP_ARRIVE_COUNT = 0;
        string STX = ((char)2).ToString();
        string ETX = ((char)3).ToString();

        TCPControl client;
        bool wbConnect = false;

        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }

        public frmATLTask(string pgmID, string host, string port)
        {
            InitializeComponent();

            _logging = new LoggingUtility(pgmID, Level.Info, 30);
            
            //전역변수 설정
            PGM_ID = pgmID;
            hostIP = host;
            hostPort = int.Parse(port);
            timer_CONNECT = Convert.ToInt32(ReadAppSettings("timer_Connect", true));
            timer_CHECK = Convert.ToInt32(ReadAppSettings("timer_Check", true));
            timer_READ = Convert.ToInt32(ReadAppSettings("timer_Read", true));
            timer_KA = Convert.ToInt32(ReadAppSettings("timer_Ka", true));
        }

        private string ReadAppSettings(string key, bool bNumber = false)
        {
            if (ConfigurationManager.AppSettings[key] != null)
            {
                return ConfigurationManager.AppSettings[key];
            }
            else
                return (bNumber) ? "0" : "";
        }

        private void frmATLTask_Load(object sender, EventArgs e)
        {
            //DB접속
            DBConnection();

            Log.WriteInfo($"{PGM_ID} : 통신 시작");

            //수신용 인스턴스 생성
            m_ThreadATLTask = new ThreadATLTask(conn, _logging, timer_READ);
            m_ThreadATLTask.ReadData += ReadDataDisplay;

            //각 컨트롤에 값을 셋팅
            Assembly assembly = Assembly.GetExecutingAssembly();
            this.lblVersion.Text = "Version: " + File.GetLastWriteTime(assembly.Location).ToString("yyyy.MM.dd");

            this.Label1.Text = $"{PGM_ID} 수신";
            this.Text = PGM_ID;
            lblIP.Text = hostIP;
            lblPort.Text = hostPort.ToString();
            this.lblSts.BackColor = Color.Red;

            //timer 컨트롤 설정
            this.timSocket_Connect.Interval = timer_CONNECT;
            this.timSocket_Check.Interval = timer_CHECK;
            this.timSocket_Ka.Interval = timer_KA;

            //쓰레드 시작
            m_ThreadATLTask.ThreadStart();

            Connect_NG_Timer(); //접속시도
        }

        private void frmATLTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                if (this.Height == 435)
                {
                    this.Height = 135;
                    LogVisible = false;
                }
                else
                {
                    this.Height = 435;
                    LogVisible = true;
                }
            }
        }        

        private void timSocket_Connect_Tick(object sender, EventArgs e)
        {
            SocketConnect();
        }

        private void timSocket_Check_Tick(object sender, EventArgs e)
        {
            SocketCheckLive();
        }

        private void timSocket_Ka_Tick(object sender, EventArgs e)
        {
            if (KEEP_ARRIVE_COUNT > 10)
            {
                SocketDisConnect();
                Connect_NG_Timer();
                KEEP_ARRIVE_COUNT = 0;
            }
            else
            {
                string lsSendData = $"{STX}|X|{ETX}";
                byte[] msg = Encoding.ASCII.GetBytes(lsSendData);

                if (client.CheckClientConnection())
                {
                    if (client.client.Connected)
                    {
                        client.Send(msg);
                        this.Log.WriteInfo("KeepArrive 요청을 함");
                    }
                    else
                    {
                        this.Log.WriteInfo("소켓이상으로 KeepArrive 요청을 하지 못함");
                    }
                }
                else
                {
                    this.Log.WriteInfo("소켓이상으로 KeepArrive 요청을 하지 못함");
                }

                KEEP_ARRIVE_COUNT++;
            }
        }

        private void frmATLTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bExit)
            {
                this.Hide();
                e.Cancel = true; 
            }
        }

        private void frmATLTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DB접속종료
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                this.Log.WriteInfo("DB접속 해제");
            }

            //소켓종료
            SocketDisConnect();
            m_ThreadATLTask.ThreadTerminate();

            Log.WriteInfo($"{PGM_ID} : 통신 중지");
            Log.RemoveRepository(PGM_ID);
        }


        private void Connect_NG_Timer() //접속이 끊긴상태에서 접속을 시도하는 타이머
        {
            this.lblSts.BackColor = Color.Red;

            timSocket_Connect.Start();      //연결 타이머 기동 
            timSocket_Check.Stop();         //통신 체크 타이머 중지
            timSocket_Ka.Stop();            //Ka 타이머 중지

            m_ThreadATLTask.ClearClient();
        }

        private void Connect_OK_Timer() //접속이 된 상태에서 수신을 시도하는 타이머
        {
            this.lblSts.BackColor = Color.Green;

            timSocket_Connect.Stop();        //연결 타이머 기동 
            timSocket_Check.Start();         //통신 체크 타이머 중지
            timSocket_Ka.Start();            //Ka 타이머 중지
        }

        private void SocketConnect()
        {
            wbConnect = false;
            try
            {
                client = new TCPControl(hostIP, hostPort);
                m_ThreadATLTask.SettingClient(client);

                this.lblSts.BackColor = Color.Green;
                Connect_OK_Timer();
                wbConnect = true;
            }
            catch (Exception err)
            {
                wbConnect = false;
                this.Log.WriteError($"[{MethodBase.GetCurrentMethod().Name}]:{err.Message}", err);
            }
        }

        private void SocketDisConnect()
        {
            try
            {
                if (client != null && client.client.Connected)
                {
                    client.dataStream.Close();
                    client.client.Close();
                }
            }
            catch (Exception err)
            {
                wbConnect = false;
                this.Log.WriteError($"[{MethodBase.GetCurrentMethod().Name}]:{err.Message}", err);
            }
        }

        private void SocketCheckLive()
        {
            try
            {
                if (!client.CheckClientConnection())
                {
                    if (wbConnect)
                    {
                        wbConnect = false;
                        client.dataStream.Close();
                        client.client.Close();

                        Thread.Sleep(1000);

                        this.Log.WriteInfo($"[{MethodBase.GetCurrentMethod().Name}]:통신장애 발생");
                        Connect_NG_Timer();
                    }
                }
                else
                {
                    if (!wbConnect)
                    {
                        wbConnect = true;
                        this.Log.WriteInfo($"[{MethodBase.GetCurrentMethod().Name}]:통신성공");
                        Connect_OK_Timer();
                    }
                }
            }
            catch (Exception err)
            {
                wbConnect = false;
                this.Log.WriteError($"[{MethodBase.GetCurrentMethod().Name}]:{err.Message}", err);
            }
        }

        private void DBConnection()
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    this.Log.WriteInfo("DB접속 해제");
                }

                Thread.Sleep(1000);

                this.Log.WriteInfo("DB접속 시작");
                
            
                //conn = new SqlConnection(//this.ConnectionString);
                conn.Open();
                this.Log.WriteInfo("DB접속 성공");
            }
            catch (Exception err)
            {
                this.Log.WriteInfo($"DB접속 실패:{err.Message}");
            }
        }

        private void ReadDataDisplay(object sender, ReadDataEventAgrs e)
        {
            KEEP_ARRIVE_COUNT = 0;

            if (LogVisible)
            {
                if (ListBox1.Items.Count > 50)
                {
                    this.Invoke((MethodInvoker)(() => ListBox1.Items.Clear()));
                }

                this.Invoke((MethodInvoker)(() => ListBox1.Items.Add(e.Data.Trim())));
                this.Invoke((MethodInvoker)(() => ListBox1.SelectedIndex = ListBox1.Items.Count - 1));
            }
            txtReadATL.Invoke((MethodInvoker)delegate { txtReadATL.Text = e.Data.Trim(); });
        }
    }
}
