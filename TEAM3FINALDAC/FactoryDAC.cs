using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TEAM3FINALVO;
using cryptography;

namespace TEAM3FINALDAC
{
    public class FactoryDAC : ConnectionAccess
    {
        //데이터 insert
        public bool InsertFactory(FACTORY_VO fac)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"insert into FACTORY(FAC_CODE, FAC_FCLTY, FAC_FCLTY_PARENT, FAC_NAME, FAC_TYP, FAC_FREE_YN, FAC_TYP_SORT, FAC_DEMAND_YN, 
FAC_PROCS_YN, FAC_MTRL_YN, FAC_LAST_MDFR, FAC_USE_YN, FAC_DESC, COM_CODE)
values(@FAC_CODE, @FAC_FCLTY, @FAC_FCLTY_PARENT, @FAC_NAME, @FAC_TYP, @FAC_FREE_YN, @FAC_TYP_SORT, @FAC_DEMAND_YN, @FAC_PROCS_YN, @FAC_MTRL_YN, @FAC_LAST_MDFR, 
@FAC_USE_YN, @FAC_DESC, @COM_CODE)";
                cmd.Parameters.AddWithValue("@FAC_CODE", fac.FAC_CODE);
                cmd.Parameters.AddWithValue("@FAC_FCLTY", fac.FAC_FCLTY);
                cmd.Parameters.AddWithValue("@FAC_FCLTY_PARENT", fac.FAC_FCLTY_PARENT);
                cmd.Parameters.AddWithValue("@FAC_NAME", fac.FAC_NAME);
                cmd.Parameters.AddWithValue("@FAC_TYP", fac.FAC_TYP);
                cmd.Parameters.AddWithValue("@FAC_FREE_YN", fac.FAC_FREE_YN);
                //cmd.Parameters.AddWithValue("@FAC_TYP_SORT", fac.FAC_TYP_SORT);
                cmd.Parameters.Add(new SqlParameter("FAC_TYP_SORT", System.Data.SqlDbType.Int));
                cmd.Parameters["FAC_TYP_SORT"].Value = (object)fac.FAC_TYP_SORT ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@FAC_DEMAND_YN", fac.FAC_DEMAND_YN);
                cmd.Parameters.AddWithValue("@FAC_PROCS_YN", fac.FAC_PROCS_YN);
                cmd.Parameters.AddWithValue("@FAC_MTRL_YN", fac.FAC_MTRL_YN);
                cmd.Parameters.AddWithValue("@FAC_LAST_MDFR", fac.FAC_LAST_MDFR);
                cmd.Parameters.AddWithValue("@FAC_USE_YN", fac.FAC_USE_YN);
                cmd.Parameters.AddWithValue("@FAC_DESC", fac.FAC_DESC);
                cmd.Parameters.AddWithValue("@COM_CODE", fac.COM_CODE);

                cmd.Connection.Open();
                int iResult = cmd.ExecuteNonQuery();
                return (iResult > 0) ? true : false;
            }
        }

        //FrmFactoryManage 로드 시 dgv에 뿌려줌
        public List<FACTORY_VO> GetFactoryInfo()
        {
            List<FACTORY_VO> list = default;

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"select [FAC_CODE], [FAC_FCLTY], [FAC_FCLTY_PARENT], [FAC_NAME], [FAC_TYP], [FAC_FREE_YN], [FAC_TYP_SORT], [FAC_DEMAND_YN], [FAC_PROCS_YN], [FAC_MTRL_YN], [FAC_LAST_MDFR], [FAC_LAST_MDFY], [FAC_USE_YN], [FAC_DESC], [COM_CODE]
from[dbo].[FACTORY]";
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                list = Helper.DataReaderMapToList<FACTORY_VO>(reader);
                return list;
            }
        }

        /// <summary>
        /// 하나의 테이블에 여러 항목을 삭제할 경우 사용하는 메서드
        /// appendcode의 경우 사용자 입력값을 건드릴 수도 있으므로 보안상 파라미터를 사용하여 처리
        /// </summary>
        /// <param name="table"></param>
        /// <param name="pkCode"></param>
        /// <param name="appendCode"></param>
        /// <returns></returns>
        public bool DeleteFactory(string table, string pkCode, StringBuilder appendCode)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = new SqlConnection(this.ConnectionString);
                cmd.CommandText = @"delete from @table 
                                     where @pkCode IN(SELECT * FROM[dbo].[SplitString](@appendCode, '@'))";
                cmd.Parameters.AddWithValue("@table", table);
                cmd.Parameters.AddWithValue("@pkCode", pkCode);
                cmd.Parameters.AddWithValue("@appendCode", appendCode.ToString());
                cmd.Connection.Open();
                int iResult = cmd.ExecuteNonQuery();
                return (iResult > 0) ? true : false;
            }
        }
    }
}
