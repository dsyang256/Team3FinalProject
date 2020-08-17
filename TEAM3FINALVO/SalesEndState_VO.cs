using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class SalesEndState_VO
    {
        public string SALES_WORK_ORDER_ID { get; set; }
        public string SALES_COM_CODE { get; set; }
        public string COM_NAME { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public string SALES_DUEDATE { get; set; }
        public int SALES_QTY { get; set; }
        public int SALES_TTL { get; set; }
        public string SALES_ENDDATE { get; set; }
        public string SALES_CANCELDATE { get; set; }
    }
}
