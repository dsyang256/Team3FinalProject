using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TEAM3FINAL
{
    public partial class FrmFacilityPopUp : TEAM3FINAL.baseFormPopUP
    {
        #region Property
        public bool Update { get; set; }
        public string FCLTS_CODE { get; set; } //설비코드
        public string FCLTS_NAME { get; set; } //설비명
        public string FCLTS_WRHS_EXHST { get; set; } //소진창고
        public string FCLTS_WRHS_GOOD { get; set; } //양품창고
        public string FCLTS_WRHS_BAD { get; set; } //불량창고
        public string FCLTS_USE_YN { get; set; } //사용유무
        public string FCLTS_EXTRL_YN { get; set; } //외주여부
        public string FCLTS_LAST_MDFR { get; set; } //수정자
        public string FCLTS_LAST_MDFY { get; set; } //최종수정일
        public string FCLTS_NOTE { get; set; } //특이사항
        public string FCLTS_REMARK { get; set; } //비고
        public string FACG_CODE { get; set; } //설비군코드

        #endregion

        public FrmFacilityPopUp()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 설비군 등록&수정

            //if ()
            //{
            //    MessageBox.Show("필수정보 입력 필요");
            //    return;
            //}

            #endregion
        }
    }
}
