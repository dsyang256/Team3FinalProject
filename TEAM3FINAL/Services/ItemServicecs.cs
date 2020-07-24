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
    public class ItemServicecs
    {
        public List<ITEM_VO> AllITEM()
        {
            ITEMDAC dac = new ITEMDAC();
            return dac.AllITEM();
        }
        public List<ITEM_VO> GetSearchItem(ITEM_VO vo)
        {
            ITEMDAC dac = new ITEMDAC();
            return dac.GetSearchItem(vo);
        }
        public string SaveItem(ITEM_VO vo, int code)
        {
            ITEMDAC dac = new ITEMDAC();
            return dac.SaveItem(vo,code);
        }

    }
}
