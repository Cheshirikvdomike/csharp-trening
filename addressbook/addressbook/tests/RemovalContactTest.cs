using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class RemovalContactTest : AuthTestBase
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
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            if (oldContacts.Count == 0)
            {
                ContactData contactData = new ContactData("Vasya", "Fedorov", "Vektor", "Horse and frogs", "123456789");
                app.Contacts.SetNewAttributes(contactData, "add");//Установка аттрибутов для создания группы
            }
            app.Contacts.ReturnContactsPage()//Переходим на страницу контактов
                .SelectContact(0)//Выбираем контакт
                .DeletedContact()//Удаляем контакт
                .CloseAlert()//Подтверждаем удаление
                .ReturnContactsPage();//Переходим на страницу контактов
            List<ContactData> newConacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newConacts);
            app.login.Logout();

        }
    }
}
