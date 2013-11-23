/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       DEmail.cs
 |  Purpose:    Defines what an email is and how to be valid in a database.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Data;
using PhoneBookLib.Business;
using Repository.Business;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Entities{
    public class DEmail : BEmail, IDataUnit{
        public int key { 
            get { return Email_ID; }
            set { Email_ID = value; }
        }

        public string dataError { get; set; }

        public void InitFromRow(DataRow row) {
            //Given datarow is parsed into an email.
            Email_ID = row["Email_ID"].ToInt();
            Url = row["Url"].ToStr();
            Contact_ID = row["Contact_ID"].ToInt();
        }

        public override bool Equivilant(IBusinessUnit comparing){
            return this.MatchingKeyAndType<DEmail>(comparing);
        }

        public override bool DeleteValid(){
            return key > 0;
        }

        public void Scrub() {
            //All string members are scrubbed.
            Url = Url.Scrub();
        }
    }
}
