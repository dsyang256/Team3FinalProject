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

        public List<ComboItemVO> GetFacilitiesCode()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetFacilitiesCode();
        }


        public List<COMMON_VO> GetAllCmCode()
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.GetAllCmCode();
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

        internal bool CheckCodeName(string code)
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.CheckCodeName(code);
        }


        internal bool CodeNameInsert(string code,string name,int SEQ)
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.CodeNameInsert(code, name, SEQ);
        }

        internal bool CodeDelete(string text)
        {
            ComboItemDAC dac = new ComboItemDAC();
            return dac.CodeDelete(text);
        }
    }
}
