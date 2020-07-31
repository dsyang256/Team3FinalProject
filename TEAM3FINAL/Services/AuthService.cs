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
       
        public List<Menu_VO> GetMenus(string userID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetMenus(userID);
        }

        public List<MANAGER_VO> GetManagers()
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetManagers();
        }

        public List<MANAGER_VO> GetMenuList(string userID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetMenuList(userID);
        }

        public List<MANAGER_VO> GetRightList(string userID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetRightList(userID);
        }

        public List<ManagerRight_VO> GetRights(string userID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetRights(userID);
        }
    }
}
