﻿using System;
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
        public Random rnd = new Random();
        public void TestRemovalContactFromgroupTests()
    {
            List<GroupData> listGroups = GroupData.GetAll();
             
                if (listGroups.Count == 0)
                {
                    app.Group.AdditionalGroup();
                }
           
            GroupData group = listGroups[0];
            List<ContactData> oldList = group.GetContacts();//Получаем изначальный список контатов
            ContactData contact = null;//Создаём и инициализируем контейнер  для будущего контакта
            if (oldList.Count == 0)//Проверяем наличие контактов в выбранной группе
            {
                app.Contacts.AdditionalContactsToGroup();//Если контактов нет то создаём
                oldList = group.GetContacts(); //Заново получаем список контактов
                contact = oldList[0];//Выбираем первый из списка контактов
            }
            else
            {
                oldList = group.GetContacts();//Если же список контактов не пуст то получем список контактов
                contact = oldList[rnd.Next(0, oldList.Count-1)];//Случайным образом выбираем контакт из списка контактов
            }
            
            app.Contacts.RemoveContactFromGroup(contact, group);//Удаляем выбранный контакт из выбранной группы
            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }

       
    }
}
