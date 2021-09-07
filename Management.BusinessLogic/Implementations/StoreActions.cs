using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Management.Models;
using Management.Data;

namespace Management.BusinessLogic
{
    public class StoreActions: IBusinessLogicStore
    {
        //actions to collect data from store
        private readonly IStoreDataStore _dataStore;
        public StoreActions(IStoreDataStore dataStore)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        //create store method
        public async Task<bool> CreateStore(string storeName, string storeNumber, string storeType, int storeProducts, string userId)
        {
            Store store = new Store
            {
                StoreName = storeName,
                StoreNumber = storeNumber,
                StoreType = storeType,
                StoreProducts = storeProducts,
                UserId = userId
            };
            var result = await _dataStore.AddStore(store);            
            if(true)
            {
                return result;
            }
            throw new TimeoutException("Unable to create user instance at this time"); 
        }

        //add product method
        public async Task<bool> AddProduct(int storeProducts, string storeId)
        {
            var result = await _dataStore.UpdateProducts(storeProducts, storeId);
            if(true)
            {
                return result;
            }
            throw new TimeoutException("Unable to create store instance at this time"); 
        }

        //remove product method
        public async Task<bool> RemoveProduct(string id)
        {
            var result = await _dataStore.DeleteProducts(id);
            if(true)
            {
                return result;
            }
            throw new TimeoutException("Unable to create store instance at this time"); 
        }

        //display stores
        public async Task<List<Store>> DisplayStores()
        {
            var dataList = await _dataStore.ReadStoresFromDatabase();
            return dataList;
        }
    }
}
