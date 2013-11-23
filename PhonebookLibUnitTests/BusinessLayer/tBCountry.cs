/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Country.cs
 |  Purpose:    Generates a set of tests for a business country.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Business;
namespace PhonebookLibUnitTests.BusinessLayer{
    [TestClass]
    public class tBCountry{
        [TestMethod]
        public void BusinessCountry_WithValidMembers_IsCreateValid() { 
            //Arrange: A country with valid short and long name is created.
            BCountry country = new BCountry { Long_Name = "Canada", Short_Name="CA"};

            //Act: The country is checked to be valid for creation.
            bool valid = country.CreateValid();

            //Assert: The country is valid for creation.
            Assert.AreEqual(true, valid) ;
        }
        [TestMethod]
        public void BusinessCountry_WithInvalidMembers_IsNotCreateValid(){
            //Arrange: A country with an invalid short and long name is created.
            BCountry country = new BCountry { 
                Long_Name = "Canadaaaaaaaaaaaaa", 
                Short_Name = "CAA" 
            };

            //Act: The country is checked to be valid for creation.
            bool valid = country.CreateValid();

            //Assert: The country is not valid for creation.
            Assert.AreEqual(false, valid);
        }

        [TestMethod]
        public void BusinessCountry_WithValidMembers_IsUpdateValid(){
            //Arrange: A country with valid short and long name is created.
            BCountry country = new BCountry { Long_Name = "Canada", Short_Name = "CA" };

            //Act: The country is checked to be valid for updating.
            bool valid = country.UpdateValid();

            //Assert: The country is valid for updating.
            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void BusinessCountry_WithInvalidMembers_IsNotUpdateValid(){
            //Arrange: A country with invalid short and long name is created.
            BCountry country = new BCountry{
                Long_Name = "Canadaaaaaaaaaaaaa",
                Short_Name = "CAA"
            };

            //Act: The country is checked to be valid for updating.
            bool valid = country.UpdateValid();

            //Assert: The country is not valid for updating.
            Assert.AreEqual(false, valid);
        }

        [TestMethod]
        public void BusinessCountry_IsDeleteValid(){
            //Arrange: A default country is created
            BCountry country = new BCountry ();

            //Act: The country is checked to be valid for deletion.
            bool valid = country.DeleteValid();

            //Assert: The country is valid for deletion.
            Assert.AreEqual(true, valid);
        }

        [TestMethod]
        public void BusinessCountry_ComparedToOthers_IsNotEquivilant(){
            //Arrange: A country with valid short and long name is created.
            BCountry country = new BCountry { Long_Name = "Canada", Short_Name = "CA" };

            //Act: The country is checked against itself for equivilance.
            bool equals = country.Equivilant(country);

            //Assert: The country is not equivilant to itself.
            Assert.AreEqual(false, equals);
        }
    }
}
