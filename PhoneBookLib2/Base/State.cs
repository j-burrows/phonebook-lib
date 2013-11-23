/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Place.cs
 |  Purpose:    Defines a basic class representing state or province belonging to a country.
 |  Updated:    October 8th 2013
*///-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
namespace PhoneBookLib.Base{
    public class State : Place{
        //Primary key.
        public int State_ID { get; set; }
        public int Country_ID { get; set; }

        public State() { }
    }
}
