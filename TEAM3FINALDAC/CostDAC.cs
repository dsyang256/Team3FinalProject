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
    public class CostDAC : ConnectionAccess
    {
        /// <summary>
        /// 자재단가 항목을 가져오는 메서드
        /// </summary>
        /// <param name="mcCode"></param>
        /// <returns></returns>
        public MaterialCostList_VO GetMaterialCostInfo(string mcCode)
        {
            List<MaterialCostList_VO> list = default;

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
                    cmd.Parameters.AddWithValue("@MC_Code", mcCode);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<MaterialCostList_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return new MaterialCostList_VO();
            }
            return list[0];

        }
        /// <summary>
        /// 자재단가 목록을 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<MaterialCostList_VO> GetMaterialCostList()
        {
            List<MaterialCostList_VO> list = default;

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
inner join COMPANY C on c.COM_CODE = m.COM_Code";
                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<MaterialCostList_VO>(reader);
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
        /// 자재단가 저장 메서드
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public Message InsertOrUpdateMaterialCost(MaterialCost_VO vo)
        {
            try
            {
                string sql = "SP_SaveMaterialCost";
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_MC_Code", vo.MC_Code);
                        cmd.Parameters.AddWithValue("@P_MC_UNITPRICE_CUR",vo.MC_UNITPRICE_CUR );
                        cmd.Parameters.AddWithValue("@P_MC_UNITPRICE_EX", vo.MC_UNITPRICE_EX);
                        cmd.Parameters.AddWithValue("@P_MC_STARTDATE", vo.MC_STARTDATE);
                        cmd.Parameters.AddWithValue("@P_MC_ENDDATE", vo.MC_ENDDATE);
                        cmd.Parameters.AddWithValue("@P_MC_LAST_MDFR", vo.MC_LAST_MDFR);
                        cmd.Parameters.AddWithValue("@P_MC_LAST_MDFY", vo.MC_LAST_MDFY);
                        cmd.Parameters.AddWithValue("@P_MC_USE_YN", vo.MC_USE_YN);
                        cmd.Parameters.AddWithValue("@P_MC_REMARK", vo.MC_REMARK);
                        cmd.Parameters.AddWithValue("@P_COM_Code",vo.COM_Code );
                        cmd.Parameters.AddWithValue("@P_ITEM_Code", vo.ITEM_Code);


                        cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", System.Data.SqlDbType.NVarChar, 5));
                        cmd.Parameters["@P_ReturnCode"].Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        string result = cmd.Parameters["@P_ReturnCode"].Value.ToString();

                        Message message = new Message();
                        if (result == "M01")
                        {
                            message.IsSuccess = true;
                            message.ResultMessage = "성공적으로 등록되었습니다.";
                        }
                        else if (result == "M02")
                        {
                            message.IsSuccess = true;
                            message.ResultMessage = "성공적으로 수정되었습니다.";
                        }
                        else if (result == "M03")
                        {
                            message.IsSuccess = false;
                            message.ResultMessage = "시작일 날짜는 이전 시작날짜보다 작을 수 없습니다.";
                        }
                        else if (result == "M00")
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
        /// 자재단가 삭제 메서드
        /// </summary>
        /// <param name="list"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public bool DeleteMaterialCostList(string list, string seperator)
        {
            int iResult = 0;
            try
            {
                string sql = "SP_DeleteMaterialCostList";
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_ItemCodes",list);
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


        /// <summary>
        /// 영업단가 항목을 가져오는 메서드
        /// </summary>
        /// <param name="scCode"></param>
        /// <returns></returns>
        public SalesCostList_VO GetSalesCostInfo(string scCode)
        {
            List<SalesCostList_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select
                                                     [SC_Code]
                                                    ,C.[COM_Code]
                                                    ,C.[COM_NAME]
                                                    , I.[ITEM_Code]
                                                    , I.ITEM_NAME
                                                    ,I.ITEM_STND
                                                    ,I.ITEM_UNIT
                                                    , [SC_UNITPRICE_CUR]
                                                    , [SC_UNITPRICE_EX]
                                                    ,CONVERT(CHAR(10), [SC_STARTDATE], 23) [SC_STARTDATE]
                                                    ,CONVERT(CHAR(10), [SC_ENDDATE], 23) [SC_ENDDATE]
                                                    , [SC_REMARK]
                                                    , [SC_USE_YN]

                                                    from [dbo].[SALES_COST] M inner join ITEM I on m.ITEM_Code = i.ITEM_CODE
                                                    inner join COMPANY C on c.COM_CODE = m.COM_Code
                                                    where SC_Code=@SC_Code";
                    cmd.Parameters.AddWithValue("@SC_Code", scCode);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<SalesCostList_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return new SalesCostList_VO();
            }
            return list[0];

        }
        /// <summary>
        /// 영업단가 목록을 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<SalesCostList_VO> GetSalesCostList()
        {
            List<SalesCostList_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select
                                                     [SC_Code]
                                                    ,C.[COM_Code]
                                                    ,C.[COM_NAME]
                                                    , I.[ITEM_Code]
                                                    , I.ITEM_NAME
                                                    ,I.ITEM_STND
                                                    ,I.ITEM_UNIT
                                                    , [SC_UNITPRICE_CUR]
                                                    , [SC_UNITPRICE_EX]
                                                    ,CONVERT(CHAR(10), [SC_STARTDATE], 23) [SC_STARTDATE]
                                                    ,CONVERT(CHAR(10), [SC_ENDDATE], 23) [SC_ENDDATE]
                                                    , [SC_REMARK]
                                                    , [SC_USE_YN]

                                                    from [dbo].[SALES_COST] M inner join ITEM I on m.ITEM_Code = i.ITEM_CODE
                                                    inner join COMPANY C on c.COM_CODE = m.COM_Code";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<SalesCostList_VO>(reader);
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
        /// 영업단가 저장 메서드
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public Message InsertOrUpdateSalesCost(SalesCost_VO vo)
        {
            try
            {
                string sql = "SP_SaveSalesCost";
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_SC_Code", vo.SC_CODE);
                        cmd.Parameters.AddWithValue("@P_SC_UNITPRICE_CUR", vo.SC_UNITPRICE_CUR);
                        cmd.Parameters.AddWithValue("@P_SC_UNITPRICE_EX", vo.SC_UNITPRICE_EX);
                        cmd.Parameters.AddWithValue("@P_SC_STARTDATE", vo.SC_STARTDATE);
                        cmd.Parameters.AddWithValue("@P_SC_ENDDATE", vo.SC_ENDDATE);
                        cmd.Parameters.AddWithValue("@P_SC_LAST_MDFR", vo.SC_LAST_MDFR);
                        cmd.Parameters.AddWithValue("@P_SC_LAST_MDFY", vo.SC_LAST_MDFY);
                        cmd.Parameters.AddWithValue("@P_SC_USE_YN", vo.SC_USE_YN);
                        cmd.Parameters.AddWithValue("@P_SC_REMARK", vo.SC_REMARK);
                        cmd.Parameters.AddWithValue("@P_COM_Code", vo.COM_Code);
                        cmd.Parameters.AddWithValue("@P_ITEM_Code", vo.ITEM_Code);


                        cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", System.Data.SqlDbType.NVarChar, 5));
                        cmd.Parameters["@P_ReturnCode"].Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        string result = cmd.Parameters["@P_ReturnCode"].Value.ToString();

                        Message message = new Message();
                        if (result == "M01")
                        {
                            message.IsSuccess = true;
                            message.ResultMessage = "성공적으로 등록되었습니다.";
                        }
                        else if (result == "M02")
                        {
                            message.IsSuccess = true;
                            message.ResultMessage = "성공적으로 수정되었습니다.";
                        }
                        else if (result == "M03")
                        {
                            message.IsSuccess = false;
                            message.ResultMessage = "시작일 날짜는 이전 시작날짜보다 작을 수 없습니다.";
                        }
                        else if (result == "M00")
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
        /// 영업단가 삭제 메서드
        /// </summary>
        /// <param name="list"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public bool DeleteSalesCostList(string list, string seperator)
        {
            int iResult = 0;
            try
            {
                string sql = "SP_DeleteSalesCostList";
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
