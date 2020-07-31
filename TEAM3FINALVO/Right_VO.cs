using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class ManagerRight_VO
    {
      public int MENU_ID            {get;set;}
      public string ManagerR_CRUD      {get;set;}
      public string MENU_PROGRAM { get; set; }
    }

    public class Right_VO
    {
        public int RIGHT_ID { get; set; }
        public string RIGHT_GROUP { get; set; }
        public string RIGHT_NAME { get; set; }
        public string RIGHT_DESC { get; set; }
        public bool RIGHT_USE { get; set; }
        public string RIGHT_FIRST_MDFR { get; set; }
        public string RIGHT_FIRST_MDFY { get; set; }
        public string RIGHT_LAST_MDFR { get; set; }
        public string RIGHT_LAST_MDFY { get; set; }

    }

    public class RightMenu_VO
    {
        public int RIGHT_ID { get; set; }
        public string RIGHT_GROUP { get; set; }
        public string RIGHT_NAME { get; set; }
        public string RIGHT_DESC { get; set; }
        public bool RIGHT_USE { get; set; }
        public string RIGHT_FIRST_MDFR { get; set; }
        public string RIGHT_FIRST_MDFY { get; set; }
        public string RIGHT_LAST_MDFR { get; set; }
        public string RIGHT_LAST_MDFY { get; set; }
    }

    public class GroupMenu
    {
        public int RIGHT_ID { get; set; }
        public string RIGHT_GROUP { get; set; }
        public string RIGHT_NAME { get; set; }
        public string RIGHT_DESC { get; set; }
        public bool RIGHT_USE { get; set; }
        public string RIGHT_FIRST_MDFR { get; set; }
        public string RIGHT_FIRST_MDFY { get; set; }
        public string RIGHT_LAST_MDFR { get; set; }
        public string RIGHT_LAST_MDFY { get; set; }
    }


}
