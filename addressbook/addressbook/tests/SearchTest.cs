using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook
{
    [TestFixture]
    public class SearchTest : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromEditForm(0);
            ContactData infoForm = app.Contacts.GetContactInformationForm(0);
            Assert.AreEqual(fromTable, infoForm);
            Assert.AreEqual(fromTable.AboutContact, infoForm.AboutContact);
        }
    }
}
