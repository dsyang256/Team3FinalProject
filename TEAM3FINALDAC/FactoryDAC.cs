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
    public class FactoryDAC : ConnectionAccess
    {
        //데이터 insert
        public Message SaveFactory(FACTORY_VO fac, bool update)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_SaveFactory";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_UPDATE", update);
                    cmd.Parameters.AddWithValue("@P_FAC_CODE", fac.FAC_CODE);
                    cmd.Parameters.AddWithValue("@P_FAC_FCLTY", fac.FAC_FCLTY);
                    cmd.Parameters.AddWithValue("@P_FAC_FCLTY_PARENT", fac.FAC_FCLTY_PARENT);
                    cmd.Parameters.AddWithValue("@P_FAC_NAME", fac.FAC_NAME);
                    cmd.Parameters.AddWithValue("@P_FAC_TYP", fac.FAC_TYP);
                    cmd.Parameters.AddWithValue("@P_FAC_FREE_YN", fac.FAC_FREE_YN);
                    cmd.Parameters.Add(new SqlParameter("@P_FAC_TYP_SORT", System.Data.SqlDbType.Int));
                    cmd.Parameters["@P_FAC_TYP_SORT"].Value = (object)fac.FAC_TYP_SORT ?? DBNull.Value;
                    cmd.Parameters.AddWithValue("@P_FAC_DEMAND_YN", fac.FAC_DEMAND_YN);
                    cmd.Parameters.AddWithValue("@P_FAC_PROCS_YN", fac.FAC_PROCS_YN);
                    cmd.Parameters.AddWithValue("@P_FAC_MTRL_YN", fac.FAC_MTRL_YN);
                    cmd.Parameters.AddWithValue("@P_FAC_LAST_MDFR", fac.FAC_LAST_MDFR);
                    cmd.Parameters.AddWithValue("@P_FAC_LAST_MDFY", fac.FAC_LAST_MDFY);
                    cmd.Parameters.AddWithValue("@P_FAC_USE_YN", fac.FAC_USE_YN);
                    cmd.Parameters.AddWithValue("@P_FAC_DESC", fac.FAC_DESC);
                    cmd.Parameters.AddWithValue("@P_COM_NAME", fac.COM_NAME);
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
                    else if (result == "S02")
                    {
                        message.IsSuccess = true;
                        message.ResultMessage = "성공적으로 수정되었습니다.";
                    }
                    else if (result == "S03")
                    {
                        message.IsSuccess = false;
                        message.ResultMessage = "코드 중복";
                    }
                    else if (result == "S00")
                    {
                        message.IsSuccess = false;
                        message.ResultMessage = "실패하였습니다.";
                    }

                    return message;
                }
            }
            catch(Exception err)
            {
                return new Message(err);
            }
        }

        //FrmFactoryManage 로드 시 dgv에 뿌려줌
        public List<FACTORY_VO> GetFactoryInfo()
        {
            List<FACTORY_VO> list = default;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select FAC_CODE, FAC_FCLTY, FAC_FCLTY_PARENT, FAC_NAME, FAC_TYP, FAC_FREE_YN, FAC_TYP_SORT, FAC_DEMAND_YN, FAC_PROCS_YN, FAC_MTRL_YN, FAC_LAST_MDFR, convert(varchar, FAC_LAST_MDFY, 120) FAC_LAST_MDFY, FAC_USE_YN, FAC_DESC, c.COM_NAME
from FACTORY f left outer join COMPANY c on f.COM_CODE = c.COM_CODE";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();                
                list = Helper.DataReaderMapToList<FACTORY_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        /// <summary>
        /// 하나의 테이블에 여러 항목을 삭제할 경우 사용하는 메서드
        /// appendcode의 경우 사용자 입력값을 건드릴 수도 있으므로 보안상 파라미터를 사용하여 처리
        /// </summary>
        /// <param name="table"></param>
        /// <param name="pkCode"></param>
        /// <param name="appendCode"></param>
        /// <returns> ture || false </returns>
        public Message DeleteFactory(string table, string pkCode, StringBuilder appendCode)
        {
            try
            {
                string str = appendCode.ToString();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"delete from {table} where {pkCode} IN (SELECT * FROM[dbo].[SplitString](@appendCode, '@'))";
                    cmd.Parameters.AddWithValue("@appendCode", str);
                    cmd.Connection.Open();
                    int iResult = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    Message message = new Message();
                    if (iResult > 0)
                    {
                        message.IsSuccess = true;
                        message.ResultMessage = "성공적으로 삭제되었습니다.";
                    }
                    else
                    {
                        message.IsSuccess = false;
                        message.ResultMessage = "실패하였습니다";
                    }

                    return message;
                }
            }
            catch(Exception err)
            {
                return new Message(err);
            }
        }

        public List<FACTORY_VO> GetSearchFactoryInfo(string facCode, string type)
        {
            List<FACTORY_VO> list = null;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_GetSearchFactoryInfo";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_FAC_CODE", facCode);
                cmd.Parameters.AddWithValue("@P_FAC_FCLTY", type);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<FACTORY_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
    }
}
