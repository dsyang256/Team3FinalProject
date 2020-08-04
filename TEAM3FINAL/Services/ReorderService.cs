using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;

namespace TEAM3FINAL
{
    public class ReorderService
    {
        public DataTable SelectREORDER()
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.SelectREORDER();
        }

        public DataTable GetSearchREORDER(string sday, string eday, string comcodeout, string item, string state, string order, string comcodein)
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.GetSearchREORDER(sday, eday, comcodeout, item, state, order, comcodein);
        }
        public DataTable GetCOM()
        {
            REORDERDAC dac = new REORDERDAC();
            return dac.GetCOM();
        }
    }
}
