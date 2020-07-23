using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TEAM3FINALVO;

namespace TEAM3FINALDAC
{
    public class LoginDAC : ConnectionAccess
    {
        public bool CheckIDExist(string userID)
        {
            int iCnt = default;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select COUNT(MANAGER_ID)
                                         from MANAGER
                                         where MANAGER_ID = @MANAGER_ID";
                    cmd.Parameters.AddWithValue("@MANAGER_ID", userID);
                    cmd.Connection.Open();
                    iCnt = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return iCnt > 0 ? true : false;
        }

        /// <summary>
        /// DB에서 로그인 ID와 비밀번호 확인하는 메서드
        /// </summary>
        /// <param name="userID">사용자ID</param>
        /// <param name="password">사용자 비밀번호</param>
        /// <returns></returns>
        public bool CheckLoginInfo(string userID, string password)
        {
            int iCnt = default;
            try
            {
                //using (SqlCommand cmd = new SqlCommand())
                //{
                //    cmd.Connection = new SqlConnection(this.ConnectionString);

                //    cmd.CommandText = $@"select COUNT(MANAGER_ID)
                //                                    from MANAGER
                //                                    where MANAGER_ID = @MANAGER_ID
                //                                    AND MANAGER_PSWD = @MANAGER_PSWD ";
                //    cmd.Parameters.AddWithValue("@MANAGER_ID", userID);
                //    cmd.Parameters.AddWithValue("@MANAGER_PSWD", password);

                //    cmd.Connection.Open();
                //    iCnt = Convert.ToInt32(cmd.ExecuteScalar());
                //    cmd.Connection.Close();
                // }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return iCnt > 0 ? true : false;
        }

        public Message InsertOrUpdateManager(MANAGER_VO mv)
        {
            try
            {
                string sql = "SaveUser";
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@P_MANAGER_ID", mv.MANAGER_ID);
                        cmd.Parameters.AddWithValue("@P_MANAGER_NAME", mv.MANAGER_NAME);
                        cmd.Parameters.AddWithValue("@P_MANAGER_PSWD", mv.MANAGER_PSWD);
                        cmd.Parameters.AddWithValue("@P_MANAGER_EML", mv.MANAGER_EML);
                        cmd.Parameters.AddWithValue("@P_MANAGER_DEP", mv.MANAGER_DEP);

                        cmd.Parameters.Add(new SqlParameter("@P_MANAGER_ID", System.Data.SqlDbType.NVarChar, 20));
                        cmd.Parameters["@P_MANAGER_ID"].Value = mv.MANAGER_ID;
                        cmd.Parameters["@P_MANAGER_ID"].Direction = System.Data.ParameterDirection.Input;
                        cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", System.Data.SqlDbType.NVarChar, 5));
                        cmd.Parameters["@P_ReturnCode"].Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        string result =cmd.Parameters["@P_ReturnCode"].Value.ToString();

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
                            message.ResultMessage = "이미 등록된 ID 입니다.";
                        }
                        else if (result == "M04")
                        {
                            message.IsSuccess = false;
                            message.ResultMessage = "이미 등록된 EMAIL 입니다.";
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
    }
}
