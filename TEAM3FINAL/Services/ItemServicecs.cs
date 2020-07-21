using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;

namespace TEAM3FINAL.Services
{
    public class ItemServicecs
    {
        public DataTable AllITEM()
        {
            ITEMDAC dac = new ITEMDAC();
            return dac.AllITEM();
        }
    }
}
