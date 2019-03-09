using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
 using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook
{
   public class BaseClass
    {
        protected FirefoxDriver driver = new FirefoxDriver();
        protected PagesGroupData pagesGroupData = new PagesGroupData("Name1", "Header1", "Footer1", "Vasya", "Fedorov", "Vektor", "Horse and frogs", "123456789");
    


    protected void SetNewAttributes()
    {
        Thread.Sleep(1000);
        driver.FindElement(By.XPath("//a[text()='add new']")).Click();
        driver.FindElement(By.Name("firstname")).Click();
        driver.FindElement(By.Name("firstname")).Clear();
        driver.FindElement(By.Name("firstname")).SendKeys(pagesGroupData.FirstName);
        driver.FindElement(By.Name("lastname")).Click();
        driver.FindElement(By.Name("lastname")).Clear();
        driver.FindElement(By.Name("lastname")).SendKeys(pagesGroupData.Lastname);
        driver.FindElement(By.Name("nickname")).Click();
        driver.FindElement(By.Name("nickname")).Clear();
        driver.FindElement(By.Name("nickname")).SendKeys(pagesGroupData.Nickname);
        driver.FindElement(By.Name("company")).Click();
        driver.FindElement(By.Name("company")).Clear();
        driver.FindElement(By.Name("company")).SendKeys(pagesGroupData.Company);
        driver.FindElement(By.Name("mobile")).Click();
        driver.FindElement(By.Name("mobile")).Clear();
        driver.FindElement(By.Name("mobile")).SendKeys(pagesGroupData.Mobile);
        driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
    }

        protected void ControlNewGroup()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected void AcceptChangesNewGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        protected void GotoUrl()
        {
            driver.Navigate().GoToUrl(pagesGroupData.BaseUrl);
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(pagesGroupData.Login);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(pagesGroupData.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }

        protected void CreateNewGroup()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Name("new")).Click();
        }

        private void SetNewAttributes(PagesGroupData pages)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(pages.NameGroup);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(pages.HeaderGroup);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(pages.FooterGroup);
        }
    }
}
