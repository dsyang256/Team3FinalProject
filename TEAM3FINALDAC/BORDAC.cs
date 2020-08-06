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
    public class BORDAC : ConnectionAccess
    {
        
        public List<BOR_VO> GetBORList()
        {
            List<BOR_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select BOR_CODE, b.ITEM_CODE, i.ITEM_NAME, b.BOR_PROCS_CODE, c.COMMON_CODE, b.FCLTS_CODE, f.FCLTS_NAME, BOR_PROCS_TIME, BOR_PRIORT, BOR_PROCS_LEADTIME, BOR_YIELD, BOR_USE_YN, BOR_REMARK, BOR_LAST_MDFR, convert(varchar, BOR_LAST_MDFY, 120) BOR_LAST_MDFY
                                    from BOR b left outer join ITEM i on b.ITEM_CODE = i.ITEM_CODE
			                        left outer join FACILITY f on b.FCLTS_CODE = f.FCLTS_CODE
			                        left outer join COMMON c on b.BOR_PROCS_CODE = c.COMMON_NAME";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<BOR_VO>(reader);

                return list;
            }
        }

        public DataTable GetBaCodeBORList(string strChkBarCodes)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection conn = new SqlConnection(this.ConnectionString);
                    string sql = $@"select concat(REPLICATE('0',5 - LEN(BOR_CODE)), BOR_CODE) BOR_CODE, BOR_PROCS_CODE, FCLTS_CODE, BOR_PROCS_TIME, ITEM_CODE
                                    from BOR
                                    where BOR_CODE in ({strChkBarCodes})";
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(dt);
                    conn.Close();

                    return dt;
                }
            }
            catch (Exception err)
            {
                return new DataTable();
            }
        }

        public List<BOR_VO> SearchBOR(string itemCode, string proc, string facility)
        {
            List<BOR_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SearchBOR";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_ITEM_CODE", itemCode);
                cmd.Parameters.AddWithValue("@P_PROC_CODE", proc);
                cmd.Parameters.AddWithValue("@P_FACILITY", facility);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<BOR_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public Message SaveBOR(BOR_VO vo, bool update)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_SaveBOR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_UPDATE", update);
                    cmd.Parameters.AddWithValue("@P_BOR_CODE", vo.BOR_CODE);
                    cmd.Parameters.AddWithValue("@P_BOR_PROCS_CODE", vo.BOR_PROCS_CODE);
                    cmd.Parameters.AddWithValue("@P_BOR_PROCS_TIME", vo.BOR_PROCS_TIME);
                    cmd.Parameters.Add(new SqlParameter("@P_BOR_PROCS_LEADTIME", System.Data.SqlDbType.Int));
                    cmd.Parameters["@P_BOR_PROCS_LEADTIME"].Value = (object)vo.BOR_PROCS_LEADTIME ?? DBNull.Value;                    
                    cmd.Parameters.AddWithValue("@P_BOR_PRIORT", vo.BOR_PRIORT);
                    cmd.Parameters.AddWithValue("@P_BOR_YIELD", vo.BOR_YIELD);
                    cmd.Parameters.AddWithValue("@P_BOR_USE_YN", vo.BOR_USE_YN);
                    cmd.Parameters.AddWithValue("@P_BOR_REMARK", vo.BOR_REMARK);
                    cmd.Parameters.AddWithValue("@P_ITEM_CODE", vo.ITEM_CODE);
                    cmd.Parameters.AddWithValue("@P_FCLTS_CODE", vo.FCLTS_CODE);
                    cmd.Parameters.AddWithValue("@P_BOR_LAST_MDFR", vo.BOR_LAST_MDFR);
                    cmd.Parameters.AddWithValue("@P_BOR_LAST_MDFY", vo.BOR_LAST_MDFY);
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
                    else if (result == "S03")
                    {
                        message.IsSuccess = false;
                        message.ResultMessage = "코드 중복";
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

    }
}
