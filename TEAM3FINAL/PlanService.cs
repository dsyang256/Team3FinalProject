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
    public class PlanService
    {
        public DataTable GetDemandPlan()
        {
            PlanDAC dac = new PlanDAC();
            return dac.GetDemandPlan();
        }
    }
}
