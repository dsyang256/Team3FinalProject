using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WInServerTask
{
    public partial class frmServerTask : Form
    {
        string PGM_ID;
        string hostIP;
        int hostPort;
        System.Timers.Timer timer1;
        TcpListener listener;
        TcpClient tc;
        NetworkStream stream;
        Random rnd;

        int interval = 0;
        readonly string STX = ((char)2).ToString();
        readonly string ETX = ((char)3).ToString();

        LoggingUtility _logging;
        public LoggingUtility Log
        {
            get { return _logging; }
        }

        public frmServerTask(string pgmID, string host, string port)
        {
            InitializeComponent();

            //전역변수 설정
            PGM_ID = pgmID;
            hostIP = host;
            hostPort = int.Parse(port);

            interval = Properties.Settings.Default.interval;
        }

        private void AsyncEchoServer()
        {
            while (true)
            {
                tc = listener.AcceptTcpClient();
                stream = tc.GetStream();
                rnd = new Random((int)DateTime.UtcNow.Ticks);

                timer1 = new System.Timers.Timer(interval);
                timer1.Enabled = true;
                timer1.Elapsed += timer1_Elapsed;
                timer1.AutoReset = true;
            }
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            //|20200817 12:01:20 Task|7|65|4|0|
            string msg = $"{STX}|{DateTime.Now.ToString("yyyyMMdd HH:mm:ss")}Task|{PGM_ID.Replace("task", "").TrimStart('0')}|{rnd.Next(1, 10)}|{rnd.Next(1, 5)}|{rnd.Next(0, 2)}|{ETX}";
            byte[] buff = Encoding.ASCII.GetBytes(msg);

            stream.Write(buff, 0, buff.Length);
            listBox1.Items.Add(msg);
        }

        public void OnStop()
        {
            stream.Close();
            tc.Close();
        }

        private void frmServerTask_Load(object sender, EventArgs e)
        {
            Label1.Text = PGM_ID;
            lblIP.Text = hostIP;
            lblPort.Text = hostPort.ToString();

            listener = new TcpListener(IPAddress.Parse(hostIP), hostPort);
            listener.Start();
            AsyncEchoServer();
        }
    }
}
