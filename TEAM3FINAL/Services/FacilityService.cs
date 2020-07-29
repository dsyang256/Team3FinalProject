using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;


namespace TEAM3FINAL.Services
{
    class FacilityService
    {
        public List<FACILITY_GROUP> GetFacilityGroupInfo()
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.GetFacilityGroupInfo();
        }

        public string InsertFacilityGroup(FACILITY_GROUP fac)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.InsertFacilityGroup(fac);
        }

        public string UpdateFacilityGroup(FACILITY_GROUP fac)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.UpdateFacilityGroup(fac);
        }
    }
}
