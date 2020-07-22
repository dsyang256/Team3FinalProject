using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class ComboItemVO
    {
        public string COMMON_CODE { get; set; }
        public string COMMON_NAME { get; set; }
        public string COMMON_PARENT { get; set; }
        public string COMMON_SEQ { get; set; }

        public ComboItemVO() { }

        public ComboItemVO(string blackText)
        {
            COMMON_PARENT = "";
            COMMON_NAME = blackText;
        }
    }
}