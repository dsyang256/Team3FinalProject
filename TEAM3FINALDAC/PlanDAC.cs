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

        public DataTable GetMaterialDemandPlan(string fromDate, string toDate, string planID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SP_GetMaterialDemandPlan";
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@P_S_DATE", fromDate));
                    cmd.Parameters.Add(new SqlParameter("@P_E_DATE", toDate));
                    cmd.Parameters.Add(new SqlParameter("@P_PLANID", planID));
                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
            }
            return ds.Tables[0];
        }

        public DataTable GetOutProductPlan(string fromDate, string toDate, string planID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SP_GetOutProductPlan";
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@P_S_DATE", fromDate));
                    cmd.Parameters.Add(new SqlParameter("@P_E_DATE", toDate));
                    cmd.Parameters.Add(new SqlParameter("@P_PLAN_ID", planID));
                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
            }
            return ds.Tables[0];

        }

        public DataTable GetProductPlan(string fromDate, string toDate, string planID)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            string sql = "SP_GetProductPlan";
            using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@P_S_DATE", fromDate));
                    cmd.Parameters.Add(new SqlParameter("@P_E_DATE", toDate));
                    cmd.Parameters.Add(new SqlParameter("@P_PLAN_ID", planID));
                    conn.Open();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
            }
            return ds.Tables[0];
        }

        public bool InsertWorkOrders(string planID)
        {
            string fromDate = planID.Substring(0, 4) + "-" + planID.Substring(4, 2) + "-" + planID.Substring(6, 2);
            string toDate = DateTime.Parse(fromDate).AddMonths(1).ToString();
            int iCnt = 0;
            try
            {
                string sql = "SP_InsertWorkOrders";
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_FromDate", fromDate);
                        cmd.Parameters.AddWithValue("@P_ToDate", toDate);
                        cmd.Parameters.AddWithValue("@P_PLAN_ID", planID);
                        iCnt= cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception err)
            {
                return false;
            }
            //  return resul > 0 ? true : false;
            return iCnt>0 ? true :false;
        }

        public bool CheckWOCreate(string planID)
        {
            string result = "";
            try
            {
                string sql = $@"select distinct PLAN_STATE
                            from DEMAND_PLANNING
                            where PLAN_ID = @planID ";
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@planID", planID);
                        result =(string)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception err)
            {

            }
            return result.Contains("생산계획대기") ? true : false;
        }

        public string CheckDemandPlan(string planID)
        {
            string fromDate = planID.Substring(0, 4) + "-" + planID.Substring(4, 2) + "-" + planID.Substring(6, 2);
            string toDate = DateTime.Parse(fromDate).AddMonths(1).ToString();

                string result = "";
            try
            {
                string sql = "SP_CheckCreateProductPlan";
                using (SqlConnection conn = new SqlConnection(this.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@P_STARTDATE", fromDate);
                        cmd.Parameters.AddWithValue("@P_ENDDATE", toDate);
                        cmd.Parameters.AddWithValue("@P_PLANID", planID);
                        var returnParameter = cmd.Parameters.Add("@P_STATE", SqlDbType.NVarChar,20);
                        returnParameter.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        result = (string)returnParameter.Value;
                    }
                }
            }
            catch (Exception err)
            {
                
            }
            //  return resul > 0 ? true : false;
            return result;
        }

    }
}
