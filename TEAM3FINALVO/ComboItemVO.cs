using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINAL
{
  public class ComboItemVO
    {
        public string COMMON_CODE { get; set; }
        public string COMMON_CODE_NAME { get; set; }
        public string COMMON_CODE_TYP { get; set; }
        public string COMMON_CODE_PCODE { get; set; }
        public int COMMON_CODE_DISPLAY { get; set; }

        public ComboItemVO() { }

        public ComboItemVO(string blackText)
        {
            COMMON_CODE_PCODE = "";
            COMMON_CODE_NAME = blackText;
        }

    }
}
