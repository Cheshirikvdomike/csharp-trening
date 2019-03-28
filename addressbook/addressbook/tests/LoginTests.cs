using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class LoginTests :BaseClass
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            LoginUserData account = new LoginUserData("admin", "secret");
            //Подготовка тестовой ситуации
            app.Auth.Logout();
            //Логин в приложение
            app.Auth.Login(account);
            //Проверка
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            LoginUserData account = new LoginUserData("admin", "123456");
            //Подготовка тестовой ситуации
            app.Auth.Logout();
            //Логин в приложение
            app.Auth.Login(account);
            //Проверка
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}
