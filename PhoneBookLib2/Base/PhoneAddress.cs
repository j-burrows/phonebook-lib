/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PhoneAddress.cs
 |  Purpose:    Defines a basic class representing phone address.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
namespace PhoneBookLib.Base{
    public class PhoneAddress{
        //Primary key.
        public int PhoneAddress_ID { get; set; }
        public int Contact_ID { get; set; }

        public int Area_Code { get; set; }
        public int Remote_Address { get; set; }
        public int Local_Address { get; set; }

        public PhoneAddress() { }
    }
}
