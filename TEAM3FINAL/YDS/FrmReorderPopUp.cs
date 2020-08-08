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
        }
        #region 올체크 이벤트
        /// <summary>
        /// 올체크 이벤트
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
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주업체", "COM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주코드", "COM_CODE", false, 30);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "납품업체", "COM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "납품코드", "COM_CODE", false, 30);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "담당자", "COM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품목", "COM_NAME", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품명", "COM_NAME", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "창고", "COM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "검사여부", "COM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주제안수량", "COM_NAME", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주수량", "COM_NAME", true, 80);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "현재고", "COM_NAME", true, 80);

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
            dgv2.DataSource = service.GetReorderItem();
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
