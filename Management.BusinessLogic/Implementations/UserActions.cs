﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Management.Models;
using Management.Data;

namespace Management.BusinessLogic
{
    public class UserActions: IBusinessLogicUser
    {
        //set user actions to read data from file
        private readonly IUserDataStore _dataStore;
        public UserActions(IUserDataStore dataStore)
        {
            _dataStore = dataStore ?? throw new ArgumentNullException(nameof(dataStore));
        }

        //register user method
        //create user object and add it to list<customer>
        public async Task<bool> RegisterUser(string firstName, string lastName, string email, string password)
        {
            User user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            var result = await _dataStore.AddUser(user);
            if(true)
            {
                return result;
            }
            throw new TimeoutException("Unable to create user instance at this time");            
        }   

        //login method
        //check if email and password match
        //return values are used to control UI
        public async Task<int> LoginUser(string email, string password)
        {
            var dataList = await _dataStore.ReadUsersFromDatabase();
            foreach (var user in dataList)
            {
                if (user.Email == email && user.Password == password)
                {
                    return 1;        
                }
            }
            return -1;
        }
    }
}
