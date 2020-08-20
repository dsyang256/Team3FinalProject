using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public class ComboItemService
    {
        public List<ComboItemVO> GetCmCode()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetCmCode();
        }

        public List<ComboItemVO> GetFacilitiesCode()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetFacilitiesCode();
        }

        public List<ComboItemVO> GetItemCode()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetItemCode();
        }

        public List<ComboItemVO> GetTopItemCode()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetTopItemCode();
        }

        public List<ComboItemVO> GetCompanyCode()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetCompanyCode();
        }

        public List<ComboItemVO> GetPlanID()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetPlanID();
        }

        public List<ComboItemVO> GetWOCode()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetWOCode();
        }
        public List<ComboItemVO> GetFactoryCode()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetFactoryCode();
        }
        
    }
}
