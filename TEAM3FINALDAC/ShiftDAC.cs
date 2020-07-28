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
        public Message SaveShiftInfo(SHIFT_VO vo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_SaveShift";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@P_SHIFT_CODE", 0);
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


                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();

                    string result = cmd.Parameters["@P_ReturnCode"].Value.ToString();

                    Message message = new Message();
                    if (result == "S001")
                    {
                        message.IsSuccess = true;
                        message.ResultMessage = "성공적으로 등록되었습니다.";
                    }
                    else if (result == "S002")
                    {
                        message.IsSuccess = true;
                        message.ResultMessage = "성공적으로 수정되었습니다.";
                    }
                    else if (result == "S003")
                    {
                        message.IsSuccess = false;
                        message.ResultMessage = "이미 등록된 ID 입니다.";
                    }

                    return message;

                }
            }
            catch (Exception err)
            {
                return new Message(err);
            }
            
        }

        public List<SHIFTList_VO> GetAllShiftList()
        {
            List<SHIFTList_VO> list = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    AESSalt salt = new AESSalt();
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select  
                                        ROW_NUMBER() OVER (ORDER BY SHIFT_CODE) AS 'idx'
                                        ,f.FCLTS_CODE
                                        ,FCLTS_NAME
                                        ,SHIFT_CODE
                                        , SHIFT_STARTTIME
                                        , SHIFT_ENDTIME
                                        , SHIFT_APPLY_STARTTIME
                                        , SHIFT_APPLY_ENDTIME
                                        , SHIFT_PERSON_DIR
                                        , SHIFT_USE_YN
                                        , SHIFT_LAST_MDFR
                                        , SHIFT_LAST_MDFY
                                        , SHIFT_REMARK
                                        , SHIFT_TYP
                                        from dbo.FACILITY f, [SHIFT] s
                                        ";

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
    }
}
