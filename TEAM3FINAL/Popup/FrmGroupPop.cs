using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public partial class FrmGroupPop : TEAM3FINAL.baseFormPopUP
    {
        #region 멤버변수
        public int InsertOrUpdate { get; set; }
        public string rightCode { get; set; }
        #endregion
        public FrmGroupPop()
        {
            InitializeComponent();
        }

        #region 메서드
        /// <summary>
        /// 콤보박스 바인딩하는 메서드
        /// </summary>
        private void BindingComboBox()
        {
            //콤보박스 서비스 호출
            ComboItemService service = new ComboItemService();
            var Commonlist = service.GetCmCode();
            var grouplist = (from item in Commonlist select item).Where(p => p.COMMON_PARENT == "RIGHT").ToList();
            //콤보박스 바인딩 
            CommonUtil.ComboBinding<ComboItemVO>(cboRightgroup, grouplist, "COMMON_CODE", "COMMON_NAME"); 
        }
        #endregion


        /// <summary>
        /// 종료 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtRightName.Text.Trim().Length <1)
            {
                MessageBox.Show("필수값을 입력하세요.", "필수값 확인", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string group = cboRightgroup.Text;
            string name = txtRightName.Text;
            string remark = txtRemark.Text;

            AuthService service = new AuthService();
            if(service.SaveGroup(group, name, remark))
            {
                MessageBox.Show("등록되었습니다.", "등록 성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("등록에 실패하였습니다.", "등록 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmGroupPop_Load(object sender, EventArgs e)
        {
            BindingComboBox();
            cboRightgroup.SelectedIndex = 0;
            cboRightUseYN.SelectedIndex = 0;
            txtMDFDate.Text = DateTime.Now.ToShortDateString();
        }
    }
}
