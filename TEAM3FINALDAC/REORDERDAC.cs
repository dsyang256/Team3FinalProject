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

        public bool DeleteREORDER(string v)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"delete from REORDER 
                                     where REORDER_CODE IN(SELECT * FROM[dbo].[SplitString](@appendCode, '@'))";
                cmd.Parameters.AddWithValue("@appendCode", v);
                cmd.Connection.Open();
                int iResult = cmd.ExecuteNonQuery();
                return (iResult > 0) ? true : false;
            }
        }

        public bool insertREORDERDETATILS(REORDERDETATILS_VO vo,ITEM_VO vo2)
        {
            bool Result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"SP_insertREORDERDETATILS";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_REORDER_DETAIL_QTY_GOOD", vo.REORDER_DETAIL_QTY_GOOD);
                    cmd.Parameters.AddWithValue("@P_REORDER_CODE", vo.REORDER);
                    cmd.Parameters.AddWithValue("@P_REORDER_QTY", vo2.ITEM_QTY_UNIT);
                    cmd.Parameters.AddWithValue("@P_ITEM_INCOME_YN", vo2.ITEM_INCOME_YN);
                    cmd.Parameters.AddWithValue("@P_ITEM_CODE", vo2.ITEM_CODE);
                    cmd.Parameters.AddWithValue("@P_ITEM_WRHS_IN", vo2.ITEM_WRHS_IN);
                    cmd.Connection.Open();
                    int iResult = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return (iResult > 0) ? true : false;
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return Result;
            }
        }

        public DataTable SPGetWarehousingWait(string day1, string day2, string code1, string name, string reorder, string cod2)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter("SP_GetWarehousingWait", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@P_sday", day1);
                da.SelectCommand.Parameters.AddWithValue("@P_eday", day2);
                da.SelectCommand.Parameters.AddWithValue("@P_REORDER_COM_DLVR", code1);
                da.SelectCommand.Parameters.AddWithValue("@P_ITEM_NAME", name);
                da.SelectCommand.Parameters.AddWithValue("@P_REORDER_CODE", reorder);
                da.SelectCommand.Parameters.AddWithValue("@P_COM_CODE", cod2);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetWarehousingWait2()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = $@"select ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,REORDER_DATE,REORDER_COM_DLVR,COM_CODE,r.ITEM_CODE,ITEM_NAME,ITEM_STND,ITEM_UNIT,ITEM_INCOME_YN,REORDER_QTY
                          ,isnull(((select SUM(ISNULL(REORDER_DETAIL_QTY_GOOD, 0)) - sum(isnull(REORDER_DETAIL_QTY_BAD,0)) REORDER_DETAIL_QTY_GOOD  
                                             from REORDERDETATILS
                                             where REORDER_CODE = r.REORDER_CODE)), REORDER_QTY) REORDER_QTY1
                         ,isnull(REORDER_QTY-((select SUM(ISNULL(REORDER_DETAIL_QTY_GOOD, 0)) - sum(isnull(REORDER_DETAIL_QTY_BAD,0)) REORDER_DETAIL_QTY_GOOD  
                                             from REORDERDETATILS
                                             where REORDER_CODE = r.REORDER_CODE)), REORDER_QTY) REORDER_QTY2,REORDER_DATE_IN,REORDER_TYP
                         from REORDER r , ITEM i
                         where REORDER_STATE = '입고대기' and r.ITEM_CODE = i.ITEM_CODE";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {

                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetWarehousingWait()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = $@"SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,r.REORDER_CODE,I.ITEM_CODE,I.ITEM_NAME,I.ITEM_STND,I.ITEM_UNIT,REORDER_QTY,ITEM_WRHS_IN,
 					isnull((REORDER_QTY-(select SUM(ISNULL(REORDER_DETAIL_QTY_GOOD, 0)) - sum(isnull(REORDER_DETAIL_QTY_BAD,0)) REORDER_DETAIL_QTY_GOOD  
                    from REORDERDETATILS
                    where REORDER_CODE = r.REORDER_CODE)), REORDER_QTY) REORDER_QTY1
                    ,REORDER_STATE,REORDER_DATE_IN,REORDER_DATE,ITEM_INCOME_YN
                    from ITEM I JOIN REORDER r ON I.ITEM_CODE =R.ITEM_CODE
                    where ITEM_TYP = '원자재' AND REORDER_STATE in ('발주','입고대기')";
             conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {

                da.Fill(dt);
            }
            return dt;
        }

        public bool insertREORDER(REORDER_VO vo)
        {
            bool Result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"INSERT INTO Reorder(REORDER_DATE, REORDER_DATE_IN,REORDER_COM_DLVR, REORDER_TYP,REORDER_QTY,REORDER_STATE,ITEM_CODE,COM_CODE, MANAGER_ID)
                                              VALUES(@REORDER_DATE, @REORDER_DATE_IN,@REORDER_COM_DLVR, @REORDER_TYP,@REORDER_QTY,@REORDER_STATE,@ITEM_CODE,@COM_CODE, @MANAGER_ID) ";
                    cmd.Parameters.AddWithValue("@REORDER_DATE",vo.REORDER_DATE);
                    cmd.Parameters.AddWithValue("@REORDER_DATE_IN",vo.REORDER_DATE_IN);
                    cmd.Parameters.AddWithValue("@REORDER_COM_DLVR",vo.REORDER_COM_DLVR);
                    cmd.Parameters.AddWithValue("@REORDER_TYP",vo.REORDER_TYP);
                    cmd.Parameters.AddWithValue("@REORDER_QTY",vo.REORDER_QTY );
                    cmd.Parameters.AddWithValue("@REORDER_STATE",vo.REORDER_STATE);
                    cmd.Parameters.AddWithValue("@ITEM_CODE",vo.ITEM_CODE);
                    cmd.Parameters.AddWithValue("@COM_CODE",vo.COM_CODE);
                    cmd.Parameters.AddWithValue("@MANAGER_ID",vo.MANAGER_ID);

                    cmd.Connection.Open();
                    int iResult = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return (iResult > 0) ? true : false;
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return Result;
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
        public bool UpDateREORDER(string day,string manager,string code)
        {
            bool Result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"UPDATE REORDER SET REORDER_DATE_IN = @REORDER_DATE_IN , MANAGER_ID = @MANAGER_ID
                                          WHERE REORDER_CODE in ((SELECT * FROM[dbo].[SplitString]({code}, '@')))";
                    cmd.Parameters.AddWithValue("@REORDER_DATE_IN", day);
                    cmd.Parameters.AddWithValue("@MANAGER_ID", manager);
                  
                   

                    cmd.Connection.Open();
                    int iResult = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return (iResult > 0) ? true : false;
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return Result;
            }
        }
        public DataTable GetSearchReorder2(string reorder ,string name)
        {
            
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = $@"SP_GetSearchReorder2";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@P_ITEM_COM_REORDER", reorder);
                da.SelectCommand.Parameters.AddWithValue("@P_ITEM_NAME", name);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
