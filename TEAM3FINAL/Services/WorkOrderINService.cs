using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEAM3FINALDAC;
using TEAM3FINALVO;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public class WorkOrderINService
    {
        public List<WORKORDERCREATE_VO> GetWorkList()
        {
            WorkOrderINDAC dac = new WorkOrderINDAC();
            return dac.GetWorkList();
        }

        public bool UpdateWorkList(string list, string gubun)
        {
            WorkOrderINDAC dac = new WorkOrderINDAC();
            return dac.UpdateWorkList(list, gubun);
        }

        public bool DeleteWorkList(string list, string gubun)
        {
            WorkOrderINDAC dac = new WorkOrderINDAC();
            return dac.DeleteWorkList(list, gubun);
        }

        public bool InsertWorkOrder(WORKORDERInsert_VO vo)
        {
            WorkOrderINDAC dac = new WorkOrderINDAC();
            return dac.InsertWorkOrder(vo);
        }

        public List<WORKORDERSearch_VO> GetWorkOrderList()
        {
            WorkOrderINDAC dac = new WorkOrderINDAC();
            return dac.GetWorkOrderList();
        }
    }
}
