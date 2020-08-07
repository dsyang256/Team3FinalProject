﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALVO;

namespace TEAM3FINALDAC
{
    public class WorkOrderDAC : ConnectionAccess
    {
        public List<WORKORDER_VO> GetWorkOrderInfo()
        {
            List<WORKORDER_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select convert(nvarchar, WO_PLAN_DATE, 23) WO_PLAN_DATE, convert(nvarchar, WO_PROD_DATE, 23) WO_PROD_DATE, w.FCLTS_CODE, f.FCLTS_NAME, WO_WORK_SEQ, w.ITEM_CODE, i.ITEM_NAME, WO_WORK_STATE, f.FCLTS_WRHS_GOOD, f.FCLTS_WRHS_BAD, WO_PLAN_QTY, s.SALES_NO_QTY, WO_QTY_OUT, 
WO_QTY_IN, SUM(WO_QTY_IN - WO_QTY_OUT) as WO_QTY_BAD, SUM(WO_PLAN_QTY - s.SALES_NO_QTY - WO_QTY_OUT) as WO_QTY, sum(WO_QTY_OUT + WO_QTY_IN - WO_QTY_OUT) as WO_QTY_PROD, convert(nvarchar, WO_PLAN_STARTTIME, 23) WO_PLAN_STARTTIME, 
convert(nvarchar, WO_PLAN_ENDTIME, 23) WO_PLAN_ENDTIME, WO_REMARK, WO_LAST_MDFR, convert(nvarchar, WO_LAST_MDFY, 120) WO_LAST_MDFY, w.SALES_WORK_ORDER_ID, PLAN_ID, WO_Code
from WORKORDER w inner join FACILITY f on w.FCLTS_CODE = f.FCLTS_CODE
				 inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
				 inner join SALES_WORK s on w.SALES_WORK_ORDER_ID = s.SALES_Work_Order_ID
group by WO_PLAN_DATE, WO_PROD_DATE, w.FCLTS_CODE, f.FCLTS_NAME, WO_WORK_SEQ, w.ITEM_CODE, i.ITEM_NAME, WO_WORK_STATE, f.FCLTS_WRHS_GOOD, f.FCLTS_WRHS_BAD, WO_PLAN_QTY, s.SALES_NO_QTY, WO_QTY_OUT, WO_QTY_IN, WO_PLAN_STARTTIME, 
		 WO_PLAN_ENDTIME, WO_REMARK, WO_LAST_MDFR, WO_LAST_MDFY, w.SALES_WORK_ORDER_ID, PLAN_ID, WO_Code";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<WORKORDER_VO>(reader);

                return list;
            }
        }
    }
}
