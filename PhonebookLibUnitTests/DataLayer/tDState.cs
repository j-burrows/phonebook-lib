/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       tDState.cs
 |  Purpose:    Generates a set of tests for a data state.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Data.Entities;
namespace PhonebookLibUnitTests.DataLayer{
    [TestClass]
    public class tDState{
        [TestMethod]
        public void DStateWithHtmlLongName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>";
            DState state = new DState { Long_Name = malicious };
            state.Scrub();
            Assert.AreNotEqual(state.Long_Name, malicious);
        }
        
        [TestMethod]
        public void DStateWithHtmlShortName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>";
            DState state = new DState { Short_Name = malicious };
            state.Scrub();
            Assert.AreNotEqual(state.Short_Name, malicious);
        }

        [TestMethod]
        public void DStateWithSqlLongName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DState state = new DState { Long_Name = malicious };
            state.Scrub();
            Assert.AreNotEqual(state.Long_Name, malicious);
        }

        [TestMethod]
        public void DStateWithSqlShortName_WhenScrubbed_BecomesSafe(){
            string malicious = "<div>Hello, world!</div>');DROP TABLE dbo.Users;--";
            DState state = new DState { Short_Name = malicious };
            state.Scrub();
            Assert.AreNotEqual(state.Short_Name, malicious);
        }

        [TestMethod]
        public void DStateWithHtmlAndSqlLongName_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DState state = new DState { Long_Name = malicious };
            state.Scrub();
            Assert.AreNotEqual(state.Long_Name, malicious);
        }

        [TestMethod]
        public void DStateWithHtmlAndSqlShortName_WhenScrubbed_BecomesSafe(){
            string malicious = "attribute');DROP TABLE dbo.Users;--";
            DState state = new DState { Short_Name = malicious };
            state.Scrub();
            Assert.AreNotEqual(state.Short_Name, malicious);
        }

        [TestMethod]
        public void DState_WhenComparedAgainstDStateWithSameKey_IsEquivilant(){
            int key = 1;
            DState first = new DState { key = key, Long_Name = "First" };
            DState second = new DState { key = key, Long_Name = "Second" };
            bool equal = first.Equivilant(second);
            Assert.AreEqual(true, equal);
        }

        [TestMethod]
        public void DState_WhenAskedForKey_ReturnsCountryID(){
            DState state = new DState { State_ID = -1 };
            int key = state.key;
            Assert.AreEqual(key, state.State_ID);
        }
    }
}
