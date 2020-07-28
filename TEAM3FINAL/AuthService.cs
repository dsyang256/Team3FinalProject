using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
  public  class AuthService
    {
       
        public List<MANAGER_VO> GetMenus()
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetMenus();
        }
        
    }
}
