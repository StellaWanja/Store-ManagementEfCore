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
    public class UserDataStoreEFCore : IUserDataStore
    {
        //insert into users table using stored procedures
        public async Task<bool> AddUser(User user)
        {
            try
            {
                //create context
                using (StoreDbContext context = new StoreDbContext())
                {
                    //add async
                    await context.Users.AddAsync(user);
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
        public async Task<List<User>> ReadUsersFromDatabase()
        {
            try
            {
                //create context
                using (StoreDbContext context = new StoreDbContext())
                {
                    //add async and load all data as a list
                    List<User> list = await context.Users.ToListAsync();
                    return list;
                }
            }
            catch (Exception e)
            {             
                throw new Exception(e.Message);
            }       
        }
    }
}