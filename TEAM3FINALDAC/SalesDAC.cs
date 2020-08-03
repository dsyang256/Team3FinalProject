using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //참조
using System.Data.SqlClient;
using TEAM3FINALVO;

namespace TEAM3FINALDAC
{
   public class SalesDAC : ConnectionAccess
    {
        /// <summary>
        /// W/O 항목을 가져오는 메서드
        /// </summary>
        /// <param name="salesID"></param>
        /// <returns></returns>
        public SALES_WORK_VO GetSalesWorkInfo(string salesID)
        {
            List<SALES_WORK_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select
                                  [MC_Code]
                                 ,C.[COM_Code]
                                 ,C.[COM_NAME]
                                 , I.[ITEM_Code]
                                 , I.ITEM_NAME
                                 ,I.ITEM_STND
                                 ,I.ITEM_UNIT
                                 , [MC_UNITPRICE_CUR]
                                 , [MC_UNITPRICE_EX]
                                 ,CONVERT(CHAR(10), [MC_STARTDATE], 23) [MC_STARTDATE]
                                 ,CONVERT(CHAR(10), [MC_ENDDATE], 23) [MC_ENDDATE]
                                 , [MC_REMARK]
                                 , [MC_USE_YN]

                                 from [dbo].[MATERIAL_COST] M inner join ITEM I on m.ITEM_Code = i.ITEM_CODE
                                 inner join COMPANY C on c.COM_CODE = m.COM_Code
                                 where MC_Code=@MC_Code";
                    cmd.Parameters.AddWithValue("@MC_Code", salesID);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<SALES_WORK_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return new SALES_WORK_VO();
            }
            return list[0];
        }

        /// <summary>
        /// W/O 목록을 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<SALESWorkList_VO> GetSalesWorkList()
        {
            List<SALESWorkList_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select SALES_ID 
                                    , SALES_Work_Order_ID 
                                    , SO_PurchaseOrder
                                    , s.COM_CODE 
                                    , c.COM_NAME
                                    , SALES_COM_CODE
                                    , (select COM_NAME from COMPANY where COM_CODE =SALES_COM_CODE) SALES_COM_NAME
                                    ,SALES_Order_TYPE
                                    ,s.ITEM_CODE
                                    ,i.ITEM_NAME
                                    ,CONVERT(CHAR(10), SALES_DUEDATE, 23) SALES_DUEDATE 
                                    , SALES_QTY
                                    , SALES_Out_QTY
                                    , SALES_NO_QTY
                                     ,SALES_ORDER_STATE

                                    from SALES_WORK s inner join COMPANY c on s.COM_CODE = c.COM_CODE
                                    inner join ITEM i on i.ITEM_CODE = s.ITEM_CODE
                                    where i.ITEM_USE_YN<>'미사용'";
                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<SALESWorkList_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;


        }

        /// <summary>
        /// W/O 저장 메서드
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public Message InsertOrUpdateSalesWork(SALES_WORK_VO vo)
        {
            try
            {
                string sql = "SP_SaveSalesWork";
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_SALES_ID", vo.SALES_ID);
                        cmd.Parameters.AddWithValue("@P_SALES_Work_Order_ID", vo.SALES_Work_Order_ID);
                        cmd.Parameters.AddWithValue("@P_SALES_Out_QTY", vo.SALES_Out_QTY);
                        cmd.Parameters.AddWithValue("@P_SALES_MKT", vo.SALES_MKT);
                        cmd.Parameters.AddWithValue("@P_SALES_DUEDATE", vo.SALES_DUEDATE);
                        cmd.Parameters.AddWithValue("@P_SALES_QTY", vo.SALES_QTY);
                        cmd.Parameters.AddWithValue("@P_SALES_NO_QTY", vo.SALES_NO_QTY);
                        cmd.Parameters.AddWithValue("@P_SALES_Order_TYPE", vo.SALES_Order_TYPE);
                        cmd.Parameters.AddWithValue("@P_SALES_COM_CODE", vo.SALES_COM_CODE);
                        cmd.Parameters.AddWithValue("@P_SALES_REMARK", vo.SALES_REMARK);
                        cmd.Parameters.AddWithValue("@P_COM_CODE", vo.COM_CODE);
                        cmd.Parameters.AddWithValue("@P_ITEM_CODE", vo.ITEM_CODE);
                        cmd.Parameters.AddWithValue("@P_SO_PurchaseOrder", vo.SO_PurchaseOrder);


                        cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", System.Data.SqlDbType.NVarChar, 5));
                        cmd.Parameters["@P_ReturnCode"].Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        string result = cmd.Parameters["@P_ReturnCode"].Value.ToString();

                        Message message = new Message();
                        if (result == "S01")
                        {
                            message.IsSuccess = true;
                            message.ResultMessage = "성공적으로 등록되었습니다.";
                        }
                        else if (result == "S02")
                        {
                            message.IsSuccess = true;
                            message.ResultMessage = "성공적으로 수정되었습니다.";
                        }
                        else if (result == "S03")
                        {
                            message.IsSuccess = false;
                            message.ResultMessage = "이미 존재하는 W/O입니다.";
                        }
                        else if (result == "S00")
                        {
                            message.IsSuccess = false;
                            message.ResultMessage = "잘못된 실행입니다.";
                        }

                        return message;
                    }
                }
            }
            catch (Exception err)
            {
                return new Message(err);
            }
        }
        /// <summary>
        /// W/O 삭제 메서드
        /// </summary>
        /// <param name="list"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public bool DeleteSalesWorkList(string list, string seperator)
        {
            int iResult = 0;
            try
            {
                string sql = "SP_DeleteSalesWorkList";
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
