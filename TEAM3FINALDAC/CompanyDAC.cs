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
    public class CompanyDAC : ConnectionAccess
    {
        public List<COMPANY_VO> GetCompanyList()
        {
            List<COMPANY_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select COM_CODE, COM_NAME, COM_TYP, COM_CEO, COM_REG_NUM, COM_TYP_INDSTRY, COM_TYP_BSNS, COM_MANAGER, COM_EML, COM_TEL, COM_FAX, COM_AUTOIN_YN, COM_START_YN, COM_USE_YN, COM_LAST_MDFR, convert(nvarchar, COM_LAST_MDFY, 120) COM_LAST_MDFY, convert(nvarchar, COM_STR_DATE, 120) COM_STR_DATE, convert(nvarchar, COM_END_DATE, 120) COM_END_DATE, COM_INFO, COM_TRAD_YN
                                    from COMPANY";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<COMPANY_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }

        public Message SaveCompany(COMPANY_VO vo, bool update)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_SaveCompany";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@P_COM_CODE", update);
                    cmd.Parameters.AddWithValue("@P_FAC_CODE", vo.COM_CODE);
                    cmd.Parameters.AddWithValue("@P_COM_NAME", vo.COM_NAME);
                    cmd.Parameters.AddWithValue("@P_COM_TYP", vo.COM_TYP);
                    cmd.Parameters.AddWithValue("@P_COM_CEO", vo.COM_CEO);
                    cmd.Parameters.AddWithValue("@P_COM_REG_NUM", vo.COM_REG_NUM);
                    cmd.Parameters.AddWithValue("@P_COM_TYP_INDSTRY", vo.COM_TYP_INDSTRY);
                    cmd.Parameters.AddWithValue("@P_FAC_CODE", vo.COM_CODE);
                    cmd.Parameters.AddWithValue("@P_COM_TYP_BSNS", vo.COM_TYP_BSNS);
                    cmd.Parameters.AddWithValue("@P_COM_MANAGER", vo.COM_MANAGER);
                    cmd.Parameters.AddWithValue("@P_COM_EML", vo.COM_EML);
                    cmd.Parameters.AddWithValue("@P_COM_TEL", vo.COM_TEL);
                    cmd.Parameters.AddWithValue("@P_COM_STR_DATE", vo.COM_STR_DATE);
                    cmd.Parameters.AddWithValue("@P_COM_END_DATE", vo.COM_END_DATE);
                    cmd.Parameters.AddWithValue("@P_COM_TRAD_YN", vo.COM_TRAD_YN);
                    cmd.Parameters.AddWithValue("@P_COM_FAX", vo.COM_FAX);
                    cmd.Parameters.AddWithValue("@P_COM_AUTOIN_YN", vo.COM_AUTOIN_YN);
                    cmd.Parameters.AddWithValue("@P_COM_START_YN", vo.COM_START_YN);
                    cmd.Parameters.AddWithValue("@P_COM_USE_YN", vo.COM_USE_YN);
                    cmd.Parameters.AddWithValue("@P_FAC_CODE", vo.COM_CODE);
                    cmd.Parameters.AddWithValue("@P_COM_INFO", vo.COM_INFO);
                    cmd.Parameters.AddWithValue("@P_COM_LAST_MDFR", vo.COM_LAST_MDFR);
                    cmd.Parameters.AddWithValue("@P_COM_LAST_MDFY", vo.COM_LAST_MDFY);
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

        public List<COMPANY_VO> SearchCompany(string comCode, string comName, string comType, string regNum)
        {
            List<COMPANY_VO> list = null;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = "SP_SearchCompany";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@P_COM_CODE", comCode);
                cmd.Parameters.AddWithValue("@P_COM_NAME", comName);
                cmd.Parameters.AddWithValue("@P_COM_TYP", comType);
                cmd.Parameters.AddWithValue("@P_COM_REG_NUM", regNum);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<COMPANY_VO>(reader);
                cmd.Connection.Close();
                return list;
            }
        }
    }
}
