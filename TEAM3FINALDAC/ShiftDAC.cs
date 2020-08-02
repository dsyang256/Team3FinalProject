using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cryptography;
using TEAM3FINALVO;

namespace TEAM3FINALDAC
{
    public class ShiftDAC : ConnectionAccess
    { 
        /// <summary>
        /// Shift 목록 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<SHIFTList_VO> GetShiftList()
        {
            List<SHIFTList_VO> list = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    AESSalt salt = new AESSalt();
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select  
                                        f.FCLTS_CODE
                                        ,FCLTS_NAME
                                        ,SHIFT_CODE
                                        , SHIFT_STARTTIME
                                        , SHIFT_ENDTIME
                                        , CONVERT(CHAR(10), [SHIFT_APPLY_STARTTIME], 23) SHIFT_APPLY_STARTTIME
                                        ,CONVERT(CHAR(10), [SHIFT_APPLY_ENDTIME], 23)  SHIFT_APPLY_ENDTIME
                                        , SHIFT_PERSON_DIR
                                        , SHIFT_USE_YN
                                        , SHIFT_REMARK
                                        , SHIFT_TYP
                                        from dbo.FACILITY f inner join [SHIFT] s on f.FCLTS_CODE = s.FCLTS_CODE ";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<SHIFTList_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                return  list;
            }
            return list;
        }
        /// <summary>
        /// Shift 항목을 가져오는 메서드
        /// </summary>
        /// <param name="shiftCode"></param>
        /// <returns></returns>
        public SHIFTList_VO GetShiftInfo(string shiftCode)
        {
            List<SHIFTList_VO> list = default;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select  
                                        f.FCLTS_CODE
                                        ,FCLTS_NAME
                                        ,SHIFT_CODE
                                        , SHIFT_STARTTIME
                                        , SHIFT_ENDTIME
                                        , CONVERT(CHAR(10), [SHIFT_APPLY_STARTTIME], 23) SHIFT_APPLY_STARTTIME
                                        ,CONVERT(CHAR(10), [SHIFT_APPLY_ENDTIME], 23)  SHIFT_APPLY_ENDTIME
                                        , SHIFT_PERSON_DIR
                                        , SHIFT_USE_YN
                                        , SHIFT_REMARK
                                        , SHIFT_TYP
                                        from dbo.FACILITY f inner join [SHIFT] s on f.FCLTS_CODE = s.FCLTS_CODE
                                        where SHIFT_CODE=@SHIFT_CODE";
                    cmd.Parameters.AddWithValue("@SHIFT_CODE", shiftCode);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<SHIFTList_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return new SHIFTList_VO();
            }
            return list[0];
        }
        /// <summary>
        /// Shift 저장 메서드
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public Message InsertOrUpdateShift(SHIFT_VO vo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_SaveShift";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@P_SHIFT_CODE", vo.SHIFT_CODE);
                    cmd.Parameters.AddWithValue("@P_SHIFT_STARTTIME", vo.SHIFT_STARTTIME);
                    cmd.Parameters.AddWithValue("@P_SHIFT_ENDTIME", vo.SHIFT_ENDTIME);
                    cmd.Parameters.AddWithValue("@P_SHIFT_APPLY_STARTTIME", vo.SHIFT_APPLY_STARTTIME);
                    cmd.Parameters.AddWithValue("@P_SHIFT_APPLY_ENDTIME", vo.SHIFT_APPLY_ENDTIME);
                    cmd.Parameters.AddWithValue("@P_SHIFT_PERSON_DIR", vo.SHIFT_PERSON_DIR);
                    cmd.Parameters.AddWithValue("@P_SHIFT_USE_YN", vo.SHIFT_USE_YN);
                    cmd.Parameters.AddWithValue("@P_SHIFT_LAST_MDFR", vo.SHIFT_LAST_MDFR);
                    cmd.Parameters.AddWithValue("@P_SHIFT_LAST_MDFY", vo.SHIFT_LAST_MDFY);
                    cmd.Parameters.AddWithValue("@P_SHIFT_REMARK", vo.SHIFT_REMARK);
                    cmd.Parameters.AddWithValue("@P_FCLTS_CODE", vo.FCLTS_CODE);
                    cmd.Parameters.AddWithValue("@P_SHIFT_TYP", vo.SHIFT_TYP);
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
                    else if (result == "S02")
                    {
                        message.IsSuccess = true;
                        message.ResultMessage = "성공적으로 수정되었습니다.";
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
        /// <summary>
        /// Shift 삭제 메서드
        /// </summary>
        /// <param name="list"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        public bool DeleteShiftList(string list, string seperator)
        {
            int iResult = 0;
            try
            {
                string sql = "SP_DeleteShiftList";
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
