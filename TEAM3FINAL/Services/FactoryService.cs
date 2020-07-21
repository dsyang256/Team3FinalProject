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
        public bool InsertFactory(FACTORY_VO fac)
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.InsertFactory(fac);
        }

        public List<FACTORY_VO> GetFactoryInfo()
        {
            FactoryDAC dac = new FactoryDAC();
            return dac.GetFactoryInfo();
        }
    }
}
