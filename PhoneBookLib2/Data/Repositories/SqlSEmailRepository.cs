/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       SqlSEmailRepository.cs
 |  Purpose:    Collection of emails, which can interact with a sql server database.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Data;
using System.Data.SqlClient;
using PhoneBookLib.Data.Entities;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Repositories{
    public class SqlSEmailRepository : SqlSRepository<DEmail>{
        public SqlSEmailRepository(int Contact_ID):base() {
            //Collection is filled with emails belonging to a given user.
            string query = string.Format(
                @"EXEC Phonebook.Email_GetByContact @Contact_ID='{0}';",
                Contact_ID
            );
            FillRepository(query);
        }

        protected override void CreateEval(DEmail creating){
            SqlCommand cmd = new SqlCommand("Phonebook.Email_Create");
            cmd.AddParam(creating.Url, "Url");
            cmd.AddParam("Contact_ID", creating.Contact_ID);

            //The email is created in the database and assigned the resulting key.
            creating.key = ExecStoredProcedure(cmd);

            base.CreateEval(creating);      //Email is created in main memory collection.
        }

        protected override void UpdateEval(DEmail updating){
            SqlCommand cmd = new SqlCommand("Phonebook.Email_Update");
            cmd.AddParam("Email_ID", updating.Email_ID);
            cmd.AddParam("Url", updating.Url);

            ExecNonReader(cmd);             //The email is updated in the database.

            base.UpdateEval(updating);      //Email is updated in main memory collection.
        }

        protected override void DeleteEval(DEmail deleting){
            SqlCommand cmd = new SqlCommand("Phonebook.Email_Delete");
            cmd.AddParam("Email_ID", deleting.Email_ID);

            ExecNonReader(cmd);             //The email is deleted from the database.

            base.DeleteEval(deleting);      //Email is deleted from main memory collection.
        }
    }
}
