using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook.tests
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
            app.Contact.ReturnContactsPage()//Переходим на страницу контактов
                .BeginEdit()//Начинаем редактирование контакта
                .SetNewAttributes(contactData, "edit")//Установка аттрибутов для редактирования группы
                .ReturnContactsPage();//Переходим на страницу контактов
            app.login.Logout();
        }
    }
}
