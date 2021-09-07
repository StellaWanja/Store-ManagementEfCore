using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Management.Models;

namespace Management.Data
{
    public class StoreDataStoreAdoNet : IStoreDataStore
    {
        //create connection string
        private const string ConnectionString = @"Data Source= .; Initial Catalog= StoreManagement; Integrated Security= True;";
        //insert into stores table using stored procedures
        public async Task<bool> AddStore(Store store)
        {
            try
            {
                //create connection instance
                var connection = CreateConnection();
                //open sql file using async
                await connection.OpenAsync();
                //create query - name of stored procedure
                string query = "INSERTINTOSTORESTABLE";
                //create command
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                //add to the table using parameters
                command.Parameters.Add("storeName", SqlDbType.VarChar).Value = store.StoreName;
                command.Parameters.Add("storeNumber", SqlDbType.VarChar).Value = store.StoreNumber;
                command.Parameters.Add("storeType", SqlDbType.VarChar).Value = store.StoreType;
                command.Parameters.Add("storeProducts", SqlDbType.Int).Value = store.StoreProducts;
                command.Parameters.Add("userId", SqlDbType.VarChar).Value = store.UserId;
                //execute the command
                //ExecuteNonQuery Executes a command that changes the data in the database
                var rows = await command.ExecuteNonQueryAsync();
                //close connection
                await connection.CloseAsync();
                //return rows
                return rows > 0;
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
                //create conncection
                var connection = CreateConnection();
                //open sql file async
                await connection.OpenAsync();
                //create query to read everything from users table
                string query = "READDATAFROMSTORESTABLE";
                //create command
                SqlCommand command = new SqlCommand(query, connection); 
                //read async
                var reader = await command.ExecuteReaderAsync();
                //create list of users
                List<Store> stores = new List<Store>();
                //read to end/to null
                while(reader.Read())
                {
                    //key - name of column in database
                    var store = new Store
                    {
                        StoreName = reader["StoreName"].ToString(),
                        StoreNumber = reader["StoreNumber"].ToString(),
                        StoreType = reader["StoreType"].ToString(),
                        StoreProducts = (int)reader["StoreProducts"],
                        UserId = reader["UserId"].ToString()
                    };

                    stores.Add(store);
                }
                return stores;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //update products
        public async Task<bool> UpdateProducts(int storeProducts, string storeId)
        {
            try
            {
                //create connection
                var connection = CreateConnection();
                //open
                await connection.OpenAsync();
                //query for updating
                string query = "UPDATE Stores SET Products = @Products WHERE StoreNumber = @StoreNumber";
                //create command
                SqlCommand command = new SqlCommand(query, connection);
                //add using parameters
                command.Parameters.Add("StoreProducts", SqlDbType.Int).Value = storeProducts;
                command.Parameters.Add("StoreId", SqlDbType.VarChar).Value = storeId;
                //execute async
                var rows = await command.ExecuteNonQueryAsync();

                return rows > 0;
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
                var connection = CreateConnection();
                await connection.OpenAsync();

                string query = "DELETE FROM Stores WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("Id", SqlDbType.VarChar).Value = id;

                var rows = await command.ExecuteNonQueryAsync();

                return rows > 0;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
        
        //create connection to database
        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString: ConnectionString);
            return connection;
        }
    }
}