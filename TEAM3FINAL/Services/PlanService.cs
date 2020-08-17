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
        public DataTable GetDemandPlan(string FromDate, string ToDate, string PlanID)
        {
            PlanDAC dac = new PlanDAC();
            return dac.GetDemandPlan(FromDate,ToDate,PlanID);
        }

        public string CheckDemandPlan(string planID)
        {
            PlanDAC dac = new PlanDAC();
            return dac.CheckDemandPlan(planID);
        }

        public bool CheckWOCreate(string planID)
        {
            PlanDAC dac = new PlanDAC();
            return dac.CheckWOCreate(planID);
        }

        public bool InsertWorkOrders(string planID)
        {
            PlanDAC dac = new PlanDAC();
            return dac.InsertWorkOrders(planID);
        }

        public DataTable GetMaterialDemandPlan(string fromDate, string toDate, string PlanID)
        {
            PlanDAC dac = new PlanDAC();
            return dac.GetMaterialDemandPlan(fromDate, toDate, PlanID);
        }

        public DataTable GetProductPlan(string fromDate, string toDate, string PlanID)
        {
            PlanDAC dac = new PlanDAC();
            return dac.GetProductPlan(fromDate, toDate, PlanID);

        }

        public DataTable GetOutProductPlan(string fromDate, string toDate, string PlanID)
        {
            PlanDAC dac = new PlanDAC();
            return dac.GetOutProductPlan(fromDate, toDate, PlanID);
        }
    }
}
