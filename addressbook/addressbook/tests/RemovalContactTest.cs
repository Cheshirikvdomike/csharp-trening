using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class RemovalContactTest : GroupTestBase
    {
        private StringBuilder verificationErrors;
        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
        }
        
        [Test]
        public void DeleteContact()
        {
            app.Contacts.ReturnContactsPage();//Переходим на страницу контактов
            List<ContactData> oldContacts = ContactData.GetAll();
            if (oldContacts.Count == 0)
            {
                ContactData contactData = new ContactData("Vasya", "Fedorov", "Vektor", "Horse and frogs", "123456789");
                app.Contacts.SetNewAttributes(contactData, "add");//Установка аттрибутов для создания группы
            }
            oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];
            app.Contacts.ReturnContactsPage()//Переходим на страницу контактов
                .Remove(toBeRemoved);
            List<ContactData> newConacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newConacts);
            app.login.Logout();

        }
    }
}
