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
        private List<ContactData> contactCashe = null;

        public ContactHelper(ApplicationManager manager):base(manager)
        {
            
        }

        public List<ContactData> GetContactList()
        {
            if (contactCashe == null)
            {
                contactCashe = new List<ContactData>();
                manager.Navigation.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                ICollection<IWebElement> cells = null;
                foreach (IWebElement element in elements)
                {
                    cells = element.FindElements(By.TagName("td"));
                    contactCashe.Add(new ContactData(cells.ElementAt(1).Text, cells.ElementAt(2).Text));
                  
                }   
            }
            return new List<ContactData>(contactCashe);
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
                contactCashe = null;
            }
            else if(typeAction == "add")
                {
                driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
                contactCashe = null;
            }
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//table//input[contains(@type, 'checkbox')])["+index+"]")).Click();
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
            contactCashe = null;
            return this;
        }

    }
}
