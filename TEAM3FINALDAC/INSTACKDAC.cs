using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALDAC
{
    public class INSTACKDAC : ConnectionAccess
    {
        public DataTable INSTACDataTable()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"select ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,INS_DATE,INS_TYP,FAC_NAME,i.ITEM_CODE,ITEM_NAME,ITEM_STND,ITEM_TYP,ITEM_MANAGE_LEVEL,i.INS_QTY
                               ,isnull((select top 1 MC_UNITPRICE_CUR from MATERIAL_COST WHERE ITEM_CODE = m.ITEM_CODE),0) as MC_UNITPRICE_CUR 
                               ,(i.INS_QTY * isnull((select top 1 MC_UNITPRICE_CUR from MATERIAL_COST WHERE ITEM_CODE = m.ITEM_CODE),0)) as price
                               FROM INSTACK i,ITEM m,FACTORY f
                               WHERE i.ITEM_CODE = m.ITEM_CODE and f.FAC_CODE=i.INS_WRHS  and INS_WRHS = 'R-01' ";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {

                da.Fill(dt);
            }
            return dt;
        }
        public DataTable INSTACDataTable(string day1, string day2, string wrhs, string name, string typ, string level, string itemtyp)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter("SP_ReleaseSearch", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@P_sday", day1);
                da.SelectCommand.Parameters.AddWithValue("@P_eday", day2);
                da.SelectCommand.Parameters.AddWithValue("@P_wrhs", wrhs);
                da.SelectCommand.Parameters.AddWithValue("@P_name", name);
                da.SelectCommand.Parameters.AddWithValue("@P_typ", typ);
                da.SelectCommand.Parameters.AddWithValue("@P_level", level);
                da.SelectCommand.Parameters.AddWithValue("@P_itemtyp", itemtyp);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable ReceivingSearch()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"select ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx
                          ,f.FAC_NAME
						  ,i.INS_WRHS
                          ,i.ITEM_CODE
                          ,te.ITEM_NAME
                          ,te.ITEM_TYP
                          ,te.ITEM_STND
                          ,v.현재고
                          ,te.ITEM_UNIT
                          ,te.ITEM_MANAGE_LEVEL
                           FROM INSTACK i , FACTORY f,item te ,INSTACK_WORK_V v
                          WHERE i.INS_WRHS = f.FAC_CODE and i.ITEM_CODE = te.ITEM_CODE and i.ITEM_CODE = v.ITEM_CODE  AND I.INS_WRHS =V.INS_WRHS AND 현재고 <> 0 AND V.INS_WRHS <> 'delete'
                          GROUP BY 
                           f.FAC_NAME
						  ,i.INS_WRHS
                          ,i.ITEM_CODE
                          ,te.ITEM_NAME
                          ,te.ITEM_TYP
                          ,te.ITEM_STND
                          ,te.ITEM_UNIT
                          ,te.ITEM_MANAGE_LEVEL
                          ,v.현재고";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {

                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SP_ReceivingSearch(string day, string name, string typ, string wrhs ,  string qty, string level)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter("SP_ReceivingSearch", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@P_INS_DATE", day);
                da.SelectCommand.Parameters.AddWithValue("@P_ITEM_NAME", name);
                da.SelectCommand.Parameters.AddWithValue("@P_ITEM_TYP", typ);
                da.SelectCommand.Parameters.AddWithValue("@P_INS_WRHS", wrhs);
                da.SelectCommand.Parameters.AddWithValue("@P_STOCK", qty);
                da.SelectCommand.Parameters.AddWithValue("@P_ITEM_MANAGE_LEVEL", level);
                da.Fill(dt);
            }
            return dt;
        }
        public bool INSERT_instack(int qty, string whrsin, string whesout, string code, string id)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"INSERT INTO instack (INS_QTY,INS_TYP,INS_WRHS,ITEM_CODE,SALES_WORK_ORDER_ID)
                                    VALUES (@INS_QTY,'입고',@INS_WRHS_IN,@ITEM_CODE,@SALES_WORK_ORDER_ID)

                                    INSERT INTO instack (INS_QTY,INS_TYP,INS_WRHS,ITEM_CODE,SALES_WORK_ORDER_ID)
                                    VALUES (@INS_QTY,'출고',@INS_WRHS_OUT,@ITEM_CODE,@SALES_WORK_ORDER_ID)";
                cmd.Parameters.AddWithValue("@INS_QTY", qty);
                cmd.Parameters.AddWithValue("@INS_WRHS_IN", whrsin);
                cmd.Parameters.AddWithValue("@INS_WRHS_OUT", whesout);
                cmd.Parameters.AddWithValue("@ITEM_CODE", code);
                cmd.Parameters.AddWithValue("@SALES_WORK_ORDER_ID", id);
                cmd.Connection.Open();
                int iResult = cmd.ExecuteNonQuery();
                return (iResult > 0) ? true : false;
            }
        }
    }
}
