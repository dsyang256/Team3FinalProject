using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmMaterialCost : TEAM3FINAL.baseForm2, CommonBtn
    {

        #region 멤버변수

        #endregion

        #region 생성자
                public FrmMaterialCost()
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
            Util.InitSettingGridView(dgvCost);
            Util.DataGridViewCheckBoxSet(dgvCost, "");
            Util.AddNewColumnToDataGridView(dgvCost, "No.", "RowNumber", true, 50);
            Util.AddNewColumnToDataGridView(dgvCost, "업체", "", false, 200);
            Util.AddNewColumnToDataGridView(dgvCost, "업체명", "", true, 200);
            Util.AddNewColumnToDataGridView(dgvCost, "품목", "", true, 200);
            Util.AddNewColumnToDataGridView(dgvCost, "품명", "", true, 200);
            Util.AddNewColumnToDataGridView(dgvCost, "규격", "", true, 150);
            Util.AddNewColumnToDataGridView(dgvCost, "단위", "", true, 100);
            Util.AddNewColumnToDataGridView(dgvCost, "현재단가", "", true, 100);
            Util.AddNewColumnToDataGridView(dgvCost, "이전단가", "", true, 100);
            Util.AddNewColumnToDataGridView(dgvCost, "시작일", "", true, 120);
            Util.AddNewColumnToDataGridView(dgvCost, "종료일", "", true, 120);
            Util.AddNewColumnToDataGridView(dgvCost, "비고", "", true, 100);
            Util.AddNewColumnToDataGridView(dgvCost, "사용유무", "", true, 100);
        }

        private void BindingComboBox()
        {

        }


        #region 공통버튼 적용
        /// <summary>
        /// 공통버튼 이벤트 추가 메서드
        /// </summary>
        private void BtnSet()
        {
            FrmMAIN frm = (FrmMAIN)this.MdiParent;
            frm.eSearch += Search;
            frm.eInsert += Insert;
            frm.eUpdate += Update;
            frm.eDelete += Delete;
            frm.ePrint += Print;
            frm.eReset += Reset;
        }

        public void Delete(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Insert(object sender, EventArgs e)
        {
            FrmMaterialCostPop frm = new FrmMaterialCostPop(InsertOrUpdate.insert);
            frm.ShowDialog();
        }

        public void Print(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Reset(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Search(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Update(object sender, EventArgs e)
        {
            FrmMaterialCostPop frm = new FrmMaterialCostPop(InsertOrUpdate.update);
            frm.ShowDialog();
        }
        #endregion

        #endregion

        #region 이벤트
        private void FrmMaterialCost_Load(object sender, EventArgs e)
        {
            //초기설정
            //그리드 초기화
            DataGridViewColumnSet();
            //공통버튼적용
            BtnSet();
            //콤보박스 바인딩
            BindingComboBox();
        }
        #endregion


    }
}
