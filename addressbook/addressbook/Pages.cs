using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook
{
    public class PagesGroupData
    {
        private string nameGroup;
        private string headerGroup;
        private string footerGroup;
        private string login = "admin";
        private string password = "secret";
        private string baseUrl = "http://localhost/addressbook";
        private string firstname;
        private string lastname;
        private string nickname;
        private string company;
        private string mobile;

        public PagesGroupData(string name, string header, string footer, string firstname, string lastname, string nickname, string company, string mobile)
        {
            this.nameGroup = name;
            this.headerGroup = header;
            this.footerGroup = footer;
            this.firstname = firstname;
            this.lastname = lastname;
            this.nickname = nickname;
            this.company = company;
            this.mobile = mobile;
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
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

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
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

        public string NameGroup
        {
            get
            {
                return nameGroup;
            }
            set
            {
                nameGroup = value;
            }
        }

        public string HeaderGroup
        {
            get
            {
                return headerGroup;
            }
            set
            {
                headerGroup = value;
            }
        }

        public string FooterGroup
        {
            get
            {
                return footerGroup;
            }
            set
            {
                footerGroup = value;
            }
        }
    }
}
