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
    }
}
