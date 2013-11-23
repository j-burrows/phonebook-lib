/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       tDPhoneAddress.cs
 |  Purpose:    Generates a set of tests for a data phone address.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Data.Entities;
namespace PhonebookLibUnitTests.DataLayer{
    [TestClass]
    public class tDPhoneAddress{
        [TestMethod]
        public void DPhoneAddress_WhenComparedAgainstDPhoneAddressWithSameKey_IsEquivilant(){
            //Arrange: Create two distinct phone_address with equivilant primary keys
            int key = 1;
            DPhoneAddress first = new DPhoneAddress { key = key, Area_Code=1};
            DPhoneAddress second = new DPhoneAddress { key = key, Area_Code = 2};

            //Act: the phone_address are checked for equivilance.
            bool equal = first.Equivilant(second);

            //Assert: The two phone_address are equivilant.
            Assert.AreEqual(true, equal);
        }

        [TestMethod]
        public void DPhoneAddress_WhenAskedForKey_ReturnsCountryID(){
            //Arrange: A phone_address is created with a phone_address id.
            DPhoneAddress phone_address = new DPhoneAddress { PhoneAddress_ID = -1 };

            //Act: the primary key is retrieved.
            int key = phone_address.key;

            //Assert: the retrieved key is equal to the phone_address id.
            Assert.AreEqual(key, phone_address.PhoneAddress_ID);
        }
    }
}
