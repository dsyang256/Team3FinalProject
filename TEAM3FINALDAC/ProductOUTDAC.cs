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
    public class ProductOUTDAC : ConnectionAccess
    {
        public List<ProductOUT_VO> GetProductOUTList()
        {
            List<ProductOUT_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select w.SALES_WORK_ORDER_ID, s.COM_CODE, c.COM_NAME, s.SALES_COM_CODE, w.ITEM_CODE, i.ITEM_NAME, convert(nvarchar, s.SALES_DUEDATE, 23) SALES_DUEDATE, w.WO_PLAN_QTY, 
	                                       sum(case when INS_TYP = '출고' then (INS_QTY*-1) when INS_TYP = '입고' then INS_QTY end) INS_QTY
                                    from WORKORDER w inner join SALES_WORK s on w.SALES_WORK_ORDER_ID = s.SALES_Work_Order_ID
				                                     inner join COMPANY c on s.COM_CODE = c.COM_CODE
				                                     inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
				                                     inner join INSTACK ii on w.ITEM_CODE = ii.ITEM_CODE
                                    where INS_WRHS = 'M_01'
                                    group by w.SALES_WORK_ORDER_ID, s.COM_CODE, c.COM_NAME, s.SALES_COM_CODE, w.ITEM_CODE, i.ITEM_NAME, s.SALES_DUEDATE, w.WO_PLAN_QTY";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<ProductOUT_VO>(reader);
                return list;
            }
        }
    }
}
