
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

        internal object GetWorkOrder2(string code,string id)
        {
            WorkOrderDSDAC dac = new WorkOrderDSDAC();
            return dac.GetWorkOrder2(code,id);
        }
        public DataTable SP_GetWorkOrder(string sday, string eday, string code, string item, string name)
        {
            WorkOrderDSDAC dac = new WorkOrderDSDAC();
            return dac.SP_GetWorkOrder(sday, eday,code,item,name);
        }

        public DataTable POPDGV1()
        {
            WorkOrderDSDAC dac = new WorkOrderDSDAC();
            return dac.POPDGV1();
        }

        public DataTable POPDGVselect(string day1, string day2, string fac, string facg)
        {
            WorkOrderDSDAC dac = new WorkOrderDSDAC();
            return dac.POPDGVselect(day1, day2,fac,facg);
        }

        public DataTable POPDGVselect1(string v)
        {
            WorkOrderDSDAC dac = new WorkOrderDSDAC();
            return dac.POPDGVselect1(v);
        }
        public DataTable ComboBinding(string v)
        {
            WorkOrderDSDAC dac = new WorkOrderDSDAC();
            return dac.ComboBinding(v);
        }
        public List<POPVO> POPFACILITY()
        {
            WorkOrderDSDAC dac = new WorkOrderDSDAC();
            return dac.POPFACILITY();
        }
    }
}
