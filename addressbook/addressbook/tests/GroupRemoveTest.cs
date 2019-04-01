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
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.SelectGroup(0)//Выбираем группу
                .RemoveGroup()//Удаляем первую выбранную группу
                .SelectGroupSection();//Возвращаемся в раздел групп
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            app.login.Logout();//Разлогиниваемся

        }
    }
}
