/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PContact.cs
 |  Purpose:    Generates a set of tests for a presentation contact.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Presentation;
namespace PhonebookLibUnitTests.PresentationLayer{
    [TestClass]
    public class tPContact{
        [TestMethod]
        public void PContactWithNullMembers_WhenFormatted_MembersBecomeEmpty(){
            //Arrange: A contact whos members which are string are all null
            PContact contact = new PContact { First_Name = null, Last_Name = null, Relation = null };

            //Act: The contact is formatted
            contact.Format();

            //Assert: the address members which are string are now empty
            Assert.AreEqual(contact.First_Name, string.Empty);
            Assert.AreEqual(contact.Last_Name, string.Empty);
            Assert.AreEqual(contact.Relation, string.Empty);
        }
    }
}
