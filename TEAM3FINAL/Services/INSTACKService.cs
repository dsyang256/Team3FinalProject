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
    public class INSTACKService
    {
        public DataTable INSTACDataTable()
        {
            INSTACKDAC dac = new INSTACKDAC();
            return dac.INSTACDataTable();
        }
        public DataTable INSTACDataTable(string day1, string day2, string wrhs, string name, string typ, string level,string itemtyp)
        {
            INSTACKDAC dac = new INSTACKDAC();
            return dac.INSTACDataTable(day1, day2, wrhs, name, typ, level, itemtyp);
        }
        public DataTable ReceivingSearch()
        {
            INSTACKDAC dac = new INSTACKDAC();
            return dac.ReceivingSearch();
        }
        public DataTable SP_ReceivingSearch(string day, string name, string typ, string wrhs, string qty, string level)
        {
            INSTACKDAC dac = new INSTACKDAC();
            return dac.SP_ReceivingSearch(day, name, typ, wrhs, qty, level);
        }
    }
}
