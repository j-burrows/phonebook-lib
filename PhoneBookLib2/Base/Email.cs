/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Email.cs
 |  Purpose:    Defines a basic class representing email address.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
namespace PhoneBookLib.Base{
    public class Email{
        public int Email_ID { get; set; }

        public int Contact_ID { get; set; }
        public string Url { get; set; }

        public Email() { }
    }
}
