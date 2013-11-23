/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       SqlSContactRepository.cs
 |  Purpose:    Collection of contacts, which can interact with a sql server database.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PhoneBookLib.Data.Entities;
using Repository.Business;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Repositories{
    public class SqlSContactRepository : SqlSRepository<DContact>{
        public SqlSContactRepository():base() {
            //Collection is filled with every contact stored in database.
            string query = string.Format(
                @"EXEC Phonebook.Contact_GetList"    
            );
            FillRepository(query);
        }

        public SqlSContactRepository(string username):base() {
            //Collection is filled with all contacts belonging to a user.
            string query = string.Format(
                @"EXEC Phonebook.Contact_GetByUser @username = '{0}';",
                username
            );
            FillRepository(query);
        }

        protected override void CreateEval(DContact creating){
            SqlCommand cmd = new SqlCommand("Phonebook.Contact_Create");
            cmd.AddParams(
                new Param("username",creating.username),
                new Param("First_Name",creating.First_Name),
                new Param("Last_Name",creating.Last_Name),
                new Param("Middle_Initial",creating.Middle_Initial),
                new Param("Relation",creating.Relation)
            );
            //Enters the data into the database and the contact is assigned the key.
            creating.key = ExecStoredProcedure(cmd);

            base.CreateEval(creating);      //Contact is added to main memory collection.
        }

        protected override void UpdateEval(DContact updating) { 
            //Transaction code for updating the entry.
            SqlCommand cmd = new SqlCommand("Phonebook.Contact_Update");
            cmd.AddParams(
                new Param("Contact_ID", updating.Contact_ID),
                new Param("First_Name", updating.First_Name),
                new Param("Last_Name", updating.Last_Name),
                new Param("Middle_Initial", updating.Middle_Initial),
                new Param("Relation", updating.Relation)
            );
            ExecNonReader(cmd);             //Deletes the data from the database.

            base.UpdateEval(updating);      //Contact is updated in main memory collection.
        }

        protected override void DeleteEval(DContact deleting){
            SqlCommand cmd = new SqlCommand("Phonebook.Contact_Delete");
            cmd.AddParam("Contact_ID", deleting.Contact_ID);

            ExecNonReader(cmd);             //Deletes the entry from the database.

            base.DeleteEval(deleting);      //Contact is deleted from main memory collection
        }
    }
}
