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
        public static bool PERFORM_LONG_UI_CHECKS = true;
        public static Random rnd = new Random();
        protected ApplicationManager app;

       [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }
        public static string GenerateRandomString(int max)
        {
            
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return builder.ToString();
        }

        public static string GenerateRandomPhonenumber(int max)
        {

            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(rnd.Next(0,10)));
            }
            return builder.ToString();
        }

    }
}
