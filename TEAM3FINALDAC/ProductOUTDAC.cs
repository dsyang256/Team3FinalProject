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
    public class ProductOUTDAC : ConnectionAccess
    {

        #region 제품출하

        public List<ProductOUT_VO> GetProductOUTList()
        {
            List<ProductOUT_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select w.SALES_WORK_ORDER_ID, s.COM_CODE, c.COM_NAME, s.SALES_COM_CODE, w.ITEM_CODE, i.ITEM_NAME, convert(nvarchar, s.SALES_DUEDATE, 23) SALES_DUEDATE, w.WO_PLAN_QTY, 
	                                       sum(case when INS_TYP = '출고' then (INS_QTY*-1) when INS_TYP = '입고' then INS_QTY end) INS_QTY,
	                                       (select isnull(sum(case when INS_TYP = '출고' then INS_QTY end), 0)
		                                    from INSTACK 
                                            where SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = ii.INS_WRHS) as OUTed_QTY, (0) OUTing_QTY
                                    from WORKORDER w inner join SALES_WORK s on w.SALES_WORK_ORDER_ID = s.SALES_Work_Order_ID
				                                     inner join COMPANY c on s.COM_CODE = c.COM_CODE
				                                     inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
				                                     inner join INSTACK ii on w.ITEM_CODE = ii.ITEM_CODE
                                    where INS_WRHS = 'M_01' and (w.WO_WORK_STATE = '제품등록' or w.WO_WORK_STATE = '마감중')
                                    group by w.SALES_WORK_ORDER_ID, s.COM_CODE, c.COM_NAME, s.SALES_COM_CODE, w.ITEM_CODE, i.ITEM_NAME, s.SALES_DUEDATE, w.WO_PLAN_QTY, ii.INS_WRHS";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<ProductOUT_VO>(reader);
                return list;
            }
        }


        public List<ProductOUT_VO> SearchProductOUT(string id, string item, string company)
        {
            List<ProductOUT_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SearchProductOUT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_SALES_WORK_ORDER_ID", id);
                cmd.Parameters.AddWithValue("@P_ITEM_CODE", item);
                cmd.Parameters.AddWithValue("@P_SALES_COM_CODE", company);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<ProductOUT_VO>(reader);
                return list;
            }
        }

        public Message ProductOUT(ProductOUT_VO vo, string id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ProductOUT";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_SALES_WORK_ORDER_ID", vo.SALES_WORK_ORDER_ID);
                    cmd.Parameters.AddWithValue("@P_SALES_COM_CODE", vo.SALES_COM_CODE);
                    cmd.Parameters.AddWithValue("@P_ITEM_CODE", vo.ITEM_CODE);
                    cmd.Parameters.AddWithValue("@P_WO_PLAN_QTY", vo.WO_PLAN_QTY);
                    cmd.Parameters.AddWithValue("@P_INS_QTY", vo.INS_QTY);
                    cmd.Parameters.AddWithValue("@P_OUTed_QTY", vo.OUTed_QTY);
                    cmd.Parameters.AddWithValue("@P_OUTing_QTY", vo.OUTing_QTY);
                    cmd.Parameters.AddWithValue("@P_WO_LAST_MDFR", id);
                    cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", System.Data.SqlDbType.NVarChar, 5));
                    cmd.Parameters["@P_ReturnCode"].Direction = System.Data.ParameterDirection.Output;

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    string result = cmd.Parameters["@P_ReturnCode"].Value.ToString();

                    Message message = new Message();
                    if (result == "S01")
                    {
                        message.IsSuccess = true;
                        message.ResultMessage = "성공적으로 등록되었습니다.";
                    }                 
                    else if (result == "S00")
                    {
                        message.IsSuccess = false;
                        message.ResultMessage = "실패하였습니다.";
                    }

                    return message;
                }

            }
            catch(Exception err)
            {
                return new Message(err);
            }
        }

        #endregion


        #region 출하현황

        public List<ProductOUT_VO> GetProductOUTStateList()
        {
            List<ProductOUT_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select w.SALES_WORK_ORDER_ID, s.COM_CODE, c.COM_NAME, s.SALES_COM_CODE, w.ITEM_CODE, i.ITEM_NAME, convert(nvarchar, s.SALES_DUEDATE, 23) SALES_DUEDATE, w.WO_PLAN_QTY, 
	                                       sum(case when INS_TYP = '출고' then (INS_QTY*-1) when INS_TYP = '입고' then INS_QTY end) INS_QTY,
	                                       (select isnull(sum(case when INS_TYP = '출고' then INS_QTY end), 0)
		                                    from INSTACK 
                                            where SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = ii.INS_WRHS) as OUTed_QTY, (0) OUTing_QTY
                                    from WORKORDER w inner join SALES_WORK s on w.SALES_WORK_ORDER_ID = s.SALES_Work_Order_ID
				                                     inner join COMPANY c on s.COM_CODE = c.COM_CODE
				                                     inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
				                                     inner join INSTACK ii on w.ITEM_CODE = ii.ITEM_CODE
                                    where INS_WRHS = 'M_01' and (w.WO_WORK_STATE = '마감완료' or w.WO_WORK_STATE = '마감중')
                                    group by w.SALES_WORK_ORDER_ID, s.COM_CODE, c.COM_NAME, s.SALES_COM_CODE, w.ITEM_CODE, i.ITEM_NAME, s.SALES_DUEDATE, w.WO_PLAN_QTY, ii.INS_WRHS";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<ProductOUT_VO>(reader);
                return list;
            }
        }

        public Message ProductOUTCancel(ProductOUT_VO vo, string id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_ProductOUTState";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_SALES_WORK_ORDER_ID", vo.SALES_WORK_ORDER_ID);
                    cmd.Parameters.AddWithValue("@P_SALES_COM_CODE", vo.SALES_COM_CODE);
                    cmd.Parameters.AddWithValue("@P_ITEM_CODE", vo.ITEM_CODE);
                    cmd.Parameters.AddWithValue("@P_OUTed_QTY", vo.OUTed_QTY);
                    cmd.Parameters.AddWithValue("@P_WO_LAST_MDFR", id);
                    cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", System.Data.SqlDbType.NVarChar, 5));
                    cmd.Parameters["@P_ReturnCode"].Direction = System.Data.ParameterDirection.Output;

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    string result = cmd.Parameters["@P_ReturnCode"].Value.ToString();

                    Message message = new Message();
                    if (result == "S01")
                    {
                        message.IsSuccess = true;
                        message.ResultMessage = "성공하였습니다.";
                    }
                    else if (result == "S00")
                    {
                        message.IsSuccess = false;
                        message.ResultMessage = "실패하였습니다.";
                    }

                    return message;
                }

            }
            catch (Exception err)
            {
                return new Message(err);
            }
        }


        public List<ProductOUT_VO> SearchProductOUTState(string id, string item, string company)
        {
            List<ProductOUT_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SearchProductOUTState";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_SALES_WORK_ORDER_ID", id);
                cmd.Parameters.AddWithValue("@P_ITEM_CODE", item);
                cmd.Parameters.AddWithValue("@P_SALES_COM_CODE", company);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<ProductOUT_VO>(reader);
                return list;
            }
        }
        #endregion
    }
}
