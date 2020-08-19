using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class SalesCOM_VO
    {
        public string SALES_COM_CODE { get; set; }
        public string COM_NAME { get; set; }
        public string COM_REG_NUM { get; set; }
        public int SALES_TTL { get; set; }
    }

    public class SalesCOMDedail_VO
    {
        public string SALES_COM_CODE { get; set; }
        public string COM_NAME { get; set; }
        public string SALES_ENDDATE { get; set; }
        public int SALES_QTY { get; set; }
        public int unitprice { get; set; }
        public int SALES_TTL { get; set; }
    }

    public class SalesCOM2_VO
    {
        public string COM_CODE { get; set; }
        public string ITEM_COM_DLVR { get; set; }
        public string COM_REG_NUM { get; set; }
        public int TTLPRICE { get; set; }
    }

    public class SalesCOMDedail2_VO
    {
        public string ITEM_COM_DLVR { get; set; }
        public string ITEM_COM_REORDER { get; set; }
        public string INS_DATE { get; set; }
        public string INS_TYP { get; set; }
        public string FAC_NAME { get; set; }
        public string ITEM_CODE { get; set; }
        public int INS_QTY { get; set; }
        public int MC_UNITPRICE_CUR { get; set; }
        public int TTLPRICE { get; set; }
    }
}
