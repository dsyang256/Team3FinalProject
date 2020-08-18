using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TEAM3FINAL;
using TEAM3FINALVO;

namespace TEAM3POP
{
    public partial class FrmPOPMAIN : ProjectBaseForm
    {
        BackgroundWorker task;
        public FrmPOPMAIN()
        {
            InitializeComponent();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmPOPMAIN_Load(object sender, EventArgs e)
        {
            ComboBinding();
            DataGridViewColumnSet1();
            DataGridViewBinding1();
        }
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //공정
            var list1 = (from item in Commonlist where item.COMMON_PARENT == "설비" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(comboBox1, list1, "COMMON_CODE", "COMMON_NAME", "");

            //작업장
            var list2 = (from item in Commonlist where item.COMMON_PARENT == "설비군" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(comboBox2, list2, "COMMON_CODE", "COMMON_NAME", "");



        }
        private void DataGridViewColumnSet1()
        {
            DataGridViewUtil.InitSettingGridView(dgv1);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "no", "idx", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "작업지시번호", "WO_Code", true, 400);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목코드", "ITEM_CODE", true, 400);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "계획수량", "WO_PLAN_QTY", true, 400);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "작업지시상태", "WO_WORK_STATE", true, 400);
           

        }
        private void DataGridViewBinding1()
        {
            dgv1.DataSource = null;
            WorkOrderDSService work = new WorkOrderDSService();
            dgv1.DataSource = work.POPDGV1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv1.DataSource = null;
            WorkOrderDSService work = new WorkOrderDSService();
            string day1 = dateTimePicker1.Value.ToShortDateString();
            string day2 = dateTimePicker2.Value.ToShortDateString();
            string fac = (comboBox1.Text.Length < 1) ? "": comboBox1.SelectedValue.ToString();
            string facg =(comboBox2.Text.Length < 1) ? "" : comboBox2.SelectedValue.ToString();
            dgv1.DataSource = work.POPDGVselect(day1, day2, fac, facg);
            RESET();
        }
        private void RESET()
        {
            WO_Code.Text = "";
            PLAN_ID.Text = "";
            FCLTS_NAME.Text = "";
            ITEM_CODE.Text = "";
            WO_PLAN_QTY.Text = "";
            WO_QTY_OUT.Text = "";
            WO_QTY_ALL.Text = "";
            WO_QTY_PROD.Text = "";
            WO_QTY_BAD.Text = "";
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            WorkOrderDSService work = new WorkOrderDSService();
            DataTable dt = work.POPDGVselect1(dgv1.Rows[e.RowIndex].Cells[1].Value.ToString());
            if(dt != null)
            {
                WO_Code.Text = dt.Rows[0][0].ToString();
                ITEM_CODE.Text = dt.Rows[0][1].ToString();
                PLAN_ID.Text = dt.Rows[0][2].ToString();
                FCLTS_NAME.Text = dt.Rows[0][3].ToString();
                WO_PLAN_QTY.Text = (dt.Rows[0][4].ToString().Length < 1) ? "0" : dt.Rows[0][4].ToString();
                WO_QTY_OUT.Text = (dt.Rows[0][5].ToString().Length < 1) ? "0" : dt.Rows[0][5].ToString();
                WO_QTY_PROD.Text = (dt.Rows[0][6].ToString().Length < 1) ? "0" : dt.Rows[0][6].ToString();
                WO_QTY_BAD.Text = (dt.Rows[0][7].ToString().Length < 1) ? "0" : dt.Rows[0][7].ToString();
                WO_QTY_ALL.Text = (int.Parse(WO_QTY_PROD.Text) + int.Parse(WO_QTY_BAD.Text)).ToString();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        
    }
}
