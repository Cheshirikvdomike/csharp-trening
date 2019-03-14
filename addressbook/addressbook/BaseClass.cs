using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
 using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook
{
    public class BaseClass
    {
        protected FirefoxDriver driver;
        private StringBuilder verificationErrors;
        protected LoginHelper loginHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
        driver = new FirefoxDriver();
        loginHelper = new LoginHelper(driver);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }
    [TearDown]
    public void TeardownTest()
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        {
            // Ignore errors if unable to close the browser
        }
        Assert.AreEqual("", verificationErrors.ToString());
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
    }
}
