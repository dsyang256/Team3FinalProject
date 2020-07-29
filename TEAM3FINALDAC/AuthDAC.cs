﻿using System;
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

        public List<MANAGER_VO> GetRightList(string userID)
        {
            List<MANAGER_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select
                                         m.MENU_ID
                                        ,[MENU_NAME] 
                                        ,case when CHARINDEX('C',ManagerR_CRUD) >0 then 'C' else '' END AS A
                                        ,case when CHARINDEX('R',ManagerR_CRUD) >0 then 'R' else '' END AS B
                                        ,case when CHARINDEX('U',ManagerR_CRUD) >0 then 'U' else '' END AS C
                                        ,case when CHARINDEX('D',ManagerR_CRUD) >0 then 'D' else '' END AS D
                                        ,case when CHARINDEX('P',ManagerR_CRUD) >0 then 'P' else '' END AS E
                                         from dbo.MENU m left outer join dbo.MANAGER_MENU mm  on m.MENU_ID = mm.MANAGER_ID
                                         where 1=1
                                         AND [MENU_PARENT] is null
                                         AND MENU_USE<>1
                                         AND MANAGER_ID = @MANAGER_ID
                                         order by MENU_ID,MENU_SEQ, MENU_LEVEL";

                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@MANAGER_ID", userID);
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

        public List<MANAGER_VO> GetMenuList(string userID)
        {
            List<MANAGER_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select
                                         m.MENU_ID
                                        ,[MENU_NAME] 
                                        ,case when CHARINDEX('C',ManagerR_CRUD) >0 then 'C' else '' END AS A
                                        ,case when CHARINDEX('R',ManagerR_CRUD) >0 then 'R' else '' END AS B
                                        ,case when CHARINDEX('U',ManagerR_CRUD) >0 then 'U' else '' END AS C
                                        ,case when CHARINDEX('D',ManagerR_CRUD) >0 then 'D' else '' END AS D
                                        ,case when CHARINDEX('P',ManagerR_CRUD) >0 then 'P' else '' END AS E
                                         from dbo.MENU m left outer join dbo.MANAGER_MENU mm  on m.MENU_ID = mm.MANAGER_ID
                                         where 1=1
                                         AND [MENU_PARENT] is null
                                         AND MENU_USE<>1
                                         AND MANAGER_ID = @MANAGER_ID
                                         order by MENU_ID,MENU_SEQ, MENU_LEVEL";

                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@MANAGER_ID", userID);
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
