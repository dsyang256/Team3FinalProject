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
    public partial class FrmBOMPopUp : TEAM3FINAL.baseFormPopUP
    {
        public FrmBOMPopUp()
        {
            InitializeComponent();
        }
        private void FrmBOMPopUp_Load(object sender, EventArgs e)
        {
            ComboBinding();
        }
        /// <summary>
        /// 콤보 박스 바인딩
        /// </summary>
        private void ComboBinding()
        {
            ComboItemService service = new ComboItemService();
            List<ComboItemVO> Commonlist = service.GetITEMCmCode();


            //상위품목
            var list1 = (from item in Commonlist where item.COMMON_PARENT == "품목" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(BOM_PARENT_CODE, list1, "COMMON_CODE", "COMMON_NAME", "-");
            //품목
            var list2 = (from item in Commonlist where item.COMMON_PARENT == "품목" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(ITEM_CODE, list2, "COMMON_CODE", "COMMON_NAME", "");
            //사용유무
            var listYN1 = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(BOM_USE_YN, listYN1, "COMMON_CODE", "COMMON_NAME", "");
            //자동차감
            var listYN2 = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(BOM_AUTOREDUCE_YN, listYN2, "COMMON_CODE", "COMMON_NAME", "");
            //소요계획
            var listYN3 = (from item in Commonlist where item.COMMON_PARENT == "사용여부" select item).ToList();
            CommonUtil.ComboBinding<ComboItemVO>(BOM_PLAN_YN, listYN3, "COMMON_CODE", "COMMON_NAME", "");



        }

       
    }
}
