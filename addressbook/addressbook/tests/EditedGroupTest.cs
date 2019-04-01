using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook.tests
{
    [TestFixture]
    public class EditedGroupTest : AuthTestBase
    {
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;
        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
        }
       
        [Test]
        public void Edited_Group_Test()
        {
            GroupData groupData = new GroupData("NewName1", "NewHeader1", "NewFooter1");
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Navigation.GotoGroupsPage();//Переходим в раздел Groups
            app.Group.SelectGroup(0)//Выбираем группу
                .BeginEditGroup()//Начинаем редактирование группы
                .SetNewAttributesgroup(groupData);//Установка аттрибутов группы
            
            app.Group.AcceptChangesNewGroup()//Применение установленых аттрибутов
                .ControlNewGroup();//Переход на страницу групп
            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[0].NameGroup = groupData.NameGroup;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            app.login.Logout();//Разлогиниваемся
        }

    }
}
