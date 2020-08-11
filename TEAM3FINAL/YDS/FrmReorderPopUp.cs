using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public partial class FrmReorderPopUp : baseFormPopUP
    {
        DataTable dt;
        CheckBox headerChk;
        CheckBox headerChk1;
        public FrmReorderPopUp()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void FrmReorderPopUp_Load(object sender, EventArgs e)
        {
            ComboBinding();
            DataGridViewColumnSet1();
            DataGridViewColumnSet2();
            DataGridViewBinding1();
            DataGridViewBinding2();
        }
        #region 콤보박스바인딩
        /// <summary>
        /// 콤보박스바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();

            //업체
            var listCOM_REORDER = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_COM_REORDER, listCOM_REORDER, "COMMON_CODE", "COMMON_NAME", "");

        }
        #endregion

        #region 데이터 그리드뷰 컬럼+체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet1()
        {
            DataGridViewUtil.InitSettingGridView(dgv1);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgv1, "all"); 
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주업체", "COM_NAME", true, 155);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주업체코드", "COM_CODE", false, 30);

            DataGridViewCheckBoxAllCheck1();

        }
        private void DataGridViewColumnSet2()
        {
            DataGridViewUtil.InitSettingGridView(dgv2);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgv2, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주업체", "ITEM_COM_REORDER", true, 150);
            //DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주코드", "COM_CODE", false, 30);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "납품업체", "ITEM_COM_DLVR", true, 150);
            //DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "납품코드", "COM_CODE", false, 30);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "담당자", "ITEM_MANAGER", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품목", "ITEM_CODE", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품명", "ITEM_NAME", true, 150);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "창고", "ITEM_WRHS_IN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "검사여부", "ITEM_INCOME_YN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주방식", "ITEM_REORDER_TYP", false, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주수량", "COM_NAME", true, 100, readOnly: false);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "현재고", "COM_NAME", false, 80);

            DataGridViewCheckBoxAllCheck2();

        }
        #endregion

        #region 데이터 그리드 바인딩
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding1()
        {
            dgv1.DataSource = null;
            ReorderService service = new ReorderService();
            dgv1.DataSource = service.GetCOM();
        }
        private void DataGridViewBinding2()
        {
            dgv2.DataSource = null;
            ReorderService service = new ReorderService();
            dt = service.GetReorderItem();
            dgv2.DataSource = dt;
        }
        #endregion

        #region 데이터 그리드뷰 올체크 체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck1()
        {
            headerChk = new CheckBox();
            Point headerCell = dgv1.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked1;
            dgv1.Controls.Add(headerChk);
        }
        private void DataGridViewCheckBoxAllCheck2()
        {
            headerChk1 = new CheckBox();
            Point headerCell = dgv2.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk1.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk1.Size = new Size(18, 18);
            headerChk1.BackColor = Color.FromArgb(245, 245, 246);
            headerChk1.Click += HeaderChk_Clicked2;
            dgv2.Controls.Add(headerChk1);
        }
        #endregion

        #region 올체크 이벤트

        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked1(object sender, EventArgs e)
        {
            dgv1.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
            dgv1_CellContentClick(null, null);
        }
        private void HeaderChk_Clicked2(object sender, EventArgs e)
        {
            dgv2.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgv2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk1.Checked;
            }
        }
        #endregion

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv1.EndEdit();
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow item in dgv1.Rows)
            {
                if (Convert.ToBoolean(item.Cells[1].Value) == true)
                {
                   sb.Append("'"+item.Cells[2].Value.ToString()+"',");
                }
            }
            if(sb.ToString().Length <1)
            {
                return;
            }
            MessageBox.Show(sb.ToString().TrimEnd(','));
            ReorderService service = new ReorderService();
            dgv2.DataSource = service.GetReorderItem2(sb.ToString().TrimEnd(','));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            dgv2.EndEdit();
            ReorderService service = new ReorderService();
            foreach (DataGridViewRow item in dgv2.Rows)
            {
                if (Convert.ToBoolean(item.Cells[1].Value) == true)
                {
                    a++;
                    if (item.Cells[10].Value == null)
                    {
                        MessageBox.Show("발주할 품목의 수량을 입력해주세요");
                        return;
                    }
                }
            }
            if (a == 0)
            {
                MessageBox.Show("발주할 품목을 선택해주세요");
                return;
            }
            REORDER_VO vo = new REORDER_VO();
            vo.REORDER_DATE = DateTime.Now;
            vo.REORDER_DATE_IN = DateTime.Now.AddDays(3);
            vo.REORDER_STATE = "발주";
            vo.MANAGER_ID = LoginInfo.UserInfo.LI_ID;
            int su = 0;
            foreach (DataGridViewRow item in dgv2.Rows)
            {
                if (Convert.ToBoolean(item.Cells[1].Value) == true)
                {
                    
                    vo.REORDER_COM_DLVR = item.Cells[3].Value.ToString();
                    vo.REORDER_TYP = (item.Cells[4].Value.ToString().Length < 1) ?"정량" : item.Cells[4].Value.ToString();
                    vo.REORDER_QTY = Convert.ToInt32(item.Cells[10].Value);
                    vo.ITEM_CODE = item.Cells[5].Value.ToString();
                    vo.COM_CODE = item.Cells[2].Value.ToString();
                    if(service.insertREORDER(vo));
                    {
                        su++;
                    }
                }
            }
            if (su > 0)
            {
                MessageBox.Show("발주가 완료 되었습니다.");
                this.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReorderService service = new ReorderService();
            dgv2.DataSource = service.GetSearchReorder2(ITEM_COM_REORDER.Text, ITEM_NAEM.Text);
        }
    }
}
