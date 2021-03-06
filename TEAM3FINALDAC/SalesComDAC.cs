﻿using System;
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

        #region 거래처별월마감

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

        #endregion


        #region 거래처별월마감2

        public List<SalesCOMDedail2_VO> GetSalesComDetail2()
        {
            List<SalesCOMDedail2_VO> list = null;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select it.ITEM_COM_DLVR, it.ITEM_COM_REORDER, convert(nvarchar, i.INS_DATE, 23) INS_DATE, i.INS_TYP, f.FAC_NAME, i.ITEM_CODE, i.INS_QTY, 
	   (select MC_UNITPRICE_CUR from MATERIAL_COST
	    where ITEM_Code = it.ITEM_CODE and MC_STARTDATE <= INS_DATE and MC_ENDDATE >= INS_DATE) MC_UNITPRICE_CUR, (i.INS_QTY * (select MC_UNITPRICE_CUR from MATERIAL_COST
	    where ITEM_Code = it.ITEM_CODE and MC_STARTDATE <= INS_DATE and MC_ENDDATE >= INS_DATE)) TTLPRICE
from INSTACK i inner join item it on i.ITEM_CODE = it.ITEM_CODE
			   inner join FACTORY f on i.INS_WRHS = f.FAC_CODE
where (INS_WRHS = 'R-01' or INS_WRHS = 'OS') and i.INS_TYP = '입고'";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<SalesCOMDedail2_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public List<SalesCOM2_VO> GetSalesCom2()
        {
            List<SalesCOM2_VO> list = null;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"with A as (
select it.ITEM_COM_DLVR, it.ITEM_COM_REORDER, convert(nvarchar, i.INS_DATE, 23) INS_DATE, i.INS_TYP, f.FAC_NAME, i.ITEM_CODE, i.INS_QTY, 
	   (select MC_UNITPRICE_CUR from MATERIAL_COST
	    where ITEM_Code = it.ITEM_CODE and MC_STARTDATE <= INS_DATE and MC_ENDDATE >= INS_DATE) MC_UNITPRICE_CUR, (i.INS_QTY * (select MC_UNITPRICE_CUR from MATERIAL_COST
	    where ITEM_Code = it.ITEM_CODE and MC_STARTDATE <= INS_DATE and MC_ENDDATE >= INS_DATE)) TTLPRICE
from INSTACK i inner join item it on i.ITEM_CODE = it.ITEM_CODE
			   inner join FACTORY f on i.INS_WRHS = f.FAC_CODE
where (INS_WRHS = 'R-01' or INS_WRHS = 'OS') and i.INS_TYP = '입고'
)
select c.COM_CODE, A.ITEM_COM_DLVR, c.COM_REG_NUM, sum(A.TTLPRICE) TTLPRICE
from A inner join COMPANY c on A.ITEM_COM_DLVR = c.COM_NAME
group by c.COM_CODE, A.ITEM_COM_DLVR, c.COM_REG_NUM";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<SalesCOM2_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public List<SalesCOMDedail2_VO> SearchSalesComDetail2(string date, string company)
        {
            List<SalesCOMDedail2_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SearchSalesComDetail2";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_SALES_COM_CODE", company);
                cmd.Parameters.AddWithValue("@P_SALES_ENDDATE", date);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<SalesCOMDedail2_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public List<SalesCOM2_VO> SearchSalesCom2(string date, string company)
        {
            List<SalesCOM2_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SearchSalesCom2";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_SALES_COM_CODE", company);
                cmd.Parameters.AddWithValue("@P_SALES_ENDDATE", date);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<SalesCOM2_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }


        #endregion
    }
}
