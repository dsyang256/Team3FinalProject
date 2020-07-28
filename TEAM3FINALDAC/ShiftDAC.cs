using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cryptography;
using TEAM3FINALVO;

namespace TEAM3FINALDAC
{
   public class ShiftDAC : ConnectionAccess
    {
        public List<SHIFT_VO> SaveShiftInfo()
        {
            //List<SHIFT_VO> list = default;
            //try
            //{
            //    using (SqlCommand cmd = new SqlCommand())
            //    {
            //        AESSalt salt = new AESSalt();
            //        cmd.Connection = new SqlConnection(this.ConnectionString);
            //        cmd.CommandText = 
            //        cmd.Connection.Open();
            //        SqlDataReader reader = cmd.ExecuteReader();
            //        list = Helper.DataReaderMapToList<ITEM_VO>(reader);
            //        cmd.Connection.Close();
            //        return list;
            //    }
            //}
            //catch (Exception err)
            //{
            //    return list;
            //}

        }

    }
}
