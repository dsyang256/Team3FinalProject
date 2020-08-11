using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEAM3FINALVO
{
   public class MANAGER_VO
    {
         public string   MANAGER_ID             {get;set;}
         public string   MANAGER_NAME           {get;set;}
         public string   MANAGER_EML            {get;set;}
         public string   MANAGER_PSWD           {get;set;}
         public string MANAGER_DEP { get; set; }
    }

    public class MANAGERMENU_VO
    {
        public int MENU_ID { get; set; }
        public string MENU_NAME { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string E { get; set; }

    }


}
