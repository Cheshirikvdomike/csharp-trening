using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook
{
    public class ContactHelper:HelperBase
    {
        
        public ContactHelper(FirefoxDriver driver):base(driver)
        {
            
        }
        public ContactHelper SetNewAttributes(ContactData contactData, string typeAction)
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//a[text()='add new']")).Click();
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contactData.FirstName);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contactData.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contactData.Nickname);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contactData.Company);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contactData.Mobile);
            if (typeAction == "edit")
                {
                driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            }
            else if(typeAction == "add")
                {
                driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
                }
            return this;
        }

        public ContactHelper SelectContact()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();
            return this;
        }

        public ContactHelper ReturnContactsPage()
        {
            driver.FindElement(By.XPath("//a[contains(text(),'home')]")).Click();
            return this;
        }

        public ContactHelper BeginEdit()
        {
            driver.FindElement(By.XPath("//tbody//a[contains(@href,'edit')]")).Click(); 
            return this;
        }

        public ContactHelper FinishedEditContact()
        {
            return this;
        }

        public ContactHelper CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper DeletedContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

    }
}
