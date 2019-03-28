using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook
{
   public class LoginUserData
    {
        private string login;
        private string password;
        

        public LoginUserData(string login, string password)
        {
            this.login = login;
            this.password = password;
            
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

       
    }
}
