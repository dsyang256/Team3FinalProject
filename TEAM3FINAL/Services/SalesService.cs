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
    public class SalesService
    {
        public SALES_WORK_VO GetSalesWorkInfo(string salesID)
        {
            SalesDAC dac = new SalesDAC();
            return dac.GetSalesWorkInfo(salesID);
        }
        public List<SALESWorkList_VO> GetSalesWorkList()
        {
            SalesDAC dac = new SalesDAC();
            return dac.GetSalesWorkList();
        }
        public Message InsertOrUpdateSalesWork(SALES_WORK_VO vo)
        {
            SalesDAC dac = new SalesDAC();
            return dac.InsertOrUpdateSalesWork(vo);
        }
        public bool DeleteSalesWorkList(string list, string gubun)
        {
            SalesDAC dac = new SalesDAC();
            return dac.DeleteSalesWorkList(list, gubun);

        }

        internal bool InsertDemandPlan(List<DEMAND_PLANNING_VO> list)
        {
            SalesDAC dac = new SalesDAC();
            return dac.InsertDemandPlan(list);
        }

        internal bool UpdateSalesWork(List<DEMAND_PLANNING_VO> list)
        {
            SalesDAC dac = new SalesDAC();
            return dac.UpdateSalesWork(list);
        }

        public DataTable GetBaCodeWorkOrderList()
        {
            SalesDAC dac = new SalesDAC();
            return dac.GetBaCodeWorkOrderList();
        }
    }
}
