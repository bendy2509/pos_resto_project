using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace POS_RESTO.Data
{
    public static class DatabaseHelper
    {
        public static MySqlConnection GetConnection()
        {
            return Configuration.DatabaseConfig.GetConnection();
        }
        
        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);
                    
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            
            return dt;
        }
        
        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);
                    
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        
        public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);
                    
                    return cmd.ExecuteScalar();
                }
            }
        }
        
        public static int InsertAndGetId(string query, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query + "; SELECT LAST_INSERT_ID();", conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);
                    
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        
        // Méthode pour lire un seul enregistrement avec un DataReader
        public static void ExecuteReader(string query, Action<MySqlDataReader> action, params MySqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            action(reader);
                        }
                    }
                }
            }
        }
    }
}