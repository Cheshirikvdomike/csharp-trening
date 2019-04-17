using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace addressbook
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allemails;
        private string aboutContact;

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

        public string Mobile{
            get
            {
                if (Mobile != null)
                {
                    return Mobile;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Mobile = value;
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

        public string Homephone
        {
            get
            {
                if (Homephone != null)
                {
                    return Homephone;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Homephone = value;
            }
        }

        public string WorkPhone {
            get
            {
                if (WorkPhone != null)
                {
                    return WorkPhone;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                WorkPhone = value;
            }
        }

        public string Address
        {
            get
            {
                if (Address != null)
                {
                    return Address;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Address = value;
            }
        }

        public string Email2
        {
            get
            {
                if (Email2 != null)
                {
                    return Email2;
                }
                else
                {
                    return (Cleanmail(Email2)).Trim();
                }
            }
            set
            {
                Email2 = value;
            }
        }

        public string Email3
        {
            get
            {
                if (Email3 != null)
                {
                    return Email3;
                }
                else
                {
                    return (Cleanmail(Email3)).Trim();
                }
            }
            set
            {
                Email3 = value;
            }
        }

        public string Email
        {
            get
            {
                if (Email != null)
                {
                    return Email;
                }
                else
                {
                    return (Cleanmail(Email)).Trim();
                }
            }
            set
            {
                Email = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allemails != null)
                {
                    return allemails;
                }
                else
                {
                    return (Email + Email2 + Email3).Trim();
                }
            }
            set
            {
                allemails = value;
            }
        }

        public string Company
        {
            get
            {
                if (Company != null)
                {
                    return Company;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Company = value;
            }
        }

        public string Lastname{
            get
            {
                if (Lastname != null)
                {
                    return Lastname;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                FirstName = value;
            }
        }

        public string Nickname
        {get;set;}

        public string FirstName
        {
            get
            {
                if (FirstName != null)
                {
                    return FirstName;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                FirstName = value;
            }
        }

        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Homephone) + CleanUp(Mobile)+ CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            } }

        public string AboutContact
        {
            get {
                if (aboutContact != null)
                {
                    return aboutContact;
                }
                
                else
                {
                    if (Homephone != null)
                    { Homephone = "H: " + CleanUp(Homephone) + "\r\n"; }
                    if (Mobile != null)
                    { Mobile = "M: " + CleanUp(Mobile) + "\r\n"; }
                    if (WorkPhone != null)
                    { WorkPhone = "W: " + CleanUp(WorkPhone) + "\r\n"; }
                    if (Company != null)
                    { Company = Company + "\r\n"; }
                    return (FirstName + " " + Lastname+ "\r\n"+CleanCompany(Company) + Homephone + Mobile+ WorkPhone +CleanCompany(Address)+ "\r\n" +AllEmails).Trim();
                }
            }
            set
            {
                aboutContact = value;
            }
      
        }

        private string CleanCompany(string company)
        {
            if (company == null || company == "")
            { return ""; }
            return company + "\r\n";
        }

        private string Cleanmail(string mail)
        {
            if (mail == null || mail == "")
            { return ""; }
            return Regex.Replace(mail, "[ ]", "")+"\r\n";
        }


        private string CleanUp(string phone)
        {
            if (phone == null||phone=="")
            { return ""; }
            return Regex.Replace(phone, "[ -()]", "") +"\r\n";
        }
    }
}
