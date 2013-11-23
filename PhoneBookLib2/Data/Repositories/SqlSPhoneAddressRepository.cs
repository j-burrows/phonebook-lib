/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       SqlSPhoneAddressRepository.cs
 |  Purpose:    Collection of phone addresses, which can interact with a sql server database
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Data;
using System.Data.SqlClient;
using PhoneBookLib.Data.Entities;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Repositories{
    public class SqlSPhoneAddressRepository : SqlSRepository<DPhoneAddress>{
        public SqlSPhoneAddressRepository(int Contact_ID):base() {
            //Collection is filled with phone addresses belonging to a given contact.
            string query = string.Format(
                @"EXEC Phonebook.PhoneAddress_GetByContact @Contact_ID='{0}';",
                Contact_ID
            );

            FillRepository(query);
        }

        protected override void CreateEval(DPhoneAddress creating){
            SqlCommand cmd = new SqlCommand("Phonebook.PhoneAddress_Create");
            cmd.AddParam("Contact_ID", creating.PhoneAddress_ID);
            cmd.AddParam("Area_Code", creating.Area_Code);
            cmd.AddParam("Remote_Address", creating.Remote_Address);
            cmd.AddParam("Local_Address", creating.Local_Address);

            //The entry is created in the database and assigned the resulting key.
            creating.key = ExecStoredProcedure(cmd);

            base.CreateEval(creating);      //Entry is created in main memory collection.
        }

        protected override void UpdateEval(DPhoneAddress updating){
            SqlCommand cmd = new SqlCommand("Phonebook.PhoneAddress_Update");
            cmd.AddParam("PhoneAddress_ID", updating.PhoneAddress_ID);
            cmd.AddParam("Area_Code", updating.Area_Code);
            cmd.AddParam("Remote_Address", updating.Remote_Address);
            cmd.AddParam("Local_Address", updating.Local_Address);

            ExecNonReader(cmd);             //The entry is updated in the database.

            base.UpdateEval(updating);      //Entry is updated in main memory collection.
        }

        protected override void DeleteEval(DPhoneAddress deleting){
            SqlCommand cmd = new SqlCommand("Phonebook.PhoneAddress_Delete");
            cmd.AddParam("PhoneAddress_ID", deleting.PhoneAddress_ID);

            ExecNonReader(cmd);             //The entry is deleted from the database.

            base.DeleteEval(deleting);      //Entry is deleted from main memory collection.
        }
    }
}
