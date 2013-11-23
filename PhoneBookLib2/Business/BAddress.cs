/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       BAddress.cs
 |  Purpose:    Defines a business logical and rules of what an address must be.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using PhoneBookLib.Presentation;
using Repository.Business;
using Repository.Business.Protocols;
namespace PhoneBookLib.Business{
    public class BAddress : PAddress, IBusinessUnit{
        public readonly ProtocolStack Address_ID_Rules = ProtocolStack.ForKey("Address_ID");
        public readonly ProtocolStack Contact_ID_Rules = ProtocolStack.ForKey("Contact_ID");
        public readonly ProtocolStack Apartment_Number_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = true, minValue = 1, numeric = true, stepValue = 1, hidden = true},
            "Apartment_Number");
        public readonly ProtocolStack Street_Number_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = false, minValue = 1, numeric = true, stepValue = 1, hidden = true },
            "Street_Number");
        public readonly ProtocolStack Street_Name_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = false, maxLength = 16 }, "Street_Name");
        public readonly ProtocolStack City_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = true, maxLength = 16 }, "City");
        public readonly ProtocolStack Postal_Code_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = true, minLength = 6, maxLength = 7 }, "Postal_Code");
        public readonly ProtocolStack State_ID_Rules = ProtocolStack.ForKey("State_ID");
        public readonly ProtocolStack Country_ID_Rules = ProtocolStack.ForKey("Country_ID");

        public virtual bool CreateValid() {
            bool isValid = true;
            isValid = Address_ID_Rules.Create.passes(Address_ID) && isValid;
            isValid = Contact_ID_Rules.Create.passes(Contact_ID) && isValid;
            isValid = Apartment_Number_Rules.Create.passes(Apartment_Number) && isValid;
            isValid = Street_Number_Rules.Create.passes(Street_Number) && isValid;
            isValid = Street_Name_Rules.Create.passes(Street_Name) && isValid;
            isValid = City_Rules.Create.passes(City) && isValid;
            isValid = Postal_Code_Rules.Create.passes(Postal_Code) && isValid;
            isValid = State_ID_Rules.Create.passes(State_ID) && isValid;
            isValid = Country_ID_Rules.Create.passes(Country_ID) && isValid;
            return isValid;
        }

        public virtual bool UpdateValid(){
            bool isValid = true;
            isValid = Address_ID_Rules.Update.passes(Address_ID) && isValid;
            isValid = Contact_ID_Rules.Update.passes(Contact_ID) && isValid;
            isValid = Apartment_Number_Rules.Update.passes(Apartment_Number) && isValid;
            isValid = Street_Number_Rules.Update.passes(Street_Number) && isValid;
            isValid = Street_Name_Rules.Update.passes(Street_Name) && isValid;
            isValid = City_Rules.Update.passes(City) && isValid;
            isValid = Postal_Code_Rules.Update.passes(Postal_Code) && isValid;
            isValid = State_ID_Rules.Update.passes(State_ID) && isValid;
            isValid = Country_ID_Rules.Update.passes(Country_ID) && isValid;
            return isValid;
        }

        public virtual bool DeleteValid() {
            return true;                    //This entity will always be valid for deletion.
        }

        public virtual bool Equivilant(IBusinessUnit comparing) {
            return false;                   //Never equivilant at this layer.
        }
    }
}
