using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;


namespace TEAM3FINAL.Services
{
    class FactoryService
    {
        public Message SaveFactory(FACTORY_VO fac, bool update)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.SaveFactory(fac, update);
        }

        public List<FACTORY_VO> GetFactoryInfo()
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.GetFactoryInfo();
        }

        public Message DeleteFactory(string table, string pkCode, StringBuilder appendCode)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.DeleteFactory(table, pkCode, appendCode);
        }

        public List<FACTORY_VO> GetSearchFactoryInfo(string facCode, string type)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.GetSearchFactoryInfo(facCode, type);
        }
    }
}
