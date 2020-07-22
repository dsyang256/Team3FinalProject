using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cryptography;

namespace TEAM3FINALDAC
{
    public class ITEMDAC : ConnectionAccess
    {
        public DataTable AllITEM()
        {
            DataTable dt = new DataTable();
            try
            {
                AESSalt salt = new AESSalt();
                string strConn = salt.Decrypt(this.ConnectionString);

                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    string sql = @"select ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,ITEM_TYP,ITEM_CODE,ITEM_NAME,ITEM_STND,ITEM_UNIT,ITEM_QTY_UNIT,ITEM_UNIT_CNVR,ITEM_QTY_CNVR,ITEM_INCOME_YN,ITEM_PROCS_YN,ITEM_XPORT_YN,ITEM_DSCN_YN,ITEM_FREE_YN,ITEM_COM_DLVR,ITEM_COM_REORDER
                                                       from ITEM;";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    da.Fill(dt);                    
                }
                return dt;
            }
            catch (Exception err)
            {
                return dt;
            }
            
        }

    }
}
