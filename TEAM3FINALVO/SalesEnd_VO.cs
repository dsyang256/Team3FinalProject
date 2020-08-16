using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class SalesEnd_VO
    {
		public string SALES_WORK_ORDER_ID { get; set; }
		public string COM_CODE { get; set; }
		public string COM_NAME { get; set; }
		public string SALES_COM_CODE { get; set; }
		public string ITEM_CODE { get; set; }
		public string ITEM_NAME { get; set; }
		public string SALES_DUEDATE { get; set; }
		public int WO_PLAN_QTY { get; set; }
		public int OUTed_QTY { get; set; }
		public int EndPrice { get; set; }
	}
}
