using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;

namespace TEAM3FINAL.Services
{
    public class ItemServicecs
    {
        public List<ITEM_VO> AllITEM()
        {
            ITEMDAC dac = new ITEMDAC();
            return dac.AllITEM();
            /////////
        }
    }
}
