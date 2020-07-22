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
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return iCnt > 0 ? true : false;
        }

        public bool InsertManager(MANAGER_VO mv)
        {
            int iCnt = default;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //cmd.Connection = new SqlConnection(this.ConnectionString);

                    //cmd.CommandText = $@"select COUNT(MANAGER_ID)
                    //                                from MANAGER
                    //                                where MANAGER_ID = @MANAGER_ID
                    //                                AND MANAGER_PSWD = @MANAGER_PSWD ";
                    //cmd.Parameters.AddWithValue("@MANAGER_ID", userID);
                    //cmd.Parameters.AddWithValue("@MANAGER_PSWD", password);

                    //cmd.Connection.Open();
                    //iCnt = Convert.ToInt32(cmd.ExecuteScalar());
                    //cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return iCnt > 0 ? true : false;
        }
    }
}
