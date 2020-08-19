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
    public class SalesComDAC : ConnectionAccess
    {
        public List<SalesCOM_VO> GetSalesCom()
        {
            List<SalesCOM_VO> list = null;

            using(SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select s.SALES_COM_CODE, c.COM_NAME, c.COM_REG_NUM, sum(s.SALES_TTL) SALES_TTL
                                    from SALES_RECORD s inner join COMPANY c on s.SALES_COM_CODE = c.COM_CODE
                                    where month(s.SALES_ENDDATE) = month(GETDATE()) and year(s.SALES_ENDDATE) = year(GETDATE())
                                    group by s.SALES_COM_CODE, c.COM_NAME, c.COM_REG_NUM";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<SalesCOM_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public List<SalesCOMDedail_VO> GetSalesComDetail()
        {
            List<SalesCOMDedail_VO> list = null;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select s.SALES_COM_CODE, c.COM_NAME, convert(nvarchar , s.SALES_ENDDATE, 23) SALES_ENDDATE, s.SALES_QTY, (SALES_TTL / s.SALES_QTY) as unitprice, s.SALES_TTL
from SALES_RECORD s inner join COMPANY c on s.SALES_COM_CODE = c.COM_CODE
where month(s.SALES_ENDDATE) = month(GETDATE()) and year(s.SALES_ENDDATE) = year(GETDATE())";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<SalesCOMDedail_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public List<SalesCOM_VO> SearchSalesCom(string date, string company)
        {
            List<SalesCOM_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SearchSalesCom";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_SALES_COM_CODE", company);
                cmd.Parameters.AddWithValue("@P_SALES_ENDDATE", date);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<SalesCOM_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public List<SalesCOMDedail_VO> SearchSalesComDetail(string date, string company)
        {
            List<SalesCOMDedail_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SearchSalesComDetail";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_SALES_COM_CODE", company);
                cmd.Parameters.AddWithValue("@P_SALES_ENDDATE", date);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<SalesCOMDedail_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
    }
}
