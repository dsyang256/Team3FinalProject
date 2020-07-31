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
        #region 설비군

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

        #endregion


        #region 설비

        public List<FACILITY_VO> GetFacilityInfo()
        {
            List<FACILITY_VO> list = null;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select FCLTS_CODE, FCLTS_NAME, FCLTS_WRHS_EXHST, FCLTS_WRHS_GOOD, FCLTS_WRHS_BAD, FCLTS_USE_YN, FCLTS_EXTRL_YN, FCLTS_LAST_MDFR, convert(nvarchar, FCLTS_LAST_MDFY, 120) FCLTS_LAST_MDFY, FCLTS_NOTE, FCLTS_REMARK, FACG_CODE
from FACILITY";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<FACILITY_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public string InsertFacility(FACILITY_VO fac)
        {
            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"insert into FACILITY(FCLTS_CODE, FCLTS_NAME, FCLTS_WRHS_EXHST, FCLTS_WRHS_GOOD, FCLTS_WRHS_BAD, FCLTS_USE_YN, FCLTS_EXTRL_YN, FCLTS_LAST_MDFR, FCLTS_LAST_MDFY, FCLTS_NOTE, FCLTS_REMARK, FACG_CODE)
values(@FCLTS_CODE, @FCLTS_NAME, @FCLTS_WRHS_EXHST, @FCLTS_WRHS_GOOD, @FCLTS_WRHS_BAD, @FCLTS_USE_YN, @FCLTS_EXTRL_YN, @FCLTS_LAST_MDFR, @FCLTS_LAST_MDFY, @FCLTS_NOTE, @FCLTS_REMARK, @FACG_CODE)";
                cmd.Parameters.AddWithValue("@FCLTS_CODE", fac.FCLTS_CODE);
                cmd.Parameters.AddWithValue("@FCLTS_NAME", fac.FCLTS_NAME);
                cmd.Parameters.AddWithValue("@FCLTS_WRHS_EXHST", fac.FCLTS_WRHS_EXHST);
                cmd.Parameters.AddWithValue("@FCLTS_WRHS_GOOD", fac.FCLTS_WRHS_GOOD);
                cmd.Parameters.AddWithValue("@FCLTS_WRHS_BAD", fac.FCLTS_WRHS_BAD);
                cmd.Parameters.AddWithValue("@FCLTS_USE_YN", fac.FCLTS_USE_YN);
                cmd.Parameters.AddWithValue("@FCLTS_EXTRL_YN", fac.FCLTS_EXTRL_YN);
                cmd.Parameters.AddWithValue("@FCLTS_LAST_MDFR", fac.FCLTS_LAST_MDFR);
                cmd.Parameters.AddWithValue("@FCLTS_LAST_MDFY", fac.FCLTS_LAST_MDFY);
                cmd.Parameters.AddWithValue("@FCLTS_LAST_MDFY", fac.FCLTS_LAST_MDFY);
                cmd.Parameters.AddWithValue("@FCLTS_NOTE", fac.FCLTS_NOTE);
                cmd.Parameters.AddWithValue("@FCLTS_REMARK", fac.FCLTS_REMARK);
                cmd.Parameters.AddWithValue("FACG_CODE", fac.FACG_CODE);

                cmd.Connection.Open();
                int result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return (result > 0) ? "C200" : "C203";
            }
        }

        #endregion
    }
}
