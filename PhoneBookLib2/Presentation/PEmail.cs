/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PEmail.cs
 |  Purpose:    Defines an email which can be formatted to avoid rendering errors.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using PhoneBookLib.Base;
using Repository.Presentation;
namespace PhoneBookLib.Presentation{
    public class PEmail : Email, IPresentationUnit{
        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Format
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        public virtual void Format() {
            if(Url == null){
                Url = string.Empty;
            }
        }
    }
}
