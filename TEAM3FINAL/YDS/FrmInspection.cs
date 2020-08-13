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
    public partial class FrmInspection : baseForm2
    {
        CheckBox headerChk;
        CheckBox headerChk1;
        public FrmInspection()
        {
            InitializeComponent();
        }

        private void FrmReceiving_Load(object sender, EventArgs e)
        {
            ComboBinding();
            DataGridViewColumnSet1();
            DataGridViewColumnSet2();
            DataGridViewBinding1();
            DataGridViewBinding2();
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
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주번호", "REORDER_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주상세번호", "REORDER_DETAIL_CODE", false, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주일", "REORDER_DATE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "입고일", "REORDER_DATE_IN", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "검사일", "REORDER_INSPECT_DATE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "납품업체", "COM_CODE", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "규격", "ITEM_STND", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "최종결과", "REORDER_INSPECT", true, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "납품수량", "REORDER_DETAIL_QTY", true, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "불량수랑", "REORDER_DETAIL_QTY_BAD", true, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "검사자", "MANAGER_NAME", true, 125);
            

            DataGridViewCheckBoxAllCheck1();

        }
        private void DataGridViewColumnSet2()
        {
            DataGridViewUtil.InitSettingGridView(dgv2);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgv2, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주번호", "REORDER_CODE", true, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주상세번호", "REORDER_DETAIL_CODE", false, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "발주일", "REORDER_DATE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "입고일", "REORDER_DATE_IN", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "납품업체", "COM_CODE", true, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품목", "ITEM_CODE", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "품명", "ITEM_NAME", true, 200);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "규격", "ITEM_STND", true, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "납품수량", "REORDER_DETAIL_QTY", true, 125);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "불량수량", "", true, 100, readOnly: false);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv2, "비고", "", true, 400 );

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
            dgv1.DataSource = service.Inspection1();
        }
        private void DataGridViewBinding2()
        {
            dgv2.DataSource = null;
            ReorderService service = new ReorderService();
            dgv2.DataSource = service.Inspection2();
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
            Point headerCell = dgv1.GetCellDisplayRectangle(1, -1, true).Location;
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
                chk.Value = headerChk1.Checked;
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            int bqty = 0;
            int gqty = 0;
            int reorder = 0;
            int reorderD = 0;
            string code = "";
            dgv2.EndEdit();
            ReorderService service = new ReorderService();
            foreach (DataGridViewRow item in dgv2.Rows)
            {
                if (Convert.ToBoolean(item.Cells[1].Value) == true)
                {
                    if (item.Cells[11].Value == null)
                    {
                        bqty = 0;
                    }
                    else
                    {
                        bqty = Convert.ToInt32(item.Cells[11].Value);
                    }
                    gqty = Convert.ToInt32(item.Cells[10].Value);
                    bqty = Convert.ToInt32(item.Cells[11].Value);
                    reorder = Convert.ToInt32(item.Cells[2].Value);
                    reorderD = Convert.ToInt32(item.Cells[3].Value);
                    code = item.Cells[7].Value.ToString();
                    service.insertInspection(gqty, bqty, reorder, reorderD,code);
                    a++;
                    
                }
            }
            if (a == 0)
            {
                MessageBox.Show("검사할 발주를 선택해주세요");
                return;
            }
            DataGridViewBinding2();
            MessageBox.Show("검사가 완료 되었습니다.");


        }
    }
}
