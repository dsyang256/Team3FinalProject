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
            using (SqlDataAdapter da = new SqlDataAdapter("SP_GetWarehousingWait", conn))
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
    }
}
