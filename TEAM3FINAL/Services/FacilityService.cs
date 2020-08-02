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
        public Message InsertFacility(FACILITY_VO fac, bool update)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.InsertFacility(fac, update);
        }

        internal object GetFacilityInfo()
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.GetFacilityInfo();
        }

        internal Message UpdateFacility(FACILITY_VO fac, bool update)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.UpdateFacility(fac, update);
        }

        internal Message DeleteFacilityGroup(string code)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.DeleteFacilityGroup(code);
        }

        internal object SearchFacilityInfo(string code)
        {
            FacilityDAC dac = new FacilityDAC();
            return dac.SearchFacilityInfo(code);
        }

        #endregion
    }
}
