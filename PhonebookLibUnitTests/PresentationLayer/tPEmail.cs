/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PEmail.cs
 |  Purpose:    Generates a set of tests for a presentation email.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Presentation;
namespace PhonebookLibUnitTests.PresentationLayer{
    [TestClass]
    public class tPEmail{
        [TestMethod]
        public void PEmailWithNullMembers_WhenFormatted_MembersBecomeEmpty(){
            //Arrange: An email with a null url
            PEmail email = new PEmail { Url = null };

            //Act: The email is formatted
            email.Format();

            //Assert: The email url is now empty
            Assert.AreEqual(email.Url, string.Empty);
        }
    }
}
