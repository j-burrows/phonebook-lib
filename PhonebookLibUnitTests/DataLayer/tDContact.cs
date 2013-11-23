/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       tDContact.cs
 |  Purpose:    Generates a set of tests for a data contact.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Data.Entities;
namespace PhonebookLibUnitTests.DataLayer{
    [TestClass]
    public class tDContact{
        [TestMethod]
        public void DContactWithHtmlFirstName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>";
            DContact contact = new DContact {  First_Name = malicious};
            contact.Scrub();
            Assert.AreNotEqual(contact.First_Name, malicious);
        }
        
        [TestMethod]
        public void DContactWithHtmlLastName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>";
            DContact contact = new DContact {  Last_Name = malicious};
            contact.Scrub();
            Assert.AreNotEqual(contact.Last_Name, malicious);
        }
        
        [TestMethod]
        public void DContactWithHtmlUsername_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>";
            DContact contact = new DContact {  username = malicious};
            contact.Scrub();
            Assert.AreNotEqual(contact.username, malicious);
        }
        
        [TestMethod]
        public void DContactWithHtmlRelation_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>";
            DContact contact = new DContact {  Relation = malicious};
            contact.Scrub();
            Assert.AreNotEqual(contact.Relation, malicious);
        }

        [TestMethod]
        public void DContactWithSqlMembers_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DContact contact = new DContact { First_Name = malicious };
            contact.Scrub();
            Assert.AreNotEqual(contact.First_Name, malicious);
        }
        
        [TestMethod]
        public void DContactWithSqlFirstName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DContact contact = new DContact { First_Name = malicious };
            contact.Scrub();
            Assert.AreNotEqual(contact.First_Name, malicious);
        }
        
        [TestMethod]
        public void DContactWithSqlLastName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DContact contact = new DContact { Last_Name = malicious };
            contact.Scrub();
            Assert.AreNotEqual(contact.Last_Name, malicious);
        }
        
        [TestMethod]
        public void DContactWithSqlUsername_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DContact contact = new DContact { username = malicious };
            contact.Scrub();
            Assert.AreNotEqual(contact.username, malicious);
        }
        
        [TestMethod]
        public void DContactWithSqlRelation_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DContact contact = new DContact { Relation = malicious };
            contact.Scrub();
            Assert.AreNotEqual(contact.Relation, malicious);
        }

        [TestMethod]
        public void DContactWithHtmlAndSqlFirstName_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DContact contact = new DContact { First_Name = malicious };
            contact.Scrub();
            Assert.AreNotEqual(contact.First_Name, malicious);
        }

        [TestMethod]
        public void DContactWithHtmlAndSqlLastName_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DContact contact = new DContact { Last_Name = malicious };
            contact.Scrub();
            Assert.AreNotEqual(contact.Last_Name, malicious);
        }

        [TestMethod]
        public void DContactWithHtmlAndSqlUsername_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DContact contact = new DContact { username = malicious };
            contact.Scrub();
            Assert.AreNotEqual(contact.username, malicious);
        }

        [TestMethod]
        public void DContactWithHtmlAndSqlRelation_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DContact contact = new DContact { Relation = malicious };
            contact.Scrub();
            Assert.AreNotEqual(contact.Relation, malicious);
        }

        [TestMethod]
        public void DContact_WhenComparedAgainstDContactWithSameKey_IsEquivilant(){
            int key = 1;
            DContact first = new DContact { key = key};
            DContact second = new DContact { key = key};
            bool equal = first.Equivilant(second);
            Assert.AreEqual(true, equal);
        }

        [TestMethod]
        public void DContact_WhenAskedForKey_ReturnsAddressID(){
            DContact contact = new DContact { Contact_ID = 11 };
            int key = contact.key;
            Assert.AreEqual(key, contact.Contact_ID);
        }
    }
}
