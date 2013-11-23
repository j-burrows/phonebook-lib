/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       BState.cs
 |  Purpose:    Defines a business logical and rules of what a province/state must be.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using PhoneBookLib.Presentation;
using Repository.Business;
using Repository.Business.Protocols;
namespace PhoneBookLib.Business{
    public class BState : PState, IBusinessUnit{
        public readonly ProtocolStack State_ID_Rules = ProtocolStack.ForKey("State_ID");
        public readonly ProtocolStack Country_ID_Rules = ProtocolStack.ForKey("State_ID");
        public readonly ProtocolStack Long_Name_Rules = ProtocolStack.WithPremise(
            new Premise { maxLength = 16, nullable = false }, "Long_Name");
        public readonly ProtocolStack Short_Name_Rules = ProtocolStack.WithPremise(
            new Premise { maxLength = 2, nullable = false }, "Short_Name");

        public virtual bool CreateValid(){
            bool isValid = true;
            isValid = State_ID_Rules.Create.passes(State_ID) && isValid;
            isValid = Country_ID_Rules.Create.passes(Country_ID) && isValid;
            isValid = Long_Name_Rules.Create.passes(Long_Name) && isValid;
            isValid = Short_Name_Rules.Create.passes(Short_Name) && isValid;
            return isValid;
        }

        public virtual bool UpdateValid(){
            bool isValid = true;
            isValid = State_ID_Rules.Update.passes(State_ID) && isValid;
            isValid = Country_ID_Rules.Update.passes(Country_ID) && isValid;
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
