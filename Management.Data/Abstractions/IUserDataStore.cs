using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Management.Models;

namespace Management.Data
{
    public interface IUserDataStore
    {
        Task<bool> AddUser(User user);

        Task<List<User>> ReadUsersFromDatabase();    }
}