using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    class BOM_VO
    {
        public int BOM_CODE { get; set; }
        public int BOM_PARENT_CODE { get; set; }
        public int BOM_QTY { get; set; }
        public DateTime BOM_STARTDATE { get; set; }
        public DateTime BOM_ENDDATE { get; set; }
        public string BOM_USE_YN { get; set; }
        public string BOM_LAST_MDFR { get; set; }
        public DateTime BOM_LAST_MDFY { get; set; }
        public string BOM_AUTOREDUCE_YN { get; set; }
        public string BOM_PLAN_YN { get; set; }
        public string BOM_REMARK { get; set; }
        public string ITEM_CODE { get; set; }
    }
}
