/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       DPhoneAddress.cs
 |  Purpose:    Defines what a phone address is and how to be valid in a database.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Data;
using PhoneBookLib.Business;
using Repository.Business;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Entities{
    public class DPhoneAddress : BPhoneAddress, IDataUnit{
        public int key { 
            get { return PhoneAddress_ID; } 
            set { PhoneAddress_ID = value; } 
        }

        public string dataError { get; set; }

        public void InitFromRow(DataRow row) {
            //Datarow is parsed into a phone address.
            Contact_ID = row["Contact_ID"].ToInt();
            PhoneAddress_ID = row["PhoneAddress_ID"].ToInt();
            Area_Code = row["Area_Code"].ToInt();
            Remote_Address = row["Remote_Address"].ToInt();
            Local_Address = row["Local_Address"].ToInt();
        }

        public override bool Equivilant(IBusinessUnit comparing){
            return this.MatchingKeyAndType<DPhoneAddress>(comparing);
        }

        public override bool DeleteValid(){
            return key > 0;
        }

        public void Scrub() { }
    }
}
