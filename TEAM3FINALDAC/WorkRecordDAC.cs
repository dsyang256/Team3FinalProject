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
    public class WorkRecordDAC : ConnectionAccess
    {
        public List<WORKORDER_VO> GetWorkRecordList()
        {
            List<WORKORDER_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select [WO_Code], [WO_PLAN_QTY], [WO_PLAN_DATE], [WO_PROD_DATE], [WO_WORK_STATE], [WO_WORK_SEQ], [WO_PLAN_STARTTIME], [WO_PLAN_ENDTIME], 
[WO_QTY_IN], [WO_QTY_OUT], [WO_QTY_PROD], [WO_PROD_REQ_NUM], [WO_REMARK], [WO_LAST_MDFR], [WO_LAST_MDFY], [SALES_WORK_ORDER_ID], 
[ITEM_CODE], [FCLTS_CODE], [PLAN_ID]
from [dbo].[WORKORDER]";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<WORKORDER_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
    }
}
