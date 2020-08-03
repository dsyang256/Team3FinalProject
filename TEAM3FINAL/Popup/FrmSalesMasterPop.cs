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

            //콤보박스 바인딩 
            CommonUtil.ComboBinding<ComboItemVO>(cboCOM, Itemlist, "COMMON_NAME", "COMMON_CODE");
            CommonUtil.ComboBinding<ComboItemVO>(cboCOM2, Itemlist, "COMMON_NAME", "COMMON_CODE");
            CommonUtil.ComboBinding<ComboItemVO>(cboItem, Itemlist, "COMMON_NAME", "COMMON_CODE");
        }
        #endregion

    }
}
