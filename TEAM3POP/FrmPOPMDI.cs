using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEAM3FINAL;

namespace TEAM3POP
{
    public partial class FrmPOPMDI : ProjectBaseForm
    {
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
                foreach (var item in SerialPort.GetPortNames())
                {
                    if (item == Properties.Settings.Default.PortName)
                    {
                        Port.PortName = Properties.Settings.Default.PortName;
                        a++;
                    }
                }
                if (a == 0)
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
        private void FrmPOPMDI_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.PortName.Length > 0)
                SerialPortConnecting();
        }
        public FrmPOPMDI()
        {
            InitializeComponent();
            
            FormUtil.OpenOrCreateForm<FrmPOPMAIN>(this);
        }


        private void 메인화면ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtil.OpenOrCreateForm<FrmPOPMAIN>(this);
        }

        private void 설비관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUtil.OpenOrCreateForm<FrmPOPALL>(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Port.IsOpen)
                Port.Close();

            FrmPOPPortSetting frm = new FrmPOPPortSetting();
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
