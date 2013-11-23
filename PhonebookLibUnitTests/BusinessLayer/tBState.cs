/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       State.cs
 |  Purpose:    Generates a set of tests for a business state.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PhonebookLibUnitTests.BusinessLayer{
    [TestClass]
    public class tBState{
        [TestMethod]
        public void BusinessState_WithValidMembers_IsCreateValid() { }
        [TestMethod]
        public void BusinessState_WithInvalidMembers_IsNotCreateValid() { }
        [TestMethod]
        public void BusinessState_WithValidMembers_IsUpdateValid() { }
        [TestMethod]
        public void BusinessState_WithInvalidMembers_IsUpdateValid() { }
        [TestMethod]
        public void BusinessState_IsDeleteValid() { }
        [TestMethod]
        public void BusinessState_ComparedToOthers_IsNotEquivilant() { }
    }
}
