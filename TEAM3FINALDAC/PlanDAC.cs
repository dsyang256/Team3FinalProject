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
                string sql = "CheckCreateProductPlan";
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

        public string CheckPlanCreate()
        {
            string result=string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    //cmd.Connection = new SqlConnection(this.ConnectionString);
                    //cmd.CommandText = "SaveBOM";
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@P_BOM_CODE", vo.BOM_CODE); //1
                    //cmd.Parameters.AddWithValue("@P_BOM_PARENT_CODE", vo.BOM_PARENT_CODE); //2
                    //cmd.Parameters.AddWithValue("@P_ITEM_CODE", vo.ITEM_CODE); //3
                    //cmd.Parameters.AddWithValue("@P_BOM_QTY", vo.BOM_QTY); // 4
                    //cmd.Parameters.AddWithValue("@P_BOM_STARTDATE", vo.BOM_STARTDATE); //5
                    //cmd.Parameters.AddWithValue("@P_BOM_ENDDATE", vo.BOM_ENDDATE); //6
                    //cmd.Parameters.AddWithValue("@P_BOM_USE_YN", vo.BOM_USE_YN); //7
                    //cmd.Parameters.AddWithValue("@P_BOM_LAST_MDFR", vo.BOM_LAST_MDFR); //8
                    //cmd.Parameters.AddWithValue("@P_BOM_LAST_MDFY", vo.BOM_LAST_MDFY); // 9
                    //cmd.Parameters.AddWithValue("@P_BOM_AUTOREDUCE_YN", vo.BOM_AUTOREDUCE_YN); //10
                    //cmd.Parameters.AddWithValue("@P_BOM_PLAN_YN", vo.BOM_PLAN_YN); //11
                    //cmd.Parameters.AddWithValue("@P_BOM_REMARK", vo.BOM_REMARK); //12

                    //cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", SqlDbType.NVarChar, 5));//13
                    //cmd.Parameters["@P_ReturnCode"].Direction = ParameterDirection.Output;

                    //cmd.Connection.Open();
                    //cmd.ExecuteNonQuery();
                    //cmd.Connection.Close();
                    //result = cmd.Parameters["@P_ReturnCode"].Value.ToString();
                    return result;
                }
            }
            catch (Exception err)
            {
                return result = "C201";
            }
        }

    }
}
