/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PAddress.cs
 |  Purpose:    Generates a set of tests for a presentation address.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Presentation;
namespace PhonebookLibUnitTests.PresentationLayer{
    [TestClass]
    public class tPAddress{
        [TestMethod]
        public void PAddressWithNullMembers_WhenFormatted_MembersBecomeEmpty(){
            //Arrange: An address whos members which are strings are all null
            PAddress address = new PAddress { Postal_Code = null, City = null, Street_Name = null };

            //Act: The address is formatted
            address.Format();

            //Assert: The addresses members which are strings are now empty
            Assert.AreEqual(address.Postal_Code, string.Empty);
            Assert.AreEqual(address.City, string.Empty);
            Assert.AreEqual(address.Street_Name, string.Empty);
        }
    }
}
