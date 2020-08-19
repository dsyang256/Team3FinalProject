using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEAM3FINAL;
using TEAM3FINALVO;
using System.Diagnostics;
using log4net.Core;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Threading;

namespace TEAM3POP
{
    public partial class UserControl1 : UserControl 
    {
        int qty1; //지시량
        int qty2; //총생산량
        int qty3; //양품수량
        int qty4; //불량수량

        int popqty = 1;
        
        BackgroundWorker task;
        int task_proc_id;

        BackgroundWorker worker;
        ATLTask atl;
        public bool IsTask
        {
            get { return btnTaskStop.Enabled; }
            set
            {
                if (value)
                {
                    btnTaskStart.Enabled = false;
                    btnTaskStop.Enabled = true;
                    panel2.BackColor = Color.Green;
                }
                else
                {
                    btnTaskStart.Enabled = true;
                    btnTaskStop.Enabled = false;
                    panel2.BackColor = Color.Red;
                }
            }
        }
        public bool IsTaskEnable
        {
            get { return btnStop.Enabled; }
            set
            {
                if (value) //task 실행중
                {
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    
                }
                else
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    
                }
            }
        }
        public string Task_ID
        {
            get { return taskID.Text; }
            set { taskID.Text = value; }
        }
        public string Task_code
        {
            get { return task_code.Text; }
            set { task_code.Text = value; }
        }

        public string Task_IP
        {
            get { return hostIP.Text; }
            set { hostIP.Text = value; }
        }

        public string Task_Port
        {
            get { return hostPort.Text; }
            set { hostPort.Text = value; }
        }
        public UserControl1(string code)
        {
            InitializeComponent();
            ComboBinding(code);
        }
        private void ComboBinding(string code)
        {
            WorkOrderDSService work = new WorkOrderDSService();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.ValueMember = "WO_Code";
            comboBox1.DisplayMember = "WO_Code";
            comboBox1.DataSource = work.ComboBinding(code);
            comboBox1.SelectedIndex = -1;

        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length > 1)
            {
                string code = comboBox1.Text;
                WorkOrderDSService work = new WorkOrderDSService();
                dgv.DataSource = work.ControlDgv(code);
                itemname.Text = dgv.Rows[0].Cells[4].Value.ToString();
                qty.Text = dgv.Rows[0].Cells[1].Value.ToString();
               
                qty1 = int.Parse(qty.Text);
                qty2 = qty1 - Convert.ToInt32(dgv.Rows[0].Cells[6].Value.ToString());
                qty3 = Convert.ToInt32(dgv.Rows[0].Cells[5].Value.ToString());
                qty4 = Convert.ToInt32(dgv.Rows[0].Cells[7].Value.ToString());
                BADQTY.Text = dgv.Rows[0].Cells[5].Value.ToString();
                residualqty.Text = qty2.ToString();
                GOODQTY.Text = dgv.Rows[0].Cells[7].Value.ToString();
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            dgv.DataSource = null;
            itemname.Text = "";
            qty.Text = "";
            DataGridViewColumnSet1();
            button1.PerformClick();
        }
        private void DataGridViewColumnSet1()
        {
            DataGridViewUtil.InitSettingGridView(dgv);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "하위품목", "ITEM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "생산필요량", "생산필요량", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "현재고", "현재고", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "소모량", "BOM_QTY", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "생산품목", "BOM_PARENT_CODE", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "불량수랑", "불량수량", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "생산수량", "생산수량", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "양품수량", "양품수량", false, 100);


        }

        private void btnTaskStart_Click(object sender, EventArgs e)
        {
            try
            {
                btnTaskStop.Enabled = true;
                task = new BackgroundWorker();
                task.RunWorkerCompleted += Task_RunWorkerCompleted;
                task.RunWorkerAsync();
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Task_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string path = $"WinServerTask{task_code.Text}.exe";
            
            try
            {
                Process proc = Process.Start(path, $"{task_code.Text} {Task_IP} {Task_Port} "); // 던질 파라미터
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                task_proc_id = proc.Id;
                IsTask = true;
            }
            catch (Exception err)
            {
                foreach (var process in Process.GetProcesses())
                {
                    if (process.ProcessName == path)
                        process.Kill();
                }
                MessageBox.Show(err.Message);
            }
        }

        private void btnTaskStop_Click(object sender, EventArgs e)
        {
            string path = $"WinServerTask{taskID.Text}.exe";
            foreach (var process in Process.GetProcesses())
            {
                if (process.Id == task_proc_id)
                {
                    process.Kill();
                    IsTask = false;
                }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            button1.Enabled = true;
            panel3.BackColor = Color.Red;
            IF_SetValue();
            //DB접속종료
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                this.Log.WriteInfo("DB접속 해제");
            }

            timSocket_Check.Stop();
            timSocket_Connect.Stop();
            timSocket_Ka.Stop();

            //소켓종료
            SocketDisConnect();
            m_ThreadATLTask.ThreadTerminate();

            Log.WriteInfo($"{taskID} : 통신 중지");
            Log.RemoveRepository(taskID.Text);

            worker.Dispose();
            button1.PerformClick(); 

        }

        private void IF_SetValue()
        {
            string strCALL_MSG = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "insert into WorkQtyLog(ProductID, TaskID, Qty, BadQty) " +
                        "                             values (@ProductID, @TaskID, @Qty, @BadQty)";

                    //cmd.Parameters.AddWithValue("@ProductID", int.Parse(arrData[2]));
                    //cmd.Parameters.AddWithValue("@TaskID", int.Parse(arrData[1]));
                    //cmd.Parameters.AddWithValue("@Qty", int.Parse(arrData[3]));
                    //cmd.Parameters.AddWithValue("@BadQty", int.Parse(arrData[4]));

                    cmd.ExecuteNonQuery();


                }

            }
            catch (Exception err)
            {
                this.Log.WriteError($"[[RECV DB 저장중오류]]:{err.Message}");

                if (strCALL_MSG.Contains("Connection Error") || err.Message.Contains("개체"))
                {
                    throw new Exception(strCALL_MSG);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                btnStop.Enabled = true;
                worker = new BackgroundWorker();
                worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
                worker.RunWorkerAsync();
               
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }

       

        int timer_CONNECT = 100;
        int timer_READ = 100;
        int timer_KA = 100;
        int timer_CHECK = 100;
        int KEEP_ARRIVE_COUNT = 0;

        ThreadATLTask m_ThreadATLTask = null;

        SqlConnection conn = null;

        //bool LogVisible = false;

        string STX = ((char)2).ToString();
        string ETX = ((char)3).ToString();

        TCPControl client;
        bool wbConnect = false;

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(itemname.Text.Length <1 || qty.Text.Length <1)
            {
                MessageBox.Show("작업을 선택해주세요.");
                return;
            }

            _logging = new LoggingUtility(taskID.Text, Level.Info, 30);

            //전역변수 설정
           
            timer_CONNECT = Convert.ToInt32(ReadAppSettings("timer_Connect", true));
            timer_CHECK = Convert.ToInt32(ReadAppSettings("timer_Check", true));
            timer_READ = Convert.ToInt32(ReadAppSettings("timer_Read", true));
            timer_KA = Convert.ToInt32(ReadAppSettings("timer_Ka", true));
            MAIN();

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
        private void MAIN()
        {
            //DB접속
            DBConnection();

            Log.WriteInfo($"{taskID.Text} : 통신 시작");

            //수신용 인스턴스 생성
            m_ThreadATLTask = new ThreadATLTask(conn, _logging, timer_READ);
            m_ThreadATLTask.ReadData += ReadDataDisplay;

            //각 컨트롤에 값을 셋팅


            //timer 컨트롤 설정
            this.timSocket_Connect.Interval = timer_CONNECT;
            this.timSocket_Check.Interval = timer_CHECK;
            this.timSocket_Ka.Interval = timer_KA;

            //쓰레드 시작
            m_ThreadATLTask.ThreadStart();

            Connect_NG_Timer(); //접속시도
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
                ConnectionAccess access = new ConnectionAccess();
                conn = new SqlConnection(access.ConnectionString);
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
            try
            {
                KEEP_ARRIVE_COUNT = 0;

                string[] str = e.Data.Split('|');
                if (int.Parse(str[2]) < 10)
                {
                    if(qty3 == 0)
                    {
                        qty3 = 1;
                    }
                    this.Invoke((MethodInvoker)(() => GOODQTY.Text = qty3.ToString()));
                    qty2 = qty2 - 1;
                    this.Invoke((MethodInvoker)(() => residualqty.Text = (qty2).ToString()));
                    qty3++;
                }
                if (qty2 == 0)
                {
                    this.Invoke((MethodInvoker)(() => btnTaskStop.PerformClick()));
                    MessageBox.Show("작업이 완료되었습니다.");
                    this.Invoke((MethodInvoker)(() => btnStop.PerformClick()));
                    

                }
            }
            catch(Exception err)
            {
                Log.WriteError(err.Message);
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
                client = new TCPControl(hostIP.Text, int.Parse(hostPort.Text));
                m_ThreadATLTask.SettingClient(client);

                this.panel2.BackColor = Color.Green;
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
        private void Connect_NG_Timer() //접속이 끊긴상태에서 접속을 시도하는 타이머
        {
            this.panel3.BackColor = Color.Red;

            timSocket_Connect.Start();      //연결 타이머 기동 
            timSocket_Check.Stop();         //통신 체크 타이머 중지
            timSocket_Ka.Stop();            //Ka 타이머 중지

            m_ThreadATLTask.ClearClient();
        }

        private void Connect_OK_Timer() //접속이 된 상태에서 수신을 시도하는 타이머
        {
            this.panel3.BackColor = Color.Green;

            timSocket_Connect.Stop();        //연결 타이머 기동 
            timSocket_Check.Start();         //통신 체크 타이머 중지
            timSocket_Ka.Start();            //Ka 타이머 중지
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            itemname.Text = "";
            qty.Text = "0";
            residualqty.Text = "0";
            GOODQTY.Text = "0";
            BADQTY.Text = "0";
            dgv.DataSource = null;
        }
    }
}
