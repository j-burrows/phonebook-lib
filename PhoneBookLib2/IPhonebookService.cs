/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       IPhonebookService.cs
 |  Purpose:    Declares the main functionality provided by the phonebook library.
 |  Note:       The library is ready to be changed into a web service when needed.
 |  Updated:    October 15th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Collections.Generic;
using System.ServiceModel;
using PhoneBookLib.Base;
using PhoneBookLib.Data.Entities;
using PhoneBookLib.Presentation;
namespace PhoneBookLib{
    [ServiceContract]
    public interface IPhonebookService{
        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Function:   Contact_GetByUser
         |  Purpose:    Retrieve a collection of all contacts owned by a given user.
         |  Param:      username                The owner of all targetted contacts.
         |  Return:     IEnumerable<DContact>   All contacts owned by the given user.
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        [OperationContract]
        IEnumerable<DContact> Contact_GetByUser(string username);
        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Function:   Country_GetList
         |  Purpose:    Retrieve a collection of all countries.
         |  Return:     IEnumerable<DCountry>   All the countries stored in the database.
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        [OperationContract]
        IEnumerable<DCountry> Country_GetList();
        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Function:   State_GetList
         |  Purpose:    Retrieve a collection of all states.
         |  Return:     IEnumerable<DState>     All states stored in the database.
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        [OperationContract]
        IEnumerable<DState> State_GetList();

        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Function:   Address Create, Update, Delete
         |  Purpose:    To insert, update, or delete a given address assigned to a contact
         |              and return an updated collection of contacts to the user.
         |  Param:      username                The contact being altered.
         |  Return:     IEnumerable<DContact>   Resulting contacts owned by the given user.
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        [OperationContract]
        IEnumerable<DContact> Address_Create(DAddress creating, string username);
        [OperationContract]
        IEnumerable<DContact> Address_Update(DAddress updating, string username);
        [OperationContract]
        IEnumerable<DContact> Address_Delete(DAddress deleting, string username);

        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Function:   Contact Create, Update, Delete
         |  Purpose:    To insert, update, or delete a given contact belonging to a given
         |              user and return the updated collection of contacts.
         |  Param:      username                Owner of the contact being altered.
         |              DContact                Contact being used in CRUD operations.
         |  Return:     IEnumerable<DContact>   Resulting contacts owned by the given user.
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        [OperationContract]
        IEnumerable<DContact> Contact_Create(DContact creating, string username);
        [OperationContract]
        IEnumerable<DContact> Contact_Update(DContact updating, string username);
        [OperationContract]
        IEnumerable<DContact> Contact_Delete(DContact deleting, string username);

        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Function:   Email Create, Update, Delete
         |  Purpose:    To insert, update, or delete a given email assigned to a contact
         |              and return an updated collection of contacts to the user.
         |  Param:      username                Owner of the contact being altered.
         |              DEmail                  The email being used in CRUD
         |  Return:     IEnumerable<DContact>   Resulting contacts owned by the given user.
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        [OperationContract]
        IEnumerable<DContact> Email_Create(DEmail creating, string username);
        [OperationContract]
        IEnumerable<DContact> Email_Update(DEmail updating, string username);
        [OperationContract]
        IEnumerable<DContact> Email_Delete(DEmail deleting, string username);

        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Function:   Phone address Create, Update, Delete
         |  Purpose:    To insert, update, or delete a given phone address assigned to a 
         |              contact and return an updated collection of contacts to the user.
         |  Param:      username                Owner of the contact being altered.
         |              DPhoneAddress           The phone address being used in CRUD
         |  Return:     IEnumerable<DContact>   Resulting contacts owned by the given user.
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        [OperationContract]
        IEnumerable<DContact> PhoneAddress_Create(DPhoneAddress creating, string username);
        [OperationContract]
        IEnumerable<DContact> PhoneAddress_Update(DPhoneAddress updating, string username);
        [OperationContract]
        IEnumerable<DContact> PhoneAddress_Delete(DPhoneAddress deleting, string username);

        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Function:   Place Create, Update, Delete
         |  Purpose:    To insert, update, or delete a given place into the database
         |  Param:      DPlace                  Place being used in CRUD operations.
         |  Return:     IEnumerable<DPlace>     Resulting places stored in database.
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        [OperationContract]
        IEnumerable<DPlace> Place_Create(DPlace creating);
        [OperationContract]
        IEnumerable<DPlace> Place_Update(DPlace updating);
        [OperationContract]
        IEnumerable<DPlace> Place_Delete(DPlace deleting);

        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Function:   State Create, Update, Delete
         |  Purpose:    To insert, update, or delete a given state into the database
         |  Param:      DState                  State being used in CRUD operations.
         |  Return:     IEnumerable<DState>     Resulting states stored in database.
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        [OperationContract]
        IEnumerable<DState> State_Create(DState creating);
        [OperationContract]
        IEnumerable<DState> State_Update(DState updating);
        [OperationContract]
        IEnumerable<DState> State_Delete(DState deleting);

        /*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
         |  Function:   Country Create, Update, Delete
         |  Purpose:    To insert, update, or delete a given country into the database
         |  Param:      PCountry                Country being used in CRUD operations.
         |  Return:     IEnumerable<DCountry>   Resulting country stored in database.
         +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
        */
        [OperationContract]
        IEnumerable<DCountry> Country_Create(DCountry creating);
        [OperationContract]
        IEnumerable<DCountry> Country_Update(DCountry updating);
        [OperationContract]
        IEnumerable<DCountry> Country_Delete(DCountry deleting);
    }
}
