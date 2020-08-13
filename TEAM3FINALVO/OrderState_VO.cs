using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class OrderState_VO
    {
        //public string ITEM_CODE { get; set; }
        //public string ITEM_NAME { get; set; }
        //public string ITEM_STND { get; set; }
        //public string FCLTS_CODE { get; set; }
        //public string FCLTS_NAME { get; set; }
        //public int WO_QTY_OUT { get; set; }
        //public string WO_REMARK { get; set; }
        //public string SALES_WORK_ORDER_ID { get; set; }
        //public string ITEM_TYP { get; set; }
        //public string ToWHouse { get; set; }

        //고객주문별현황
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public string ITEM_STND { get; set; }
        public string FAC_CODE { get; set; }
        public string FAC_NAME { get; set; }
        public int WO_QTY_OUT { get; set; }
        public string WO_REMARK { get; set; }
        public string SALES_WORK_ORDER_ID { get; set; }
        public string ITEM_TYP { get; set; }
        public string ToWHouse { get; set; }
    }
}
