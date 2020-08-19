using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TEAM3FINALVO;

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

        public DataTable POPDGV1()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,WO_Code,ITEM_CODE,WO_PLAN_QTY,WO_WORK_STATE
                             FROM WORKORDER
                            WHERE WO_WORK_STATE ='작업지시'";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {

                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ComboBinding(string v)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"  SELECT WO_Code
                               FROM WORKORDER
                               where WO_WORK_STATE = '작업지시' and FCLTS_CODE = @FCLTS_CODE";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@FCLTS_CODE", v);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ControlDgv(string code)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"select m.ITEM_CODE ,w.WO_PLAN_QTY as 생산필요량
                                         ,(select isnull(sum(i.INS_QTY),0) qty
                                         from INSTACK i 
                                         where i.SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and i.INS_TYP = '입고' and i.INS_WRHS = t.ITEM_WRHS_IN and ITEM_CODE = m.ITEM_CODE) as 현재고
                                         ,m.BOM_QTY
                                         ,m.BOM_PARENT_CODE
                                         ,isnull(w.WO_QTY_BAD,0) as 불량수량
                                         ,isnull(w.WO_QTY_PROD,0) as 생산수량
                                         ,isnull(w.WO_QTY_OUT,0) as 양품수량
 
                                         
                                         from BOM m ,WORKORDER w,ITEM t,BOM_QTY q
                                         where m.BOM_PARENT_CODE = w.ITEM_CODE
                                         and WO_Code = @WO_Code 
                                         and M.ITEM_CODE = t.ITEM_CODE
                                         and m.ITEM_CODE = q.ITEM_CODE";
                                                     conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@WO_Code", code);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable POPDGVselect1(string v)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"  SELECT WO_Code,ITEM_CODE,PLAN_ID,f.FCLTS_NAME,WO_PLAN_QTY,WO_QTY_IN,WO_QTY_OUT,WO_QTY_PROD,WO_QTY_BAD
                               FROM  WORKORDER w, FACILITY f
                              WHERE w.FCLTS_CODE = f.FCLTS_CODE
                                AND WO_Code = @WO_Code";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@WO_Code", v);
                da.Fill(dt);
            }
            return dt;
        }
        public List<POPVO> POPFACILITY()
        {
            List<POPVO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"   SELECT POP_CODE, FCLTS_CODE, FCLTS_NAME, FCLTS_IP, FCLTS_PORT
                                                    FROM POP";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<POPVO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;
        }

        public DataTable POPDGVselect(string day1, string day2, string fac, string facg)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter("SP_POPDGVselect", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@P_day1", day1);
                da.SelectCommand.Parameters.AddWithValue("@P_day2", day2);
                da.SelectCommand.Parameters.AddWithValue("@P_fac", fac);
                da.SelectCommand.Parameters.AddWithValue("@P_facg", facg);
                da.Fill(dt);
            }
            return dt;
        }


        public DataTable GetWorkOrder2(string code,string id)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            string sql = @"SELECT ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,m.ITEM_CODE,i.ITEM_NAME,i.ITEM_STND,fa.FAC_NAME,CONVERT(CHAR(10), GETDATE(), 23) as Date

                           ,((select isnull(sum(INS_QTY),0)
                           from INSTACK 
                           where INS_TYP = '입고' and SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = i.ITEM_WRHS_IN and ITEM_CODE = m.ITEM_CODE)-
                           (select isnull(sum(INS_QTY),0)
                           from INSTACK 
                           where INS_TYP = '출고' and SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = i.ITEM_WRHS_IN and ITEM_CODE = m.ITEM_CODE)) as 현재고
                           
                           ,I.ITEM_QTY_STND as 표준불출수량
                           ,w.WO_PLAN_QTY
                           ,f.FCLTS_WRHS_GOOD
                           ,w.SALES_WORK_ORDER_ID
                           ,i.ITEM_WRHS_IN
                           
                           ,(select isnull(sum(INS_QTY),0) 
                           from INSTACK 
                           where INS_TYP = '출고' and SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = i.ITEM_WRHS_IN and ITEM_CODE = m.ITEM_CODE) as 출고
                           
                           ,(W.WO_PLAN_QTY - (select isnull(sum(INS_QTY),0) 
                           from INSTACK 
                           where INS_TYP = '출고' and SALES_WORK_ORDER_ID = w.SALES_WORK_ORDER_ID and INS_WRHS = i.ITEM_WRHS_IN and ITEM_CODE = m.ITEM_CODE)) as 잔량
                           
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
                           and m.BOM_PARENT_CODE = @code
						   and w.WO_Code = @WO_Code
                           and i.ITEM_TYP = '원자재'";
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@code", code);
                da.SelectCommand.Parameters.AddWithValue("@WO_Code", id);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable SP_GetWorkOrder(string sday, string eday, string code, string item, string name)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(this.ConnectionString);
            conn.Open();
            using (SqlDataAdapter da = new SqlDataAdapter("SP_GetWorkOrder", conn))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@P_DATE_IN_S", sday);
                da.SelectCommand.Parameters.AddWithValue("@P_DATE_IN_E", eday);
                da.SelectCommand.Parameters.AddWithValue("@P_WO_Code", code);
                da.SelectCommand.Parameters.AddWithValue("@P_ITEM_NAME", item);
                da.SelectCommand.Parameters.AddWithValue("@P_FCLTS_NAME", name);
                da.Fill(dt);
            }
            return dt;
        }

    }
}
