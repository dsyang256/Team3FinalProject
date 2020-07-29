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
    }
}
