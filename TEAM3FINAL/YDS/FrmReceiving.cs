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
    public partial class FrmReceiving : baseForm2
    {
        CheckBox headerChk;
        CheckBox headerChk1;
        public FrmReceiving()
        {
            InitializeComponent();
        }

        private void FrmReceiving_Load(object sender, EventArgs e)
        {
            ComboBinding();
            DataGridViewColumnSet1();
            DataGridViewColumnSet2();
        }
        #region 콤보박스 바인딩
        /// <summary>
        /// 콤보박스 바인딩
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBinding()
        {
            CommonService service = new CommonService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();

            //발주업체
            var listCOM_REORDER_OUT = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(COM_REORDER_OUT, listCOM_REORDER_OUT, "COMMON_CODE", "COMMON_NAME", "");

            //납품업체
            var listCOM_REORDER_IN = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(COM_REORDER_IN, listCOM_REORDER_IN, "COMMON_CODE", "COMMON_NAME", "");

            var listREORDER_STATE = (from item in Commonlist where item.COMMON_PARENT == "발주상태" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(REORDER_STATE, listREORDER_STATE, "COMMON_CODE", "COMMON_NAME", "");

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
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "업체", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "납품업체", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품명", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "규격", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목유형", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "단위", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "검사여부", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "출발처리유무", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주수량", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "잔량", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "납기일", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "주문상태", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "생성일", "", true, 100);

            DataGridViewCheckBoxAllCheck1();

        }
        private void DataGridViewColumnSet2()
        {
            DataGridViewUtil.InitSettingGridView(dgv2);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgv2, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품목", "", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품명", "", false, 30);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "규격", "", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품목유형", "", false, 30);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "단위", "", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "입고창고", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "입고일자", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "입고량", "", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "단가", "", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "수정자", "", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "비고", "", true, 80);
          
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
            //dgv2.DataSource = null;
            //ReorderService service = new ReorderService();
            //dgv2.DataSource = service.GetCOM();
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
        }
        private void HeaderChk_Clicked2(object sender, EventArgs e)
        {
            dgv2.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgv2.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }
        #endregion
    }
}
