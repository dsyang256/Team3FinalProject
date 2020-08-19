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

namespace TEAM3POP
{
    public partial class UserControl1 : UserControl
    {
        BackgroundWorker task;
        int task_proc_id;

        BackgroundWorker worker;
        frmATLTask frm;
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
                    btnShow.Enabled = true;
                }
                else
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    btnShow.Enabled = false;
                }
            }
        }
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
            if (comboBox1.Text.Length > 1)
            {
                string code = comboBox1.Text;
                WorkOrderDSService work = new WorkOrderDSService();
                dgv.DataSource = work.ControlDgv(code);
                textBox5.Text = dgv.Rows[0].Cells[4].Value.ToString();
                textBox1.Text = dgv.Rows[0].Cells[1].Value.ToString();
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            dgv.DataSource = null;
            textBox5.Text = "";
            textBox1.Text = "";
            DataGridViewColumnSet1();
        }
        private void DataGridViewColumnSet1()
        {
            DataGridViewUtil.InitSettingGridView(dgv);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "하위품목", "ITEM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "생산필요량", "생산필요량", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "현재고", "현재고", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "소모량", "BOM_QTY", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv, "생산품목", "BOM_PARENT_CODE", false, 100);


        }

        private void btnTaskStart_Click(object sender, EventArgs e)
        {
            try
            {
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
            string path = $"WinServerTask{taskID.Text}.exe";
            
            try
            {
                Process proc = Process.Start(path, $"{Task_ID} {Task_IP} {Task_Port}"); // 던질 파라미터
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                worker = new BackgroundWorker();
                worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
                worker.RunWorkerAsync();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frm = new frmATLTask(Task_ID, Task_IP, Task_Port);
            frm.Show();
            IsTaskEnable = true;
            frm.Hide();
        }
    }
}
