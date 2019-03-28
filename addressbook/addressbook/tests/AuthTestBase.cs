﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook
{
   public class AuthTestBase :BaseClass
    {
        [SetUp]
        public void SetupLogin()
        {
            app.login.Login(new LoginUserData("admin", "secret"));//Логин на сайт
        }
    }
}
