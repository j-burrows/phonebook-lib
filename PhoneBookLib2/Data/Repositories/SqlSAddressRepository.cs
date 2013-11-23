/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       SqlSAddressRepository.cs
 |  Purpose:    Collection of addresses, which can interact with an sql server database.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PhoneBookLib.Data.Entities;
using Repository.Data;
using Repository.Helpers;
namespace PhoneBookLib.Data.Repositories{
    public class SqlSAddressRepository : SqlSRepository<DAddress>{
        public SqlSAddressRepository(int Contact_ID):base() {
            //Collection is filled with all addresses belonging to a given contact.
            string query = string.Format(
                @"EXEC  Phonebook.Address_GetByContact @Contact_ID='{0}'" ,
                Contact_ID
            );

            FillRepository(query);
        }

        protected override void CreateEval(DAddress creating){
            SqlCommand cmd = new SqlCommand("Phonebook.Address_Create");
            cmd.AddParams(
                new Param("Contact_ID",creating.Contact_ID),
                new Param("Apartment_Number",creating.Apartment_Number),
                new Param("Street_Number",creating.Street_Number),
                new Param("Street_Name",creating.Street_Name),
                new Param("City",creating.City),
                new Param("State_ID",creating.State_ID),
                new Param("Country_ID",creating.Country_ID),
                new Param("Address_ID",creating.Address_ID),
                new Param("Postal_Code",creating.Postal_Code)
            );

            try{
                //The entry is made into the database and assigned the resulting key.
                creating.key = ExecStoredProcedure(cmd);
            }
            catch(Exception e){
                creating.dataError = "Error occured while creating in database.";
            }
            finally{
                base.CreateEval(creating);  //Entry is placed into main memory collection.
            }

        }

        protected override void UpdateEval(DAddress updating){
            SqlCommand command = new SqlCommand("Phonebook.Address_Update");
            command.AddParams(
                new Param("Address_ID", updating.Address_ID),
                new Param("Apartment_Number", updating.Apartment_Number),
                new Param("Street_Number", updating.Street_Number),
                new Param("Street_Name", updating.Street_Name),
                new Param("City", updating.City),
                new Param("State_ID", updating.State_ID),
                new Param("Country_ID", updating.Country_ID),
                new Param("Postal_Code", updating.Address_ID)
            );

            try{
                ExecNonReader(command);         //The entry is updated in the database.
            }
            catch{
                updating.dataError ="Error occured while updating database.";
            }
            finally{
                base.UpdateEval(updating);      //Entry is updated in main memory collection.
            }
        }

        protected override void DeleteEval(DAddress deleting){
            SqlCommand cmd = new SqlCommand("Phonebook.Address_Delete");
            cmd.AddParam("Address_ID", deleting.Address_ID);

            try{
                ExecNonReader(cmd);         //The entry is removed from the database.
            }
            catch{
                deleting.dataError = "Error occured while deleting from database.";
            }
            finally{
                base.DeleteEval(deleting);  //Entry is removed from main memory collection.
            }
        }
    }
}
