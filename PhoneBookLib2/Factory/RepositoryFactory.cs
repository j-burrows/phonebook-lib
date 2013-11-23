/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       RepositoryFactory.cs
 |  Purpose:    Singleton which implements an abstract factory.
 |  Updated:    October 8th 2013
*/// --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
using System;
using System.Collections.Generic;
using PhoneBookLib.Base;
using PhoneBookLib.Data.Repositories;
using Repository.Data;
using Repository.Data;
using Repository.Factory;

namespace PhoneBookLib.Factory{

    public sealed class RepositoryFactory : SqlSRepositoryFactory, IRepositoryFactory{
        private static volatile RepositoryFactory _instance;

        private static object _lock = new object();

        private RepositoryFactory() { }

        public static RepositoryFactory Instance {
            get { 
                if(_instance == null){
                    lock (_lock) { 
                        if(_instance == null){
                            _instance = new RepositoryFactory();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
