/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Contact.cs
 |  Purpose:    Generates a set of tests for a business address.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Business;
namespace PhonebookLibUnitTests.BusinessLayer{
    [TestClass]
    public class tBContact{
        [TestMethod]
        public void BusinessContact_WithValidMembers_IsCreateValid() {
            //Arrange: A contact with a valid first and last name is created.
            BContact contact = new BContact { 
                First_Name = "John", 
                Last_Name = "Smith", 
                username="username"
            };

            //Act: the contact is checked to be valid for creation.
            bool valid = contact.CreateValid();

            //Assert: The contact is valid for creation
            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void BusinessContact_WithInvalidMembers_IsNotCreateValid(){
            //Arrange: A contact with an invalid first and last name is created.
            BContact contact = new BContact { First_Name = null, Last_Name = null };

            //Act: the contact is checked to be valid for creation.
            bool valid = contact.CreateValid();

            //Assert: The contact is not valid for creation
            Assert.AreEqual(false, valid);
        }

        [TestMethod]
        public void BusinessContact_WithValidMembers_IsUpdateValid(){
            //Arrange: A contact with a valid first and last name.
            BContact contact = new BContact { First_Name = null, Last_Name = null };

            //Act: the contact is checked to be valid for updating.
            bool valid = contact.UpdateValid();

            //Assert: The contact is valid for updating
            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void BusinessContact_WithInvalidMembers_IsNotUpdateValid(){
            //Arrange: A contact with an invalid first and last name is created.
            BContact contact = new BContact { 
                First_Name = "123123123123123123123", 
                Last_Name = "123123123123123123123" 
            };

            //Act: the contact is checked to be valid for creation.
            bool valid = contact.UpdateValid();

            //Assert: The contact is valid for creation
            Assert.AreEqual(false, valid);
        }

        [TestMethod]
        public void BusinessContact_IsDeleteValid(){
            //Arrange: A standard contact is created
            BContact contact = new BContact ();

            //Act: the contact is checked to be valid for creation.
            bool valid = contact.DeleteValid();

            //Assert: The contact is valid for creation
            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void BusinessContact_ComparedToOthers_IsNotEquivilant(){
            //Arrange: A contact with a normal first and last name is created.
            BContact contact = new BContact { First_Name = "John", Last_Name = "Smith" };

            //Act: the contact is checked against itself to be equivilant.
            bool equals = contact.Equivilant(contact);

            //Assert: The contact is not equivilant.
            Assert.AreEqual(false, equals);
        }
    }
}
