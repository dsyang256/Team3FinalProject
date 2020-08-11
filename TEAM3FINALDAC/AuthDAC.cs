using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //참조
using System.Data.SqlClient;
using TEAM3FINALVO;
using System.Data.Common;

namespace TEAM3FINALDAC
{
    public class AuthDAC : ConnectionAccess
    {
        public List<Menu_VO> GetMenus(string userID)
        {
            List<Menu_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select m.MENU_ID, mn.MENU_NAME, mn.MENU_PARENT, mn.MENU_SEQ, mn.MENU_LEVEL, mn.MENU_PROGRAM, mn.MENU_DESC,mn.MENU_USE,mn.[MENU_FIRST_MDFR],mn.MENU_FIRST_MDFY,mn.[MENU_LAST_MDFR],mn.MENU_LAST_MDFY
                                        from dbo.MENU_RIGHT m inner join dbo.MANAGER_RIGHT r on m.RIGHT_ID=r.RIGHT_ID
								                                           inner join	dbo.MENU mn on m.MENU_ID = mn.MENU_ID
                                        where 1=1 AND mn.MENU_USE <>1
                                        AND r.MANAGER_ID = @MANAGER_ID
										order by mn.MENU_PARENT, m.MENU_ID";
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@MANAGER_ID", userID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<Menu_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;
        }

        public bool SaveManagerMenu(List<ManagerMenu_VO> list, string userID)
        {
            int iCnt = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"update MANAGER_MENU set ManagerR_CRUD = @ManagerR_CRUD
										 where 1=1
										 AND MANAGER_ID = @MANAGER_ID
										 AND MENU_ID = @MENU_ID";

                    cmd.Parameters.Add("@ManagerR_CRUD", SqlDbType.NVarChar, 20);
                    cmd.Parameters.Add("@MANAGER_ID", SqlDbType.NVarChar, 20);
                    cmd.Parameters.Add("@MENU_ID", SqlDbType.Int);
                    cmd.Connection.Open();

                    foreach (var item in list)
                    {
                        cmd.Parameters["@ManagerR_CRUD"].Value = item.CRUDPR;
                        cmd.Parameters["@MANAGER_ID"].Value = userID;
                        cmd.Parameters["@MENU_ID"].Value = item.MENU_ID;
                        iCnt += cmd.ExecuteNonQuery();
                    }
                    cmd.Connection.Close();
                }

            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return iCnt > 0 ? true : false;
        }

        public List<ManagerRight_VO> GetRights(string userID)
        {
            List<ManagerRight_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select  mm.MENU_ID , ManagerR_CRUD,  MENU_PROGRAM
                                        from dbo.MANAGER_MENU mm inner join dbo.MENU m on m.MENU_ID = mm.MENU_ID
                                        where 1=1
                                        AND  MENU_USE <>1
                                        AND MANAGER_MENU_USE<>1
                                        AND mm.MANAGER_ID = @MANAGER_ID";
                    cmd.Connection.Open();

                    cmd.Parameters.AddWithValue("@MANAGER_ID", userID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<ManagerRight_VO>(reader);
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
                    cmd.CommandText = $@"select r.RIGHT_ID, RIGHT_GROUP, RIGHT_NAME, RIGHT_DESC
                                        from RIGHTS r inner join dbo.MANAGER_RIGHT mr on r.RIGHT_ID = mr.RIGHT_ID
                                        where 1=1
                                         AND MANAGER_RIGHT_USE<>1
                                         AND MANAGER_ID = @MANAGER_ID
                                        order by r.RIGHT_ID,RIGHT_GROUP, RIGHT_NAME";
                    cmd.Parameters.AddWithValue("@MANAGER_ID", userID);
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

        public List<MANAGERMENU_VO> GetMenuList(string userID)
        {
            List<MANAGERMENU_VO> list = null;

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
                                         ,case when CHARINDEX('P',ManagerR_CRUD) >0 then 'R' else '' END AS F
                                         from dbo.MENU m left outer join dbo.MANAGER_MENU mm  on m.MENU_ID = mm.MENU_ID
                                         where 1=1
                                         AND [MENU_PARENT] is not null
                                         AND MENU_USE<>1
                                         AND MANAGER_ID = @MANAGER_ID
                                         order by MENU_ID,MENU_SEQ, MENU_LEVEL";
                    cmd.Parameters.Add("@MANAGER_ID", SqlDbType.NVarChar,20);
                    cmd.Parameters["@MANAGER_ID"].Value = userID;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<MANAGERMENU_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
                return new List<MANAGERMENU_VO>();
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
