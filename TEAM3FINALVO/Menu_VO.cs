using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
    public class Menu_VO
    {
        public int MENU_ID { get; set; }
        public string MENU_NAME { get; set; }
        public int MENU_SEQ { get; set; }
        public int MENU_PARENT { get; set; }
        public int MENU_LEVEL { get; set; }
        public bool MENU_USE { get; set; }
        public string MENU_LAST_MDFR   {get;set;}
    public string MENU_LAST_MDFY { get; set; }
    public string MENU_PROGRAM { get; set; }
    public string MENU_DESC { get; set; }
}

    public class ManagerMenu_VO 
    {
        public int MENU_ID { get; set; }
        public string CRUDPR { get; set; }

    }
}
