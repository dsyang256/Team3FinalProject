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
    public partial class Form1 : Form
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
    }
}
