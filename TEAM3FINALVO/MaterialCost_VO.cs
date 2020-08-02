using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class MaterialCost_VO
    {
        public int MC_Code { get; set; }
        public int MC_UNITPRICE_CUR { get; set; }
        public int MC_UNITPRICE_EX { get; set; }
        public string MC_STARTDATE { get; set; }
        public string MC_ENDDATE { get; set; }
        public string MC_LAST_MDFR { get; set; }
        public string MC_LAST_MDFY { get; set; }
        public string MC_USE_YN { get; set; }
        public string MC_REMARK { get; set; }
        public string COM_Code { get; set; }
        public string ITEM_Code { get; set; }
            }
    public class MaterialCostList_VO
    {
        public int MC_Code { get; set; }
        public string COM_Code { get; set; }
        public string COM_NAME { get; set; }
        public string ITEM_Code { get; set; }
        public string ITEM_NAME { get; set; }
        public string ITEM_STND { get; set; }
        public string ITEM_UNIT { get; set; }
        public int MC_UNITPRICE_CUR { get; set; }
        public int MC_UNITPRICE_EX { get; set; }
        public string MC_STARTDATE { get; set; }
        public string MC_ENDDATE { get; set; }
        public string MC_REMARK { get; set; }
        public string MC_USE_YN { get; set; }
    }
    public class SalesCost_VO
    {
        public int SC_CODE { get; set; }
        public int SC_UNITPRICE_CUR { get; set; }
        public int SC_UNITPRICE_EX { get; set; }
        public string SC_STARTDATE { get; set; }
        public string SC_ENDDATE { get; set; }
        public string SC_LAST_MDFR { get; set; }
        public string SC_LAST_MDFY { get; set; }
        public string SC_USE_YN { get; set; }
        public string SC_REMARK { get; set; }
        public string COM_Code { get; set; }
        public string ITEM_Code { get; set; }

    }

    public class SalesCostList_VO
    {
        public int SC_CODE { get; set; }
        public string COM_Code { get; set; }
        public string COM_NAME { get; set; }
        public string ITEM_Code { get; set; }
        public string ITEM_NAME { get; set; }
        public string ITEM_STND { get; set; }
        public string ITEM_UNIT { get; set; }
        public int SC_UNITPRICE_CUR { get; set; }
        public int SC_UNITPRICE_EX { get; set; }
        public string SC_STARTDATE { get; set; }
        public string SC_ENDDATE { get; set; }
        public string SC_REMARK { get; set; }
        public string SC_USE_YN { get; set; }
    }
}