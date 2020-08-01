using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public enum InsertOrUpdate
    {
        insert = 1, update = 2
    }

    public partial class FrmMaterialCostPop : TEAM3FINAL.baseFormPopUP
    {

        #region 멤버변수
        public int InsertOrUpdate { get; set; }
        #endregion

        #region 생성자
        public FrmMaterialCostPop(InsertOrUpdate iu)
        {
            InitializeComponent();
            InsertOrUpdate = Convert.ToInt32(iu);
        }
        #endregion

        #region 메서드
        /// <summary>
        /// 콤보박스 바인딩 메서드
        /// </summary>
        private void BindingComboBox()
        {
            //서비스호출
            ComboItemService service = new ComboItemService();
            var ComList =service.GetCompanyCode();
            var ItemList = service.GetItemCode();

            CommonUtil.ComboBinding<ComboItemVO>(cboCompany, ComList, "COMMON_CODE", "COMMON_NAME");
            CommonUtil.ComboBinding<ComboItemVO>(cboItem, ItemList, "COMMON_CODE", "COMMON_NAME");
        }
        #endregion

        #region 이벤트
        /// <summary>
        /// 시작시간 KeyPress 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSTARTTIME_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력받음
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 폼 종료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 저장이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 자재단가등록
            //유효성 검사
            if (!(txtSTARTTIME.Text.Trim().Length > 0))
            {
                MessageBox.Show("현재단가는 입력 필수값입니다.", "필수 입력", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!(txtENDTIME.Text.Trim().Length > 0))
            {
                MessageBox.Show("이전단가는 입력 필수값입니다.", "필수 입력", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MaterialCost_VO vo = new MaterialCost_VO();



            
            //서비스호출
            CostService service = new CostService();
            var msg = service.InsertOrUpdateMaterialCost(vo);
            if (msg.IsSuccess)
            {
                MessageBox.Show(msg.ResultMessage);
                this.Close();
            }
            else
            {
                MessageBox.Show(msg.ResultMessage);
                return;
            }

            ////등록완료
            //MessageBox.Show($"{list.COM_Code}업체의 {list.ITEM_Code}의 단가가 성공적으로 등록되었습니다 \n 현재 날짜를 기준으로 화면이 재구성됩니다.", "확인", MessageBoxButtons.OK);

            //이전단가 업데이트
            #endregion

            #region 자재단가수정
            //유효성 검사
            #endregion
        }





        private void FrmMaterialCostPop_Load(object sender, EventArgs e)
        {
            txtMDFDate.Text = DateTime.Now.ToShortDateString();
            if (InsertOrUpdate == 1) //등록
            {
                txtENDTIME.ReadOnly = false;
                txtENDTIME.Text = "2099 - 12 - 31";
            }
            else
            {
                txtENDTIME.ReadOnly = true; //수정
                
                //수정할 데이터 조회
                //서비스 호출


            }
            //콤보박스 바인딩
            BindingComboBox();
        }

        #endregion


    }
}
