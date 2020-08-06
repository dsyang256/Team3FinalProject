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
    public class BORService
    {
        public List<BOR_VO> GetBORList()
        {
            BORDAC dac = new BORDAC();
            return dac.GetBORList();
        }

        public List<BOR_VO> SearchBOR(string itemCode, string proc, string facility)
        {
            BORDAC dac = new BORDAC();
            return dac.SearchBOR(itemCode, proc, facility);
        }

        public Message SaveBOR(BOR_VO vo, bool update)
        {
            BORDAC dac = new BORDAC();
            return dac.SaveBOR(vo, update);
        }

        internal DataTable GetBaCodeBORList(string strChkBarCodes)
        {
            BORDAC dac = new BORDAC();
            return dac.GetBaCodeBORList(strChkBarCodes);
        }
    }
}
