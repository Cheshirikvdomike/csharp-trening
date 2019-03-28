using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook.tests
{
    [TestFixture]
  public class GroupRemoveTest: AuthTestBase
    {
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;
        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
        } 

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigation.GotoGroupsPage();//Переходим в раздел Groups
            app.Group.SelectGroup()//Выбираем группу
                .RemoveGroup()//Удаляем первую выбранную группу
                .SelectGroupSection();//Возвращаемся в раздел групп
            app.login.Logout();//Разлогиниваемся

        }
    }
}
