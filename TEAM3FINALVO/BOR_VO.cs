using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    class BOR_VO
    {
        public string BOR_CODE { get; set; }
        public string BOR_PROCS_CODE { get; set; }
        public int BOR_PROCS_TIME { get; set; }
        public int BOR_PROCS_LEADTIME { get; set; }
        public int BOR_PRIORT { get; set; }
        public decimal BOR_YIELD { get; set; }
        public string BOR_USE_YN { get; set; }
        public string BOR_REMARK { get; set; }
        public string ITEM_CODE { get; set; }
        public string FCLTS_CODE { get; set; }
    }
}
