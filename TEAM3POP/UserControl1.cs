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

namespace TEAM3POP
{
    public partial class UserControl1 : UserControl
    {
        public string Task_ID
        {
            get { return taskID.Text; }
            set { taskID.Text = value; }
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
            string code  = comboBox1.Text;
        }
    }
}
