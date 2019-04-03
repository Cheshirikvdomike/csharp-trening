using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Threading;

namespace addressbook
{
    public class ApplicationManager
    {
        protected FirefoxDriver driver;
        protected LoginHelper loginHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected NavigationHelper navigator;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        protected string baseUrl;

        private ApplicationManager()
        {

            driver = new FirefoxDriver();
            baseUrl = "http://localhost";
            navigator = new NavigationHelper(this,baseUrl);
            loginHelper = new LoginHelper(this);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
            
        }

        public static ApplicationManager GetInstance()
        {
            if (app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.GoToHomePage();
                app.Value = newInstance;
                
                
            }

            return app.Value;
        }

        public FirefoxDriver Driver
        {
            get
            {
                return driver;
            }
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception) { }
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

        public NavigationHelper Navigation
        {
            get { return navigator; }
        }
        
    }

}
