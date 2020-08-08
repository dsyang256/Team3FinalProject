using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALVO;

namespace TEAM3FINALDAC
{
    public class WorkOrderDAC : ConnectionAccess
    {
        public List<WORKORDER_VO> GetWorkOrderInfo()
        {
            List<WORKORDER_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select convert(nvarchar, WO_PLAN_DATE, 23) WO_PLAN_DATE, convert(nvarchar, WO_PROD_DATE, 23) WO_PROD_DATE, w.FCLTS_CODE, f.FCLTS_NAME, WO_WORK_SEQ, w.ITEM_CODE, i.ITEM_NAME, WO_WORK_STATE, f.FCLTS_WRHS_GOOD, f.FCLTS_WRHS_BAD, WO_PLAN_QTY, s.SALES_NO_QTY, WO_QTY_OUT, 
WO_QTY_IN, SUM(WO_QTY_IN - WO_QTY_OUT) as WO_QTY_BAD, SUM(WO_PLAN_QTY - s.SALES_NO_QTY - WO_QTY_OUT) as WO_QTY, sum(WO_QTY_OUT + WO_QTY_IN - WO_QTY_OUT) as WO_QTY_PROD, convert(nvarchar, WO_PLAN_STARTTIME, 23) WO_PLAN_STARTTIME, 
convert(nvarchar, WO_PLAN_ENDTIME, 23) WO_PLAN_ENDTIME, WO_REMARK, WO_LAST_MDFR, convert(nvarchar, WO_LAST_MDFY, 120) WO_LAST_MDFY, w.SALES_WORK_ORDER_ID, PLAN_ID, WO_Code
from WORKORDER w inner join FACILITY f on w.FCLTS_CODE = f.FCLTS_CODE
				 inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
				 inner join SALES_WORK s on w.SALES_WORK_ORDER_ID = s.SALES_Work_Order_ID
where 1=1 and WO_WORK_STATE <> '실적등록'
group by WO_PLAN_DATE, WO_PROD_DATE, w.FCLTS_CODE, f.FCLTS_NAME, WO_WORK_SEQ, w.ITEM_CODE, i.ITEM_NAME, WO_WORK_STATE, f.FCLTS_WRHS_GOOD, f.FCLTS_WRHS_BAD, WO_PLAN_QTY, s.SALES_NO_QTY, WO_QTY_OUT, WO_QTY_IN, WO_PLAN_STARTTIME, 
		 WO_PLAN_ENDTIME, WO_REMARK, WO_LAST_MDFR, WO_LAST_MDFY, w.SALES_WORK_ORDER_ID, PLAN_ID, WO_Code";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<WORKORDER_VO>(reader);

                return list;
            }
        }

        public Message WorkCancel(string code)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "update WORKORDER set WO_WORK_STATE = '작업취소' where WO_Code = @WO_Code";
                cmd.Parameters.AddWithValue("@WO_Code", code);
                cmd.Connection.Open();
                int iResult = cmd.ExecuteNonQuery();
                string result;
                if (iResult > 0)
                    result = "S02";
                else
                    result = "S00";
                Message message = new Message();
                if (result == "S02")
                {
                    message.IsSuccess = true;
                    message.ResultMessage = "성공적으로 수정되었습니다.";
                }
                else if (result == "S0")
                {
                    message.IsSuccess = true;
                    message.ResultMessage = "실패하였습니다.";
                }

                return message;

            }
        }

        public List<WORKORDER_VO> SearchWORKORDER(string dateTYP, string fromDATE, string fromTO, string state)
        {
            List<WORKORDER_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SearchWORKORDER";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_DateType", dateTYP);
                cmd.Parameters.AddWithValue("@P_FromDATE", fromDATE);
                cmd.Parameters.AddWithValue("@P_ToDATE", fromTO);
                cmd.Parameters.AddWithValue("@P_State", state);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<WORKORDER_VO>(reader);
                return list;
            }
        }
    }
}
