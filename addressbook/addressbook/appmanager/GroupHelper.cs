using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook
{
   public class GroupHelper : HelperBase
    {
        

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper CreateNewGroup()
        {
            manager.Navigation.GotoGroupsPage();
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper BeginEditGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[3]")).Click();

            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[2]")).Click();
            return this;
        }

        public GroupHelper SelectGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[1]/input[1]")).Click();
            return this;
        }

        public GroupHelper SelectGroupSection()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SetNewAttributesgroup(GroupData groupData)
        {
            Type(By.Name("group_name"), groupData.NameGroup);
            Type(By.Name("group_header"), groupData.HeaderGroup);
            Type(By.Name("group_footer"), groupData.FooterGroup);
            return this;
        }
       

        public GroupHelper ControlNewGroup()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper AcceptChangesNewGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
    }
}
