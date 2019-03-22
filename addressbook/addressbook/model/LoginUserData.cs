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
        private string baseUrl;

        public LoginUserData(string login, string password, string baseURL)
        {
            this.login = login;
            this.password = password;
            this.baseUrl = baseURL;
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

        public string BaseUrl
        {
            get
            {
                return baseUrl;
            }
            set
            {
                baseUrl = value;
            }
        }
    }
}
