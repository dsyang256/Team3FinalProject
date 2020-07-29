using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
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

        /*
         * select mr.RIGHT_ID, RIGHT_GROUP, RIGHT_NAME, RIGHT_DESC, RIGHT_USE,null [RIGHT_FIRST_MDFR], convert(varchar, RIGHT_FIRST_MDFY, 120) RIGHT_FIRST_MDFY,null  [RIGHT_LAST_MDFR], convert(varchar, RIGHT_LAST_MDFY, 120) RIGHT_LAST_MDFY,mr.MANAGER_ID
from  dbo.RIGHTS r  left outer join dbo.MANAGER_RIGHT mr  on mr.RIGHT_ID = r.RIGHT_ID
where 1=1
         * */

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
