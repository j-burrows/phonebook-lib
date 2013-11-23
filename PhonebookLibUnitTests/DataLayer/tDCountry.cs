/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       tDCountry.cs
 |  Purpose:    Generates a set of tests for a data country.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Data.Entities;
namespace PhonebookLibUnitTests.DataLayer{
    [TestClass]
    public class tDCountry{
        [TestMethod]
        public void DCountryWithHtmlLongName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>";
            DCountry country = new DCountry { Long_Name = malicious };
            country.Scrub();
            Assert.AreNotEqual(country.Long_Name, malicious);
        }
        
        [TestMethod]
        public void DCountryWithHtmlShortName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>";
            DCountry country = new DCountry { Short_Name = malicious };
            country.Scrub();
            Assert.AreNotEqual(country.Short_Name, malicious);
        }

        [TestMethod]
        public void DCountryWithSqlLongName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DCountry country = new DCountry { Long_Name = malicious };
            country.Scrub();
            Assert.AreNotEqual(country.Long_Name, malicious);
        }

        [TestMethod]
        public void DCountryWithSqlShortName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DCountry country = new DCountry { Short_Name = malicious };
            country.Scrub();
            Assert.AreNotEqual(country.Short_Name, malicious);
        }

        [TestMethod]
        public void DCountryWithHtmlAndSqlLongName_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DCountry country = new DCountry { Long_Name = malicious };
            country.Scrub();
            Assert.AreNotEqual(country.Long_Name, malicious);
        }

        [TestMethod]
        public void DCountryWithHtmlAndSqlShortName_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DCountry country = new DCountry { Short_Name = malicious };
            country.Scrub();
            Assert.AreNotEqual(country.Short_Name, malicious);
        }

        [TestMethod]
        public void DCountry_WhenComparedAgainstDCountryWithSameKey_IsEquivilant(){
            int key = 1;
            DCountry first = new DCountry { key = key };
            DCountry second = new DCountry { key = key };
            bool equal = first.Equivilant(second);
            Assert.AreEqual(true, equal);
        }

        [TestMethod]
        public void DCountry_WhenAskedForKey_ReturnsCountryID(){
            DCountry country = new DCountry { Country_ID = -1 };
            int key = country.key;
            Assert.AreEqual(key, country.Country_ID);
        }
    }
}
