/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       DState.cs
 |  Purpose:    Defines what a physical place is and how to be valid in a database.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Data;
using PhoneBookLib.Business;
using Repository.Business;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Entities{
    public class DState : BState, IDataUnit{
        public int key { 
            get { return State_ID; }
            set { State_ID = value; }
        }

        public string dataError { get; set; }

        public void InitFromRow(DataRow row) {
            //Given datarow is parsed into a state.
            Country_ID = row["Country_ID"].ToInt();
            State_ID = row["Country_ID"].ToInt();
            Long_Name = row["Long_Name"].ToStr();
            Short_Name = row["Short_Name"].ToStr();
        }

        public override bool Equivilant(IBusinessUnit comparing){
            return this.MatchingKeyAndType<DState>(comparing);
        }

        public override bool DeleteValid(){
            return key > 0;
        }

        public void Scrub() {
            //All string members are scrubbed.
            Long_Name = Long_Name.Scrub();
            Short_Name = Short_Name.Scrub();
        }
    }
}
