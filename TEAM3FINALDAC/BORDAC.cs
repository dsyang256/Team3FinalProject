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
    }
}
