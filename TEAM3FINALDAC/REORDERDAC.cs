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
    public class REORDERDAC : ConnectionAccess
    {
        public DataTable SelectREORDER()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"SELECT 
                          R.REORDER_CODE          
                         ,COM_CODE                
                         ,REORDER_COM_DLVR        
                         ,REORDER_STATE           
                         ,r.ITEM_CODE             
                         ,ITEM_NAME               
                         ,ITEM_STND               
                         ,ITEM_UNIT               
                         ,REORDER_DATE_IN         
                         ,REORDER_QTY             
                         ,REORDER_DETAIL_QTY_GOOD 
                         ,(NULL)REORDER_DETAIL_QTY_START                     
                         ,(REORDER_QTY - REORDER_DETAIL_QTY_GOOD) REORDER_QTY_CANCEL 
                         ,REORDER_DATE             
                         ,MANAGER_NAME             
                          FROM REORDER r 
                          join item i on r.ITEM_CODE = i.ITEM_CODE
                          join MANAGER m on r.MANAGER_ID = m.MANAGER_ID
                          LEFT JOIN REORDERDETATILS D ON D.REORDER_CODE = R.REORDER_CODE ";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {

                da.Fill(dt);
            }
            return dt;
        }

        public void insertREORDER(REORDER_VO vo)
        {
            bool Result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"INSERT INTO Reorder(COMMON_CODE, COMMON_NAME,COMMON_PARENT, COMMON_SEQ)
                                              VALUES(@COMMON_CODE, @COMMON_NAME,@COMMON_PARENT,@COMMON_SEQ) ";
                    cmd.Parameters.AddWithValue("@COMMON_CODE", code + "_" + name);
                    cmd.Parameters.AddWithValue("@COMMON_NAME", name);
                    cmd.Parameters.AddWithValue("@COMMON_PARENT", code);
                    cmd.Parameters.AddWithValue("@COMMON_SEQ", SEQ);
                    cmd.Connection.Open();
                    int iResult = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    //return (iResult > 0) ? true : false;
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                //return Result;
            }
        }

        public DataTable GetReorderItem()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,ITEM_COM_REORDER,ITEM_COM_DLVR,ITEM_MANAGER,ITEM_CODE,ITEM_NAME,ITEM_WRHS_IN,ITEM_INCOME_YN,ITEM_REORDER_TYP
                            from ITEM 
                           where ITEM_TYP = '원자재'";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {

                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetReorderItem2(string com)
        {
            //i join BOM b on i.ITEM_CODE = b.ITEM_CODE
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = $@"SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,ITEM_COM_REORDER,ITEM_COM_DLVR,ITEM_MANAGER,ITEM_CODE,ITEM_NAME,ITEM_WRHS_IN,ITEM_INCOME_YN,ITEM_REORDER_TYP
                            from ITEM
                           where ITEM_TYP = '원자재' and ITEM_COM_REORDER in({com})";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {

                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetSearchREORDER(string sday, string eday, string comcodeout, string item, string state, string order, string comcodein)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter("SP_GetSearchREORDER", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@P_REORDER_DATE_IN_S", sday);
                da.SelectCommand.Parameters.AddWithValue("@P_REORDER_DATE_IN_E", eday);
                da.SelectCommand.Parameters.AddWithValue("@P_COM_CODE", comcodeout);
                da.SelectCommand.Parameters.AddWithValue("@P_ITEM_CODE", item);
                da.SelectCommand.Parameters.AddWithValue("@P_REORDER_STATE", state);
                da.SelectCommand.Parameters.AddWithValue("@P_REORDER_CODE", order);
                da.SelectCommand.Parameters.AddWithValue("@P_COM_CODE_IN", comcodein);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetCOM()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            conn.Open();
            string sql = @"SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,COM_CODE , COM_NAME 
                             FROM COMPANY";
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.Fill(dt);
            }
            return dt;


        }
    }
}
