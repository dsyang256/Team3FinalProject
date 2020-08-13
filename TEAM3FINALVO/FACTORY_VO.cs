using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class FACTORY_VO
    {
        public string FAC_CODE { get; set; } //시설코드*
        public string FAC_FCLTY { get; set; } //시설군*
        public string FAC_FCLTY_PARENT { get; set; } //상위시설*
        public string FAC_NAME { get; set; } //시설명*
        public string FAC_TYP { get; set; } //시설구분*
        public string FAC_FREE_YN { get; set; } //유무상구분
        public int? FAC_TYP_SORT { get; set; } //순서
        public string FAC_DEMAND_YN { get; set; } //수요차감
        public string FAC_PROCS_YN { get; set; } //공정차감
        public string FAC_MTRL_YN { get; set; } //자재차감
        public string FAC_LAST_MDFR { get; set; } //수정자
        public string FAC_LAST_MDFY { get; set; } //수정날짜 DB getdate 사용
        public string FAC_USE_YN { get; set; } //사용유무*
        public string FAC_DESC { get; set; } //시설설명
        public string COM_NAME { get; set; } //업체명
    }
}
