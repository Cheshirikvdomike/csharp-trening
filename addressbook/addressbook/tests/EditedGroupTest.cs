using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class EditedGroupTest : GroupTestBase
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
            GroupData newData = new GroupData("NmeGroup1");
            newData.HeaderGroup = "Header1";
            newData.FooterGroup = "Footer1";
            List<GroupData> oldGroups = GroupData.GetAll();
            if (oldGroups.Count == 0)
            {
               app.Group.CreateNewGroup()//Начало создание новой группы
                  .SetNewAttributesgroup(newData)//Установка аттрибутов группы
                  .AcceptChangesNewGroup();//Применение установленых аттрибутов
            }
            oldGroups = GroupData.GetAll();
            app.Group.Modify(0, newData);
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            app.login.Logout();//Разлогиниваемся

               
            }

        
    }
}
