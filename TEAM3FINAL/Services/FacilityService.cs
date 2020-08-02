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
        #region 설비군

        public List<FACILITY_GROUP> GetFacilityGroupInfo()
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.GetFacilityGroupInfo();
        }

        public Message InsertFacilityGroup(FACILITY_GROUP fac, bool update)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.InsertFacilityGroup(fac, update);
        }

        public Message UpdateFacilityGroup(FACILITY_GROUP fac, bool update)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.UpdateFacilityGroup(fac, update);
        }

        #endregion

        #region 설비
        public string InsertFacility(FACILITY_VO fac)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.InsertFacility(fac);
        }

        internal object GetFacilityInfo()
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.GetFacilityInfo();
        }

        #endregion
    }
}
