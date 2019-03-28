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
        
        public ContactHelper(ApplicationManager manager):base(manager)
        {
            
        }
        public ContactHelper SetNewAttributes(ContactData contactData, string typeAction)
        {
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//a[text()='add new']")).Click();
            Type(By.Name("firstname"), contactData.FirstName);
            Type(By.Name("lastname"), contactData.Lastname);
            Type(By.Name("nickname"), contactData.Nickname);
            Type(By.Name("company"), contactData.Company);
            Type(By.Name("mobile"), contactData.Mobile);
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
            manager.Navigation.GoToHomePage();
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
