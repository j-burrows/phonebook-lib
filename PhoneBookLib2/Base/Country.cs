/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Country.cs
 |  Purpose:    Defines a basic class representing sovereign country.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Collections;
using System.Collections.Generic;
using PhoneBookLib.Factory;
namespace PhoneBookLib.Base{
    public class Country : Place{
        public int Country_ID { get; set; }

        public IEnumerable<State> states { get; set; }

        public Country(int Country_ID=0) {
            this.Country_ID = Country_ID;
            states = new List<State>();
        }
    }
}
