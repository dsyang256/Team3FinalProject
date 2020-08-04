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
    public partial class FrmWarehousingWait : baseForm2
    {
        CheckBox headerChk;
        CheckBox headerChk1;
        public FrmWarehousingWait()
        {
            InitializeComponent();
        }

        private void FrmWarehousingWait_Load(object sender, EventArgs e)
        {
            ComboBinding();
            DataGridViewColumnSet1();
            DataGridViewColumnSet2();
        }
        /// <summary>
        /// 콤보 박스 바인딩
        /// </summary>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //발주업체
            var listCOM_CODE_OUT = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(COM_CODE_OUT, listCOM_CODE_OUT, "COMMON_CODE", "COMMON_NAME", "");

            //납품업체
            var listCOM_CODE_IN = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(COM_CODE_IN, listCOM_CODE_IN, "COMMON_CODE", "COMMON_NAME", "");

        }
        /// <summary>
        /// 데이터 그리드뷰 컬럼 만들기
        /// </summary>
        private void DataGridViewColumnSet1()
        {
            DataGridViewUtil.InitSettingGridView(dgv1);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgv1, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주일자", "REORDER_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주업체", "COM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "납품업체", "REORDER_COM_DLVR", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목", "REORDER_STATE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품명", "ITEM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "규격", "ITEM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "단위", "ITEM_STND", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "검사여부", "ITEM_UNIT", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주량", "REORDER_DATE_IN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "입고량", "REORDER_QTY", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "잔량", "REORDER_DETAIL_QTY_GOOD", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "납기일자", "REORDER_DATE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주유형", "MANAGER_NAME", true, 100);
            DataGridViewCheckBoxAllCheck1();
        }
        private void DataGridViewColumnSet2()
        {
            DataGridViewUtil.InitSettingGridView(dgv2);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgv2, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주코드", "REORDER_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품목", "COM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품명", "REORDER_COM_DLVR", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "규격", "REORDER_STATE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "단위", "ITEM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발수수량", "ITEM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "잔여수량", "ITEM_STND", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "입고수량", "ITEM_UNIT", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주유형", "REORDER_DATE_IN", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "입고일자", "REORDER_QTY", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주일자", "REORDER_DETAIL_QTY_GOOD", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "검사유무", "REORDER_DATE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "비고", "MANAGER_NAME", true, 100);
            DataGridViewCheckBoxAllCheck2();
        }
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
            headerChk1= new CheckBox();
            Point headerCell = dgv2.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk1.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk1.Size = new Size(18, 18);
            headerChk1.BackColor = Color.FromArgb(245, 245, 246);
            headerChk1.Click += HeaderChk_Clicked2;
            dgv2.Controls.Add(headerChk1);
        }
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
        }
        private void HeaderChk_Clicked2(object sender, EventArgs e)
        {
            dgv1.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgv2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }
    }
}
