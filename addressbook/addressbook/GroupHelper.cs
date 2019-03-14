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

        public GroupHelper(FirefoxDriver driver) : base(driver)
        {
        }

        public void CreateNewGroup()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Name("new")).Click();
        }

        public void SetNewAttributesgroup(GroupData groupData)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(groupData.NameGroup);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(groupData.HeaderGroup);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(groupData.FooterGroup);
        }
        public void ControlNewGroup()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void AcceptChangesNewGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
    }
}
