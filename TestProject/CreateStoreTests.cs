using NUnit.Framework;
using Moq;
using System;
using System.Threading.Tasks;
using Management.BusinessLogic;
using Management.Models;
using Management.Data;

namespace TestProject
{
    //handle mock tests on BusinessLogic operations
    public class CreateStoreTests
    {
        private IStoreDataStore _dataStore;

        private void Setup(bool value = false)
        {
            //create instance of mock test
            var mockIStoreDataStore = new Mock<IStoreDataStore>();
            //use lambda function
            mockIStoreDataStore
                .Setup(data => data.AddStore(It.IsAny<Store>()))
                .Returns(Task.FromResult(true));

            //assign value
            _dataStore = mockIStoreDataStore.Object;
        }

        [Test]
        public async Task Create_Store_Method_When_Successful()
        {
            //Arrange
            Setup(true);
            StoreActions storeActions = new StoreActions(_dataStore);
            string storeName = "Kiosk One";
            string storeNumber = "123-abc";
            string storeType = "Kiosk";
            int storeProducts = 150;
            string userId = "101";

            //Act - user = true since it is bool
            var store = await storeActions.CreateStore(storeName, storeNumber, storeType, storeProducts, userId);

            //Assert
            Assert.IsNotNull(store);
            Assert.AreEqual(store, true);
        }

        //test if fails
        [Test]
        public void Create_Store_Method_When_Not_Successful()
        {
            //Arrange
            Setup();
            StoreActions storeActions = new StoreActions(_dataStore);
            string storeName = "Kiosk One";
            string storeNumber = "123-abc";
            string storeType = "Kiosk";
            int storeProducts = 150;
            string userId = "101";

            //Act & Assert
            Assert.ThrowsAsync<TimeoutException>( 
                async () => await storeActions.CreateStore(storeName, storeNumber, storeType, storeProducts, userId)
            );

            //Apply a constraint to an actual value, succeeding if the constraint is satisfied and throwing an assertion exception on failure.
            Assert.That(
               async ()=> await storeActions.CreateStore(storeName, storeNumber, storeType, storeProducts, userId),
               Throws.InstanceOf(typeof(TimeoutException))
            );
        }
    }
}