using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAM3FINALDAC;


namespace TEAM3FINAL
{
    public class LoginService
    {
        public bool CheckLoginInfo(string userID, string password)
        {
            LoginDAC dac = new LoginDAC();
            return dac.CheckLoginInfo(userID, password);
        }
    }
}
