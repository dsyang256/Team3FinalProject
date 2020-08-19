using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINAL;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using log4net.Core;
using System.Reflection;
using System.Drawing;

namespace TEAM3POP
{
    public class ATLTask : ConnectionAccess
    {
        System.Windows.Forms.Timer timSocket_Connect = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timSocket_Check = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timSocket_Ka = new System.Windows.Forms.Timer();
        string PGM_ID;
        string hostIP;
        int hostPort;
        
        string item ;
        int qty;

        int timer_CONNECT = 100;
        int timer_READ = 100;
        int timer_KA = 100;
        int timer_CHECK = 100;

        SqlConnection conn = null;
        ThreadATLTask m_ThreadATLTask = null;

        int KEEP_ARRIVE_COUNT = 0;
        string STX = ((char)2).ToString();
        string ETX = ((char)3).ToString();

        TCPControl client;
        bool wbConnect = false;

        bool LogVisible = false;

        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }
        public ATLTask(string pgmID, string host, string port,string item , int qty )
        {
            this.item = item;
            this.qty = qty;

            _logging = new LoggingUtility(pgmID, Level.Info, 30); 

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

        public void APTMAIN()
        {
            DBConnection();

            Log.WriteInfo($"{PGM_ID} : 통신 시작");

            //수신용 인스턴스 생성
            m_ThreadATLTask = new ThreadATLTask(conn, _logging, timer_READ);
            //m_ThreadATLTask.ReadData += ReadDataDisplay;

            //각 컨트롤에 값을 셋팅
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //this.lblVersion.Text = "Version: " + File.GetLastWriteTime(assembly.Location).ToString("yyyy.MM.dd");

            //this.Label1.Text = $"{PGM_ID} 수신";
            //this.Text = PGM_ID;
            //lblIP.Text = hostIP;
            //lblPort.Text = hostPort.ToString();
            //this.lblSts.BackColor = Color.Red;

            //timer 컨트롤 설정
            this.timSocket_Connect.Interval = timer_CONNECT;
            this.timSocket_Check.Interval = timer_CHECK;
            this.timSocket_Ka.Interval = timer_KA;

            //쓰레드 시작
            m_ThreadATLTask.ThreadStart();

            Connect_NG_Timer(); //접속시도
        }
        private void Connect_NG_Timer() //접속이 끊긴상태에서 접속을 시도하는 타이머
        {
            //this.lblSts.BackColor = Color.Red;

            timSocket_Connect.Start();      //연결 타이머 기동 
            timSocket_Check.Stop();         //통신 체크 타이머 중지
            timSocket_Ka.Stop();            //Ka 타이머 중지

            m_ThreadATLTask.ClearClient();
        }

        private void Connect_OK_Timer() //접속이 된 상태에서 수신을 시도하는 타이머
        {
            //this.lblSts.BackColor = Color.Green;

            timSocket_Connect.Stop();        //연결 타이머 기동 
            timSocket_Check.Start();         //통신 체크 타이머 중지
            timSocket_Ka.Start();            //Ka 타이머 중지
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
                conn = new SqlConnection(this.ConnectionString);
                conn.Open();
                this.Log.WriteInfo("DB접속 성공");
            }
            catch (Exception err)
            {
                this.Log.WriteInfo($"DB접속 실패:{err.Message}");
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
        private void SocketConnect()
        {
            wbConnect = false;
            try
            {
                client = new TCPControl(hostIP, hostPort);
                m_ThreadATLTask.SettingClient(client);

                //this.BackColor = Color.Green;
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
    }
}
