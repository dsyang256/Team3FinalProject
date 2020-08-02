using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmSalesMasterUpLoad : TEAM3FINAL.baseForm2
    {
        #region 멤버변수

        #endregion

        #region 생성자
        public FrmSalesMasterUpLoad()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        /// <summary>
        /// 그리드뷰 컬럼 설정
        /// </summary>
        private void DataGridViewColumnSet()
        {
            //데이터그리드뷰 초기설정
            DataGridViewUtil.InitSettingGridView(dgvSalesMaster);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "planDate", "", true, 160);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "WORK_ORDER_ID", "", true, 180);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "업체CODE", "", true, 100);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "발주구분", "", true, 90);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "납품처", "", true, 90);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "ITEM CODE", " ", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "계획수량합계", "", true, 120);
            DataGridViewUtil.AddNewColumnToDataGridView(dgvSalesMaster, "납기일", "", true, 200);

            //행번호 추가
            DataGridViewUtil.DataGridViewRowNumSet(dgvSalesMaster);
        }
        #endregion
    }
}
