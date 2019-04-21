using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Firefox;
using System.Xml.Serialization;
using System.Xml;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace addressbook
{
    [TestFixture]
    public class GroupCreationTest: GroupTestBase
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

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    HeaderGroup = parts[1], 
                    FooterGroup = parts[2]
                });

            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {

            return (List<GroupData>)
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }
        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void CreateNewGroups(GroupData groupData)
        {
            //GroupData groupData = new GroupData("Name1", "Header1", "Footer1");
            List<GroupData> oldGroups = GroupData.GetAll();
            app.Group.CreateNewGroup()//Начало создание новой группы
                     .SetNewAttributesgroup(groupData);//Установка аттрибутов группы
            app.Group.AcceptChangesNewGroup()//Применение установленых аттрибутов
                     .ControlNewGroup();//Переход на страницу групп
            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupList().Count());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            
        }
        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> fromUi = app.Group.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
            start = DateTime.Now;
            List<GroupData> fromDB = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
        
    }
}
