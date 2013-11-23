/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Address.cs
 |  Purpose:    Generates a set of tests for a business address.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Business;
namespace PhonebookLibUnitTests.BusinessLayer{
    [TestClass]
    public class BusinessLayer{
        [TestMethod]
        public void BAddressWithValidNameCityOrPostalCode_WhenCreateValidated_IsTrue(){ 
            BAddress address = new BAddress { 
                Street_Number = 1, 
                Street_Name="Street Name", 
                City = "City", 
                Postal_Code= "VVV VVV"
            };
            bool valid = address.CreateValid();
            Assert.AreEqual(valid, true);
        }

        [TestMethod]
        public void BAddressWithInvalidNameCityOrPostalCode_WhenCreateValidated_IsFalse() {
            BAddress address = new BAddress { 
                Street_Number = -1, 
                City = "12312312312312312312312312313", 
                Postal_Code = "VVV VVVVV" 
            };
            bool valid = address.CreateValid();
            Assert.AreEqual(valid, false);
        }

        [TestMethod]
        public void BAddressWithValidNameCityOrPostalCode_WhenUpdateValidated_IsTrue() {
            BAddress address = new BAddress { 
                Street_Number = 1, 
                Street_Name="Street Name", 
                City = "City", 
                Postal_Code = "VVV VVV" 
            };
            bool valid = address.UpdateValid();
            Assert.AreEqual(valid, true);
        }

        [TestMethod]
        public void BAddressWithInvalidNameCityOrPostalCode_WhenUpdateValidated_IsFalse() {
            BAddress address = new BAddress { 
                Street_Number = 1, 
                City = "123123123123123123123123123", 
                Postal_Code = "VVVVVVVVVV" 
            };
            bool valid = address.UpdateValid();
            Assert.AreEqual(valid, false);
        }

        [TestMethod]
        public void BAddress_WhenDeleteValidated_IsTrue(){
            BAddress address = new BAddress();
            bool valid = address.DeleteValid();
            Assert.AreEqual(valid, true);
        }

        [TestMethod]
        public void BAddress_WhenCheckedForEquivilance_IsFalse() {
            //Arrange: An address with all valid members is created.
            BAddress address = new BAddress();
            
            //Act: The address is checked to be valid for creation.
            bool valid = address.Equivilant(null);
            
            //Assert: The address is create valid.
            Assert.AreEqual(valid, false);
        }
    }
}
