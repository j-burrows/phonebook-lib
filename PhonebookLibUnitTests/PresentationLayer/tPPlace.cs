/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PPlace.cs
 |  Purpose:    Generates a set of tests for a presentation place.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Presentation;
namespace PhonebookLibUnitTests.PresentationLayer{
    [TestClass]
    public class tPPlace{
        [TestMethod]
        public void PPlaceWithNullMembers_WhenFormatted_MembersBecomeEmpty(){
            //Arrange: A place whos members are strings are set to null
            PPlace place = new PPlace { Short_Name = null, Long_Name = null };

            //Act: the place is formatted.
            place.Format();

            //Assert: all string members are now set to empty.
            Assert.AreEqual(place.Long_Name, string.Empty);
            Assert.AreEqual(place.Short_Name, string.Empty);
        }
    }
}
