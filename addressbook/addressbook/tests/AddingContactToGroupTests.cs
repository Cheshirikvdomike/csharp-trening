using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook
{
   public class AddingContactToGroupTests:AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            List<GroupData> listGroups = GroupData.GetAll();
            if (listGroups.Count == 0)//проверяем наличие групп
            {
                app.Group.AdditionalGroup();//если групп нет, то добавляем группу
            }
            listGroups = GroupData.GetAll();//Вновь получаем список групп
            GroupData group = null;//Создаём и инициализируем контейнер для будущей выбранной группы
            List<ContactData> oldList = null;//Создаём и инициализируем контейнер для будущего списка контактов выбранной группы
            ContactData contact = null; //создаём и инициализируем контейнер для будущего выбранного контакта
            for (int i = 0; i < listGroups.Count; i++)//Начинаем перебирать группы с проверкой на наличие все контактов в выбранной группе
            {
                group = listGroups[i]; //Выбираем группу
                oldList = group.GetContacts(); //Получаем список всех контактов группы
                if (ContactData.GetAll().Except(oldList).Any())//Проверяем, есть ли не добавленные контакты в списке контактов выбранной группы
                {
                    contact = ContactData.GetAll().Except(oldList).First();//Если отсутствующий контакт найден, то получаем первый не добавленный
                    break;//Выходим из цикла
                } else if ` (i == listGroups.Count-1)//Если не находим группу с недобавленными контактами
                {
                    app.Group.AdditionalGroup();//то создаём новую группу
                    group = listGroups[listGroups.Count + 1];//Выбираем созданную группу и записываем её в контейнер
                    oldList = group.GetContacts(); //получаем список не добавленных контактов в группу
                    contact = ContactData.GetAll().Except(oldList).First();//Получаем первый не добавленный контакт выбранной группы
                    break;//Выходим из цикла
                }
            }
            app.Contacts.AddContactToGroup(contact, group);//Добавляем контакт в группу
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        
    }
}
