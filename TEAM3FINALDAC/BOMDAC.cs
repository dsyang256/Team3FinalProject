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

        public BOM_VO GetBOM(int code)
        {
            List<BOM_VO> list = default;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"select BOM_CODE,BOM_PARENT_CODE,BOM_QTY,CONVERT(CHAR(10), BOM_STARTDATE, 23) BOM_STARTDATE,CONVERT(CHAR(10), BOM_ENDDATE, 23) BOM_ENDDATE,BOM_USE_YN,BOM_LAST_MDFR,CONVERT(CHAR(10), BOM_LAST_MDFY, 23) BOM_LAST_MDFY,BOM_AUTOREDUCE_YN,BOM_PLAN_YN,BOM_REMARK,ITEM_CODE
                                          from BOM
                                         Where BOM_CODE = @BOM_CODE";
                    cmd.Parameters.AddWithValue("@BOM_CODE", code);
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<BOM_VO>(reader);
                    cmd.Connection.Close();
                    return list[0];
                }
            }
            catch (Exception err)
            {
                return list[0];
            }
        }

        public DataTable SelectBOM()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"WITH A AS
                        (SELECT T1.BOM_CODE, T1.ITEM_CODE, T1.BOM_PARENT_CODE, T1.BOM_QTY, 0 AS Lvl, convert(varchar(255), T1.ITEM_CODE) sortOrder
                           FROM BOM T1 INNER JOIN ITEM i ON T1.ITEM_CODE = i.ITEM_CODE
                          WHERE T1.BOM_PARENT_CODE = '-' 
                      
                         UNION ALL
                      
                          SELECT T.BOM_CODE, T.ITEM_CODE, T.BOM_PARENT_CODE, T.BOM_QTY, A.Lvl + 1 as Lvl, convert(varchar(255), convert(nvarchar, A.sortOrder) + '>' + convert(varchar(255), T.ITEM_CODE)) sortOrder
                          FROM A INNER JOIN BOM T ON T.BOM_PARENT_CODE = A.ITEM_CODE
                      )
                      
                      SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,A.BOM_CODE,A.ITEM_CODE
                      ,CASE WHEN A.Lvl = 0 THEN '▶' ELSE SUBSTRING('      ',1,A.LVL * 3) +'L' END + B.ITEM_NAME AS ITEM_NAME, B.ITEM_TYP,B.ITEM_UNIT, A.BOM_QTY,A.Lvl,CONVERT(CHAR(10), C.BOM_STARTDATE, 23) BOM_STARTDATE,CONVERT(CHAR(10), C.BOM_ENDDATE, 23) BOM_ENDDATE,C.BOM_USE_YN,C.BOM_PLAN_YN,C.BOM_AUTOREDUCE_YN,D.FCLTS_CODE,FCLTS_NAME,B.ITEM_STND
                         FROM A
                         INNER JOIN ITEM B ON A.ITEM_CODE = B.ITEM_CODE
                        INNER JOIN BOM C ON C.ITEM_CODE = B.ITEM_CODE
                        LEFT JOIN BOR D ON D.ITEM_CODE = B.ITEM_CODE
                        LEFT JOIN FACILITY E ON E.FCLTS_CODE = D.FCLTS_CODE
                        order by A.SortOrder";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable SearchBOM(string day ,string name,string yn )
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter("SP_GetSearchBOM", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@P_BOM_DATE", day);
                da.SelectCommand.Parameters.AddWithValue("@P_ITEM_NAME", name);
                da.SelectCommand.Parameters.AddWithValue("@P_BOM_USE_YN", yn);
                da.Fill(dt);
            }
            return dt;
        }

        public bool DeleteBOM(StringBuilder code)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"WITH A AS
                                 (SELECT T1.BOM_CODE, T1.ITEM_CODE
                                    FROM BOM T1
                               	   WHERE T1.BOM_CODE IN(select Item from dbo.SplitString(@CODE, '@'))
                               
                                   UNION ALL 
                               
                                   SELECT T.BOM_CODE, T.ITEM_CODE
                                     FROM A INNER JOIN BOM T ON T.BOM_PARENT_CODE = A.ITEM_CODE
                               )
                               UPDATE BOM SET BOM_USE_YN = '미사용'
                               WHERE BOM_CODE IN(SELECT DISTINCT BOM_CODE  FROM A)";
                cmd.Parameters.AddWithValue("@CODE", code.ToString());
                cmd.Connection.Open();
                int iResult = cmd.ExecuteNonQuery();
                return (iResult > 0) ? true : false;
            }
        }
    }
}
