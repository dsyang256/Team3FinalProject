using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    class SALES_ORDER_VO
    {
        public string SO_PurchaseOrder { get; set; }
        public string SO_MKT { get; set; }
        public DateTime SO_DUEDATE { get; set; }
        public int SO_QTY { get; set; }
        public string SO_Order_TYPE { get; set; }
        public string SO_COM_CODE { get; set; }
        public string SO_REMARK { get; set; }
        public string COM_CODE { get; set; }
        public string ITEM_CODE { get; set; }
    }
}
