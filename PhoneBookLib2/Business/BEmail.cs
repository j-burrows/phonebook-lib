/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       BEmail.cs
 |  Purpose:    Defines a business logical and rules of what an email address must be.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using PhoneBookLib.Presentation;
using Repository.Business;
using Repository.Business.Protocols;
namespace PhoneBookLib.Business{
    public class BEmail : PEmail, IBusinessUnit{
        public readonly ProtocolStack Email_ID_Rules = ProtocolStack.ForKey("Email_ID_Rules");
        public readonly ProtocolStack Contact_ID_Rules = ProtocolStack.ForKey("Contact_ID");
        public readonly ProtocolStack Url_Rules = ProtocolStack.WithPremise(
            new Premise { maxLength = 1024, nullable = false}, "Url");

        public virtual bool CreateValid() {
            bool isValid = true;
            isValid = Email_ID_Rules.Create.passes(Email_ID) && isValid;
            isValid = Contact_ID_Rules.Create.passes(Contact_ID) && isValid;
            isValid = Url_Rules.Create.passes(Url) && isValid;
            return isValid;
        }

        public virtual bool UpdateValid() {
            bool isValid = true;
            isValid = Email_ID_Rules.Update.passes(Email_ID) && isValid;
            isValid = Contact_ID_Rules.Update.passes(Contact_ID) && isValid;
            isValid = Url_Rules.Update.passes(Url) && isValid;
            return isValid;
        }

        public virtual bool DeleteValid() {
            return true;                    //Will always be valid for deletion.
        }

        public virtual bool Equivilant(IBusinessUnit comparing) {
            return false;                   //Never is equivilant (no unique attributes).
        }
    }
}
