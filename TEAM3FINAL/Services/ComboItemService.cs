using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public class ComboItemService
    {
        public List<ComboItemVO> GetCmCode()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetCmCode();
        }

        public List<ComboItemVO> GetITEMCmCode()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetITEMCmCode();
        }
        public bool CheckCode(string code)
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.CheckCode(code);
        }
        public bool CodeInsert(string code)
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.CodeInsert(code);
        }


    }
}
