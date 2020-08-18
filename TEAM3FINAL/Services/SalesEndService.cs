using DevExpress.XtraEditors.Controls;
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
    public class SalesEndService
    {
        public List<SalesEnd_VO> GetSalesEnd()
        {
            SalesEndDAC dac = new SalesEndDAC();
            return dac.GetSalesEnd();
        }

        public Message SalesRecord(SalesEndState_VO vo, string name)
        {
            SalesEndDAC dac = new SalesEndDAC();
            return dac.SalesRecord(vo, name);
        }

        public List<SalesEndState_VO> GetSalesEndState()
        {
            SalesEndDAC dac = new SalesEndDAC();
            return dac.GetSalesEndState();
        }

        public List<SalesEnd_VO> SearchSalesEnd(string id, string item, string company)
        {
            SalesEndDAC dac = new SalesEndDAC();
            return dac.SearchSalesEnd(id, item, company);
        }

        public Message SalesCancel(SalesEndState_VO vo, string id)
        {
            SalesEndDAC dac = new SalesEndDAC();
            return dac.SalesCancel(vo, id);
        }

        public List<SalesEndState_VO> SearchSalesEndState(string id, string item, string company)
        {
            SalesEndDAC dac = new SalesEndDAC();
            return dac.SearchSalesEndState(id, item, company);
        }
    }
}
