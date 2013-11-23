/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PState.cs
 |  Purpose:    Generates a set of tests for a presentation state.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Presentation;
namespace PhonebookLibUnitTests.PresentationLayer{
    [TestClass]
    public class tPState{
        [TestMethod]
        public void PStateWithNullMembers_WhenFormatted_MembersBecomeEmpty(){
            //Arrange: A state whos members are strings are set to null.
            PState state = new PState { Long_Name = null, Short_Name = null };

            //Act: The state is formatted.
            state.Format();

            //Assert: all string members are now set to empty.
            Assert.AreEqual(state.Long_Name, string.Empty);
            Assert.AreEqual(state.Short_Name, string.Empty);
        }
    }
}
