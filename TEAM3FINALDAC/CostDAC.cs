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
   public class CostDAC : ConnectionAccess
    {
    public Message InsertOrUpdateMaterialCost(MaterialCost_VO vo)
    {
            //try
            //{
            //    string sql = "SP_SaveMaterialCost";
            //    using (SqlConnection conn = new SqlConnection(this.ConnectionString))
            //    {
            //        conn.Open();
            //        using (SqlCommand cmd = new SqlCommand(sql, conn))
            //        {
            //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //            //cmd.Parameters.AddWithValue("@P_MANAGER_ID", mv.MANAGER_ID);
            //            cmd.Parameters.AddWithValue("@P_MANAGER_NAME", mv.MANAGER_NAME);
            //            cmd.Parameters.AddWithValue("@P_MANAGER_EML", mv.MANAGER_EML);
            //            cmd.Parameters.AddWithValue("@P_MANAGER_DEP", mv.MANAGER_DEP);

            //            cmd.Parameters.Add(new SqlParameter("@P_MANAGER_ID", System.Data.SqlDbType.NVarChar, 20));
            //            cmd.Parameters["@P_MANAGER_ID"].Value = mv.MANAGER_ID;
            //            cmd.Parameters["@P_MANAGER_ID"].Direction = System.Data.ParameterDirection.Input;
            //            cmd.Parameters.Add(new SqlParameter("@P_ReturnCode", System.Data.SqlDbType.NVarChar, 5));
            //            cmd.Parameters["@P_ReturnCode"].Direction = System.Data.ParameterDirection.Output;
            //            cmd.ExecuteNonQuery();
            //            conn.Close();

            //            string result = cmd.Parameters["@P_ReturnCode"].Value.ToString();

            //            Message message = new Message();
            //            if (result == "M01")
            //            {
            //                message.IsSuccess = true;
            //                message.ResultMessage = "성공적으로 등록되었습니다.";
            //            }
            //            else if (result == "M02")
            //            {
            //                message.IsSuccess = true;
            //                message.ResultMessage = "성공적으로 수정되었습니다.";
            //            }
            //            else if (result == "M03")
            //            {
            //                message.IsSuccess = false;
            //                message.ResultMessage = "이미 등록된 ID 입니다.";
            //            }
            //            else if (result == "M04")
            //            {
            //                message.IsSuccess = false;
            //                message.ResultMessage = "이미 등록된 EMAIL 입니다.";
            //            }

            //            return message;
            //        }
            //    }
            //}
            //catch (Exception err)
            //{
            //    return new Message(err);
            //}
            return new Message();
    }

}
}
