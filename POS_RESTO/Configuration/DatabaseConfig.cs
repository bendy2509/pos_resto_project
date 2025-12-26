using System;
using MySql.Data.MySqlClient;

namespace POS_RESTO.Configuration
{
    public static class DatabaseConfig
    {
        public static MySqlConnection GetConnection()
        {
            // Parametres mis a jour
            string host = "localhost";
            string port = "3310";
            string database = "posresto";
            string user = "pos_resto_admin";
            string password = "groupabb";
            
            // On ajoute "Port={port};" dans la chaine
            string connString = $"Server={host};Port={port};Database={database};Uid={user};Pwd={password};";
            
            return new MySqlConnection(connString);
        }
    }
}