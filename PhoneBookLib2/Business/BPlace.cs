/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       BPhoneAddress.cs
 |  Purpose:    Defines a business logical and rules of what an place must be.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using PhoneBookLib.Presentation;
using Repository.Business;
using Repository.Business.Protocols;
namespace PhoneBookLib.Business{
    public class BPlace : PPlace, IBusinessUnit{
        public readonly ProtocolStack Place_ID_Rules = ProtocolStack.ForKey("Place_ID");
        public readonly ProtocolStack Long_Name_Rules = ProtocolStack.WithPremise(
            new Premise { maxLength = 16, nullable = false }, "Long_Name");
        public readonly ProtocolStack Short_Name_Rules = ProtocolStack.WithPremise(
            new Premise { maxLength = 2, nullable = false }, "Short_Name");

        public virtual bool CreateValid(){
            bool isValid = true;
            isValid = Place_ID_Rules.Create.passes(Place_ID) && isValid;
            isValid = Long_Name_Rules.Create.passes(Long_Name) && isValid;
            isValid = Short_Name_Rules.Create.passes(Short_Name) && isValid;
            return isValid;
        }

        public virtual bool UpdateValid(){
            bool isValid = true;
            isValid = Place_ID_Rules.Update.passes(Place_ID) && isValid;
            isValid = Long_Name_Rules.Update.passes(Long_Name) && isValid;
            isValid = Short_Name_Rules.Update.passes(Short_Name) && isValid;
            return isValid;
        }

        public virtual bool DeleteValid(){
            return true;                    //Will always be valid for deletion.
        }

        public virtual bool Equivilant(IBusinessUnit comparing){
            return false;                   //Never equivilant (no unique attributes)
        }
    }
}
