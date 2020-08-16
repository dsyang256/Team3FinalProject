using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALVO;

namespace TEAM3FINALDAC
{
    public class WorkOrderINDAC : ConnectionAccess
    {
        public List<WORKORDERCREATE_VO> GetWorkList()
        {
            List<WORKORDERCREATE_VO> list = null;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = new SqlConnection(this.ConnectionString);
                    cmd.CommandText = $@"select w.ITEM_CODE, i.ITEM_NAME, i.ITEM_STND, w.WO_WORK_STATE , w.FCLTS_CODE,f.FCLTS_NAME
                                                        ,w.WO_PLAN_QTY,w.WO_PLAN_QTY WO_QTY_PROD
                                                        , convert(nvarchar, w.WO_PLAN_STARTTIME, 23) WO_PLAN_STARTTIME
                                                        , (r.BOR_PROCS_TIME*w.WO_PLAN_QTY)/60 Tacminute
                                                        , convert(nvarchar, w.WO_PLAN_ENDTIME, 23) WO_PLAN_ENDTIME
                                                        ,w.WO_Code
                                                        from WORKORDER w inner join ITEM i on w.ITEM_CODE = i.ITEM_CODE
				                                                         inner join FACILITY f on f.FCLTS_CODE = w.FCLTS_CODE
				                                                         left outer join BOR r on r.ITEM_CODE = w.ITEM_CODE ";
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    list = Helper.DataReaderMapToList<WORKORDERCREATE_VO>(reader);
                    cmd.Connection.Close();
                }
            }
            catch (Exception err)
            {
                return list;
            }
            return list;

        }
    }
}
