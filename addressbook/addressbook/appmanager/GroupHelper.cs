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
   public class GroupHelper : HelperBase
    {
        private List<GroupData> groupCashe = null;

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper CreateNewGroup()
        {
            manager.Navigation.GotoGroupsPage();
            driver.FindElement(By.LinkText("groups")).Click();
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper BeginEditGroup()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[3]")).Click();
            groupCashe = null;
            return this;
        }

        public GroupHelper Edit(GroupData group)
        {
            manager.Navigation.GotoGroupsPage();
            SelectGroup(group.Id);

            return this;
        }

        public GroupHelper RemoveGroup(int index)
        {
            manager.Navigation.GoToHomePage();
            SelectGroup(index);
            driver.FindElement(By.XPath("//div[@id='content']/form/input[2]")).Click();
            manager.Navigation.GotoGroupsPage();
            groupCashe = null;
            return this;
        }
        public GroupHelper Remove(GroupData group)
        {
            manager.Navigation.GotoGroupsPage();
            SelectGroup(group.Id);
            driver.FindElement(By.XPath("//div[@id='content']/form/input[2]")).Click();
            manager.Navigation.GotoGroupsPage();
            return this;
        }

        public GroupHelper Modify(int index, GroupData group)
        {
            manager.Navigation.GotoGroupsPage();
            SelectGroup(index);
            BeginEditGroup();
            Type(By.Name("group_name"), group.NameGroup);
            Type(By.Name("group_header"), group.HeaderGroup);
            Type(By.Name("group_footer"), group.FooterGroup);
            return this;
        }


        public List<GroupData> GetGroupList()
        {
            if (groupCashe == null)
            {
                groupCashe = new List<GroupData>();
                manager.Navigation.GotoGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCashe.Add(new GroupData(element.Text));
                }
            }
            return new List<GroupData>(groupCashe);
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[1]/input["+(index+1)+"]")).Click();
            return this;
        }

        public GroupHelper SelectGroup(string id)
        {
            driver.FindElement(By.XPath("//input[@name = 'selected[]' and @value'"+id+"']")).Click();
            return this;
        }

        public GroupHelper SelectGroupSection()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SetNewAttributesgroup(GroupData groupData)
        {
            Type(By.Name("group_name"), groupData.NameGroup);
            Type(By.Name("group_header"), groupData.HeaderGroup);
            Type(By.Name("group_footer"), groupData.FooterGroup);
            return this;
        }
       

        public GroupHelper ControlNewGroup()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper AcceptChangesNewGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCashe = null;
            return this;
        }
    }
}
