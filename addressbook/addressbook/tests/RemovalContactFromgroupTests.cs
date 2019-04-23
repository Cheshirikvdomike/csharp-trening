using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook;
using NUnit.Framework;

namespace addressbook
{
   public class RemovalContactFromgroupTests:AuthTestBase
    {
    public void TestRemovalContactFromgroupTests()
    {
            List<GroupData> listGroups = GroupData.GetAll();
             
                if (listGroups.Count == 0)
                {
                    app.Group.AdditionalGroup();
                }
           
            GroupData group = listGroups[0];
            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count == 0)
            {
                app.Contacts.AdditionalContactsToGroup();
            }
            oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();
            app.Contacts.RemoveContactFromGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

       
    }
}
