using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook.tests
{
    [TestFixture]
    public class EditedGroupTest : BaseClass
    {
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;
        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
        }
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        [Test]
        public void Edited_Group_Test()
        {
            GroupData groupData = new GroupData("NewName1", "NewHeader1", "NewFooter1");
            LoginUserData loginUserData = new LoginUserData("admin", "secret", "http://localhost/addressbook");
            app.login.GotomyUrl(loginUserData);//Переход по Url, Логин на сайт
            app.Group.SelectGroupSection()//Переходим в раздел Groups
                .SelectGroup()//Выбираем группу
                .BeginEditGroup()//Начинаем редактирование группы
                .SetNewAttributesgroup(groupData)//Установка аттрибутов группы
                .AcceptChangesNewGroup()//Применение установленых аттрибутов
                .ControlNewGroup();//Переход на страницу групп
            app.login.Logout();//Разлогиниваемся
        }

    }
}
