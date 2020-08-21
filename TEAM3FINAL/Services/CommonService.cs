using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public class CommonService
    {
        public List<COMMON_VO> GetAllCmCode()
        {
            CommonDAC dac = new CommonDAC();
            return dac.GetAllCmCode();
        }

        public List<ComboItemVO> GetITEMCmCode()
        {
            CommonDAC dac = new CommonDAC();
            return dac.GetITEMCmCode();
        }
        public bool CheckCode(string code)
        {
            CommonDAC dac = new CommonDAC();
            return dac.CheckCode(code);
        }
        public bool CodeInsert(string code)
        {
            CommonDAC dac = new CommonDAC();
            return dac.CodeInsert(code);
        }

        internal bool CheckCodeName(string code)
        {
            CommonDAC dac = new CommonDAC();
            return dac.CheckCodeName(code);
        }


        internal bool CodeNameInsert(string code, string name, int SEQ)
        {
            CommonDAC dac = new CommonDAC();
            return dac.CodeNameInsert(code, name, SEQ);
        }

        internal bool CodeDelete(string text)
        {
            CommonDAC dac = new CommonDAC();
            return dac.CodeDelete(text);
        }

        internal bool CodeDelete1(string code)
        {
            CommonDAC dac = new CommonDAC();
            return dac.CodeDelete1(code);
        }
    }
}
