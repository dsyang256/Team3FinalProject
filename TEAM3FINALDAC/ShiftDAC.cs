using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cryptography;
using TEAM3FINALVO;

namespace TEAM3FINALDAC
{
   public class ShiftDAC : ConnectionAccess
    {
        public List<ITEM_VO> AllITEM()

        {
            List<ITEM_VO> list = default;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    AESSalt salt = new AESSalt();
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = @"select ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,ITEM_CODE, ITEM_NAME, ITEM_STND, ITEM_UNIT, ITEM_QTY_UNIT, ITEM_TYP, ITEM_INCOME_YN, ITEM_PROCS_YN, ITEM_XPORT_YN, ITEM_FREE_YN, ITEM_COM_DLVR, ITEM_COM_REORDER, ITEM_WRHS_IN, ITEM_WRHS_OUT, ITEM_LEADTIME, ITEM_QTY_REORDER_MIN, ITEM_QTY_STND, ITEM_QTY_SAFE, ITEM_MANAGE_LEVEL, ITEM_MANAGER, ITEM_UNIT_CNVR, ITEM_QTY_CNVR, ITEM_LAST_MDFR, CONVERT(CHAR(10), ITEM_LAST_MDFY, 23)ITEM_LAST_MDFY, ITEM_USE_YN, ITEM_DSCN_YN, ITEM_REORDER_TYP, ITEM_REMARK
                                                       from ITEM";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<ITEM_VO>(reader);
                    cmd.Connection.Close();
                    return list;
                }
            }
            catch (Exception err)
            {
                return list;
            }

        }

    }
}
