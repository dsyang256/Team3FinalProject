using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    class SALES_COST_VO
    {
        public int SC_CODE { get; set; }
        public int SC_UNITPRICE_CUR { get; set; }
        public int SC_UNITPRICE_EX { get; set; }
        public DateTime SC_STARTDATE { get; set; }
        public DateTime SC_ENDDATE { get; set; }
        public string SC_LAST_MDFR { get; set; }
        public DateTime SC_LAST_MDFY { get; set; }
        public string SC_USE_YN { get; set; }
        public string SC_REMARK { get; set; }
        public string COM_Code { get; set; }
        public string ITEM_Code { get; set; }
    }
}
