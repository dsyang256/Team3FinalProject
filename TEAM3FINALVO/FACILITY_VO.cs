using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class FACILITY_VO
    {
        public string FCLTS_CODE { get; set; } //설비코드
        public string FCLTS_NAME { get; set; } //설비명
        public string FCLTS_WRHS_EXHST { get; set; } //소진창고
        public string FCLTS_WRHS_GOOD { get; set; } //양품창고
        public string FCLTS_WRHS_BAD { get; set; } //불량창고
        public string FCLTS_USE_YN { get; set; } //사용유무
        public string FCLTS_EXTRL_YN { get; set; } //외주여부
        public string FCLTS_LAST_MDFR { get; set; } //수정자
        public string FCLTS_LAST_MDFY { get; set; } //최종수정일
        public string FCLTS_NOTE { get; set; } //특이사항
        public string FCLTS_REMARK { get; set; } //비고
        public string FACG_CODE { get; set; } //설비군코드
    }
}
