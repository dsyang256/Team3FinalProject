using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEAM3FINALDAC;
using TEAM3FINALVO;
using Message = TEAM3FINALVO.Message;

namespace TEAM3FINAL
{
    public class ShiftService
    {
        public Message InsertOrUpdateShift(SHIFT_VO vo)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.InsertOrUpdateShift(vo);
        }
        public List<SHIFTList_VO> GetShiftList()
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.GetShiftList();
        }
        public bool DeleteShiftList(string list, string gubun)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.DeleteShiftList(list, gubun);
        }
        public SHIFTList_VO GetShiftInfo(string shiftCode)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.GetShiftInfo(shiftCode);
        }

        public DataTable GetShiftManage(string fromdate,string todate)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.GetShiftManage(fromdate,todate);
        }
    }
}
