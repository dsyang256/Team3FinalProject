using System;
using System.Collections.Generic;
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
    }
}
