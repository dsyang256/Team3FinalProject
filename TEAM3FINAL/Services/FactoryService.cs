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
        public string InsertFactory(FACTORY_VO fac)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.InsertFactory(fac);
        }

        public List<FACTORY_VO> GetFactoryInfo()
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.GetFactoryInfo();
        }

        public string DeleteFactory(string table, string pkCode, StringBuilder appendCode)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.DeleteFactory(table, pkCode, appendCode);
        }

        public string UpdateFactoryInfo(FACTORY_VO fac)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.UpdateFactoryInfo(fac);
        }

        public List<FACTORY_VO> GetSearchFactoryInfo(string facCode, string type)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.GetSearchFactoryInfo(facCode, type);
        }
    }
}
