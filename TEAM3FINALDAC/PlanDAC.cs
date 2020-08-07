using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TEAM3FINALVO;
using cryptography;


namespace TEAM3FINALDAC
{
    public class PlanDAC : ConnectionAccess
    {
        public DataTable GetDemandPlan(string FromDate, string ToDate, string PlanID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SP_GetDemandPlan";
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@P_S_DATE", FromDate));
                    cmd.Parameters.Add(new SqlParameter("@P_E_DATE", ToDate));
                    cmd.Parameters.Add(new SqlParameter("@PLAN_ID", PlanID));
                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
            }
            return ds.Tables[0];
        }

    }
}
