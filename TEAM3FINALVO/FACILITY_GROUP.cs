using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    class FACILITY_GROUP
    {
        public string FACG_CODE { get; set; } //시설군코드
        public string FACG_NAME { get; set; } //설비군명
        public string FACG_USE_YN { get; set; } //사용유무
        public string FACG_LAST_MDFR { get; set; } //수정자
        public string FACG_LAST_MDFY { get; set; } //최종수정날짜
        public string FACG_DESC { get; set; } //시설설명
    }
}
