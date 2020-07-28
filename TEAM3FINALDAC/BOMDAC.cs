using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //참조
using System.Data.SqlClient;
using TEAM3FINALVO;
using System.Configuration;

namespace TEAM3FINALDAC
{
    public class BOMDAC : ConnectionAccess
    {
        public string SaveBOM(BOM_VO vo)
        {
            string result;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SaveBOM";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_BOM_CODE", vo.BOM_CODE); //1
                    cmd.Parameters.AddWithValue("@P_BOM_PARENT_CODE", vo.BOM_PARENT_CODE); //2
                    cmd.Parameters.AddWithValue("@P_ITEM_CODE", vo.ITEM_CODE); //3
                    cmd.Parameters.AddWithValue("@P_BOM_QTY", vo.BOM_QTY); // 4
                    cmd.Parameters.AddWithValue("@P_BOM_STARTDATE", vo.BOM_STARTDATE); //5
                    cmd.Parameters.AddWithValue("@P_BOM_ENDDATE", vo.BOM_ENDDATE); //6
                    cmd.Parameters.AddWithValue("@P_BOM_USE_YN", vo.BOM_USE_YN); //7
                    cmd.Parameters.AddWithValue("@P_BOM_LAST_MDFR", vo.BOM_LAST_MDFR); //8
                    cmd.Parameters.AddWithValue("@P_BOM_LAST_MDFY", vo.BOM_LAST_MDFY); // 9
                    cmd.Parameters.AddWithValue("@P_BOM_AUTOREDUCE_YN", vo.BOM_AUTOREDUCE_YN); //10
                    cmd.Parameters.AddWithValue("@P_BOM_PLAN_YN", vo.BOM_PLAN_YN); //11
                    cmd.Parameters.AddWithValue("@P_BOM_REMARK", vo.BOM_REMARK); //12

                    cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", SqlDbType.NVarChar, 5));//13
                    cmd.Parameters["@P_ReturnCode"].Direction = ParameterDirection.Output;

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    result = cmd.Parameters["@P_ReturnCode"].Value.ToString();
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
