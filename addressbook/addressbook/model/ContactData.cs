﻿using System;
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
        private string email;
        private string aboutContact;

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

        public string WorkPhone { get; set; }

        public string Address { get; set; }

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
                    return (Cleanmail(email)).Trim();
                }
            }
            set
            {
                email = value;
            }
        }

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
                    return (FirstName + " " + Lastname + "\r\n" + "\r\n" + "H: "+CleanUp(Homephone)+"\r\n"+"M: "+ CleanUp(Mobile)).Trim();
                }
            }
            set
            {
                aboutContact = value;
            }
      
        }
        private string Cleanmail(string mail)
        {
            if (mail == null || mail == "")
            { return ""; }
            return Regex.Replace(mail, "[ ]", "");
        }


        private string CleanUp(string phone)
        {
            if (phone == null||phone=="")
            { return ""; }
            return Regex.Replace(phone, "[ -()]", "") +"\r\n";
        }
    }
}
