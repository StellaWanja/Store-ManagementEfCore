using Newtonsoft.Json;
using Management.Models;
using Management.Commons;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data
{
    public class Seeder
    {
        public async static Task Seed(StoreDbContext context)
        {
            //create databse if not existing
            await context.Database.EnsureCreatedAsync();
            //if database is empty
            if (!context.Users.Any())
            {
                //read from the json file
                var userData = await File.ReadAllTextAsync(@"..\Management.Data\Seeder\Users.json");
                List<User> users = JsonConvert.DeserializeObject<List<User>>(userData);
                //add to list
                await context.Users.AddRangeAsync(users);
                //save
                await context.SaveChangesAsync();
            }

            if (!context.Stores.Any())
            {
                var storeData = await File.ReadAllTextAsync(@"..\Management.Data\Seeder\Stores.json");
                List<Store> stores = JsonConvert.DeserializeObject<List<Store>>(storeData);

                await context.Stores.AddRangeAsync(stores);

                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var productData = await File.ReadAllTextAsync(@"..\Management.Data\Seeder\Products.json");
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productData);

                await context.Products.AddRangeAsync(products);

                await context.SaveChangesAsync();
            }        
        }
    }
}