using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
 

namespace addressbook
{
    public class BaseClass
    {
        protected ApplicationManager app;

       [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
    
        
    }
}
