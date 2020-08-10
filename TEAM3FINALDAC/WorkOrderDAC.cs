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
        #region 작업실적등록
        public List<WORKORDER_VO> GetMOVEList()
        {
            List<WORKORDER_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select convert(nvarchar, WO_PLAN_DATE, 23) WO_PLAN_DATE, convert(nvarchar, WO_PROD_DATE, 23) WO_PROD_DATE, w.FCLTS_CODE, f.FCLTS_NAME, WO_WORK_SEQ, w.ITEM_CODE, i.ITEM_NAME, WO_WORK_STATE, f.FCLTS_WRHS_GOOD, f.FCLTS_WRHS_BAD, WO_PLAN_QTY, s.SALES_NO_QTY, WO_QTY_OUT, 
WO_QTY_IN, SUM(WO_QTY_IN - WO_QTY_OUT) as WO_QTY_BAD, SUM(WO_PLAN_QTY - s.SALES_NO_QTY - WO_QTY_OUT) as WO_QTY, sum(WO_QTY_OUT + WO_QTY_IN - WO_QTY_OUT) as WO_QTY_PROD, convert(nvarchar, WO_PLAN_STARTTIME, 23) WO_PLAN_STARTTIME, 
convert(nvarchar, WO_PLAN_ENDTIME, 23) WO_PLAN_ENDTIME, WO_REMARK, WO_LAST_MDFR, convert(nvarchar, WO_LAST_MDFY, 120) WO_LAST_MDFY, w.SALES_WORK_ORDER_ID, PLAN_ID, WO_Code, i.ITEM_TYP
from WORKORDER w inner join FACILITY f on w.FCLTS_CODE = f.FCLTS_CODE
				 inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
				 inner join SALES_WORK s on w.SALES_WORK_ORDER_ID = s.SALES_Work_Order_ID
where 1=1 and WO_WORK_STATE <> '실적등록' and WO_WORK_STATE <> '공정이동'
group by WO_PLAN_DATE, WO_PROD_DATE, w.FCLTS_CODE, f.FCLTS_NAME, WO_WORK_SEQ, w.ITEM_CODE, i.ITEM_NAME, WO_WORK_STATE, f.FCLTS_WRHS_GOOD, f.FCLTS_WRHS_BAD, WO_PLAN_QTY, s.SALES_NO_QTY, WO_QTY_OUT, WO_QTY_IN, WO_PLAN_STARTTIME, 
		 WO_PLAN_ENDTIME, WO_REMARK, WO_LAST_MDFR, WO_LAST_MDFY, w.SALES_WORK_ORDER_ID, PLAN_ID, WO_Code, i.ITEM_TYP";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<WORKORDER_VO>(reader);

                return list;
            }
        }        

        public Message InsertMoveUpdate(WORKORDER_VO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"insert into FACILITY_DETAIL(WO_Code, IN_QTY, FCLTS_CODE, WHOUSE_LAST_MDFR, ITEM_CODE) values(@WO_Code, @WO_QTY_OUT, @FCLTS_CODE, @WO_LAST_MDFR, @ITEM_CODE);
                                    update WORKORDER set WO_WORK_STATE = '공정이동' where WO_Code = @WO_Code;";
                cmd.Parameters.AddWithValue("@WO_Code", vo.WO_Code);
                cmd.Parameters.AddWithValue("@WO_QTY_OUT", vo.WO_QTY_OUT);
                cmd.Parameters.AddWithValue("@FCLTS_CODE", vo.FCLTS_CODE);
                cmd.Parameters.AddWithValue("@WO_LAST_MDFR", vo.WO_LAST_MDFR);
                cmd.Parameters.AddWithValue("@ITEM_CODE", vo.ITEM_CODE);
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
                    message.ResultMessage = "완료 되었습니다.";
                }
                else if (result == "S0")
                {
                    message.IsSuccess = true;
                    message.ResultMessage = "실패하였습니다.";
                }

                return message;
            }
        }

        public Message WorkMOVE(string code)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "update WORKORDER set WO_WORK_STATE = '실적등록' where WO_Code in (SELECT * FROM[dbo].[SplitString](@WO_Code, '@'))";
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

        public List<WorkMOVE_VO> GetWorkMOVEInfo()
        {
            List<WorkMOVE_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select w.ITEM_CODE, i.ITEM_NAME, i.ITEM_STND, w.FCLTS_CODE, f.FCLTS_NAME, w.WO_QTY_OUT, w.WO_REMARK, WO_Code, i.ITEM_TYP 
from WORKORDER w inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
				 inner join FACILITY f on w.FCLTS_CODE = f.FCLTS_CODE
where WO_WORK_STATE = '실적등록'";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<WorkMOVE_VO>(reader);

                return list;
            }
        }

        public Message WorkCancel(string code)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "update WORKORDER set WO_WORK_STATE = '작업취소' where WO_Code in (SELECT * FROM[dbo].[SplitString](@WO_Code, '@'))";
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

        #endregion

        #region 공정재고현황

        public List<MOVESTATE_VO> MOVEList()
        {
            List<MOVESTATE_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select f.FCLTS_CODE, FAC_NAME, f.ITEM_CODE, i.ITEM_NAME, i.ITEM_TYP, i.ITEM_STND, IN_QTY, i.ITEM_UNIT, WHOUSE_LAST_MDFR, convert(nvarchar, IN_DATE, 120) IN_DATE
                                    from FACILITY_DETAIL f inner join FACTORY fa on f.FCLTS_CODE = fa.FAC_CODE
					                                       inner join ITEM i on f.ITEM_CODE = i.ITEM_CODE";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<MOVESTATE_VO>(reader);
                return list;
            }
        }

        public List<MOVESTATE_VO> SearchMOVELIST(string wHouse, string type, string itemCode)
        {
            List<MOVESTATE_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SearchMOVESTATE";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_FCLTS_CODE", wHouse);
                cmd.Parameters.AddWithValue("@P_ITEM_TYP", type);
                cmd.Parameters.AddWithValue("@P_ITEM_CODE", itemCode);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<MOVESTATE_VO>(reader);
                return list;
            }
        }

        #endregion
    }
}
