/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Place.cs
 |  Purpose:    Generates a set of tests for a business place.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace PhonebookLibUnitTests.BusinessLayer{
    [TestClass]
    public class tBPlace{
        [TestMethod]
        public void BusinessPlace_WithValidMembers_IsCreateValid() { }
        [TestMethod]
        public void BusinessPlace_WithInvalidMembers_IsNotCreateValid() { }
        [TestMethod]
        public void BusinessPlace_WithValidMembers_IsUpdateValid() { }
        [TestMethod]
        public void BusinessPlace_WithInvalidMembers_IsUpdateValid() { }
        [TestMethod]
        public void BusinessPlace_IsDeleteValid() { }
        [TestMethod]
        public void BusinessPlace_ComparedToOthers_IsNotEquivilant() { }
    }
}
