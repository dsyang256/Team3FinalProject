using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class SHIFT_VO
    {
        public int SHIFT_CODE { get; set; }
        public string SHIFT_TYP { get; set; }
        public int SHIFT_STARTTIME { get; set; }
        public int SHIFT_ENDTIME { get; set; }
        public string SHIFT_APPLY_STARTTIME { get; set; }
        public string SHIFT_APPLY_ENDTIME { get; set; }
        public int SHIFT_PERSON_DIR { get; set; }
        public string SHIFT_USE_YN { get; set; }
        public string SHIFT_LAST_MDFR { get; set; }
        public string SHIFT_LAST_MDFY { get; set; }
        public string SHIFT_REMARK { get; set; }
        public string FCLTS_CODE { get; set; }
    }

    public class SHIFTList_VO
    {
        public string FCLTS_CODE { get; set; }
        public string FCLTS_NAME { get; set; }
        public int SHIFT_CODE { get; set; }
        public int SHIFT_STARTTIME { get; set; }
        public int SHIFT_ENDTIME { get; set; }
        public string SHIFT_APPLY_STARTTIME { get; set; }
        public string SHIFT_APPLY_ENDTIME { get; set; }
        public int SHIFT_PERSON_DIR { get; set; }
        public string SHIFT_USE_YN { get; set; }
        public string SHIFT_REMARK { get; set; }
        public string SHIFT_TYP { get; set; }
    }

}
