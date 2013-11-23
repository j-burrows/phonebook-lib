/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       DAddress.cs
 |  Purpose:    Defines what an address is and how to be valid in a database.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Data;
using PhoneBookLib.Business;
using PhoneBookLib.Factory;
using Repository.Business;
using Repository.Data;
using Repository.Helpers;
using System.Collections.Generic;
using System.Linq;
namespace PhoneBookLib.Data.Entities{
    public class DAddress : BAddress, IDataUnit{
        public int key {
            get { return Address_ID; } 
            set { Address_ID = value; }
        }

        public string dataError { get; set; }

        //Parameterless constructor required for databinding.
        public DAddress() {
            country = new DCountry();
            state = new DState();
        }
        
        public void InitFromRow(DataRow row) {
            //Given datarow is parsed into an address.
            Contact_ID = row["Contact_ID"].ToInt();
            Address_ID = row["Address_ID"].ToInt();
            Apartment_Number = row["Apartment_Number"].ToInt();
            Street_Name = row["Street_Name"].ToStr();
            Street_Number = row["Street_Number"].ToInt();
            City = row["City"].ToStr();
            Postal_Code = row["Postal_Code"].ToStr();
            Country_ID = row["Country_ID"].ToInt();
            State_ID = row["State_ID"].ToInt();

            country = RepositoryFactory.Instance.Construct<DCountry>(
                Country_ID).FirstOrDefault();
            state = RepositoryFactory.Instance.Construct<DState>(
                State_ID).FirstOrDefault();
        }

        public override bool Equivilant(IBusinessUnit comparing){
            return this.MatchingKeyAndType<DAddress>(comparing);
        }

        public void Scrub() {
            //All string members are scrubbed.
            Street_Name = Street_Name.Scrub();
            City = City.Scrub();
            Postal_Code = Postal_Code.Scrub();
        }
    }
}
