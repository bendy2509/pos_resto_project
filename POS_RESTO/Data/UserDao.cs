using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using POS_RESTO.Models;

namespace POS_RESTO.Data
{
    public static class UserDao
    {
        public static User Authenticate(string username, string password)
        {
            string query = "SELECT * FROM Users WHERE username = @username AND password = @password";
            
            var parameters = new[]
            {
                new MySqlParameter("@username", MySqlDbType.VarChar) { Value = username },
                new MySqlParameter("@password", MySqlDbType.VarChar) { Value = password }
            };
            
            var dt = DatabaseHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new User
                {
                    UserId = Convert.ToInt32(row["user_id"]),
                    Username = row["username"].ToString(),
                    Password = row["password"].ToString(),
                    Role = row["role"].ToString()
                };
            }
            
            return null;
        }
        
        public static int AddUser(User user)
        {
            string query = @"
                INSERT INTO Users (username, password, role) 
                VALUES (@username, @password, @role)";
            
            var parameters = new[]
            {
                new MySqlParameter("@username", MySqlDbType.VarChar) { Value = user.Username },
                new MySqlParameter("@password", MySqlDbType.VarChar) { Value = user.Password },
                new MySqlParameter("@role", MySqlDbType.VarChar) { Value = user.Role ?? "user" }
            };
            
            return DatabaseHelper.InsertAndGetId(query, parameters);
        }
        
        public static List<User> GetAllUsers()
        {
            var users = new List<User>();
            
            string query = "SELECT * FROM Users ORDER BY username";
            var dt = DatabaseHelper.ExecuteQuery(query);
            
            foreach (DataRow row in dt.Rows)
            {
                users.Add(new User
                {
                    UserId = Convert.ToInt32(row["user_id"]),
                    Username = row["username"].ToString(),
                    Password = row["password"].ToString(),
                    Role = row["role"].ToString()
                });
            }
            
            return users;
        }
        
        public static int UpdateUser(User user)
        {
            string query = @"
                UPDATE Users 
                SET username = @username, password = @password, role = @role 
                WHERE user_id = @id";
            
            var parameters = new[]
            {
                new MySqlParameter("@username", MySqlDbType.VarChar) { Value = user.Username },
                new MySqlParameter("@password", MySqlDbType.VarChar) { Value = user.Password },
                new MySqlParameter("@role", MySqlDbType.VarChar) { Value = user.Role },
                new MySqlParameter("@id", MySqlDbType.Int32) { Value = user.UserId }
            };
            
            return DatabaseHelper.ExecuteNonQuery(query, parameters);
        }
        
        public static int DeleteUser(int userId)
        {
            string query = "DELETE FROM Users WHERE user_id = @id";
            var param = new MySqlParameter("@id", MySqlDbType.Int32) { Value = userId };
            
            return DatabaseHelper.ExecuteNonQuery(query, param);
        }
        
        public static User GetUserById(int userId)
        {
            string query = "SELECT * FROM Users WHERE user_id = @id";
            var param = new MySqlParameter("@id", MySqlDbType.Int32) { Value = userId };
            
            var dt = DatabaseHelper.ExecuteQuery(query, param);
            
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new User
                {
                    UserId = Convert.ToInt32(row["user_id"]),
                    Username = row["username"].ToString(),
                    Password = row["password"].ToString(),
                    Role = row["role"].ToString()
                };
            }
            
            return null;
        }
    }
}