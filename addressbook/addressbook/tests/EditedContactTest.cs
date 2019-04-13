using System;
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
            app.Contacts.ReturnContactsPage();//Переходим на страницу контактов
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            if (oldContacts.Count == 0)
            {
                app.Contacts.SetNewAttributes(contactData, "add");//Установка аттрибутов для создания группы
            }
            app.Contacts.ReturnContactsPage()//Переходим на страницу контактов
                .BeginEdit(1)//Начинаем редактирование контакта
                .SetNewAttributes(contactData, "edit")//Установка аттрибутов для редактирования группы
                .ReturnContactsPage();//Переходим на страницу контактов
            List<ContactData> newConacts = app.Contacts.GetContactList();
            oldContacts[0].Mobile = contactData.Mobile;
            oldContacts.Sort();
            newConacts.Sort();
            Assert.AreEqual(oldContacts, newConacts);
            app.login.Logout();
        }
    }
}
