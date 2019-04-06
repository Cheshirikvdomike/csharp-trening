﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class EditedContactTest : AuthTestBase
    {
        private StringBuilder verificationErrors;
        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
        }
        
        [Test]
        public void EditedContact()
        {
            ContactData contactData = new ContactData("Vasya", "Fedorov", "Vektor", "Horse and frogs", "123456789");
            app.Contact.ReturnContactsPage();//Переходим на страницу контактов
            List<ContactData> oldContacts = app.Contact.GetContactList();
            if (oldContacts.Count == 0)
            {
                app.Contact.SetNewAttributes(contactData, "add");//Установка аттрибутов для создания группы
            }
            app.Contact.ReturnContactsPage()//Переходим на страницу контактов
                .BeginEdit()//Начинаем редактирование контакта
                .SetNewAttributes(contactData, "edit")//Установка аттрибутов для редактирования группы
                .ReturnContactsPage();//Переходим на страницу контактов
            List<ContactData> newConacts = app.Contact.GetContactList();
            oldContacts[0].Mobile = contactData.Mobile;
            oldContacts.Sort();
            newConacts.Sort();
            Assert.AreEqual(oldContacts, newConacts);
            app.login.Logout();
        }
    }
}
