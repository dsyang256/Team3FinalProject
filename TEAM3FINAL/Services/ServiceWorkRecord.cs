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
    public class ServiceWorkRecord
    {
        public List<WORKORDER_VO> GetWorkRecordList()
        {
            WorkRecordDAC dac = new WorkRecordDAC();
            return dac.GetWorkRecordList();
        }
    }
}
