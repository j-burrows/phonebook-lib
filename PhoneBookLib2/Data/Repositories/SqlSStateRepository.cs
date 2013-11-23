/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       SqlSStateRepository.cs
 |  Purpose:    Collection of states, which can interact with a sql server database.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Data;
using System.Data.SqlClient;
using PhoneBookLib.Data.Entities;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Repositories{
    public class SqlSStateRepository : SqlSRepository<DState>{
        public SqlSStateRepository():base() { 
            //Collection is filled with all states in the database.
            string query = string.Format(
                @"EXEC dbo.State_GetList;"    
            );
            FillRepository(query);
        }

        public SqlSStateRepository(int State_ID) : base() { 
            //Collection is filled with a targetted state in the database.
            string query = string.Format(
                @"EXEC dbo.State_GetByID @State_ID = '{0}';",
                State_ID
            );
            FillRepository(query);
        }

        protected override void CreateEval(DState creating){
            SqlCommand cmd = new SqlCommand("dbo.State_Create");
            cmd.AddParam("Long_Name", creating.Long_Name);
            cmd.AddParam("Short_Name", creating.Short_Name);
            cmd.AddParam("Country_ID", creating.Country_ID);

            //The entry is created in the database and assigned the resulting key.
            creating.key = ExecStoredProcedure(cmd);

            base.CreateEval(creating);      //Entry is created in main memory collection.
        }

        protected override void UpdateEval(DState updating){
            SqlCommand cmd = new SqlCommand("dbo.State_Update");
            cmd.AddParam("State_ID", updating.State_ID);
            cmd.AddParam("Long_Name", updating.Long_Name);
            cmd.AddParam("Short_Name", updating.Short_Name);
            
            ExecNonReader(cmd);             //The entry is updated in the database. 

            base.UpdateEval(updating);      //Entry is updated in main memory collection.
        }

        protected override void DeleteEval(DState deleting){
            SqlCommand cmd = new SqlCommand("dbo.State_Delete");
            cmd.AddParam("State_ID", deleting.State_ID);

            ExecNonReader(cmd);             //The entry is deleted from the database.

            base.DeleteEval(deleting);      //The entry is deleted from the main memory collection.
        }
    }
}
