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

        public bool CodeNameInsert(string code, string name,int SEQ)
        {
            bool Result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"INSERT INTO COMMON (COMMON_CODE, COMMON_NAME,COMMON_PARENT, COMMON_SEQ)
                                              VALUES(@COMMON_CODE, @COMMON_NAME,@COMMON_PARENT,@COMMON_SEQ) ";
                    cmd.Parameters.AddWithValue("@COMMON_CODE", code+"_"+name);
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
                                         WHERE FAC_TYP = '창고'";

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

       
        /*
        public int InsertOrUpdateCmCode(ComboItemVO combo)
        {
            int iCnt = default;
            ComboItemVO temp = combo;
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "SP_SaveCommonCode";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@P_CODE", temp.COMMON_CODE);
                    cmd.Parameters.AddWithValue("@P_CODE_NAME", temp.COMMON_CODE_NAME);
                    cmd.Parameters.AddWithValue("@P_CODE_TYP", temp.COMMON_CODE_TYP);

                    if (string.IsNullOrEmpty(temp.COMMON_CODE_PCODE))
                        cmd.Parameters.Add(new SqlParameter("@P_CODE_PCODE", DBNull.Value));
                    else
                        cmd.Parameters.Add(new SqlParameter("@P_CODE_PCODE", temp.COMMON_CODE_PCODE));

                    cmd.Parameters.AddWithValue("@P_CODE_DISPLAY", temp.COMMON_CODE_DISPLAY);
                    cmd.Parameters.Add("@P_SP_RESULT", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    int insertOrUpdate = Convert.ToInt32(cmd.Parameters["@P_SP_RESULT"].Value); //0 : insert , 1: update
                    iCnt = insertOrUpdate;
                    cmd.Connection.Close();
                }

            }
            catch (Exception err)
            {
                string msg = err.Message;
                iCnt = 2;
            }
            return iCnt;
        }

        public bool DeleteCmCode(string commonCode)
        {
            int iCnt = default;
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"delete from COMMON where COMMON_CODE=@P_CODE ";

                    cmd.Parameters.AddWithValue("@P_CODE", commonCode);

                    cmd.Connection.Open();
                    iCnt = cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }

            }
            catch (Exception err)
            {
                string msg = err.Message;
                iCnt = 0;
            }
            return iCnt > 0 ? true : false;
        }
        public List<ComboItemVO> ReOrderCbo()
        {
            List<ComboItemVO> list = default;
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select (MANAGER_ID) COMMON_CODE,(MANAGER_NAME)  COMMON_CODE_NAME,(null)COMMON_CODE_TYP, (null)COMMON_CODE_PCODE, (null)COMMON_CODE_DISPLAY
                                           from MANAGER";
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

        public List<ComboItemVO> GetProductName()
        {
            List<ComboItemVO> list = default;
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@" select p.PRODUCT_CODE COMMON_CODE_DISPLAY
                                         , p.PRODUCT_NAME COMMON_CODE_NAME
                                         ,' ' COMMON_CODE_TYP
                                         ,' ' COMMON_CODE_PCODE
                                         ,' ' COMMON_CODE
                                        from [ORDER]  o inner join dbo.ORDERDETAILS od on o.ORDER_CODE = od.ORDER_CODE
						                                        inner join PRODUCT p on p.PRODUCT_CODE = od.PRODUCT_CODE
	                                    group by p.PRODUCT_CODE  , p.PRODUCT_NAME ";
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

        public List<ComboItemVO> GetItemName()
        {
            List<ComboItemVO> list = default;
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@" select ITEM_CODE COMMON_CODE_DISPLAY
                                            , ITEM_NAME COMMON_CODE_NAME
                                            ,' ' COMMON_CODE_TYP
                                            ,' ' COMMON_CODE_PCODE
                                            ,' ' COMMON_CODE
                                           from ITEM 
                                           where ITEM_DSCNT_YN <> 1
                                           group by ITEM_CODE  , ITEM_NAME  ";
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


        */
    }
}