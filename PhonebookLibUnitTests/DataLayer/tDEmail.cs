/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       tDEmail.cs
 |  Purpose:    Generates a set of tests for a data email.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Data.Entities;
namespace PhonebookLibUnitTests.DataLayer{
    [TestClass]
    public class tDEmail{
        [TestMethod]
        public void DEmailWithHtmlUrl_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>";
            DEmail email = new DEmail { Url = malicious };
            email.Scrub();
            Assert.AreNotEqual(email.Url, malicious);
        }

        [TestMethod]
        public void DEmailWithSqlUrl_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DEmail email = new DEmail { Url = malicious };
            email.Scrub();
            Assert.AreNotEqual(email.Url, malicious);
        }

        [TestMethod]
        public void DEmailWithHtmlAndSqlUrl_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DEmail email = new DEmail { Url = malicious };
            email.Scrub();
            Assert.AreNotEqual(email.Url, malicious);
        }

        [TestMethod]
        public void DEmail_WhenComparedAgainstDEmailWithSameKey_IsEquivilant(){
            int key = 1;
            DEmail first = new DEmail { key = key, Url = "First" };
            DEmail second = new DEmail { key = key, Url = "Second" };
            bool equal = first.Equivilant(second);
            Assert.AreEqual(true, equal);
        }

        [TestMethod]
        public void DEmail_WhenAskedForKey_ReturnsCountryID(){
            DEmail email = new DEmail { Email_ID = -1 };
            int key = email.key;
            Assert.AreEqual(key, email.Email_ID);
        }
    }
}
