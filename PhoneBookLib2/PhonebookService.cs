/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       PhonebookService.cs
 |  Purpose:    Defines the main functionality provided by the phonebook library.
 |  Updated:    October 15th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PhoneBookLib.Base;
using PhoneBookLib.Data.Entities;
using PhoneBookLib.Factory;
using PhoneBookLib.Presentation;
using Repository.Data;

namespace PhoneBookLib{
    public class PhonebookService : IPhonebookService{
        public IEnumerable<DContact> Contact_GetByUser(string username){
            return RepositoryFactory.Instance.Construct<DContact>(username);
        }

        public IEnumerable<DCountry> Country_GetList() {
            return RepositoryFactory.Instance.Construct<DCountry>();
        }

        public IEnumerable<DState> State_GetList(){
            return RepositoryFactory.Instance.Construct<DState>();
        }

        public IEnumerable<DContact> Contact_Create(DContact creating, string username){
            IDataRepository<DContact> contacts = 
                RepositoryFactory.Instance.Construct<DContact>(username);
            contacts.Create(creating);

            return contacts;
        }

        public IEnumerable<DContact> Contact_Update(DContact updating, string username){
            IDataRepository<DContact> contacts = 
                RepositoryFactory.Instance.Construct<DContact>(username);
            contacts.Update(updating);

            return contacts;
        }

        public IEnumerable<DContact> Contact_Delete(DContact deleting, string username){
            IDataRepository<DContact> contacts = 
                RepositoryFactory.Instance.Construct<DContact>(username);
            contacts.Delete(deleting);

            return contacts;
        }

        public IEnumerable<DContact> Address_Create(DAddress creating, string username){
            IDataRepository<DContact> contacts = 
                RepositoryFactory.Instance.Construct<DContact>(username);
            IDataRepository<DAddress> addresses;

            if ((addresses = contacts.FirstOrDefault(x => x.Contact_ID==creating.Contact_ID)
                .addresses as IDataRepository<DAddress>) != null) {
                addresses.Create(creating);
            }

            return contacts;
        }

        public IEnumerable<DContact> Address_Update(DAddress updating, string username){
            IDataRepository<DContact> contacts = 
                RepositoryFactory.Instance.Construct<DContact>(username);
            IDataRepository<DAddress> addresses;
            if ((addresses = 
                    contacts.FirstOrDefault(x => x.Contact_ID == updating.Contact_ID)
                    .addresses as IDataRepository<DAddress>) != null){
                addresses.Update(updating);
            }

            return contacts;
        }

        public IEnumerable<DContact> Address_Delete(DAddress deleting, string username){
            IDataRepository<DContact> contacts =
                RepositoryFactory.Instance.Construct<DContact>(username);
            IDataRepository<DAddress> addresses;
            if ((addresses = 
                    contacts.FirstOrDefault(x => x.Contact_ID == deleting.Contact_ID)
                    .addresses as IDataRepository<DAddress>) != null){
                addresses.Delete(deleting);
            }

            return contacts;
        }

        public IEnumerable<DContact> Email_Create(DEmail creating, string username){
            IDataRepository<DContact> contacts =
                RepositoryFactory.Instance.Construct<DContact>(username);
            IDataRepository<DEmail> emails;
            if ((emails = contacts.FirstOrDefault(x => x.Contact_ID == creating.Contact_ID)
                    .emails as IDataRepository<DEmail>) != null){
                emails.Create(creating);
            }

            return contacts;
        }

        public IEnumerable<DContact> Email_Update(DEmail updating, string username){
            IDataRepository<DContact> contacts = 
                RepositoryFactory.Instance.Construct<DContact>(username);
            IDataRepository<DEmail> emails;
            if ((emails = contacts.FirstOrDefault(x => x.Contact_ID == updating.Contact_ID)
                    .emails as IDataRepository<DEmail>) != null){
                emails.Update(updating);
            }

            return contacts;
        }

        public IEnumerable<DContact> Email_Delete(DEmail deleting, string username){
            IDataRepository<DContact> contacts =
                RepositoryFactory.Instance.Construct<DContact>(username);
            IDataRepository<DEmail> emails;
            if ((emails = contacts.FirstOrDefault(x => x.Contact_ID == deleting.Contact_ID)
                    .emails as IDataRepository<DEmail>) != null){
                emails.Delete(deleting);
            }

            return contacts;
        }

        public IEnumerable<DContact> PhoneAddress_Create(DPhoneAddress creating, 
                                                         string username){
            IDataRepository<DContact> contacts = 
                RepositoryFactory.Instance.Construct<DContact>(username);
            IDataRepository<DPhoneAddress> phoneAddresses;
            if ((phoneAddresses = 
                    contacts.FirstOrDefault(x => x.Contact_ID == creating.Contact_ID)
                    .phoneAddresses as IDataRepository<DPhoneAddress>) != null){
                phoneAddresses.Create(creating);
            }

            return contacts;
        }

        public IEnumerable<DContact> PhoneAddress_Update(DPhoneAddress updating, 
                                                         string username){
            IDataRepository<DContact> contacts = 
                RepositoryFactory.Instance.Construct<DContact>(username);
            IDataRepository<DPhoneAddress> phoneAddresses;
            if ((phoneAddresses = 
                    contacts.FirstOrDefault(x => x.Contact_ID == updating.Contact_ID)
                    .phoneAddresses as IDataRepository<DPhoneAddress>) != null){
                phoneAddresses.Update(updating);
            }

            return contacts;
        }

        public IEnumerable<DContact> PhoneAddress_Delete(DPhoneAddress deleting, 
                                                         string username){
            IDataRepository<DContact> contacts = 
                RepositoryFactory.Instance.Construct<DContact>(username);
            IDataRepository<DPhoneAddress> phoneAddresses;
            if ((phoneAddresses =
                    contacts.FirstOrDefault(x => x.Contact_ID == deleting.Contact_ID)
                    .phoneAddresses as IDataRepository<DPhoneAddress>) != null){
                phoneAddresses.Delete(deleting);
            }

            return contacts;
        }

        public IEnumerable<DPlace> Place_Create(DPlace creating){
            IDataRepository<DPlace> places = 
                RepositoryFactory.Instance.Construct<DPlace>();
            places.Create(creating);

            return places;
        }

        public IEnumerable<DPlace> Place_Update(DPlace updating){
            IDataRepository<DPlace> places = 
                RepositoryFactory.Instance.Construct<DPlace>();
            places.Update(updating);

            return places;
        }

        public IEnumerable<DPlace> Place_Delete(DPlace deleting){
            IDataRepository<DPlace> places = 
                RepositoryFactory.Instance.Construct<DPlace>();
            places.Delete(deleting);

            return places;
        }

        public IEnumerable<DState> State_Create(DState creating){
            IDataRepository<DState> states = 
                RepositoryFactory.Instance.Construct<DState>();
            states.Create(creating);

            return states;
        }

        public IEnumerable<DState> State_Update(DState updating){
            IDataRepository<DState> states = 
                RepositoryFactory.Instance.Construct<DState>();
            states.Update(updating);

            return states;
        }

        public IEnumerable<DState> State_Delete(DState deleting){
            IDataRepository<DState> contacts = 
                RepositoryFactory.Instance.Construct<DState>();

            IDataRepository<DState> states = 
                RepositoryFactory.Instance.Construct<DState>();
            states.Delete(deleting);

            return states;
        }

        public IEnumerable<DCountry> Country_Create(DCountry creating){
            IDataRepository<DCountry> countries = 
                RepositoryFactory.Instance.Construct<DCountry>();
            countries.Create(creating);

            return countries;
        }

        public IEnumerable<DCountry> Country_Update(DCountry updating){
            IDataRepository<DCountry> countries = 
                RepositoryFactory.Instance.Construct<DCountry>();
            countries.Update(updating);

            return countries;
        }

        public IEnumerable<DCountry> Country_Delete(DCountry deleting){
            IDataRepository<DCountry> countries = 
                RepositoryFactory.Instance.Construct<DCountry>();
            countries.Delete(deleting);

            return countries;
        }
    }
}
