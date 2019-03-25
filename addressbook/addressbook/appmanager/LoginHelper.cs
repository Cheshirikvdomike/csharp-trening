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
   public class LoginHelper : HelperBase
    {
        public LoginHelper(FirefoxDriver driver) : base(driver)
        {
        }

        public void GotomyUrl(LoginUserData loginUserData)
        {
            driver.Navigate().GoToUrl(loginUserData.BaseUrl);
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(loginUserData.Login);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(loginUserData.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
    }
}
