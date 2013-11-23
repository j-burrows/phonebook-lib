/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       tDAddress.cs
 |  Purpose:    Generates a set of tests for a data address.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Data.Entities;
namespace PhonebookLibUnitTests.DataLayer{
    [TestClass]
    public class tDAddress{
        [TestMethod]
        public void DAddressWithHtmlStreet_WhenScrubbed_BecomesSafe() {
            string malicious = "<div>Hello, world!</div>";
            DAddress address = new DAddress { Street_Name = malicious};
            address.Scrub();
            Assert.AreNotEqual(address.Street_Name, malicious);
        }
        
        [TestMethod]
        public void DAddressWithHtmlCity_WhenScrubbed_BecomesSafe() {
            string malicious = "<div>Hello, world!</div>";
            DAddress address = new DAddress { City = malicious};
            address.Scrub();
            Assert.AreNotEqual(address.City, malicious);
        }
        
        [TestMethod]
        public void DAddressWithHtmlPostalCode_WhenScrubbed_BecomesSafe() {
            string malicious = "<div>Hello, world!</div>";
            DAddress address = new DAddress { Postal_Code = malicious};
            address.Scrub();
            Assert.AreNotEqual(address.Street_Name, malicious);
        }

        [TestMethod]
        public void DAddressWithSqlStreet_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DAddress address = new DAddress { Street_Name = malicious };
            address.Scrub();
            Assert.AreNotEqual(address.Street_Name, malicious);
        }
        
        [TestMethod]
        public void DAddressWithSqlCity_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DAddress address = new DAddress { City = malicious };
            address.Scrub();
            Assert.AreNotEqual(address.City, malicious);
        }
        
        [TestMethod]
        public void DAddressWithSqlPostalCode_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DAddress address = new DAddress { Postal_Code = malicious };
            address.Scrub();
            Assert.AreNotEqual(address.Postal_Code, malicious);
        }

        [TestMethod]
        public void DAddressWithHtmlAndSqlStreet_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DAddress address = new DAddress { Street_Name = malicious };
            address.Scrub();
            Assert.AreNotEqual(address.Street_Name, malicious);
        }

        [TestMethod]
        public void DAddressWithHtmlAndSqlCity_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DAddress address = new DAddress { City = malicious };
            address.Scrub();
            Assert.AreNotEqual(address.City, malicious);
        }

        [TestMethod]
        public void DAddressWithHtmlAndSqlPostalCode_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DAddress address = new DAddress { Postal_Code = malicious };
            address.Scrub();
            Assert.AreNotEqual(address.Postal_Code, malicious);
        }

        [TestMethod]
        public void DAddress_WhenComparedAgainstDAddressWithSameKey_IsEquivilant() { 
            int key = 1;
            DAddress first = new DAddress { key = key };
            DAddress second = new DAddress { key = key };

            bool equal = first.Equivilant(second);
            Assert.AreEqual(true, equal);
        }

        [TestMethod]
        public void DAddress_WhenAskedForKey_ReturnsAddressID(){
            DAddress address = new DAddress { Address_ID = -1 };
            int key = address.key;
            Assert.AreEqual(key, address.Address_ID);
        }

        [TestMethod]
        public void DAddress_WhenAssignedKey_ChangesAddressID() {
            int key = -1;
            DAddress address = new DAddress { key = key };
            Assert.AreEqual(key, address.Address_ID);
        }
    }
}
