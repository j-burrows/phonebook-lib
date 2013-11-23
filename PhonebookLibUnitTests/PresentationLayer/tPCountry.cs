/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PCountry.cs
 |  Purpose:    Generates a set of tests for a presentation country.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Presentation;
namespace PhonebookLibUnitTests.PresentationLayer{
    [TestClass]
    public class tPCountry{
        [TestMethod]
        public void PCountryWithNullMembers_WhenFormatted_MembersBecomeEmpty(){
            //Arrange: A country whos members which are string are all null
            PCountry country = new PCountry { Long_Name = null, Short_Name = null };

            //Act: The country is formatted.
            country.Format();

            //Assert: The Country members which are string are now all empty
            Assert.AreEqual(country.Short_Name, string.Empty);
            Assert.AreEqual(country.Long_Name, string.Empty);
        }
    }
}
