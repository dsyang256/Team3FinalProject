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

        public List<ComboItemVO> GetWOCode()
        {
            List<ComboItemVO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select distinct SALES_Work_Order_ID COMMON_CODE, SALES_Work_Order_ID COMMON_NAME, null COMMON_PARENT, null COMMON_SEQ
                                                        from SALES_WORK
                                                        where 1=1  ";

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
        public List<ComboItemVO> GetFactoryCode()
        {
            List<ComboItemVO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select distinct FAC_CODE COMMON_CODE, FAC_NAME COMMON_NAME, null COMMON_PARENT, null COMMON_SEQ
                                                        from [dbo].[FACTORY]
                                                        where FAC_FCLTY = '창고' ";

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

        public List<ComboItemVO> GetPlanID()
        {
            List<ComboItemVO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select distinct [PLAN_ID] COMMON_CODE, [PLAN_ID] COMMON_NAME, null COMMON_PARENT, null COMMON_SEQ
                                                    from [dbo].[DEMAND_PLANNING]
                                                    where 1=1  ";

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


    }
}