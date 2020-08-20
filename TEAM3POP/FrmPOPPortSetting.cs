using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TEAM3POP
{
    public partial class FrmPOPPortSetting : TEAM3FINAL.baseFormPopUP
    {
        SerialPort _port;

        private SerialPort Port
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
        private String Strings
        {
            set
            {
                if (_strings == null)
                    _strings = new StringBuilder(1024);

                _strings.AppendLine(value);
                textBox1.Text = _strings.ToString();
            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(500);

            string msg = Port.ReadExisting();
            this.Invoke(new EventHandler(delegate
            {
                Strings = $"[RECV] {msg}";
            }));
        }

        private bool IsOPen
        {
            get { return Port.IsOpen; }
            set
            {
                if (value)
                {
                    button1.Text = "연결 끊기";
                }
                else
                {
                    button1.Text = "연결";
                }
            }
        }


        public FrmPOPPortSetting()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //시리얼포트 목록 조회
            cbComPort.DataSource = SerialPort.GetPortNames();

            //컨피그에서 설정값이 있는 경우, 그 값을 조회해서 바인딩.
            cbComPort.SelectedIndex = cbComPort.Items.IndexOf(Properties.Settings.Default.PortName);
            cbBaudRate.SelectedIndex = cbBaudRate.Items.IndexOf(Properties.Settings.Default.BaudRate);
            cbDataSize.SelectedIndex = cbDataSize.Items.IndexOf(Properties.Settings.Default.DataSize);
            cbParity.SelectedIndex = cbParity.Items.IndexOf(Properties.Settings.Default.Parity);
            cbHandShake.SelectedIndex = cbHandShake.Items.IndexOf(Properties.Settings.Default.Handshake);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Port.IsOpen) //연결
            {
                Port.PortName = cbComPort.SelectedItem.ToString();
                Port.BaudRate = Convert.ToInt32(cbBaudRate.SelectedItem);
                Port.DataBits = Convert.ToInt32(cbDataSize.SelectedItem);
                Port.Parity = (Parity)cbParity.SelectedIndex;
                Port.Handshake = (Handshake)cbHandShake.SelectedIndex;

                try
                {
                    Port.Open();
                    textBox1.Text = "연결 됨";
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
            else  //연결끊기
            {
                Port.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbComPort.Text.Length > 1 && cbBaudRate.Text.Length > 1)
            {
                Properties.Settings.Default.PortName = cbComPort.Text;
                Properties.Settings.Default.BaudRate = cbBaudRate.Text;
                Properties.Settings.Default.DataSize = cbDataSize.Text;
                Properties.Settings.Default.Parity = cbParity.Text;
                Properties.Settings.Default.Handshake = cbHandShake.Text;

                Properties.Settings.Default.Save();

                MessageBox.Show("시리얼포트 설정이 저장되었습니다.");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void PortSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Port.IsOpen)
                Port.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
