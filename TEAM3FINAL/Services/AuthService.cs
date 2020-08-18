using System;
using System.Collections.Generic;
using System.Data;
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

        public List<MANAGERMENU_VO> GetMenuList(string userID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetMenuList(userID);
        }

        public List<Right_VO> GetRightList(string userID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetRightList(userID);
        }

        public List<ManagerRight_VO> GetRights(string userID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetRights(userID);
        }

        public bool SaveManagerMenu(List<ManagerMenu_VO> list, string userID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.SaveManagerMenu(list,userID);
        }

        public List<ManagerRightInfo_VO> GetManagerRightInfo()
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetManagerRightInfo();
        }

        public List<Right_VO> GetManagerRightList(string userID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetManagerRightList(userID);
        }

        public bool SaveManagerGroup(List<Right_VO> list, string userID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.SaveManagerGroup(list, userID);
        }

        public List<MANAGERMENU_VO> GetAllMenuList()
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetAllMenuList();
        }

        public bool SaveGroup(string group, string name, string remark)
        {
            AuthDAC dac = new AuthDAC();
            return dac.SaveGroup(group, name, remark);
        }

        public List<Right_VO> GetALLRightList()
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetALLRightList();
        }

        public List<MANAGERMENU_VO> GetRightMenuList(string rightID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.GetRightMenuList(rightID);
        }

        public bool SaveRightMenu(List<RightMenus_VO> list, string rightID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.SaveRightMenu(list, rightID);
        }

        public bool DeleteGroup(string rightID)
        {
            AuthDAC dac = new AuthDAC();
            return dac.DeleteGroup(rightID);
        }
    }
}
