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
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(LoginUserData loginUserData)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(loginUserData))
                { return; }
                Logout();
            }
            Type(By.Name("user"), loginUserData.Login);
            Type(By.Name("pass"), loginUserData.Password);
            driver.FindElement(By.Id("LoginForm")).Submit();
        }

        public bool IsLoggedIn(LoginUserData loginUserData)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == loginUserData.Login;
                
        }

        private string GetLoggetUserName()
        {
            string text = driver.FindElement(By.LinkText("Logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Logout"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }
    }
}
