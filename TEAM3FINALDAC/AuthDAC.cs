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
   public class AuthDAC : ConnectionAccess
    {
        public List<MANAGER_VO> GetMenus()
        {
            List<MANAGER_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select[MENU_ID] [MANAGER_ID],[MENU_NAME] [MANAGER_NAME],[MENU_PARENT] [MANAGER_EML],[MENU_PROGRAM] [MANAGER_PSWD],null [MANAGER_DEP]
                                                        from dbo.MENU
                                                        where 1=1 ";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<MANAGER_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;
        }

        public List<MANAGER_VO> GetMenuList()
        {
            List<MANAGER_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select [MENU_ID] [MANAGER_ID]    ,[MENU_NAME] [MANAGER_NAME]      ,[MENU_PARENT] [MANAGER_EML]     ,[MENU_PROGRAM] [MANAGER_PSWD]      ,null [MANAGER_DEP]
                                         from dbo.MENU
                                         where 1=1
                                         AND [MENU_PARENT] is null
                                         AND MENU_USE<>1
                                         order by MENU_SEQ, MENU_LEVEL";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<MANAGER_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;
        }

        public List<MANAGER_VO> GetManagers()
        {
            List<MANAGER_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select MANAGER_ID, MANAGER_NAME, null MANAGER_EML, null MANAGER_PSWD, MANAGER_DEP
                                            from dbo.MANAGER ";

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<MANAGER_VO>(reader);
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
