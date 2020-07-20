using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    class MATERIAL_COST_VO
    {
        public int MC_Code { get; set; }
        public int MC_UNITPRICE_CUR { get; set; }
        public int MC_UNITPRICE_EX { get; set; }
        public DateTime MC_STARTDATE { get; set; }
        public DateTime MC_ENDDATE { get; set; }
        public string MC_LAST_MDFR { get; set; }
        public DateTime MC_LAST_MDFY { get; set; }
        public string MC_USE_YN { get; set; }
        public string MC_REMARK { get; set; }
        public string COM_Code { get; set; }
        public string ITEM_Code { get; set; }
    }
}
