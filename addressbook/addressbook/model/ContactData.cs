using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
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

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public int CompareTo(ContactData other)
        {
            int resultCompare = 0;
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return (FirstName.CompareTo(other.FirstName));
            }
            else { return Lastname.CompareTo(other.Lastname); }
        }

        

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return ((FirstName == other.FirstName)&&(Lastname == other.Lastname));
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

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + FirstName;
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
