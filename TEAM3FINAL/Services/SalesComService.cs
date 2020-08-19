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
    public class SalesComService
    {
        public List<SalesCOM_VO> GetSalesCom()
        {
            SalesComDAC dac = new SalesComDAC();
            return dac.GetSalesCom();
        }

        public List<SalesCOMDedail_VO> GetSalesComDetail()
        {
            SalesComDAC dac = new SalesComDAC();
            return dac.GetSalesComDetail();
        }

        public List<SalesCOM_VO> SearchSalesCom(string date, string company)
        {
            SalesComDAC dac = new SalesComDAC();
            return dac.SearchSalesCom(date, company);
        }

        public List<SalesCOMDedail_VO> SearchSalesComDetail(string date, string company)
        {
            SalesComDAC dac = new SalesComDAC();
            return dac.SearchSalesComDetail(date, company);
        }

        public List<SalesCOMDedail2_VO> GetSalesComDetail2()
        {
            SalesComDAC dac = new SalesComDAC();
            return dac.GetSalesComDetail2();
        }

        public List<SalesCOM2_VO> GetSalesCom2()
        {
            SalesComDAC dac = new SalesComDAC();
            return dac.GetSalesCom2();
        }

        public List<SalesCOM2_VO> SearchSalesCom2(string date, string company)
        {
            SalesComDAC dac = new SalesComDAC();
            return dac.SearchSalesCom2(date, company);
        }

        public List<SalesCOMDedail2_VO> SearchSalesComDetail2(string date, string company)
        {
            SalesComDAC dac = new SalesComDAC();
            return dac.SearchSalesComDetail2(date, company);
        }
    }
}
