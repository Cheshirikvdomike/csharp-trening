using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using addressbook;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {

            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string newFormat = args[2];
            string typeTest = args[3];
            if (typeTest == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                { 
                    contacts.Add(new ContactData(BaseClass.GenerateRandomString(10), BaseClass.GenerateRandomString(10))
                    {
                        Company = BaseClass.GenerateRandomString(100),
                        Address = BaseClass.GenerateRandomString(100),
                        Homephone = BaseClass.GenerateRandomPhonenumber(10),
                        Mobile = BaseClass.GenerateRandomPhonenumber(10),
                        WorkPhone = BaseClass.GenerateRandomPhonenumber(10),
                        Email = BaseClass.GenerateRandomString(10),
                        Email2 = BaseClass.GenerateRandomString(10),
                        Email3 = BaseClass.GenerateRandomString(10)
                    }
                    );
                }
                if (newFormat == "csv")
                {
                    WritecontactToCsvFile(contacts, writer);
                }
                else if (newFormat == "xml")
                {
                    WritecontactToXmlFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Указан не верный формат файла " + newFormat);
                }
            }
            else if (typeTest == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(BaseClass.GenerateRandomString(10))
                {
                    HeaderGroup = BaseClass.GenerateRandomString(100),
                    FooterGroup = BaseClass.GenerateRandomString(100)
                }
                );
            }
            if (newFormat == "csv")
            {
                WritegroupsToCsvFile(groups, writer);
            }
            else if (newFormat == "xml")
            {
                WritegroupsToXmlFile(groups, writer);
            }
            else
            {
                System.Console.Out.Write("Указан не верный формат файла " + newFormat);
            }
        }
            writer.Close();
        }

        static void WritegroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.NameGroup, group.HeaderGroup, group.FooterGroup));
            }
        }
        static void WritegroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer,groups);
        }

        static void WritecontactToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5},${6},${7},${8},${9}",
                    contact.FirstName,
                    contact.Lastname,
                    contact.Company,
                    contact.Address,
                    contact.Homephone,
                    contact.Mobile,
                    contact.WorkPhone,
                    contact.Email,
                    contact.Email2,
                    contact.Email3));
            }
        }
        static void WritecontactToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
    }
}
