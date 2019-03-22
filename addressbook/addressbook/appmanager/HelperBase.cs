using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook
{
   public class HelperBase
    {
        protected FirefoxDriver driver;
        public HelperBase(FirefoxDriver driver)
        {
            this.driver = driver;
        }
    }
}
