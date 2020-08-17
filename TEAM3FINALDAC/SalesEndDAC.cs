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
        #region 마감
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


        public Message SalesRecord(SalesEndState_VO vo, string name)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SalesRecord";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_SALES_WORK_ORDER_ID", vo.SALES_WORK_ORDER_ID);
                cmd.Parameters.AddWithValue("@P_SALES_COM_CODE", vo.SALES_COM_CODE);
                cmd.Parameters.AddWithValue("@P_ITEM_CODE", vo.ITEM_CODE);
                cmd.Parameters.AddWithValue("@P_SALES_DUEDATE", vo.SALES_DUEDATE);
                cmd.Parameters.AddWithValue("@P_SALES_QTY", vo.SALES_QTY);
                cmd.Parameters.AddWithValue("@P_SALES_TTL", vo.SALES_TTL);
                cmd.Parameters.AddWithValue("@P_WO_LAST_MDFR", name);
                cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", System.Data.SqlDbType.NVarChar, 5));
                cmd.Parameters["@P_ReturnCode"].Direction = System.Data.ParameterDirection.Output;

                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                string result = cmd.Parameters["@P_ReturnCode"].Value.ToString();

                Message message = new Message();
                if (result == "S01")
                {
                    message.IsSuccess = true;
                    message.ResultMessage = "성공적으로 등록되었습니다.";
                }
                else if (result == "S00")
                {
                    message.IsSuccess = false;
                    message.ResultMessage = "실패하였습니다.";
                }

                return message;
            }
        }

        #endregion


        #region 마감현황

        public List<SalesEndState_VO> GetSalesEndState()
        {
            List<SalesEndState_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select s.SALES_WORK_ORDER_ID, s.SALES_COM_CODE, c.COM_NAME, s.ITEM_CODE, i.ITEM_NAME, SALES_QTY, SALES_TTL, convert(nvarchar, SALES_DUEDATE, 23) SALES_DUEDATE,
	                                       convert(nvarchar, SALES_ENDDATE, 23) SALES_ENDDATE, convert(nvarchar, SALES_CANCELDATE, 23) SALES_CANCELDATE
                                    from SALES_RECORD s inner join ITEM i on s.ITEM_CODE = i.ITEM_CODE
					                                    inner join COMPANY c on s.SALES_COM_CODE = c.COM_CODE";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<SalesEndState_VO>(reader);
                return list;
            }
        }



        #endregion
    }
}
