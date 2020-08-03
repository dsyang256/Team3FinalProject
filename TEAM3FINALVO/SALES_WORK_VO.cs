using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class SALES_WORK_VO
    {
        public int SALES_ID { get; set; }
        public string SALES_Work_Order_ID { get; set; }
        public int SALES_Out_QTY { get; set; }
        public string SALES_MKT { get; set; }
        public string SALES_DUEDATE { get; set; }
        public int SALES_QTY { get; set; }
        public int SALES_NO_QTY { get; set; }
        public string SALES_Order_TYPE { get; set; }
        public string SALES_COM_CODE { get; set; }
        public string SALES_REMARK { get; set; }
        public string COM_CODE { get; set; }
        public string ITEM_CODE { get; set; }
        public string SO_PurchaseOrder { get; set; }
    }

    public class SALESWorkList_VO
    {
        public int SALES_ID { get; set; }
        public string SALES_Work_Order_ID { get; set; }
        public string SO_PurchaseOrder { get; set; }
        public string COM_CODE { get; set; }
        public string COM_NAME { get; set; }
        public string SALES_COM_CODE { get; set; }
        public string SALES_COM_NAME { get; set; }
        public string SALES_Order_TYPE { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public string SALES_DUEDATE { get; set; }
        public int SALES_QTY { get; set; }
        public int SALES_Out_QTY { get; set; }
        public int SALES_NO_QTY { get; set; }
        public string SALES_ORDER_STATE { get; set; }

    }
}
