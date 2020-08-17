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
    public class WorkOrderINDAC : ConnectionAccess
    {
        public List<WORKORDERCREATE_VO> GetWorkList()
        {
            List<WORKORDERCREATE_VO> list = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select w.ITEM_CODE, i.ITEM_NAME, i.ITEM_STND, w.WO_WORK_STATE , w.FCLTS_CODE,f.FCLTS_NAME
                                                        ,w.WO_PLAN_QTY,w.WO_PLAN_QTY WO_QTY_PROD
                                                        , convert(nvarchar, w.WO_PLAN_STARTTIME, 23) WO_PLAN_STARTTIME
                                                        , (r.BOR_PROCS_TIME*w.WO_PLAN_QTY)/60 Tacminute
                                                        , convert(nvarchar, w.WO_PLAN_ENDTIME, 23) WO_PLAN_ENDTIME
                                                        ,w.WO_Code
                                                        from WORKORDER w inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
				                                                         inner join FACILITY f on f.FCLTS_CODE = w.FCLTS_CODE
				                                                         left outer join BOR r on r.ITEM_CODE = w.ITEM_CODE
																		 where WO_WORK_STATE in ('작업생성','작업지시','작업취소')";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<WORKORDERCREATE_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                return list;
            }
            return list;

        }

        public List<WORKORDERSearch_VO> GetWorkOrderList()
        {
            List<WORKORDERSearch_VO> list = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select 
                                        convert(nvarchar, w.WO_PLAN_STARTTIME, 23) WO_PLAN_STARTTIME
                                        ,convert(nvarchar, w.WO_PLAN_DATE, 23) WO_PLAN_DATE
                                        ,w.FCLTS_CODE
                                        ,f.FCLTS_NAME
                                        ,w.WO_WORK_SEQ
                                        ,w.WO_WORK_STATE
                                        ,w.ITEM_CODE
                                        ,i.ITEM_NAME
                                        ,isnull( (select FAC_NAME from Factory where FAC_CODE = f.FCLTS_WRHS_EXHST),'') FCLTS_WRHS_EXHST
                                        ,isnull( (select FAC_NAME from Factory where FAC_CODE = f.FCLTS_WRHS_GOOD),'') FCLTS_WRHS_GOOD
                                        ,isnull( (select FAC_NAME from Factory where FAC_CODE = f.FCLTS_WRHS_BAD) ,'') FCLTS_WRHS_BAD
                                        ,w.WO_PLAN_QTY
                                        ,(isnull(w.WO_QTY_IN,0) - isnull(w.WO_QTY_OUT,0)) WO_QTY_BAD
                                        ,(isnull(w.WO_QTY_PROD,0) - (isnull(w.WO_QTY_IN,0) - isnull(w.WO_QTY_OUT,0))) WO_QTY_GOOD
                                        ,w.WO_Code

                                        from WORKORDER w inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
                                                                 inner join FACILITY f on f.FCLTS_CODE = w.FCLTS_CODE
                                                                 left outer join BOR r on r.ITEM_CODE = w.ITEM_CODE

        				                                         where WO_WORK_STATE in ('작업생성','작업지시','작업취소','작업완료')
                                            ";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<WORKORDERSearch_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                return list;
            }
            return list;

        }

        public bool InsertWorkOrder(WORKORDERInsert_VO vo)
        {
            bool Result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"insert into [dbo].[WORKORDER]
            (WO_Code,ITEM_CODE,FCLTS_CODE,WO_PLAN_DATE,WO_WORK_STATE,WO_PLAN_STARTTIME,WO_PLAN_ENDTIME,WO_PLAN_QTY,WO_WORK_SEQ,WO_LAST_MDFR,WO_LAST_MDFY,SALES_WORK_ORDER_ID,PLAN_ID,WO_REMARK)
            values(@WO_Code,@ITEM_CODE,@FCLTS_CODE,@WO_PLAN_DATE,'작업생성',@WO_PLAN_STARTTIME,@WO_PLAN_ENDTIME,@WO_PLAN_QTY,@WO_WORK_SEQ,@WO_LAST_MDFR,@WO_LAST_MDFY,@SALES_WORK_ORDER_ID,@PLAN_ID,@WO_REMARK)
            ";
                    cmd.Parameters.AddWithValue("@WO_Code", vo.WO_Code);
                    cmd.Parameters.AddWithValue("@ITEM_CODE", vo.ITEM_CODE);
                    cmd.Parameters.AddWithValue("@FCLTS_CODE", vo.FCLTS_CODE);
                    cmd.Parameters.AddWithValue("@WO_PLAN_DATE", vo.WO_PLAN_DATE);
                    cmd.Parameters.AddWithValue("@WO_PLAN_STARTTIME", vo.WO_PLAN_STARTTIME);
                    cmd.Parameters.AddWithValue("@WO_PLAN_ENDTIME", vo.WO_PLAN_ENDTIME);
                    cmd.Parameters.AddWithValue("@WO_PLAN_QTY", vo.WO_PLAN_QTY);
                    cmd.Parameters.AddWithValue("@WO_WORK_SEQ", vo.WO_WORK_SEQ);
                    cmd.Parameters.AddWithValue("@WO_LAST_MDFR", vo.WO_LAST_MDFR);
                    cmd.Parameters.AddWithValue("@WO_LAST_MDFY", vo.WO_LAST_MDFY);
                    cmd.Parameters.AddWithValue("@SALES_WORK_ORDER_ID", vo.SALES_WORK_ORDER_ID);
                    cmd.Parameters.AddWithValue("@PLAN_ID", vo.PLAN_ID);
                    cmd.Parameters.AddWithValue("@WO_REMARK", vo.WO_REMARK);

                    cmd.Connection.Open();
                    int iResult = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return (iResult > 0) ? true : false;
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return Result;
            }
        }

        public bool DeleteWorkList(string list, string seperator)
        {
            int iResult = 0;
            try
            {
                string sql = "SP_DeleteWorkList";
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_ItemCodes", list);
                        cmd.Parameters.AddWithValue("@P_Seperator", seperator);
                        iResult = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception err)
            {
                iResult = 0;
            }
            return iResult > 0 ? true : false;

        }

        public bool UpdateWorkList(string list, string seperator)
        {
            int iResult = 0;
            try
            {
                string sql = "SP_UpdateWorkList";
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_ItemCodes", list);
                        cmd.Parameters.AddWithValue("@P_Seperator", seperator);
                        iResult = cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception err)
            {
                iResult = 0;
            }
            return iResult > 0 ? true : false;

        }

    }
}
