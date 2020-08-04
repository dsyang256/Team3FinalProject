using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public partial class FrmSalesMasterPop : TEAM3FINAL.baseFormPopUP
    {
        #region 멤버변수
        public int InsertOrUpdate { get; set; }
        public string SalesID { get; set; }
        #endregion

        #region 생성자
        public FrmSalesMasterPop(InsertOrUpdate iu)
        {
            InitializeComponent();
            InsertOrUpdate = Convert.ToInt32(iu);
        }
        public FrmSalesMasterPop(InsertOrUpdate iu, string id)
        {
            InitializeComponent();
            InsertOrUpdate = Convert.ToInt32(iu);
            SalesID = id;
        }
        #endregion

        #region 메서드
        /// <summary>
        /// 콤보박스 바인딩하는 메서드
        /// </summary>
        private void BindingComboBox()
        {
            //콤보박스 서비스 호출
            ComboItemService service = new ComboItemService();
            var Itemlist = service.GetItemCode();
            var ComList = service.GetCompanyCode();

            //콤보박스 바인딩 
            CommonUtil.ComboBinding<ComboItemVO>(cboCOM, ComList, "COMMON_CODE", "COMMON_NAME");
            CommonUtil.ComboBinding<ComboItemVO>(cboCOM2, ComList, "COMMON_CODE", "COMMON_NAME");
            CommonUtil.ComboBinding<ComboItemVO>(cboItem, Itemlist, "COMMON_CODE", "COMMON_NAME");
        }
        #endregion

        #region 이벤트
        private void FrmSalesMasterPop_Load(object sender, EventArgs e)
        {
            //콤보박스 바인딩
            BindingComboBox();

            //초기값
            cboCOM.SelectedIndex = 0;
            cboCOM2.SelectedIndex = 0;
            cboMarket.SelectedIndex = 0;
            cboOrderTyp.SelectedIndex = 0;
            cboItem.SelectedIndex = 0;

            if (InsertOrUpdate == 2) //수정
            {
                ////서비스 호출
                SalesService service = new SalesService();
                var vo = service.GetSalesWorkInfo(SalesID);
                txtID.Text = vo.SALES_ID.ToString();
                txtWO.Text = vo.SALES_Work_Order_ID;
                txtPO.Text = vo.SO_PurchaseOrder;
                cboCOM.SelectedIndex = cboCOM.FindIndexByValue(vo.COM_CODE);
                cboCOM2.SelectedIndex = cboCOM2.FindIndexByValue(vo.SALES_COM_CODE);
                dtpDueDate.Value = Convert.ToDateTime(vo.SALES_DUEDATE);
                cboItem.SelectedIndex = cboItem.FindIndexByValue(vo.ITEM_CODE);
                txtOrderQTY.Text = vo.SALES_QTY.ToString();
                txtOutQTY.Text = vo.SALES_Out_QTY.ToString();
                txtNoQTY.Text = vo.SALES_NO_QTY.ToString();
                cboMarket.SelectedIndex = cboMarket.FindStringExact(vo.SALES_MKT);
                cboOrderTyp.SelectedIndex = cboOrderTyp.FindStringExact(vo.SALES_Order_TYPE);
                txtRemark.Text = vo.SALES_REMARK;
            }

        }

        /// <summary>
        /// W/O 저장하는 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //유효값 확인
            bool bQTY = txtOrderQTY.Text.Length > 0;
            bool bWO = txtWO.Text.Trim().Length > 0;

            if (!(bQTY || bWO))
            {
                MessageBox.Show("필수값을 입력해주세요.", "필수값 입력 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //전달 vo 생성
            SALES_WORK_VO vo = new SALES_WORK_VO();
            vo.SALES_ID = 0; //등록
            if (InsertOrUpdate == 2)
                vo.SALES_ID = int.Parse(txtID.Text); //수정
            vo.SALES_Work_Order_ID = txtWO.Text.Trim();
            vo.SO_PurchaseOrder = txtPO.Text.Trim();
            vo.COM_CODE = cboCOM.SelectedValue.ToString();
            vo.SALES_COM_CODE = cboCOM2.SelectedValue.ToString();
            vo.SALES_DUEDATE = dtpDueDate.Value.ToShortDateString();
            vo.ITEM_CODE = cboItem.SelectedValue.ToString();
            vo.SALES_QTY = int.Parse(txtOrderQTY.Text);
            if (txtOutQTY.Text.Trim().Length < 1)
                txtOutQTY.Text = "0";
            vo.SALES_Out_QTY = int.Parse(txtOutQTY.Text);
            if (txtNoQTY.Text.Trim().Length < 1)
                txtNoQTY.Text = "0";
            vo.SALES_NO_QTY = int.Parse(txtNoQTY.Text);
            vo.SALES_MKT = cboMarket.Text;
            vo.SALES_Order_TYPE = cboOrderTyp.Text;
            vo.SALES_REMARK = txtRemark.Text;

            //서비스호출
            SalesService service = new SalesService();
            Message msg = service.InsertOrUpdateSalesWork(vo);
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

        }

        /// <summary>
        /// 입력값 숫자처리 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOrderQTY_KeyPress(object sender, KeyPressEventArgs e)
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
        #endregion

    }
}
