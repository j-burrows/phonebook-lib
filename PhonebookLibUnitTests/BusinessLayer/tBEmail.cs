/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Email.cs
 |  Purpose:    Generates a set of tests for a business email.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PhonebookLibUnitTests.BusinessLayer{
    [TestClass]
    public class tBEmail{
        [TestMethod]
        public void BusinessEmail_WithValidMembers_IsCreateValid() { }
        [TestMethod]
        public void BusinessEmail_WithInvalidMembers_IsNotCreateValid() { }
        [TestMethod]
        public void BusinessEmail_WithValidMembers_IsUpdateValid() { }
        [TestMethod]
        public void BusinessEmail_WithInvalidMembers_IsUpdateValid() { }
        [TestMethod]
        public void BusinessEmail_IsDeleteValid() { }
        [TestMethod]
        public void BusinessEmail_ComparedToOthers_IsNotEquivilant() { }
    }
}
