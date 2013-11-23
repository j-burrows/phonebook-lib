/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       SqlSPlaceRepository.cs
 |  Purpose:    Collection of physical places, which can interact with a sql server database
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Data;
using System.Data.SqlClient;
using PhoneBookLib.Data.Entities;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Repositories{
    public class SqlSPlaceRepository : SqlSRepository<DPlace>{
        public SqlSPlaceRepository() : base() { 
            //Collection is filled with all places stored in the database.
            string query = string.Format(
                @"EXEC dbo.Place_GetList;"    
            );
            FillRepository(query);
        }

        public SqlSPlaceRepository(int Event_ID):base() { 
            //Collection is filled with all places associated with an event.
            string query = string.Format(
                @"EXEC dbo.Place_GetByEvent @Event_ID = '{0}';",
                Event_ID
            );
            FillRepository(query);
        }

        protected override void CreateEval(DPlace creating){
            SqlCommand cmd = new SqlCommand("dbo.Place_Create");
            cmd.AddParam("Long_Name", creating.Long_Name);
            cmd.AddParam("Short_Name", creating.Short_Name);

            //The entry is created in the database and assigned the resulting key.
            creating.key = ExecStoredProcedure(cmd);


            base.CreateEval(creating);      //Entry is created in main memory collection.
        }

        protected override void UpdateEval(DPlace updating){
            SqlCommand cmd = new SqlCommand("dbo.Place_Update");
            cmd.AddParam("Place_ID", updating.Place_ID);
            cmd.AddParam("Long_Name", updating.Long_Name);
            cmd.AddParam("Short_Name", updating.Short_Name);

            ExecNonReader(cmd);             //The entry is updated in the database.

            base.UpdateEval(updating);      //Entry is updated in main memory collection.
        }

        protected override void DeleteEval(DPlace deleting){
            SqlCommand cmd = new SqlCommand("dbo.Place_Delete");
            cmd.AddParam("Place_ID", deleting.Place_ID);

            ExecNonReader(cmd);             //The entry is deleted from the database.

            base.DeleteEval(deleting);      //Entry is deleted from main memory collection.
        }
    }
}
