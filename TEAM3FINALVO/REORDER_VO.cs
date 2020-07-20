using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    class REORDER_VO
    {
        public int REORDER_CODE { get; set; }
        public DateTime REORDER_DATE { get; set; }
        public DateTime REORDER_DATE_IN { get; set; }
        public int REORDER_COM_DLVR { get; set; }
        public string REORDER_TYP { get; set; }
        public int REORDER_QTY { get; set; }
        public string REORDER_INSPECT { get; set; }
        public string REORDER_STATE { get; set; }
        public int ITEM_CODE { get; set; }
        public int COM_CODE { get; set; }
        public string MANAGER_ID { get; set; }
    }
}
