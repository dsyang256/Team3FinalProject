using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //참조
using System.Data.SqlClient;
using TEAM3FINALVO;

namespace TEAM3FINALDAC
{
    public class ComboItemDAC : ConnectionAccess
    {
        /// <summary>
        /// 전체 공통코드 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<ComboItemVO> GetCmCode()
        {
            List<ComboItemVO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select COMMON_CODE, COMMON_NAME, COMMON_PARENT, COMMON_SEQ
                            from dbo.COMMON
                            where 1=1 ";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<ComboItemVO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;
        }

        public List<ComboItemVO> GetFacilitiesCode()
        {
            List<ComboItemVO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select [FCLTS_CODE] COMMON_CODE, [FCLTS_NAME] COMMON_NAME, null COMMON_PARENT, null COMMON_SEQ
                                                        from [dbo].[FACILITY]
                                                        where 1=1 ";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<ComboItemVO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;
        }

        /// <summary>
        /// 업체 목록 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<ComboItemVO> GetCompanyCode()
        {
            List<ComboItemVO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select [COM_CODE] COMMON_CODE,[COM_NAME] COMMON_NAME,null COMMON_PARENT, null COMMON_SEQ
                                                        from [dbo].[COMPANY]
                                                        where 1=1
                                                        ";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<ComboItemVO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;
        }

        /// <summary>
        /// 품목 목록 가져오는 메서드
        /// </summary>
        /// <returns></returns>
        public List<ComboItemVO> GetItemCode()
        {
            List<ComboItemVO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select [ITEM_CODE] COMMON_CODE,[ITEM_NAME] COMMON_NAME,null COMMON_PARENT, null COMMON_SEQ
                                                      from [dbo].ITEM
                                                      where 1=1 ";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<ComboItemVO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;
        }

































        public List<COMMON_VO> GetAllCmCode()
        {
            List<COMMON_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select ROW_NUMBER() OVER(ORDER BY(SELECT 1)) idx,COMMON_CODE, COMMON_NAME, COMMON_PARENT, COMMON_SEQ
                            from dbo.COMMON
                            where 1=1 ";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<COMMON_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;
        }

        public bool CodeDelete(string text)
        {

            bool Result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"delete 
                                           from COMMON
                                          where COMMON_PARENT = @COMMON_CODE

                                         delete 
                                           from COMMON
                                          where COMMON_CODE = @COMMON_CODE";
                    cmd.Parameters.AddWithValue("@COMMON_CODE", text);

                    cmd.Connection.Open();
                    int iResult = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return (iResult > 0) ? true : false;
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return Result;
            }
        }

        public bool CheckCodeName(string name)
        {
            bool Result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select COUNT(COMMON_CODE)
                                           from dbo.COMMON
                                          where COMMON_NAME = @COMMON_NAME";
                    cmd.Parameters.AddWithValue("@COMMON_NAME", name);
                    cmd.Connection.Open();
                    int iResult = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Connection.Close();
                    return (iResult > 0) ? true : false;
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return Result;
            }
        }

        public bool CodeNameInsert(string code, string name, int SEQ)
        {
            bool Result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"INSERT INTO COMMON (COMMON_CODE, COMMON_NAME,COMMON_PARENT, COMMON_SEQ)
                                              VALUES(@COMMON_CODE, @COMMON_NAME,@COMMON_PARENT,@COMMON_SEQ) ";
                    cmd.Parameters.AddWithValue("@COMMON_CODE", code + "_" + name);
                    cmd.Parameters.AddWithValue("@COMMON_NAME", name);
                    cmd.Parameters.AddWithValue("@COMMON_PARENT", code);
                    cmd.Parameters.AddWithValue("@COMMON_SEQ", SEQ);
                    cmd.Connection.Open();
                    int iResult = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return (iResult > 0) ? true : false;
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return Result;
            }
        }

        public List<ComboItemVO> GetITEMCmCode()
        {
            List<ComboItemVO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"SELECT MANAGER_ID 'COMMON_CODE',MANAGER_NAME 'COMMON_NAME', ('담당자')'COMMON_PARENT', null 'COMMON_SEQ'
                                         FROM MANAGER

                                         Union

                                         SELECT COM_CODE 'COMMON_CODE',COM_NAME 'COMMON_NAME', ('업체명')'COMMON_PARENT', null 'COMMON_SEQ'
                                         FROM COMPANY

                                         Union

                                         SELECT COMMON_CODE, COMMON_NAME, COMMON_PARENT, COMMON_SEQ
                                         FROM COMMON

                                         Union

                                         SELECT FAC_CODE 'COMMON_CODE',FAC_NAME 'COMMON_NAME', ('창고')'COMMON_PARENT', null 'COMMON_SEQ'
                                          FROM FACTORY
                                         WHERE FAC_TYP = '창고'

                                         Union

                                         SELECT ITEM_CODE 'COMMON_CODE',ITEM_NAME 'COMMON_NAME', ('품목')'COMMON_PARENT', null 'COMMON_SEQ'
                                         FROM ITEM ";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<ComboItemVO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;
        }
        public bool CheckCode(string code)
        {
            bool Result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select COUNT(COMMON_CODE)
                                           from dbo.COMMON
                                          where COMMON_CODE = @COMMON_CODE";
                    cmd.Parameters.AddWithValue("@COMMON_CODE", code);
                    cmd.Connection.Open();
                    int iResult = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Connection.Close();
                    return (iResult > 0) ? true : false;
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return Result;
            }
;
        }
        public bool CodeInsert(string code)
        {
            bool Result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"INSERT INTO COMMON (COMMON_CODE, COMMON_NAME, COMMON_SEQ)
                                              VALUES(@COMMON_CODE, @COMMON_NAME,1) ";
                    cmd.Parameters.AddWithValue("@COMMON_CODE", code);
                    cmd.Parameters.AddWithValue("@COMMON_NAME", code);
                    cmd.Connection.Open();
                    int iResult = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    return (iResult > 0) ? true : false;
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return Result;
            }
;
        }

    }
}