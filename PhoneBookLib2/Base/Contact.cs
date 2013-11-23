/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Contact.cs
 |  Purpose:    Defines a basic class representing a human contact.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Collections;
using System.Collections.Generic;
using PhoneBookLib.Factory;
namespace PhoneBookLib.Base{
    public class Contact{
        public int Contact_ID { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public char Middle_Initial { get; set; }
        public string Relation { get; set; }
        public string username { get; set; }

        public IEnumerable<PhoneAddress> phoneAddresses { get; set; }
        public IEnumerable<Email> emails { get; set; }
        public IEnumerable<Address> addresses { get; set; }

        public Contact(int Contact_ID=0) {
            this.Contact_ID = Contact_ID;
            phoneAddresses = new List<PhoneAddress>();
            emails = new List<Email>();
            addresses = new List<Address>();
        }
    }
}
