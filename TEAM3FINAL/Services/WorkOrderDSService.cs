﻿
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
    public class WorkOrderDSService
    {
        public DataTable GetWorkOrder()
        {
            WorkOrderDSDAC dac = new WorkOrderDSDAC();
            return dac.GetWorkOrder();
        }

        internal object GetWorkOrder2(string code)
        {
            WorkOrderDSDAC dac = new WorkOrderDSDAC();
            return dac.GetWorkOrder2(code);
        }
    }
}
