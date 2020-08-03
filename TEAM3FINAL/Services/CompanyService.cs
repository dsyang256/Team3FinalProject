using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public class CompanyService
    {
        public List<COMPANY_VO> GetCompanyList()
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.GetCompanyList();
        }

        public List<COMPANY_VO> SearchCompany(string comCode, string comName, string comType, string regNum)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.SearchCompany(comCode, comName, comType, regNum);
        }

        internal Message SaveCompany(COMPANY_VO vo, bool update)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.SaveCompany(vo, update);
        }
    }
}
