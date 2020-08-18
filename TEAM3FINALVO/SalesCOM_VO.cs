using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class SalesCOM_VO
    {
        public string SALES_COM_CODE { get; set; }
        public string COM_NAME { get; set; }
        public string COM_REG_NUM { get; set; }
        public int SALES_TTL { get; set; }
    }

    public class SalesCOMDedail_VO
    {
        public string SALES_COM_CODE { get; set; }
        public string COM_NAME { get; set; }
        public string SALES_ENDDATE { get; set; }
        public int SALES_QTY { get; set; }
        public int unitprice { get; set; }
        public int SALES_TTL { get; set; }
    }
}
