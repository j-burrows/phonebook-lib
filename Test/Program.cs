using System;
using System.Collections.Generic;
using PhoneBookLib.Base;
using PhoneBookLib.Data.Entities;
using PhoneBookLib.Factory;
using System.Linq;
using PhoneBookLib.Presentation;
using PhoneBookLib.Business;
using PhoneBookLib.Data.Repositories;
using PhoneBookLib;
using System.Collections;
namespace PhonebookLibUnitTests{
    class Program{
        public class Infant { }
        public class Child : Infant { }
        public class Parent : Child { }
        static void Main(string[] args){
            Repository.Configuration.connString = "Server=localhost;Database=ApplicationData;Trusted_Connection=True;";
            IPhonebookService service = new PhonebookService();

            IEnumerable<Contact> contacts = service.Contact_GetByUser("");

            Console.Write(contacts.Count());
        }
    }
}
