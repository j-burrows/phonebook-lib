/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Place.cs
 |  Purpose:    Defines a basic class representing physical place in the world.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
namespace PhoneBookLib.Base{
    public class Place{
        public string Long_Name { get; set; }

        public string Short_Name { get; set; }
        public int Place_ID { get; set; }

        public Place() { }
    }
}
