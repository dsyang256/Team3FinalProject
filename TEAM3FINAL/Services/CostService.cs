using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;


namespace TEAM3FINAL
{
   public class CostService
    {
        public Message InsertOrUpdateMaterialCost(MaterialCost_VO vo)
        {
           CostDAC dac = new CostDAC();
            return dac.InsertOrUpdateMaterialCost(vo);
        }
    }
}
