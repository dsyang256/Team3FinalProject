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
    public class FacilityDAC : ConnectionAccess
    {
        public List<FACILITY_GROUP> GetFacilityGroupInfo()
        {
            List<FACILITY_GROUP> list = default;

            using (SqlCommand cmd = new SqlCommand()) 
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select FACG_CODE, FACG_NAME, FACG_USE_YN, FACG_LAST_MDFR, convert(varchar, FACG_LAST_MDFY, 120) FACG_LAST_MDFY, FACG_DESC
from FACILITY_GROP";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<FACILITY_GROUP>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public string InsertFacilityGroup(FACILITY_GROUP fac)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"insert into FACILITY_GROP(FACG_CODE, FACG_NAME, FACG_USE_YN, FACG_LAST_MDFR, FACG_DESC)
values(@FACG_CODE, @FACG_NAME, @FACG_USE_YN, @FACG_LAST_MDFR, @FACG_DESC)";
                cmd.Parameters.AddWithValue("@FACG_CODE", fac.FACG_CODE);
                cmd.Parameters.AddWithValue("@FACG_NAME", fac.FACG_NAME);
                cmd.Parameters.AddWithValue("@FACG_USE_YN", fac.FACG_USE_YN);
                cmd.Parameters.AddWithValue("@FACG_LAST_MDFR", fac.FACG_LAST_MDFR);
                cmd.Parameters.AddWithValue("@FACG_DESC", fac.FACG_DESC);

                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return (result > 0) ? "C200" : "C203";
            }
        }

        public string UpdateFacilityGroup(FACILITY_GROUP fac)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"update FACILITY_GROP set FACG_CODE = @FACG_CODE, FACG_NAME = @FACG_NAME, FACG_USE_YN = @FACG_USE_YN,
FACG_LAST_MDFR = @FACG_LAST_MDFR, FACG_LAST_MDFY = @FACG_LAST_MDFY, FACG_DESC = @FACG_DESC WHERE FACG_CODE = @FACG_CODE";
                cmd.Parameters.AddWithValue("@FACG_CODE", fac.FACG_CODE);
                cmd.Parameters.AddWithValue("@FACG_NAME", fac.FACG_NAME);
                cmd.Parameters.AddWithValue("@FACG_USE_YN", fac.FACG_USE_YN);
                cmd.Parameters.AddWithValue("@FACG_LAST_MDFR", fac.FACG_LAST_MDFR);
                cmd.Parameters.AddWithValue("@FACG_LAST_MDFY", fac.FACG_LAST_MDFY);
                cmd.Parameters.AddWithValue("@FACG_DESC", fac.FACG_DESC);

                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return (result > 0) ? "C200" : "C203";
            }                
        }
    }
}
