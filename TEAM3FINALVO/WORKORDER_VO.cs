using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    class WORKORDER_VO
    {
        public string WO_Code { get; set; }
        public int WO_PLAN_QTY { get; set; }
        public DateTime WO_PLAN_DATE { get; set; }
        public DateTime WO_PROD_DATE { get; set; }
        public string WO_WORK_STATE { get; set; }
        public int WO_WORK_SEQ { get; set; }
        public DateTime WO_PLAN_STARTTIME { get; set; }
        public DateTime WO_PLAN_ENDTIME { get; set; }
        public int WO_QTY_IN { get; set; }
        public int WO_QTY_OUT { get; set; }
        public int WO_QTY_PROD { get; set; }
        public string WO_PROD_REQ_NUM { get; set; }
        public string WO_REMARK { get; set; }
        public string WO_LAST_MDFR { get; set; }
        public DateTime WO_LAST_MDFY { get; set; }
        public string SALES_WORK_ORDER_ID { get; set; }
        public string ITEM_CODE { get; set; }
        public string FCLTS_CODE { get; set; }
    }
}
