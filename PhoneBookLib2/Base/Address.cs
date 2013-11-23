/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Address.cs
 |  Purpose:    Defines a basic class representing a physical house address.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using PhoneBookLib.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookLib.Base;
namespace PhoneBookLib.Base{
    public class Address{
        public int Address_ID { get; set; }
        public int Contact_ID { get; set; }

        public int Apartment_Number { get; set; }
        public int Street_Number{get;set;}
        public string Street_Name { get; set; }
        public string City { get; set; }
        public string Postal_Code { get; set; }
        public int State_ID { get; set; }
        public State state { get; set; }
        public Country country { get; set; }
        public int Country_ID { get; set; }

        public Address() {
            state = new State();
            country = new Country();
        }
    }
}
