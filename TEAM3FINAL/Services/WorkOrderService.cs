using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public class WorkOrderService
    {
        public List<WORKORDER_VO> GetWorkOrderInfo()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetWorkOrderInfo();
        }
    }
}
