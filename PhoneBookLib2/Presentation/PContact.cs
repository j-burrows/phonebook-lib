using System.Linq;
/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PContact.cs
 |  Purpose:    Defines a contact which can be formatted to avoid rendering errors.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using PhoneBookLib.Base;
using Repository.Presentation;
namespace PhoneBookLib.Presentation{
    public class PContact : Contact, IPresentationUnit{
        public PContact() {        }

        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Format
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        public virtual void Format() { 
            if(First_Name == null){
                First_Name = string.Empty;
            }
            if(Last_Name == null){
                Last_Name = string.Empty;
            }
            if(Relation == null){
                Relation = string.Empty;
            }
            if(username == null){
                username = string.Empty;
            }
            if(phoneAddresses == null){
                phoneAddresses = Enumerable.Empty<PhoneAddress>();
            }
            if (emails == null){
                emails = Enumerable.Empty<PEmail>();
            }
            if (addresses == null){
                addresses = Enumerable.Empty<PAddress>();
            }
        }
    }
}
