/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PhoneAddress.cs
 |  Purpose:    Generates a set of tests for a business phone address.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PhonebookLibUnitTests.BusinessLayer{
    [TestClass]
    public class tBPhoneAddress{
        [TestMethod]
        public void BusinessPhoneAddress_WithValidMembers_IsCreateValid() { }
        [TestMethod]
        public void BusinessPhoneAddress_WithInvalidMembers_IsNotCreateValid() { }
        [TestMethod]
        public void BusinessPhoneAddress_WithValidMembers_IsUpdateValid() { }
        [TestMethod]
        public void BusinessPhoneAddress_WithInvalidMembers_IsUpdateValid() { }
        [TestMethod]
        public void BusinessPhoneAddress_IsDeleteValid() { }
        [TestMethod]
        public void BusinessPhoneAddress_ComparedToOthers_IsNotEquivilant() { }
    }
}
