using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace addressbook
{
    [TestFixture]
    public class GroupCreationTest: AuthTestBase
    {
        private StringBuilder verificationErrors;

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    HeaderGroup = GenerateRandomString(100),
                    FooterGroup = GenerateRandomString(100)
                });
            }
            return groups;
        }

        

        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
        }


        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void CreateNewGroups(GroupData groupData)
        {
            //GroupData groupData = new GroupData("Name1", "Header1", "Footer1");
            List<GroupData> oldGroups = app.Group.GetGroupList();
            app.Group.CreateNewGroup()//Начало создание новой группы
                     .SetNewAttributesgroup(groupData);//Установка аттрибутов группы
            app.Group.AcceptChangesNewGroup()//Применение установленых аттрибутов
                     .ControlNewGroup();//Переход на страницу групп
            List<GroupData> newGroups =  app.Group.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            
        }
        
    }
}
