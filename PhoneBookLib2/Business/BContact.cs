/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       BContact.cs
 |  Purpose:    Defines a business logical and rules of what an human contact must be.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using PhoneBookLib.Presentation;
using Repository.Business;
using Repository.Business.Protocols;
namespace PhoneBookLib.Business{
    public class BContact : PContact, IBusinessUnit{
        public readonly ProtocolStack Contact_ID_Rules = ProtocolStack.ForKey("Contact_ID");
        public readonly ProtocolStack username_Rules = ProtocolStack.ForUsername();
        public readonly ProtocolStack First_Name_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = false, maxLength = 16 }, "First_Name");
        public readonly ProtocolStack Last_Name_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = false, maxLength = 16 }, "Last_Name");
        public readonly ProtocolStack Middle_Initial_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = true, maxLength = 1 }, "Middle_Initial");
        public readonly ProtocolStack Relation_Rules = ProtocolStack.WithPremise(
            new Premise { nullable = true, minLength = 64 }, "Relation");
        
        public BContact() : base() {
            phoneAddresses = new BusinessRepository<BPhoneAddress>();
            emails = new BusinessRepository<BEmail>();
            addresses = new BusinessRepository<BAddress>();
        }

        public virtual bool CreateValid() {
            bool isValid = true;
            isValid = Contact_ID_Rules.Create.passes(Contact_ID) && isValid;
            isValid = username_Rules.Create.passes(username) && isValid;
            isValid = First_Name_Rules.Create.passes(First_Name) && isValid;
            isValid = Last_Name_Rules.Create.passes(Last_Name) && isValid;
            isValid = Middle_Initial_Rules.Create.passes(Middle_Initial) && isValid;
            isValid = Relation_Rules.Create.passes(Relation) && isValid;
            return isValid;
        }

        public virtual bool UpdateValid(){
            bool isValid = true;
            isValid = Contact_ID_Rules.Update.passes(Contact_ID) && isValid;
            isValid = username_Rules.Update.passes(username) && isValid;
            isValid = First_Name_Rules.Update.passes(First_Name) && isValid;
            isValid = Last_Name_Rules.Update.passes(Last_Name) && isValid;
            isValid = Middle_Initial_Rules.Update.passes(Middle_Initial) && isValid;
            isValid = Relation_Rules.Update.passes(Relation) && isValid;
            return isValid;
        }

        public virtual bool DeleteValid(){
            return true;                    //Will always be valid for deletion.
        }

        public virtual bool Equivilant(IBusinessUnit comparing) {
            //Will never be equivilant to other business units (No unique attributes)
            return false;
        }
    }
}
