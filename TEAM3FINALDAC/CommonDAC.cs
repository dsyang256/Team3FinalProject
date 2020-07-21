using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //참조
using System.Data.SqlClient;

namespace TEAM3FINALDAC
{
    public class CommonDAC : ConnectionAccess  //추상클래스인 ConnectionAccess를 상속받아 connection하기위한
    {
        /*

        public List<ComboItemVO> GetCodeInfoByCodeTypes(string codeTypes, string seperator)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = "GetCodeInfoByCodeTypes";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@P_CodeTypes", codeTypes);
                    cmd.Parameters.AddWithValue("@P_Seperator", seperator);

                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ComboItemVO> list = Helper.DataReaderMapToList<ComboItemVO>(reader);
                    cmd.Connection.Close();

                    return list;
                }
            }
            catch
            {
                return null;
            }
        }
        */
    }
}
