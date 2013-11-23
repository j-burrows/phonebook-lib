/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PCountry.cs
 |  Purpose:    Defines a sovereign nation which can be formatted to avoid rendering errors.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using PhoneBookLib.Base;
using Repository.Presentation;
namespace PhoneBookLib.Presentation{
    public class PCountry : Country, IPresentationUnit{
        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Format
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        public virtual void Format() { 
            if(Long_Name == null){
                Long_Name = string.Empty;
            }
            if(Short_Name == null){
                Short_Name = string.Empty;
            }
        }
    }
}
