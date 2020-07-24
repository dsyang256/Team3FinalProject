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
    public class ITEMDAC : ConnectionAccess
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
                    cmd.CommandText = @"select ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,ITEM_CODE, ITEM_NAME, ITEM_STND, ITEM_UNIT, ITEM_QTY_UNIT, ITEM_TYP, ITEM_INCOME_YN, ITEM_PROCS_YN, ITEM_XPORT_YN, ITEM_FREE_YN, ITEM_COM_DLVR, ITEM_COM_REORDER, ITEM_WRHS_IN, ITEM_WRHS_OUT, ITEM_LEADTIME, ITEM_QTY_REORDER_MIN, ITEM_QTY_STND, ITEM_QTY_SAFE, ITEM_MANAGE_LEVEL, ITEM_MANAGER, ITEM_UNIT_CNVR, ITEM_QTY_CNVR, ITEM_LAST_MDFR, CONVERT(CHAR(10), ITEM_LAST_MDFY, 23)ITEM_LAST_MDFY, ITEM_USE_YN, ITEM_DSCN_YN, ITEM_GROUP, ITEM_REORDER_TYP, ITEM_REMARK
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
        public string SaveItem(ITEM_VO vo,int code)
        {
            string result;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                     AESSalt salt = new AESSalt();
                     cmd.Connection = new SqlConnection(this.ConnectionString);
                     cmd.CommandText = "SaveItem";
                     cmd.CommandType = CommandType.StoredProcedure;
                     cmd.Parameters.AddWithValue("@P_ITEM_CODE",vo.ITEM_CODE);
                     cmd.Parameters.AddWithValue("@P_ITEM_NAME",vo.ITEM_NAME);
                     cmd.Parameters.AddWithValue("@P_ITEM_STND",vo.ITEM_STND);
                     cmd.Parameters.AddWithValue("@P_ITEM_UNIT",vo.ITEM_UNIT);
                     cmd.Parameters.AddWithValue("@P_ITEM_QTY_UNIT",vo.ITEM_QTY_UNIT);
                     cmd.Parameters.AddWithValue("@P_ITEM_TYP",vo.ITEM_TYP);
                     cmd.Parameters.AddWithValue("@P_ITEM_INCOME_YN",vo.ITEM_INCOME_YN);
                     cmd.Parameters.AddWithValue("@P_ITEM_PROCS_YN",vo.ITEM_PROCS_YN);
                     cmd.Parameters.AddWithValue("@P_ITEM_XPORT_YN",vo.ITEM_XPORT_YN);
                     cmd.Parameters.AddWithValue("@P_ITEM_FREE_YN",vo.ITEM_FREE_YN);
                     cmd.Parameters.AddWithValue("@P_ITEM_COM_DLVR",vo.ITEM_COM_DLVR);
                     cmd.Parameters.AddWithValue("@P_ITEM_COM_REORDER",vo.ITEM_COM_REORDER);
                     cmd.Parameters.AddWithValue("@P_ITEM_WRHS_IN",vo.ITEM_WRHS_IN);
                     cmd.Parameters.AddWithValue("@P_ITEM_WRHS_OUT",vo.ITEM_WRHS_OUT);
                     cmd.Parameters.AddWithValue("@P_ITEM_LEADTIME",vo.ITEM_LEADTIME);
                     cmd.Parameters.AddWithValue("@P_ITEM_QTY_REORDER_MIN",vo.ITEM_COM_REORDER);
                     cmd.Parameters.AddWithValue("@P_ITEM_QTY_STND",vo.ITEM_QTY_STND);
                     cmd.Parameters.AddWithValue("@P_ITEM_QTY_SAFE",vo.ITEM_QTY_SAFE);
                     cmd.Parameters.AddWithValue("@P_ITEM_MANAGE_LEVEL",vo.ITEM_MANAGE_LEVEL);
                     cmd.Parameters.AddWithValue("@P_ITEM_MANAGER",vo.ITEM_MANAGER);
                     cmd.Parameters.AddWithValue("@P_ITEM_UNIT_CNVR",vo.ITEM_UNIT_CNVR);
                     cmd.Parameters.AddWithValue("@P_ITEM_QTY_CNVR",vo.ITEM_QTY_CNVR);
                     cmd.Parameters.AddWithValue("@P_ITEM_LAST_MDFR",vo.ITEM_LAST_MDFR);
                     cmd.Parameters.AddWithValue("@P_ITEM_USE_YN",vo.ITEM_USE_YN);
                     cmd.Parameters.AddWithValue("@P_ITEM_DSCN_YN",vo.ITEM_DSCN_YN);
                     cmd.Parameters.AddWithValue("@P_ITEM_REORDER_TYP",vo.ITEM_REORDER_TYP);
                     cmd.Parameters.AddWithValue("@P_ITEM_REMARK",vo.ITEM_REMARK);
                     cmd.Parameters.AddWithValue("@P_INSERT_YN",code);

                    cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", SqlDbType.NVarChar, 5));
                    cmd.Parameters["@P_ReturnCode"].Direction = ParameterDirection.Output;

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close(); 
                    result = cmd.Parameters["@P_ReturnCode"].Value.ToString();
                    return result;
                }
            }
            catch (Exception err)
            {
                return result = "C201";
            }


        }

        public List<ITEM_VO> GetSearchItem(ITEM_VO vo)
        {
            List<ITEM_VO> list = default;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    AESSalt salt = new AESSalt();
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_GetSearchItem";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_ITEM_NAME", vo.ITEM_NAME);
                    cmd.Parameters.AddWithValue("@P_ITEM_STND", vo.ITEM_STND);
                    cmd.Parameters.AddWithValue("@P_ITEM_COM_REORDER", vo.ITEM_COM_REORDER);
                    cmd.Parameters.AddWithValue("@P_ITEM_COM_DLVR", vo.ITEM_COM_DLVR);
                    cmd.Parameters.AddWithValue("@P_ITEM_WRHS_IN", vo.ITEM_WRHS_IN);
                    cmd.Parameters.AddWithValue("@P_ITEM_WRHS_OUT", vo.ITEM_WRHS_OUT);
                    cmd.Parameters.AddWithValue("@P_ITEM_MANAGER", vo.ITEM_MANAGER);
                    cmd.Parameters.AddWithValue("@P_ITEM_TYP", vo.ITEM_TYP);
                    cmd.Parameters.AddWithValue("@P_ITEM_USE_YN", vo.ITEM_USE_YN);

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
