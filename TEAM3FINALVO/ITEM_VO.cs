using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
     public class ITEM_VO
    {
        public Int64 idx { get; set;  }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public string ITEM_STND { get; set; }
        public string ITEM_UNIT { get; set; }
        public int ITEM_QTY_UNIT { get; set; }
        public string ITEM_TYP { get; set; }
        public string ITEM_INCOME_YN { get; set; }
        public string ITEM_PROCS_YN { get; set; }
        public string ITEM_XPORT_YN { get; set; }
        public string ITEM_FREE_YN { get; set; }
        public string ITEM_COM_DLVR { get; set; }
        public string ITEM_COM_REORDER { get; set; }
        public string ITEM_WRHS_IN { get; set; }
        public string ITEM_WRHS_OUT { get; set; }
        public int ITEM_LEADTIME { get; set; }
        public int ITEM_QTY_REORDER_MIN { get; set; }
        public int ITEM_QTY_STND { get; set; }
        public int ITEM_QTY_SAFE { get; set; }
        public string ITEM_MANAGE_LEVEL { get; set; }
        public string ITEM_MANAGER { get; set; }
        public string ITEM_UNIT_CNVR { get; set; }
        public int ITEM_QTY_CNVR { get; set; }
        public string ITEM_LAST_MDFR { get; set; }
        public string ITEM_LAST_MDFY { get; set; }
        public string ITEM_USE_YN { get; set; }
        public string ITEM_DSCN_YN { get; set; }
        public string ITEM_GROUP { get; set; }
        public string ITEM_REORDER_TYP { get; set; }
        public string ITEM_REMARK { get; set; }
    }
}
