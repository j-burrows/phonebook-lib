/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       MySqlRepositoryFactory.cs
 |  Purpose:    Implements behaviour of factory which produces MySql Data repositories.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System.Collections.Generic;
using Repository.Data;
using Repository.Factory;
namespace PhoneBookLib.Factory{
    public class MySqlRepositoryFactory : IRepositoryFactory{
        public IDataRepository<T> Construct<T>(params object[] args) where T : IDataUnit{
            return null;                    //Factory cannot built anything.
        }
    }
}
