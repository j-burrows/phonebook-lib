/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       SqlSRepositoryFactory.cs
 |  Purpose:    Implements behaviour of factory which produces Sql Server Data repositories.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System;
using System.Collections.Generic;
using PhoneBookLib.Base;
using PhoneBookLib.Data.Repositories;
using Repository.Data;
using Repository.Factory;
using Repository.Helpers;
namespace PhoneBookLib.Factory{
    public class SqlSRepositoryFactory : IRepositoryFactory{
        public IDataRepository<T> Construct<T>(params object[] args) where T : IDataUnit{
            if (Polymorphism.IsInHierachy(typeof(T), typeof(Contact))){
                return (IDataRepository<T>)Activator.CreateInstance(
                    typeof(SqlSContactRepository), args);
            }
            if (Polymorphism.IsInHierachy(typeof(T), typeof(Address))){
                return (IDataRepository<T>)Activator.CreateInstance(
                    typeof(SqlSAddressRepository), args);
            }
            else if (Polymorphism.IsInHierachy(typeof(T), typeof(Country))){
                return (IDataRepository<T>)Activator.CreateInstance(
                    typeof(SqlSCountryRepository), args);
            }
            else if (Polymorphism.IsInHierachy(typeof(T), typeof(Email))){
                return (IDataRepository<T>)Activator.CreateInstance(
                    typeof(SqlSEmailRepository), args);
            }
            else if (Polymorphism.IsInHierachy(typeof(T), typeof(PhoneAddress))){
                return (IDataRepository<T>)Activator.CreateInstance(
                    typeof(SqlSPhoneAddressRepository), args);
            }
            else if (Polymorphism.IsInHierachy(typeof(T), typeof(Place))
                && !Polymorphism.IsInHierachy(typeof(T), typeof(State))
                && !Polymorphism.IsInHierachy(typeof(T), typeof(Country))){
                //The given is of type place, but not state or country
                return (IDataRepository<T>)Activator.CreateInstance(typeof(SqlSPlaceRepository), args);
            }
            else if (Polymorphism.IsInHierachy(typeof(T), typeof(State))){
                return (IDataRepository<T>)Activator.CreateInstance(typeof(SqlSStateRepository), args);
            }
            return null;                    //Factory cannot build the requested order.
        }
    }
}
