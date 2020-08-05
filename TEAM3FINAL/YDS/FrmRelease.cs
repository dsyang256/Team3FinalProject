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
    public partial class FrmRelease : baseForm2
    {
        CheckBox headerChk;
        public FrmRelease()
        {
            InitializeComponent();
        }

        private void FrmRelease_Load(object sender, EventArgs e)
        {
            ComboBinding();
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

            //발주업체
            //var listCOM_OUT = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            //CommonUtil.ComboBinding<ComboItemVO>(COM_OUT, listCOM_OUT, "COMMON_CODE", "COMMON_NAME", "");

            //납품업체
            //var listCOM_IN = (from item in Commonlist where item.COMMON_PARENT == "업체명" select item).ToList();
            //CommonUtil.ComboBinding<ComboItemVO>(COM_IN, listCOM_IN, "COMMON_CODE", "COMMON_NAME", "");

            //발주상태
            //var listUSER = (from item in Commonlist where item.COMMON_PARENT == "담당자" select item).ToList();
            //CommonUtil.ComboBinding<ComboItemVO>(USER, listUSER, "COMMON_CODE", "COMMON_NAME", "");

            //창고
            //var listWRHS = (from item in Commonlist where item.COMMON_PARENT == "FACILITY_TYPE" select item).ToList();
            //CommonUtil.ComboBinding<ComboItemVO>(WRHS, listWRHS, "COMMON_CODE", "COMMON_NAME", "");

        }
        #endregion

        #region 데이터 그리드뷰 컬럼+체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            DataGridViewUtil.InitSettingGridView(dgv1);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(dgv1, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주업체", "COM_NAME", true, 155);
            DataGridViewUtil.AddNewColumnToDataGridView(dgv1, "발주업체코드", "COM_CODE", false, 30);

            DataGridViewCheckBoxAllCheck();

        }

        #endregion

        #region 데이터 그리드 바인딩
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding1()
        {
            dgv1.DataSource = null;


        }

        #endregion

        #region 데이터 그리드뷰 올체크 체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = dgv1.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            dgv1.Controls.Add(headerChk);
        }

        #endregion

        #region 올체크 이벤트

        /// <summary>
        /// 올체크 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderChk_Clicked(object sender, EventArgs e)
        {
            dgv1.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in dgv1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }

        #endregion
    }
}
