using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook
{
    public class ContactData
    {
        private string nameGroup;
        private string headerGroup;
        private string footerGroup;
        private string firstname;
        private string lastname;
        private string nickname;
        private string company;
        private string mobile;

        public ContactData( string firstname, string lastname, string nickname, string company, string mobile)
        {
      
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

   

   
    }
}
