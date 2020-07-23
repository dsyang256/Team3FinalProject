using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;
using TEAM3FINALVO;

namespace TEAM3FINAL
{
    public class LoginService
    {
        public bool CheckIDExist(string userID)
        {
            LoginDAC dac = new LoginDAC();
            return dac.CheckIDExist(userID);
        }
        public bool CheckLoginInfo(string userID, string password)
        {
            LoginDAC dac = new LoginDAC();
            return dac.CheckLoginInfo(userID, password);
        }

        internal Message InsertOrUpdateManager(MANAGER_VO mv)
        {
            LoginDAC dac = new LoginDAC();
            return dac.InsertOrUpdateManager(mv);
        }
    }
}
