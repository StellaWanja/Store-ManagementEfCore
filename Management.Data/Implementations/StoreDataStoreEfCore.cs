using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Management.Models;

namespace Management.Data
{
    public class StoreDataStoreEFCore : IStoreDataStore
    {
        //add store to database
        public async Task<bool> AddStore(Store store)
        {
            try
            {
                //create context
                using (StoreDbContext context = new StoreDbContext())
                {
                    //add async
                    await context.Stores.AddAsync(store);
                    //save changes async
                    var result = await context.SaveChangesAsync();

                    return result > 0;
                }
            }
            catch (Exception e)
            {             
                throw new Exception(e.Message);
            }       
        }

        //Read users data for login
        public async Task<List<Store>> ReadStoresFromDatabase()
        {
            try
            {
                //create context
                using (StoreDbContext context = new StoreDbContext())
                {
                    //add async and load all data as a list
                    List<Store> list = await context.Stores.ToListAsync();
                    return list;
                }
            }
            catch (Exception e)
            {             
                throw new Exception(e.Message);
            }       
        }

        //update products
        public async Task<bool> UpdateProducts(int storeProducts, string id)
        {
            try
            {
                //create context
                using (StoreDbContext context = new StoreDbContext())
                {
                    //find the store number
                    Store store = await context.Stores.FirstOrDefaultAsync(store => store.Id == id);
                    //update
                    store.StoreProducts = storeProducts;

                    context.Update(store);

                    var result = await context.SaveChangesAsync();

                    return result > 0;
                }            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //delete products
        public async Task<bool> DeleteProducts(string id)
        {
            try
            {
                //create context
                using (StoreDbContext context = new StoreDbContext())
                {
                    //find the store number
                    Store store = await context.Stores.FirstOrDefaultAsync(store => store.Id == id);
                    //delete
                    context.Stores.Remove(store);

                    var result = await context.SaveChangesAsync();

                    return result > 0;
                }            
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }
    }
}