﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
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

    

        [Test]
        public void CreateNewContacts()
        {
            ContactData contactData = new ContactData("Vasya", "Fedorov", "Vektor", "Horse and frogs", "123456789");
            List<ContactData> oldContacts = app.Contact.GetContactList();
            app.Contact.SetNewAttributes(contactData, "add");//Установка аттрибутов для создания группы
            List<ContactData> newConacts = app.Contact.GetContactList();
            oldContacts.Add(contactData);
            oldContacts.Sort();
            oldContacts.Sort();
            Assert.AreEqual(oldContacts, newConacts);
            app.login.Logout();
        }


    

       

       
    }
}
