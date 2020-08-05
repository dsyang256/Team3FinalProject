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

            //발주창고
            var listWRHS = (from item in Commonlist where item.COMMON_PARENT == "창고" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(WRHS, listWRHS, "COMMON_CODE", "COMMON_NAME", "");
            
            //설비
            var listFCLTS = (from item in Commonlist where item.COMMON_PARENT == "설비" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(FCLTS, listFCLTS, "COMMON_CODE", "COMMON_NAME", "");

            //품목유형
            var listTYP = (from item in Commonlist where item.COMMON_PARENT == "품목유형" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_TYP, listTYP, "COMMON_CODE", "COMMON_NAME", "");

            //상태
            var listSTATE = (from item in Commonlist where item.COMMON_PARENT == "발주상태" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(STATE, listSTATE, "COMMON_CODE", "COMMON_NAME", "");

            //재고량
            var list1 = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM1, list1, "COMMON_CODE", "COMMON_NAME", "");

            //잔량
            var list2 = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM1, list2, "COMMON_CODE", "COMMON_NAME", "");

        }
        #endregion

        #region 데이터 그리드뷰 컬럼+체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 컬럼+체크박스 만들기
        /// </summary>
        private void DataGridViewColumnSet()
        {
            DataGridViewUtil.InitSettingGridView(list1);
            DataGridViewUtil.AddNewColumnToDataGridView(list1, "no", "idx", true, 30);
            DataGridViewUtil.DataGridViewCheckBoxSet(list1, "all");
            DataGridViewUtil.AddNewColumnToDataGridView(list1, "발주업체", "COM_NAME", true, 155);
            DataGridViewUtil.AddNewColumnToDataGridView(list1, "발주업체코드", "COM_CODE", false, 30);

            DataGridViewCheckBoxAllCheck();

        }

        #endregion

        #region 데이터 그리드 바인딩
        /// <summary>
        /// 데이터 그리드 바인딩
        /// </summary>
        private void DataGridViewBinding1()
        {
            list1.DataSource = null;


        }

        #endregion

        #region 데이터 그리드뷰 올체크 체크박스 만들기
        /// <summary>
        /// 데이터 그리드뷰 올체크 체크박스 만들기
        /// </summary>
        private void DataGridViewCheckBoxAllCheck()
        {
            headerChk = new CheckBox();
            Point headerCell = list1.GetCellDisplayRectangle(1, -1, true).Location;
            headerChk.Location = new Point(headerCell.X + 4, headerCell.Y + 15);
            headerChk.Size = new Size(18, 18);
            headerChk.BackColor = Color.FromArgb(245, 245, 246);
            headerChk.Click += HeaderChk_Clicked;
            list1.Controls.Add(headerChk);
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
            list1.EndEdit();

            //데이터그리드뷰의 전체 행의 체크를 체크 or 언체크
            foreach (DataGridViewRow row in list1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["all"];
                chk.Value = headerChk.Checked;
            }
        }

        #endregion
    }
}
