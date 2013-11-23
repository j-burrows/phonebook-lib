/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       BPhoneAddress.cs
 |  Purpose:    Defines a business logic and rules of what an phone address must be.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using PhoneBookLib.Presentation;
using Repository.Business;
using Repository.Business.Protocols;
namespace PhoneBookLib.Business{
    public class BPhoneAddress : PPhoneAddress, IBusinessUnit{
        public readonly ProtocolStack PhoneAddress_ID_Rules 
            = ProtocolStack.ForKey("PhoneAddress_ID");
        public readonly ProtocolStack Contact_ID_Rules = ProtocolStack.ForKey("Contact_ID");
        public readonly ProtocolStack Area_Code_Rules = ProtocolStack.WithPremise(
            new Premise { minValue = 100, maxValue = 999, numeric = true, stepValue = 1 },
            "Area_Code");
        public readonly ProtocolStack Remote_Address_Rules = ProtocolStack.WithPremise(
            new Premise { minValue = 100, maxValue = 999, numeric = true, stepValue = 1 },
            "Remote_Address");
        public readonly ProtocolStack Local_Address_Rules = ProtocolStack.WithPremise(
            new Premise { minValue = 1000, maxValue = 9999, numeric = true, stepValue = 1 },
            "Local_Address");
        
        public virtual bool CreateValid(){
            bool isValid = true;
            isValid = PhoneAddress_ID_Rules.Create.passes(PhoneAddress_ID) && isValid;
            isValid = Contact_ID_Rules.Create.passes(Contact_ID) && isValid;
            isValid = Area_Code_Rules.Create.passes(Area_Code) && isValid;
            isValid = Remote_Address_Rules.Create.passes(Remote_Address) && isValid;
            isValid = Local_Address_Rules.Create.passes(Local_Address) && isValid;
            return isValid;
        }

        public virtual bool UpdateValid() {
            bool isValid = true;
            isValid = PhoneAddress_ID_Rules.Update.passes(PhoneAddress_ID) && isValid;
            isValid = Contact_ID_Rules.Update.passes(Contact_ID) && isValid;
            isValid = Area_Code_Rules.Update.passes(Area_Code) && isValid;
            isValid = Remote_Address_Rules.Update.passes(Remote_Address) && isValid;
            isValid = Local_Address_Rules.Update.passes(Local_Address) && isValid;
            return isValid;
        }

        public virtual bool DeleteValid(){
            return true;                    //Will always be valid for deletion.
        }

        public virtual bool Equivilant(IBusinessUnit comparing) {
            return false;                   //Never is equivilant (no unique attributes).
        }
    }
}
