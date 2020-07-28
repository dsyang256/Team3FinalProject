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
    public partial class ShiftPop : TEAM3FINAL.baseFormPopUP
    {
        public ShiftPop()
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
            var Commonlist = service.GetFacilitiesCode();
            //콤보박스 바인딩 - 부서명
            CommonUtil.ComboBinding<ComboItemVO>(cboFcltsCode, Commonlist, "COMMON_CODE", "COMMON_NAME");
        }

        #endregion

    }
}
