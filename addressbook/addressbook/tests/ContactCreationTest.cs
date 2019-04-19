﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace addressbook
{
    [TestFixture]
    public class ContactCreationTest:AuthTestBase
    {
        
        private StringBuilder verificationErrors;
       

        [SetUp]
        public void SetupTest()
        {          
        verificationErrors = new StringBuilder();
        }

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(20),GenerateRandomString(20))
                {
                    Company = GenerateRandomString(20),
                    Mobile = GenerateRandomPhonenumber(10)
                   
                });
            }
            return contact;
        }

        public static IEnumerable<ContactData> ContactDataFromFile()
        {
            List<ContactData> contact = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contact.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contact.Add(new ContactData(parts[0], parts[1])
                {
                    Company = parts[3],
                    Address = parts[4],
                    Homephone = parts[5],
                    Mobile = parts[6],
                    WorkPhone = parts[7],
                    Email = parts[8],
                    Email2 = parts[9],
                    Email3 = parts[10]

                });

            }
            return contact;

        }

        [Test, TestCaseSource("ContactDataFromFile")]
        public void CreateNewContacts(ContactData contactData)
        {
            //ContactData contactData = new ContactData("Vasya", "Fedorov", "Vektor", "Horse and frogs", "123456789");
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.SetNewAttributes(contactData, "add");//Установка аттрибутов для создания группы
            List<ContactData> newConacts = app.Contacts.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newConacts);
            app.login.Logout();
        }


    

       

       
    }
}
