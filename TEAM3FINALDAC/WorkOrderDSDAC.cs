using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TEAM3FINALDAC
{
    public class WorkOrderDSDAC : ConnectionAccess
    {
        public DataTable GetWorkOrder()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,WO_PLAN_DATE,WO_Code,f.FCLTS_NAME,fa.FAC_NAME,w.ITEM_CODE,i.ITEM_NAME,w.WO_PLAN_QTY,i.ITEM_UNIT,w.WO_WORK_STATE
                             FROM WORKORDER w,FACILITY f,FACTORY fa,ITEM i 
                            WHERE w.FCLTS_CODE = f.FCLTS_CODE and f.FCLTS_WRHS_EXHST = fa.FAC_CODE and w.ITEM_CODE = i.ITEM_CODE and w.WO_WORK_STATE = '작업지시'";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {

                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetWorkOrder2(string code)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,m.ITEM_CODE,i.ITEM_NAME,i.ITEM_STND,fa.FAC_NAME,CONVERT(CHAR(10), GETDATE(), 23) as Date

                           ,((select isnull(sum(INS_QTY),0)
                           from INSTACK 
                           where INS_TYP = '입고' and SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = f.FCLTS_WRHS_EXHST and ITEM_CODE = m.ITEM_CODE)-
                           (select isnull(sum(INS_QTY),0)
                           from INSTACK 
                           where INS_TYP = '출고' and SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = f.FCLTS_WRHS_EXHST and ITEM_CODE = m.ITEM_CODE)) as 현재고
                           
                           ,I.ITEM_QTY_STND as 표준불출수량
                           ,w.WO_PLAN_QTY
                           ,f.FCLTS_WRHS_GOOD
                           ,w.SALES_WORK_ORDER_ID
                           ,f.FCLTS_WRHS_EXHST
                           
                           ,(select isnull(sum(INS_QTY),0) 
                           from INSTACK 
                           where INS_TYP = '출고' and SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = f.FCLTS_WRHS_EXHST and ITEM_CODE = m.ITEM_CODE) as 출고
                           
                           ,(W.WO_PLAN_QTY - (select isnull(sum(INS_QTY),0) 
                           from INSTACK 
                           where INS_TYP = '출고' and SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = f.FCLTS_WRHS_EXHST and ITEM_CODE = m.ITEM_CODE)) as 잔량
                           
                           FROM BOM m
                           , WORKORDER w
                           ,ITEM i
                           ,FACILITY f
                           ,FACTORY fa
                           WHERE
                           f.FCLTS_WRHS_GOOD = fa.FAC_CODE
                           and w.FCLTS_CODE = f.FCLTS_CODE 
                           and m.ITEM_CODE = i.ITEM_CODE 
                           and m.BOM_PARENT_CODE = w.ITEM_CODE 
                           and w.WO_WORK_STATE = '작업지시'
                           and m.BOM_PARENT_CODE = @code";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@code", code);
                da.Fill(dt);
            }
            return dt;
        }
       
    }
}
