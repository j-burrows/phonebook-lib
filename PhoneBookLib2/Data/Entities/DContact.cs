/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       DContact.cs
 |  Purpose:    Defines what a human contact is and how to be valid in a database.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Data;
using PhoneBookLib.Business;
using PhoneBookLib.Factory;
using Repository.Business;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Entities{
    public class DContact : BContact, IDataUnit{
        public int key { 
            get { return Contact_ID; } 
            set { Contact_ID = value; } 
        }

        public string dataError { get; set; }

        public void InitFromRow(DataRow row) {
            //The given datarow is parsed in a contact.
            username = row["username"].ToStr();
            Contact_ID = row["Contact_ID"].ToInt();
            First_Name = row["First_Name"].ToStr();
            Last_Name = row["Last_Name"].ToStr();
            Middle_Initial = row["Middle_Initial"].ToChar();
            Relation = row["Relation"].ToStr();

            phoneAddresses = RepositoryFactory.Instance.Construct<DPhoneAddress>(Contact_ID);
            emails = RepositoryFactory.Instance.Construct<DEmail>(Contact_ID);
            addresses = RepositoryFactory.Instance.Construct<DAddress>(Contact_ID);
        }

        public override bool Equivilant(IBusinessUnit comparing){
            return this.MatchingKeyAndType<DContact>(comparing);
        }

        public override bool DeleteValid(){
            return key > 0;
        }

        public void Scrub() {
            //All string members are scrubbed.
            First_Name = First_Name.Scrub();
            Last_Name = Last_Name.Scrub();
            Relation = Relation.Scrub();
            username = username.Scrub();
        }
    }
}
