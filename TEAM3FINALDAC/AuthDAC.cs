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

        public List<Right_VO> GetManagerRightList(string userID)
        {
            List<Right_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@" select r.RIGHT_ID, RIGHT_GROUP, RIGHT_NAME, RIGHT_DESC, null RIGHT_USE ,null RIGHT_FIRST_MDFR,null RIGHT_FIRST_MDFY ,null RIGHT_LAST_MDFR ,null RIGHT_LAST_MDFY
                                              from RIGHTS r inner join dbo.MANAGER_RIGHT mr on r.RIGHT_ID = mr.RIGHT_ID
                                              where 1=1
                                               AND MANAGER_RIGHT_USE<>1
                                               AND MANAGER_ID = @MANAGER_ID
                                              order by r.RIGHT_ID,RIGHT_GROUP, RIGHT_NAME";
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@MANAGER_ID", userID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<Right_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;


        }

        public bool DeleteGroup(string rightID)
        {
            int iCnt = 0;
            try
            {
                using (SqlCommand cmd1 = new SqlCommand())
                {
                    cmd1.Connection = new SqlConnection(this.ConnectionString);
                    cmd1.CommandText = $@" update RIGHTS set RIGHT_USE	= 1
                                            where RIGHT_ID = @RIGHT_ID ";

                    cmd1.Parameters.AddWithValue("@RIGHT_ID", rightID);

                    cmd1.Connection.Open();
                    iCnt += cmd1.ExecuteNonQuery();

                    cmd1.Connection.Close();
                }

            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return iCnt > 0 ? true : false;

        }

        public bool SaveGroup(string group, string name, string remark)
        {
            int iCnt = 0;
            try
            {
                using (SqlCommand cmd1 = new SqlCommand())
                {
                    cmd1.Connection = new SqlConnection(this.ConnectionString);
                    cmd1.CommandText = $@" insert into RIGHTS (RIGHT_GROUP,RIGHT_NAME,RIGHT_DESC,RIGHT_USE)
                                                        values(@RIGHT_GROUP,@RIGHT_NAME,@RIGHT_DESC,0)";

                    cmd1.Parameters.AddWithValue("@RIGHT_GROUP", group);
                    cmd1.Parameters.AddWithValue("@RIGHT_NAME", name);
                    cmd1.Parameters.AddWithValue("@RIGHT_DESC", remark);
                    
                    cmd1.Connection.Open();
                    iCnt += cmd1.ExecuteNonQuery();

                    cmd1.Connection.Close();
                }

            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return iCnt > 0 ? true : false;

        }

        public bool SaveRightMenu(List<RightMenus_VO> list, string rightID)
        {
            int iCnt = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"delete from MENU_RIGHT where RIGHT_ID = @RIGHT_ID";

                    cmd.Parameters.AddWithValue("@RIGHT_ID", rightID);
                    cmd.Connection.Open();
                    iCnt += cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                using (SqlCommand cmd2 = new SqlCommand())
                {
                    cmd2.Connection = new SqlConnection(this.ConnectionString);
                    cmd2.CommandText = $@"insert into MENU_RIGHT(RIGHT_ID,MENU_ID,MENU_RIGHT_USE)
                                                        values
                                                         (@RIGHT_ID , 4 , 0)
                                                        ,(@RIGHT_ID , 7 , 0) 
                                                        ,(@RIGHT_ID , 12 , 0) 
                                                        ,(@RIGHT_ID , 18 , 0) 
                                                        ,(@RIGHT_ID , 21 , 0) 
                                                        ,(@RIGHT_ID , 22 , 0) 
                                                        ,(@RIGHT_ID , 26 , 0) 
                                                        ,(@RIGHT_ID ,  30, 0) 
                                                        ,(@RIGHT_ID , 40 , 0) 
                                                        ,(@RIGHT_ID ,  44, 0) 
                                                        ,(@RIGHT_ID , 47 , 0) 
                                                        ,(@RIGHT_ID , 53 , 0) 
                                                        ,(@RIGHT_ID ,  60, 0)";
                    cmd2.Parameters.AddWithValue("@RIGHT_ID", rightID);
                    cmd2.Connection.Open();
                    iCnt += cmd2.ExecuteNonQuery();
                    cmd2.Connection.Close();
                }
                using (SqlCommand cmd1 = new SqlCommand())
                {
                    cmd1.Connection = new SqlConnection(this.ConnectionString);
                    cmd1.CommandText = $@" insert into MENU_RIGHT(RIGHT_ID,MENU_ID,MENU_RIGHT_USE)
                                                               values (@RIGHT_ID , @MENU_ID , 0)";

                    cmd1.Parameters.Add("@RIGHT_ID", SqlDbType.Int);
                    cmd1.Parameters.Add("@MENU_ID", SqlDbType.Int);

                    cmd1.Connection.Open();

                    foreach (var item in list)
                    {
                        cmd1.Parameters["@RIGHT_ID"].Value = item.RIGHT_ID;
                        cmd1.Parameters["@MENU_ID"].Value = item.MENU_ID;
                        iCnt += cmd1.ExecuteNonQuery();
                    }
                    cmd1.Connection.Close();
                }

            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return iCnt > 0 ? true : false;

        }

        public List<MANAGERMENU_VO> GetRightMenuList(string rightID)
        {
            List<MANAGERMENU_VO> list = null;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"    --전체메뉴(상위아닌거)
                                                         select m.MENU_ID, MENU_NAME,null A,null B,null C,null D,null E
                                                            from MENU_RIGHT m inner join MENU r on r.MENU_ID = m.MENU_ID
                                                            where m.RIGHT_ID = @RIGHT_ID
                                                            AND r.MENU_USE<>1
                                                            AND m.MENU_RIGHT_USE <> 1
                                                            AND r.MENU_PARENT is not null ";
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@RIGHT_ID", rightID);
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

        public List<Right_VO> GetALLRightList()
        {
            List<Right_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@" 
   select RIGHT_ID, RIGHT_GROUP, RIGHT_NAME, RIGHT_DESC, case when RIGHT_USE=0 then '사용' else '미사용' end RIGHT_FIRST_MDFR
   ,null RIGHT_USE, null RIGHT_FIRST_MDFY,null RIGHT_LAST_MDFR,null RIGHT_LAST_MDFY
   from RIGHTS";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<Right_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return list;



        }

        public List<MANAGERMENU_VO> GetAllMenuList()
        {
            List<MANAGERMENU_VO> list = null;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"    --전체메뉴(상위아닌거)
   select MENU_ID, MENU_NAME,null A,null B,null C,null D,null E
   from MENU
   where MENU_PARENT is not null
   AND MENU_USE<>1";
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

        public bool SaveManagerGroup(List<Right_VO> list, string userID)
        {
            int iCnt = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"delete from [MANAGER_RIGHT] where MANAGER_ID = @MANAGER_ID";

                    cmd.Parameters.AddWithValue("@MANAGER_ID", userID);
                    cmd.Connection.Open();
                    iCnt += cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
                using (SqlCommand cmd1 = new SqlCommand())
                {
                    cmd1.Connection = new SqlConnection(this.ConnectionString);
                    cmd1.CommandText = $@" insert into [MANAGER_RIGHT] (MANAGER_ID,RIGHT_ID,[MANAGER_RIGHT_LAST_ MDFR],MANAGER_RIGHT_LAST_MDFY)
                                    values(@MANAGER_ID,@RIGHT_ID,@MANAGER_ID2,getdate()) ";

                    cmd1.Parameters.Add("@MANAGER_ID", SqlDbType.NVarChar, 20);
                    cmd1.Parameters.Add("@RIGHT_ID", SqlDbType.Int);
                    cmd1.Parameters.Add("@MANAGER_ID2", SqlDbType.NVarChar, 20);
                    cmd1.Connection.Open();

                    foreach (var item in list)
                    {
                        cmd1.Parameters["@MANAGER_ID"].Value = item.RIGHT_NAME;
                        cmd1.Parameters["@RIGHT_ID"].Value = item.RIGHT_ID;
                        cmd1.Parameters["@MANAGER_ID2"].Value = item.RIGHT_NAME;
                        iCnt += cmd1.ExecuteNonQuery();
                    }
                    cmd1.Connection.Close();
                }

            }
            catch (Exception err)
            {
                string msg = err.Message;
            }
            return iCnt > 0 ? true : false;

        }

        public List<ManagerRightInfo_VO> GetManagerRightInfo()
        {
            List<ManagerRightInfo_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select m.MANAGER_ID, MANAGER_NAME, MANAGER_DEP, s.RIGHT_NAME, s.RIGHT_GROUP, s.RIGHT_DESC
                        from MANAGER m inner join MANAGER_RIGHT r on m.MANAGER_ID = r.MANAGER_ID
			                           inner join RIGHTS s on r.RIGHT_ID = s.RIGHT_ID";
                    cmd.Connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<ManagerRightInfo_VO>(reader);
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

        public List<Right_VO> GetRightList(string userID)
        {
            List<Right_VO> list = default;

            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@" select r.RIGHT_ID, RIGHT_GROUP, RIGHT_NAME, RIGHT_DESC, null RIGHT_USE ,null RIGHT_FIRST_MDFR,null RIGHT_FIRST_MDFY ,null RIGHT_LAST_MDFR ,null RIGHT_LAST_MDFY
                              from RIGHTS r
                              where 1=1
                              order by r.RIGHT_ID,RIGHT_GROUP, RIGHT_NAME";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<Right_VO>(reader);
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
                    cmd.Parameters.Add("@MANAGER_ID", SqlDbType.NVarChar, 20);
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
