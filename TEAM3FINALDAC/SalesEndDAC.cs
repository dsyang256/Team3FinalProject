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
    public class SalesEndDAC : ConnectionAccess
    {
        public List<SalesEnd_VO> GetSalesEnd()
        {
            List<SalesEnd_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select w.SALES_WORK_ORDER_ID, s.COM_CODE, c.COM_NAME, s.SALES_COM_CODE, w.ITEM_CODE, i.ITEM_NAME, convert(nvarchar, s.SALES_DUEDATE, 23) SALES_DUEDATE, w.WO_PLAN_QTY, 
	   (select isnull(sum(case when INS_TYP = '출고' then INS_QTY end), 0)
		from INSTACK 
		where SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = ii.INS_WRHS) as OUTed_QTY, w.WO_PLAN_QTY,
	   (select isnull(sum(case when INS_TYP = '출고' then INS_QTY end), 0)
		from INSTACK 
		where SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = ii.INS_WRHS) * 
	   (select top 1 MC_UNITPRICE_CUR 
		from MATERIAL_COST
		where ITEM_Code = w.ITEM_CODE
		order by MC_ENDDATE desc) as EndPrice
from WORKORDER w inner join SALES_WORK s on w.SALES_WORK_ORDER_ID = s.SALES_Work_Order_ID
				 inner join COMPANY c on s.COM_CODE = c.COM_CODE
				 inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
				 inner join INSTACK ii on w.ITEM_CODE = ii.ITEM_CODE
				 inner join MATERIAL_COST m on w.ITEM_CODE = m.ITEM_Code
where ii.INS_WRHS = 'M_01' and (w.WO_WORK_STATE = '마감완료' or w.WO_WORK_STATE = '마감중') and ii.INS_TYP = '출고'
group by w.SALES_WORK_ORDER_ID, s.COM_CODE, c.COM_NAME, s.SALES_COM_CODE, w.ITEM_CODE, i.ITEM_NAME, s.SALES_DUEDATE, w.WO_PLAN_QTY, ii.INS_WRHS
order by SALES_DUEDATE";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<SalesEnd_VO>(reader);
                return list;
            }
        }
    }
}
