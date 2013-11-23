/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PAddress.cs
 |  Purpose:    Defines an address which can be formatted to avoid rendering errors.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using PhoneBookLib.Base;
using Repository.Presentation;
namespace PhoneBookLib.Presentation{
    public class PAddress : Address, IPresentationUnit{
        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Format
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        public virtual void Format() { 
            if(Street_Name == null){
                Street_Name = string.Empty;
            }
            if(City == null){
                City = string.Empty;
            }
            if(Postal_Code == null){
                Postal_Code = string.Empty;
            }
        }
    }
}
