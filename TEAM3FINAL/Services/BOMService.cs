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
    public class BOMService
    {
        public string SaveBOM(BOM_VO vo)
        {
            BOMDAC dac = new BOMDAC();
            return dac.SaveBOM(vo);
        }
        public DataTable SearchBOM(string day, string name, string yn)
        {
            BOMDAC dac = new BOMDAC();
            return dac.SearchBOM(day, name, yn);
        }

        public DataTable SelectBOM()
        {
            BOMDAC dac = new BOMDAC();
            return dac.SelectBOM();
        }
    }
}
