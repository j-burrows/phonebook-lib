/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       SqlSCountryRepository.cs
 |  Purpose:    Collection of countries, which can interact with a sql server database.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Data;
using System.Data.SqlClient;
using PhoneBookLib.Data.Entities;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Repositories{
    public class SqlSCountryRepository : SqlSRepository<DCountry>{
        public SqlSCountryRepository():base() { 
            //A query to retrieve all the countries is created.
            string query = string.Format(
                @"EXEC dbo.Country_GetList;"    
            );
            FillRepository(query);
        }

        public SqlSCountryRepository(int Country_ID) {
            //Generates the transaction to retrieve a specific country.
            string query = string.Format(
                @"EXEC dbo.Country_GetByID @Country_ID = '{0}';",
                Country_ID
            );
            FillRepository(query);
        }

        protected override void CreateEval(DCountry creating){
            SqlCommand cmd = new SqlCommand("dbo.Country_Create");
            cmd.AddParam("Long_Name", creating.Long_Name);
            cmd.AddParam("Short_Name", creating.Short_Name);

            //The entry is created in database and the country is assigned the primary key.
            creating.key = ExecStoredProcedure(cmd);

            base.CreateEval(creating);      //Entry is created in main memory collection.
        }

        protected override void UpdateEval(DCountry updating){
            SqlCommand cmd = new SqlCommand("dbo.Country_Update");
            cmd.AddParam("Country_ID", updating.Country_ID);
            cmd.AddParam("Long_Name", updating.Long_Name);
            cmd.AddParam("Short_Name", updating.Short_Name);

            ExecNonReader(cmd);           //The entry is updated in the database.

            base.UpdateEval(updating);      //Entry is updated in main memory collection.
        }

        protected override void DeleteEval(DCountry deleting){
            SqlCommand cmd = new SqlCommand("dbo.Country_Delete");
            cmd.AddParam("Country_ID", deleting.Country_ID);

            ExecNonReader(cmd);             //The entry is deleted from the database.

            base.DeleteEval(deleting);      //Entry is deleted from main memory collection.
        }
    }
}
