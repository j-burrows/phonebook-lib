/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       tDPlace.cs
 |  Purpose:    Generates a set of tests for a data place.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Data.Entities;
namespace PhonebookLibUnitTests.DataLayer{
    [TestClass]
    public class tDPlace{
        [TestMethod]
        public void DPlaceWithHtmlLongName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>";
            DPlace place = new DPlace { Long_Name = malicious };
            place.Scrub();
            Assert.AreNotEqual(place.Long_Name, malicious);
        }
        
        [TestMethod]
        public void DPlaceWithHtmlShortName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>";
            DPlace place = new DPlace { Short_Name = malicious };
            place.Scrub();
            Assert.AreNotEqual(place.Short_Name, malicious);
        }

        [TestMethod]
        public void DPlaceWithSqlLongName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DPlace place = new DPlace { Long_Name = malicious };
            place.Scrub();
            Assert.AreNotEqual(place.Long_Name, malicious);
        }

        [TestMethod]
        public void DPlaceWithSqlShortName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DPlace place = new DPlace { Short_Name = malicious };
            place.Scrub();
            Assert.AreNotEqual(place.Short_Name, malicious);
        }

        [TestMethod]
        public void DPlaceWithHtmlAndSqlLongName_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DPlace place = new DPlace { Long_Name = malicious };
            place.Scrub();
            Assert.AreNotEqual(place.Long_Name, malicious);
        }

        [TestMethod]
        public void DPlaceWithHtmlAndSqlShortName_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DPlace place = new DPlace { Short_Name = malicious };
            place.Scrub();
            Assert.AreNotEqual(place.Short_Name, malicious);
        }

        [TestMethod]
        public void DPlace_WhenComparedAgainstDPlaceWithSameKey_IsEquivilant(){
            int key = 1;
            DPlace first = new DPlace { key = key };
            DPlace second = new DPlace { key = key };
            bool equal = first.Equivilant(second);
            Assert.AreEqual(true, equal);
        }

        [TestMethod]
        public void DPlace_WhenAskedForKey_ReturnsCountryID(){
            DPlace place = new DPlace { Place_ID = -1 };
            int key = place.key;
            Assert.AreEqual(key, place.Place_ID);
        }
    }
}
