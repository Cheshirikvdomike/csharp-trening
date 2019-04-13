using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        /* private string nameGroup;
private string headerGroup;
private string footerGroup;
private string firstname;
private string lastname;
private string nickname;
private string company;
private string mobile;*/

        public ContactData( string firstname, string lastname, string nickname, string company, string mobile)
        {
      
            FirstName = firstname;
            Lastname = lastname;
            Nickname = nickname;
            Company = company;
            Mobile = mobile;
        }

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            Lastname = lastname;
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

        public string Mobile{get;set;}

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + FirstName;
        }

        public string Homephone {get; set; }
        
        public string Company{get;set;}

        public string Lastname{get;set;}

        public string Nickname{get;set;}

        public string FirstName{get;set;}

        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Homephone) + CleanUp(Mobile)).Trim();
                }
            }
            set
            {
                allPhones = value;
            } }

        private string CleanUp(string phone)
        {
            if (phone == null||phone=="")
            { return ""; }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")+"\r\n";
        }
    }
}
