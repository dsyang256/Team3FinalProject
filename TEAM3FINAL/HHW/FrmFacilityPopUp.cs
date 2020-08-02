using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEAM3FINALVO;
using TEAM3FINAL.Services;
using System.Linq;

namespace TEAM3FINAL
{
    public partial class FrmFacilityPopUp : TEAM3FINAL.baseFormPopUP
    {
        #region Property
        public bool Update { get; set; }
        public string FACG_CODE { get; set; } //설비군코드
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
        

        #endregion

        public FrmFacilityPopUp()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 설비군 등록&수정

            if (txtFACGCODE.Text == "" || txtFACCODE.Text == "" || txtFACNAME.Text == "" ||
                cboFACEXHST.Text == "" || cboFACGOOD.Text == "" || cboFACGUseYN.Text == "")
            {
                MessageBox.Show("필수정보 입력 필요");
                return;
            }

            FACILITY_VO vo = new FACILITY_VO();
            vo.FACG_CODE = txtFACGCODE.Text;
            vo.FCLTS_CODE = txtFACCODE.Text;
            vo.FCLTS_NAME = txtFACNAME.Text;
            vo.FCLTS_WRHS_EXHST = cboFACEXHST.Text;
            vo.FCLTS_WRHS_GOOD = cboFACGOOD.Text;
            vo.FCLTS_WRHS_BAD = cboFACBAD.Text;
            vo.FCLTS_USE_YN = cboFACGUseYN.Text;
            vo.FCLTS_EXTRL_YN = cboEXTRLYN.Text;
            vo.FCLTS_LAST_MDFR = FCLTS_LAST_MDFR;
            vo.FCLTS_LAST_MDFY = FCLTS_LAST_MDFY;
            vo.FCLTS_NOTE = txtNote.Text;
            vo.FCLTS_REMARK = txtREMARK.Text;

            if(!Update) //설비 등록
            {
                FacilityService service = new FacilityService();
                //string result = service
            }

            #endregion
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Update = false;
            this.Close();
        }
    }
}
