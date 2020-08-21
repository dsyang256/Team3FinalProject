using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINAL;
using TEAM3FINALVO;

namespace TEAM3POP
{
    public partial class FrmPOPALL : TEAM3POP.ProjectBaseForm
    {
        public FrmPOPALL()
        {
            InitializeComponent();
        }

        private void FrmPOPALL_Load(object sender, EventArgs e)
        {
            WorkOrderDSService work = new WorkOrderDSService();
            List<POPVO> pop = work.POPFACILITY();

            int iCnt = 0;
            foreach (POPVO task in pop)
            {
                UserControl1 taskcontrol = new UserControl1(task.FCLTS_CODE);
                taskcontrol.Location = new Point(50, 25 + (225 * iCnt));
                taskcontrol.Size = new Size(1800, 200);
                taskcontrol.Name = $"taskControl{iCnt}";

                taskcontrol.Task_ID = task.FCLTS_NAME;
                taskcontrol.Task_code = task.FCLTS_CODE;
                taskcontrol.Task_IP = task.FCLTS_IP;
                taskcontrol.Task_Port = task.FCLTS_PORT;
               

                panel1.Controls.Add(taskcontrol);
                iCnt++;
            }
            FrmPOPMDI frm = (FrmPOPMDI)this.MdiParent;
            frm.Readed += Readed_BarCode;
        }
        private void Readed_BarCode(object sender, ReadEventArgs e)
        {
            if (((FrmPOPMDI)this.MdiParent).ActiveMdiChild == this)
            {
                string msg = e.ReadMsg.Replace("%O", "_").Trim();
                if (MessageBox.Show($"{msg} 입력하신 작업지시 번호가 맞습니까??", "작업확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ((FrmPOPMDI)this.MdiParent).ClearStrings();
                    foreach (var Control in panel1.Controls)
                    {
                        UserControl1 user = Control as UserControl1;
                        user.comboBox1.Text = msg;
                    }
                }

            }
        }
    }
}
