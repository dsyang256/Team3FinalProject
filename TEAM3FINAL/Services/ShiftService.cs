using System;
using System.Collections.Generic;
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
        public Message SaveShiftInfo(SHIFT_VO vo)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.SaveShiftInfo(vo);
        }

        public List<SHIFTList_VO> GetAllShiftList()
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.GetAllShiftList();
        }
    }
}
