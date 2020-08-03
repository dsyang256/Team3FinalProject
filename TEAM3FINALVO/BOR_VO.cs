using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class BOR_VO
    {
        //public string BOR_CODE { get; set; } //BOR 코드
        //public string BOR_PROCS_CODE { get; set; } //공정코드
        //public int BOR_PROCS_TIME { get; set; } //TACTTIME
        //public int BOR_PROCS_LEADTIME { get; set; } //공정선행일
        //public int BOR_PRIORT { get; set; } //우선순위
        //public decimal BOR_YIELD { get; set; } //수율
        //public string BOR_USE_YN { get; set; } //사용유무
        //public string BOR_REMARK { get; set; } // 비고
        //public string ITEM_CODE { get; set; } //품목코드
        //public string FCLTS_CODE { get; set; } //설비코드
        public int BOR_CODE { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public string BOR_PROCS_CODE { get; set; }
        public string COMMON_CODE { get; set; }
        public string FCLTS_CODE { get; set; }
        public string FCLTS_NAME { get; set; }
        public int? BOR_PROCS_TIME { get; set; }
        public int? BOR_PRIORT { get; set; }
        public int? BOR_PROCS_LEADTIME { get; set; }
        public decimal? BOR_YIELD { get; set; }
        public string BOR_USE_YN { get; set; }
        public string BOR_REMARK { get; set; }
        public string BOR_LAST_MDFR { get; set; }
        public string BOR_LAST_MDFY { get; set; }
    }
}
