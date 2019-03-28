﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook
{
    [TestFixture]
    public class GroupCreationTest: AuthTestBase
    {
        private StringBuilder verificationErrors;
        
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
        }


        [Test]
        public void CreateNewGroups()
        {
            GroupData groupData = new GroupData("Name1", "Header1", "Footer1");
            app.Group.CreateNewGroup()//Начало создание новой группы
                     .SetNewAttributesgroup(groupData)//Установка аттрибутов группы
                     .AcceptChangesNewGroup()//Применение установленых аттрибутов
                     .ControlNewGroup();//Переход на страницу групп
        }
        
    }
}
