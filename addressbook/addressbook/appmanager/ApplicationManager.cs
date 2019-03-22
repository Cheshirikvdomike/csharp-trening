using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace addressbook
{
    public class ApplicationManager
    {
        protected FirefoxDriver driver;
        protected LoginHelper loginHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            loginHelper = new LoginHelper(driver);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }
        public LoginHelper Auth
        {
            get { return loginHelper; }
        }

        public GroupHelper Group
        {
            get { return groupHelper; }
        }

        public ContactHelper Contact
        {
            get { return contactHelper; }
        }

        public LoginHelper login
        {
            get { return loginHelper; }
        }
    }
}
