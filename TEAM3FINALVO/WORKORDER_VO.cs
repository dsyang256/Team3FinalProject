using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class WORKORDER_VO
    {
        public string WO_Code { get; set; } //작업지시번호 
        public int WO_PLAN_QTY { get; set; } //계획수량(지시량) *
        public string WO_PLAN_DATE { get; set; } //계획날짜 *
        public string WO_PROD_DATE { get; set; } //생산일자 (작업실적등록일)
        public string WO_WORK_STATE { get; set; } //작업지시상태 *
        public int WO_WORK_SEQ { get; set; } //작업순서 *
        public string WO_PLAN_STARTTIME { get; set; } //계획실제시작일
        public string WO_PLAN_ENDTIME { get; set; } //계획실제종료일
        public int WO_QTY { get; set; } //잔량
        public int WO_QTY_IN { get; set; } //투입수량 * 
        public int WO_QTY_OUT { get; set; } //산출수량 * = 양품
        public int WO_QTY_BAD { get; set; } //불량수량 (투입수량 - 산출수량) *
        public int WO_QTY_PROD { get; set; } //생산수량 (양품 + 불량) *
        //public string WO_PROD_REQ_NUM { get; set; } //생산의뢰번호
        public string WO_REMARK { get; set; } //비고
        public string WO_LAST_MDFR { get; set; } //최종수정자
        public string WO_LAST_MDFY { get; set; } //최종수정일자
        public string SALES_WORK_ORDER_ID { get; set; } //작업지시서번호
        public string ITEM_CODE { get; set; } //품목코드 *
        public string ITEM_NAME { get; set; }
        public string FCLTS_CODE { get; set; } //작업장코드 *
        public string FCLTS_Name { get; set; }
        public string FCLTS_WRHS_GOOD { get; set; }
        public string FCLTS_WRHS_BAD { get; set; }
        public int SALES_NO_QTY { get; set; }
        public string PLAN_ID { get; set; } //계획ID
        public string ITEM_TYP { get; set; }                                        
    }

    public class WORKORDERCREATE_VO
    {
        public string WO_Code { get; set; } //작업지시번호
        public int WO_PLAN_QTY { get; set; } //계획수량(지시량) *
        public int WO_QTY_PROD { get; set; }
        public int Tacminute { get; set; }
        public string WO_WORK_STATE { get; set; } //작업지시상태 *
        public string WO_PLAN_STARTTIME { get; set; } //계획실제시작일
        public string WO_PLAN_ENDTIME { get; set; } //계획실제종료일
        public string ITEM_CODE { get; set; } //품목코드 *
        public string ITEM_NAME { get; set; }
        public string FCLTS_CODE { get; set; } //작업장코드 *
        public string FCLTS_Name { get; set; }
        public string ITEM_STND { get; set; }
    }

    public class WORKORDERInsert_VO
    {
        public string WO_Code { get; set; } //작업지시번호 
        public string ITEM_CODE { get; set; } //품목코드 *
        public string FCLTS_CODE { get; set; } //작업장코드 *
        public string WO_PLAN_DATE { get; set; } //계획날짜 *
        //public string WO_WORK_STATE { get; set; } //작업지시상태 *
        public string WO_PLAN_STARTTIME { get; set; } //계획실제시작일
        public string WO_PLAN_ENDTIME { get; set; } //계획실제종료일
        public int WO_PLAN_QTY { get; set; } //계획수량(지시량) *
        public int WO_WORK_SEQ { get; set; } //작업순서 *
        public string WO_LAST_MDFR { get; set; } //최종수정자
        public string WO_LAST_MDFY { get; set; } //최종수정일자
        public string SALES_WORK_ORDER_ID { get; set; } //작업지시서번호
        public string PLAN_ID { get; set; } //계획ID
        public string WO_REMARK { get; set; } //비고
    }


    public class WORKORDERSearch_VO
    {
        public string WO_PLAN_STARTTIME { get; set; }
        public string WO_PLAN_DATE { get; set; }
        public string FCLTS_CODE { get; set; } //작업장코드 *
        public string FCLTS_Name { get; set; }
        public int WO_WORK_SEQ { get; set; }
        public string WO_WORK_STATE { get; set; } //작업지시상태 *
        public string ITEM_CODE { get; set; } //품목코드 *
        public string ITEM_NAME { get; set; }
        public string FCLTS_WRHS_EXHST { get; set; }
        public string FCLTS_WRHS_GOOD { get; set; }
        public string FCLTS_WRHS_BAD { get; set; }
        public int WO_PLAN_QTY { get; set; }
        public int WO_QTY_GOOD { get; set; }
        public int WO_QTY_BAD { get; set; }
        public string WO_Code { get; set; } //작업지시번호
    }

}
