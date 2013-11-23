/*-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
 |  File:       Factory.cs
 |  Purpose:    Generates a set of tests for repositories of the factories library.
 |  Author:     Jonathan Burrows
 |  Updated:    October 8th 2013
 +-- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- --- ---
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookLib.Factory;
using Repository.Factory;
namespace PhonebookLibUnitTests{
    [TestClass]
    public class Factory{
        [TestMethod]
        public void AbstractFactory_Requesting2Factories_AreDifferent() { 
            //Arrange: Two factories are stored.
            IRepositoryFactory factory_one = RepositoryFactory.Instance;
            IRepositoryFactory factory_two = RepositoryFactory.Instance;

            //Act: the two factories are compared against one another.
            bool equals = factory_one.Equals(factory_two);

            //Assert: The two factories are the same.
            Assert.AreEqual(true, equals);
        }

        [TestMethod]
        public void AbstractFactory_RequestingFactory_GetsSqlTypeFactory() { 
            //Arrange: a factory is stored from the abstract factory.
            IRepositoryFactory factory = RepositoryFactory.Instance;

            //Act: The factory is checked to be of type sql server.
            bool is_of_type = factory is SqlSRepositoryFactory;

            //Assert: the factory is of Sql server type.
            Assert.AreEqual(true, is_of_type);
        }
    }
}
