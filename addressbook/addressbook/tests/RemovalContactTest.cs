using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook.tests
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
            
            app.Contact.ReturnContactsPage()//Переходим на страницу контактов
                .SelectContact()//Выбираем контакт
                .DeletedContact()//Удаляем контакт
                .CloseAlert()//Подтверждаем удаление
                .ReturnContactsPage();//Переходим на страницу контактов
            app.login.Logout();

        }
    }
}
