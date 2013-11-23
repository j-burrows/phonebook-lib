/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       DPlace.cs
 |  Purpose:    Defines what a physical place is and how to be valid in a database.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Data;
using PhoneBookLib.Business;
using Repository.Business;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Entities{
    public class DPlace : BPlace, IDataUnit{
        public int key { 
            get { return Place_ID; } 
            set { Place_ID = value; }
        }

        public string dataError { get; set; }

        public void InitFromRow(DataRow row) {
            //Given datarow is parsed into a place.
            Place_ID = row["Place_ID"].ToInt();
            Long_Name = row["Long_Name"].ToStr();
            Short_Name = row["Short_Name"].ToStr();
        }

        public override bool Equivilant(IBusinessUnit comparing){
            return this.MatchingKeyAndType<DPlace>(comparing);
        }

        public override bool DeleteValid(){
            return key > 0;
        }

        public void Scrub(){
            //All string members are scrubbed.
            Long_Name = Long_Name.Scrub();
            Short_Name = Short_Name.Scrub();
        }
    }
}
