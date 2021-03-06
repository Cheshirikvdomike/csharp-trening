﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace addressbook
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string firstName;
        private string allemails;
        private string aboutContact;
        private string lastName;
        private string nickName;
        private string company;
        private string mobile;
        private string homePhone;
        private string workPhone;
        private string email;
        private string email2;
        private string email3;
        private string address;

        public ContactData() { }
        public ContactData(string firstname, string lastname, string nickname, string company, string mobile)
        {

            this.firstName = firstname;
            this.lastName = lastname;
            this.nickName = nickname;
            this.company = company;
            this.mobile = mobile;
        }

        public ContactData(string firstname, string lastname)
        {
            firstName = firstname;
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
            return ((FirstName == other.FirstName) && (Lastname == other.Lastname));
        }

        [Column(Name = "mobile"), NotNull]
        public string Mobile {
            get
            {
                if (mobile != null)
                {
                    return mobile;
                }
                else
                {
                    return null;
                }
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

        [Column(Name = "home"), NotNull]
        public string Homephone
        {
            get
            {
                if (homePhone != null)
                {
                    return homePhone;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                homePhone = value;
            }
        }

        [Column(Name = "work"), NotNull]
        public string WorkPhone {
            get
            {
                if (workPhone != null)
                {
                    return workPhone;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                workPhone = value;
            }
        }

        [Column(Name = "address"), NotNull]
        public string Address
        {
            get
            {
                if (address != null)
                {
                    return address;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                address = value;
            }
        }

        [Column(Name = "email2"), NotNull]
        public string Email2
        {
            get
            {
                if (email2 != null)
                {
                    return email2;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                email2 = value;
            }
        }

        [Column(Name = "email3"), NotNull]
        public string Email3
        {
            get
            {
                if (email3 != null)
                {
                    return email3;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                email3 = value;
            }
        }

        [Column(Name = "email"), NotNull]
        public string Email
        {
            get
            {
                if (email != null)
                {
                    return email;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                email = value;
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
                    return (Cleanmail(Email) + Cleanmail(Email2) + Cleanmail(Email3)).Trim();
                }
            }
            set
            {
                allemails = value;
            }
        }

        [Column(Name = "company"), NotNull]
        public string Company
        {
            get
            {
                if (company != null)
                {
                    return company;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                company = value;
            }
        }

        [Column(Name = "lastname"), NotNull]
        public string Lastname {
            get
            {
                if (lastName != null)
                {
                    return lastName;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                lastName = value;
            }
        }

        [Column(Name = "nickname"), NotNull]
        public string Nickname
        { get; set; }

        [Column(Name = "firstname"), NotNull]
        public string FirstName
        {
            get
            {
                if (firstName != null)
                {
                    return firstName;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                firstName = value;
            }
        }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<ContactData> GetAll()
        {
          using (AddressBookDB db = new AddressBookDB())
            {
            return (from g in db.Contacts.Where(x=>x.Deprecated== "0000-00-00 00:00:00") select g).ToList(); 
            }
        }

        [Column (Name ="deprecated")]
        public string Deprecated
        {
            get; set;
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

        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p=>p.GroupID ==Id &&   p.ContactID == c.Id)
                        select c).ToList();
            }
        }   
    }
}
