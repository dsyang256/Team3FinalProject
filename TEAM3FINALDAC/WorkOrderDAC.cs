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
where 1=1 and WO_WORK_STATE <> '실적등록' and WO_WORK_STATE <> '공정이동' and WO_WORK_STATE <> '제품이동' and WO_WORK_STATE <> '마감중' and WO_WORK_STATE <> '마감완료' and WO_WORK_STATE <> '판매완료'
group by WO_PLAN_DATE, WO_PROD_DATE, w.FCLTS_CODE, f.FCLTS_NAME, WO_WORK_SEQ, w.ITEM_CODE, i.ITEM_NAME, WO_WORK_STATE, f.FCLTS_WRHS_GOOD, f.FCLTS_WRHS_BAD, WO_PLAN_QTY, s.SALES_NO_QTY, WO_QTY_OUT, WO_QTY_IN, WO_PLAN_STARTTIME, 
		 WO_PLAN_ENDTIME, WO_REMARK, WO_LAST_MDFR, WO_LAST_MDFY, w.SALES_WORK_ORDER_ID, PLAN_ID, WO_Code, i.ITEM_TYP";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<WORKORDER_VO>(reader);

                return list;
            }
        }
        

        public Message InsertMoveUpdate(INSTACK_VO vo)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"insert into INSTACK(INS_QTY, INS_TYP, INS_WRHS, ITEM_CODE, SALES_WORK_ORDER_ID) values(@INS_QTY, '출고', @INS_WRHS, @ITEM_CODE, @SALES_WORK_ORDER_ID);
                                    insert into INSTACK(INS_QTY, INS_TYP, INS_WRHS, ITEM_CODE, SALES_WORK_ORDER_ID) values(@INS_QTY, '입고', @INS_WRHS, @ITEM_CODE, @SALES_WORK_ORDER_ID);
                                    update WORKORDER set WO_WORK_STATE = '공정이동' where SALES_Work_Order_ID = @SALES_WORK_ORDER_ID;";
                cmd.Parameters.AddWithValue("@INS_QTY", vo.INS_QTY);
                cmd.Parameters.AddWithValue("@INS_WRHS", vo.INS_WRHS);
                cmd.Parameters.AddWithValue("@ITEM_CODE", vo.ITEM_CODE);
                cmd.Parameters.AddWithValue("@SALES_WORK_ORDER_ID", vo.SALES_WORK_ORDER_ID);
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
                cmd.CommandText = @"select w.ITEM_CODE, i.ITEM_NAME, i.ITEM_STND, w.FCLTS_CODE, f.FCLTS_NAME, w.WO_QTY_OUT, w.WO_REMARK, SALES_WORK_ORDER_ID, i.ITEM_TYP 
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
                cmd.CommandText = @"select i.INS_WRHS, FAC_NAME, i.ITEM_CODE, it.ITEM_NAME, it.ITEM_TYP, it.ITEM_STND, it.ITEM_UNIT, INS_QTY
                                      from (select i.INS_WRHS, i.ITEM_CODE, 
	                                               sum(case when INS_TYP = '출고' then (INS_QTY*-1) when INS_TYP = '입고' then INS_QTY end) INS_QTY
	                                          from INSTACK i
	                                        group by i.INS_WRHS, i.ITEM_CODE) i inner join FACTORY f on i.INS_WRHS = f.FAC_CODE
		  	   									                           	   inner join item it on i.ITEM_CODE = it.ITEM_CODE
                                     where 1=1 
                                    group by i.INS_WRHS, FAC_NAME, i.ITEM_CODE, it.ITEM_NAME, it.ITEM_TYP, it.ITEM_STND, INS_QTY, it.ITEM_UNIT";
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


        #region 고객주문별현황

        public List<OrderState_VO> OrderList()
        {
            List<OrderState_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select w.ITEM_CODE, i.ITEM_NAME, i.ITEM_STND, fa.FAC_CODE, fa.FAC_NAME, w.WO_QTY_OUT, w.WO_REMARK, SALES_WORK_ORDER_ID, i.ITEM_TYP , ('제품창고') ToWHouse
                                    from WORKORDER w inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
				                                     inner join FACILITY f on w.FCLTS_CODE = f.FCLTS_CODE
													 inner join FACTORY fa on f.FCLTS_WRHS_EXHST = fa.FAC_CODE
                                    where WO_WORK_STATE = '공정이동' and i.ITEM_TYP = '제품' and WO_WORK_STATE <> '작업완료'";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<OrderState_VO>(reader);
                return list;
            }
        }

        public Message OrderMoveFac(OrderState_VO vo)
        {
            List<WorkMOVE_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"insert into INSTACK(INS_QTY, INS_TYP, INS_WRHS, ITEM_CODE, SALES_WORK_ORDER_ID) values(@INS_QTY, '출고', @INS_WRHS, @ITEM_CODE, @SALES_WORK_ORDER_ID);
                                    insert into INSTACK(INS_QTY, INS_TYP, INS_WRHS, ITEM_CODE, SALES_WORK_ORDER_ID) values(@INS_QTY, '입고', 'M_01', @ITEM_CODE, @SALES_WORK_ORDER_ID);
                                    update WORKORDER set WO_WORK_STATE = '제품이동' where SALES_WORK_ORDER_ID = @SALES_WORK_ORDER_ID;";
                cmd.Parameters.AddWithValue("@INS_QTY", vo.WO_QTY_OUT);
                cmd.Parameters.AddWithValue("@INS_WRHS", vo.FAC_CODE);
                cmd.Parameters.AddWithValue("@ITEM_CODE", vo.ITEM_CODE);
                cmd.Parameters.AddWithValue("@SALES_WORK_ORDER_ID", vo.SALES_WORK_ORDER_ID);
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
        
        public List<WorkMOVE_VO> SearchOrderState(string fromDATE, string fromTO, string code)
        {
            List<WorkMOVE_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SearchOrderState";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_FromDate", fromDATE);
                cmd.Parameters.AddWithValue("@P_ToDate", fromTO);
                cmd.Parameters.AddWithValue("@P_ITEM_CODE", code);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<WorkMOVE_VO>(reader);
                return list;
            }
        }

        #endregion
    }
}
